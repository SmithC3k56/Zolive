using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zolive_db;

namespace zolive_unit_test.TestPerform
{
    public class Example
    {
        public IConfiguration InitConfiguration()
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        [SetUp]
        public void Setup()
        {
            var config = InitConfiguration();

            ConfigNew.Configuration = config;
        }

        [Test]
        public void Test()
        {
            Maintest();
            //Nomal();
        } 
        public void Maintest()
        {
            var list = new List<dynamic>();
            
            for(var i = 0; i < 100000; i++)
            {
                list.Add(new { name = "Smith", age = i });
            }
            var b = list.Where(x => x.age == 9999).FirstOrDefault();
        }
        public void Nomal()
        {
       
                // Just loop.
                int max = 1000000;
                int ctr = 0;
                for (ctr = 0; ctr <= max; ctr++)
                {
                    if (ctr == max / 2 && DateTime.Now.Hour <= 12)
                    {
                        ctr++;
                        break;
                    }
                }
                
            Console.WriteLine("Finished {0:N0} iterations.", ctr);
        }
    }
}
