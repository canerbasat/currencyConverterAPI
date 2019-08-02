using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace barisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        string url = "https://api.exchangeratesapi.io/latest";

        #region Methods
        [HttpPost("getResponseAsString")]
        //Ignore Api true api icinde kullanıma kapatır ve göstermez
        [ApiExplorerSettings(IgnoreApi = true)]
        public string getResponseAsAString()
        {
            using (WebClient client = new WebClient())
            {
                var response = client.DownloadString(url);
                return response;
            }
        }

        [HttpPost("ConvertStringToJson")]
        //Ignore Api true api icinde kullanıma kapatır ve göstermez
        [ApiExplorerSettings(IgnoreApi = true)]
        public JObject ConvertStringToJson()
        {
            var x = getResponseAsAString();
            JObject json = JObject.Parse(x);
            return json;
        }
        #endregion Methods

        // GET api/values
        [HttpGet("GetLatest")]
        public string Get()
        {
            return getResponseAsAString();
        }


        //date Format = 2010-02-12
        // GET api/values
        [HttpGet("GetByDate")]
        public string GetSpecialDate(string date)
        {
            url = "https://api.exchangeratesapi.io/"+date;
            return getResponseAsAString();
        }

        // GET api/values
        [HttpGet("GetSpecificExchange")]
        public string GetSpecialExchange(string baseCur,string toCur)
        {
            url = "https://api.exchangeratesapi.io/latest?symbols="+baseCur+","+toCur;
            return getResponseAsAString();
        }

        // GET api/values
        [HttpGet("GetHistoricalRatesTimePeriod")]
        public string GetHistoricalRatesTimePeriod(string startDate, string endDate)
        {
            url = "https://api.exchangeratesapi.io/history?start_at="+startDate+"&end_at="+endDate;
            return getResponseAsAString();
        }

        //// GET api/values
        [HttpGet("GetToCur")]
        public string GetToCur(string toCur)
        {
            url = "https://api.exchangeratesapi.io/latest?base="+toCur;
            return getResponseAsAString();
        }  

        [HttpPost]
        public JObject Post()
        {
            url = "https://api.exchangeratesapi.io/latest";
            return ConvertStringToJson();
        }

        [HttpPost("toCurrencyConvert")]
        //Ignore Api true api icinde kullanıma kapatır ve göstermez
        [ApiExplorerSettings(IgnoreApi = false)]
        public JObject toCurrencyConvert(string toCur)
        {
            url = "https://api.exchangeratesapi.io/latest?base=" + toCur;
            return ConvertStringToJson();
        }



    }
}