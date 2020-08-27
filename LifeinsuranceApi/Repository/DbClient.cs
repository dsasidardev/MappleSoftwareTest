using LifeinsuranceApi.Model;
using LifeinsuranceApi.Utility;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System;
using DbWrapperStandard;
using System.Globalization;

namespace LifeinsuranceApi.Repository
{
    public class DbClient
    {
        IConfiguration config = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json", true, true)
                 .Build();
        ServicebusKeys appConfig = new ServicebusKeys();
        private string ConnectionString { get; set; }
        private DapperDbService dbservice;

        public List<CustomerData> GetData()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            ConnectionString = config.GetSection("Dapper").GetSection("Conn").Value;
            dbservice = new DapperDbService(ConnectionString);
            List<CustomerData> data = new List<CustomerData>();

            try
            {
                var res = dbservice.GetList<CustomerData>(@"
            EXEC [dbo].[GetCustomerData]             
            "
                    ); data = (List<CustomerData>)res;
            }
            catch (Exception ex)
            {
            }
            return data;
        }

        

       

        public bool Delete(CustomerData data, string connString, string stroeProc)
        {
            bool isSuccess = false;



            config.GetSection("ServiceBusSettings").Bind(appConfig);
            try
            {
                using (SqlConnection sql = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(stroeProc, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@customerName", data.CustomerName));                       
                        cmd.Parameters.Add(new SqlParameter("@dob", DateTime.ParseExact(data.DOB, "ddMMyyyy", CultureInfo.InvariantCulture)));
                       

                        sql.Open();
                        cmd.ExecuteNonQuery();
                        isSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }


        public bool Update(CustomerData data, string coveragePlanid, string netprice, string connString, string stroeProc)
        {
            bool isSuccess = false;
            
            config.GetSection("ServiceBusSettings").Bind(appConfig);
            try
            {
                using (SqlConnection sql = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(stroeProc, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@customerName", data.CustomerName));
                        cmd.Parameters.Add(new SqlParameter("@country", data.Country));
                        cmd.Parameters.Add(new SqlParameter("@gender", data.Gender));
                        cmd.Parameters.Add(new SqlParameter("@dob", DateTime.ParseExact(data.DOB, "ddMMyyyy", CultureInfo.InvariantCulture)));
                        cmd.Parameters.Add(new SqlParameter("@coveragePlanId", coveragePlanid));
                        cmd.Parameters.Add(new SqlParameter("@netprice", netprice));

                        sql.Open();
                        cmd.ExecuteNonQuery();
                        isSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;    
           }

        public bool Insert(CustomerData data, string coveragePlanid, string netprice, string connString, string stroeProc)
        {
            bool isSuccess = false;



            config.GetSection("ServiceBusSettings").Bind(appConfig);
            try
            {
                using (SqlConnection sql = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(stroeProc, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@customerName", data.CustomerName));
                        cmd.Parameters.Add(new SqlParameter("@customerAddress", data.CustomerAddress));
                        cmd.Parameters.Add(new SqlParameter("@country", data.Country));
                        cmd.Parameters.Add(new SqlParameter("@gender", data.Gender));
                        cmd.Parameters.Add(new SqlParameter("@dob", DateTime.ParseExact(data.DOB, "ddMMyyyy", CultureInfo.InvariantCulture)));
                        cmd.Parameters.Add(new SqlParameter("@coveragePlanId", coveragePlanid));
                        cmd.Parameters.Add(new SqlParameter("@netprice", netprice));

                        sql.Open();
                        cmd.ExecuteNonQuery();
                        isSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }



        public string GetCoveragePlanID(string country)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            ConnectionString = config.GetSection("Dapper").GetSection("Conn").Value;
            dbservice = new DapperDbService(ConnectionString);
            string data = String.Empty;

            try
            {
                var res = dbservice.Get<string>(@"
            EXEC [dbo].[GetCoveragePlanId]
             @Country 	        
            ", new
                {
                    Country = country
                   
                }
                    ); data = res;
            }
            catch (Exception ex)
            {
            }
            return data;
        }

        public string GetNetPrice(string country, string gender, bool age)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            ConnectionString = config.GetSection("Dapper").GetSection("Conn").Value;
            dbservice = new DapperDbService(ConnectionString);
            string data = String.Empty;

            try
            {
                var res = dbservice.Get<string>(@"
            EXEC [dbo].[GetNetPrice]
             @Country,@Gender, @age
            ", new
                {
                    Country = country,
                    Gender =gender,
                    Age=age

                }
                    ); data = res;
            }
            catch (Exception ex)
            {
            }
            return data;
        }

    }
  }



    
