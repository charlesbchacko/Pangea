using Newtonsoft.Json;
using NuGet.DependencyResolver;
using System.Collections.Generic;
using System.IO;

namespace thirdparty
{
    public class jsonData
    {
        public string currency_code;
        public jsonData(string country_code)
        {
            Dictionary<string, string> country_currency_map = new Dictionary<string, string>()
            {
                {
                    "MEX","MXN"
                },
                {
                    "PHL","PHP"
                },
                {
                    "IND","INR"
                },
                {
                    "GTM","GTQ"
                }
            };
             this.currency_code = country_currency_map[country_code];

        }
        public List<Dictionary<string, string>> getExchangeData()
        {
            using (StreamReader streamobj = new StreamReader("/Users/charleschacko/Projects/TestApi/TestApi/conversion.json"))
            {

                string json = streamobj.ReadToEnd();


                Dictionary<string, List<Dictionary<string, string>>> rate_map = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(json);
                List<Dictionary<string, string>> arr = rate_map["PartnerRates"];
                List<Dictionary<string, string>> new_arr = new List<Dictionary<string, string>>();
                    for (int i =0; i< arr.Count; i++)
                {
                    if (arr.ElementAt(i)["Currency"] == this.currency_code)
                        new_arr.Add(arr.ElementAt(i));
                }
                return (new_arr);
            }

        }



    }
}




