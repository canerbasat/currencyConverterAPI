using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using barisApi.Controllers;
using System.Net;
using System.Collections;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myApi.Controllers
{
    [Route("api/[controller]")]
    public class ConvertOperationsController : Controller
    {
        string url = "https://api.exchangeratesapi.io/";


        [HttpPost("toCurrencyConvertLatest")]
        //Ignore Api true api icinde kullanıma kapatır ve göstermez
        [ApiExplorerSettings(IgnoreApi = false)]
        public double toCurrencyConvertLatest(string takeBaseCur, string toConvertCur,double price)
        {
            url = "https://api.exchangeratesapi.io/latest?symbols=" + toConvertCur + "&base=" + takeBaseCur;
            WebClient client = new WebClient();
            var response = client.DownloadString(url);
            var root = JObject.Parse(response);
            //JSON daki degerlere göre erişebiliriz
            /*
             {  
                "rates":{  
                    "TRY":5.5736160188
                        },
                "base":"USD",
                "date":"2019-08-01"
             }
             */
            var rates = root.Value<JObject>("rates");
            //String ile ulastik
            // "USD"
            var baseCurType = root.Value<string>("base");
            // "2019-08-01
            var dateT = root.Value<string>("date");
            var toCur = rates.Value<double>(toConvertCur);


            price = price * toCur;
            return price;
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
