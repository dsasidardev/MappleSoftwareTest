using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LifeinsuranceApi.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LifeinsuranceApi.Utility
{

    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
       
    public class UserService : IUserService
    {

        IConfiguration config = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json", true, true)
                 .Build();
        User appSettings = new User();
        ServicebusKeys appConfig = new ServicebusKeys();

        public async Task<User> Authenticate(string username, string password)
        {

            config.GetSection("ApiAuthenticationSettings").Bind(appSettings);
            
            List<User> list = new List<User> { new User { Username = appSettings.Username, Password = appSettings.Password } };
            
            var user = await Task.Run(() => list.SingleOrDefault(x => x.Username == username && x.Password == password));
          

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }

        public async Task<bool> CheckUseAtEDAsync(string studentId, string dob, string surName)
        {
            
            config.GetSection("ServiceBusSettings").Bind(appConfig);
            bool isUserExists = false;
            
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var byteArray = Encoding.ASCII.GetBytes(appConfig.Username + ":" + appConfig.Password);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    HttpResponseMessage response = await client.GetAsync(appConfig.EdWebserviceURL+studentId);
                    HttpContent content = response.Content;

                    var result = await content.ReadAsStringAsync();

                    if (result != null)
                    {
                        dynamic jsonObj = JToken.Parse(result);

                        string retStudentId = (string)jsonObj["oci_stuc"];
                        string retucaID = (string)jsonObj["oci_ucid"];
                        string retSurname = (string)jsonObj["oci_surn"];
                        string retdDb = (string)jsonObj["oci_dob"];
                       //to cater for any date formats
                        string[] formats = new[] { "MM/dd/yyyy", "MM/dd/yyyy hh:mm:ss", "dd-MMM-yyyy",
                            "yyyy-MM-dd", "dd-MM-yyyy", "dd/MM/yyyy","dd MMM yyyy" };
                        DateTime dt = DateTime.ParseExact( retdDb, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                        DateTime convDt = DateTime.ParseExact(dob, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                        string compareDt = dt.ToShortDateString();
                        string convDob = convDt.ToShortDateString();                       

                        if (retStudentId==studentId ||retucaID==studentId && String.Equals(retSurname, surName, StringComparison.OrdinalIgnoreCase) && compareDt == convDob)
                        {
                                isUserExists = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            return isUserExists;
        }

    }
    }

