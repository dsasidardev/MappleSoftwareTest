using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Web;
using LifeinsuranceApi.Model;
using LifeinsuranceApi.Repository;
using LifeinsuranceApi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LifeinsuranceApi.Controllers
{
   [Authorize]
   [Produces("application/json")]
   
    public class InsuranceDataExtractController : Controller
    {
       private readonly IOptions<DBConSettingsModel> appSettings;
       
        public InsuranceDataExtractController(IOptions<DBConSettingsModel> app)
        {
            appSettings = app;
        }

      
        [HttpDelete]
        [Route("api/DeleteCustomerData")]
        public IActionResult DeleteCustomerData(CustomerData data)
        {
            var sucessMessage = "Data deletion successfull";
            var badRequest = "Error occured in deleting data";
            var exceptionDeails = string.Empty;
           
            try
            {

                //acknoweldge the message
                bool result = DbClientFactory<DbClient>.Instance.Delete(data, appSettings.Value.DbConn, appSettings.Value.SpForDeleteCustomerData);
                if (result)
                    return Ok(sucessMessage);
            }
            catch (Exception ex)
            {
                exceptionDeails = ex.ToString();
                return BadRequest(badRequest + ex.ToString());
            }

            return BadRequest(badRequest + exceptionDeails);
        }


        [HttpPost]
        [Route("api/InsertCustomerData")]
        public IActionResult InsertCustomerData(CustomerData data)
        {
            var sucessMessage = "Data saved successfull";
            var badRequest = "Error occured in saving data";
            var exceptionDeails = string.Empty;
            var coveragePlan = GetCoveragePlanID(data.Country);
            DateTime dt = DateTime.ParseExact(data.DOB, "ddMMyyyy", CultureInfo.InvariantCulture);
            bool ageFlag = GetAge(dt);
            
            var netPrice = GetNetPrice(data.Country, data.Gender,ageFlag);

            try
            {

                //acknoweldge the message
                bool result = DbClientFactory<DbClient>.Instance.Insert(data, coveragePlan, netPrice, appSettings.Value.DbConn, appSettings.Value.SpForInsertCustomerData);
                if (result)
                   return Ok(sucessMessage);
            }
            catch (Exception ex)
            {
                exceptionDeails = ex.ToString();
                return BadRequest(badRequest + ex.ToString());
            }

            return BadRequest(badRequest + exceptionDeails);
        }

        [HttpPut]
        [Route("api/UpdateCustomerData")]
        public IActionResult UpdateCustomerData(CustomerData data)
        {
            var sucessMessage = "Data update successfull";
            var badRequest = "Error occured in updating data";
            var exceptionDeails = string.Empty;
            var coveragePlan = GetCoveragePlanID(data.Country);
            DateTime dt = DateTime.ParseExact(data.DOB, "ddMMyyyy", CultureInfo.InvariantCulture);
            bool ageFlag = GetAge(dt);

            var netPrice = GetNetPrice(data.Country, data.Gender, ageFlag);

            try
            {

               
                bool result = DbClientFactory<DbClient>.Instance.Update(data, coveragePlan, netPrice, appSettings.Value.DbConn, appSettings.Value.SpForUpdateCustomerData);
                if (result)
                    return Ok(sucessMessage);
            }
            catch (Exception ex)
            {
                exceptionDeails = ex.ToString();
                return BadRequest(badRequest + ex.ToString());
            }

            return BadRequest(badRequest + exceptionDeails);
        }

        public  bool GetAge(DateTime birthDate)
        {
            bool ageCheck = true;
            DateTime n = DateTime.Now; // To avoid a race condition around midnight
            int age = n.Year - birthDate.Year;
            int aboveAge = 41;
          
            if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                age--;
            if (age == 40)
                ageCheck = true;
            if (age > 40)
              ageCheck=false;


            return ageCheck;

            
        }


        public string GetCoveragePlanID(string  country)
        {
            string result = string.Empty;
            try
            {
                
                result = DbClientFactory<DbClient>.Instance.GetCoveragePlanID(country);                
                   
            }
            catch (Exception ex)
            {
                
                return (ex.ToString());
            }

            return result;

        }
        public string GetNetPrice(string country, string gender, bool age)
        {
            string result = string.Empty;
            try
            {

                result = DbClientFactory<DbClient>.Instance.GetNetPrice(country, gender, age);

            }
            catch (Exception ex)
            {

                return (ex.ToString());
            }

            return result;

        }

     
        [HttpGet]
        [Route("api/GetCustomerData")]
        public string GetCustomerData()
        {
            dynamic jsonData = string.Empty;
            string entity = string.Empty;
            try
            {
                DbClient db = new DbClient();
                var result = db.GetData();
                entity = JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return entity;

        }
      
    }
}