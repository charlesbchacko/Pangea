using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pangea;
using thirdparty;


namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {

        [HttpGet("{country}")]
        public List<Dictionary<string, string>> getRates(string country)
        {
            jsonData data = new jsonData(country);
            List<Dictionary<string,string>> list_of_rates = data.getExchangeData();
            filterData filterobj = new filterData(country);
            return (filterobj.getFilteredData(list_of_rates));
            
        }
        
    }
}
