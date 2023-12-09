using Newtonsoft.Json;
using NuGet.DependencyResolver;
using System.Collections.Generic;
using System.IO;

namespace pangea

{
    public class filterData
    {
        public float flat_rate;
        public filterData(string country_code) 
        {
            Dictionary<string, float> country_change_rate = new Dictionary<string, float>();
            country_change_rate.Add("MEX", (float)0.024);
            country_change_rate.Add("PHL", (float)2.437);
            country_change_rate.Add("IND", (float)0.056); 
            country_change_rate.Add("GTM", (float)3.213);
            this.flat_rate = 1 + country_change_rate[country_code];
            

        }
        
        public List<Dictionary<string, string>> getFilteredData(List<Dictionary<string, string>> arr)
        {
            Dictionary<string, Dictionary<string, string>> result_set = new Dictionary<string, Dictionary<string, string>>();

            
            for (int i = 0; i < arr.Count; i++)
            {
                Dictionary<string, string> current_val = arr.ElementAt(i);
                current_val["Rate"] = (float.Parse(current_val["Rate"]) * this.flat_rate).ToString("0.00");
                string temp = current_val["PaymentMethod"]+current_val["DeliveryMethod"];
                if (result_set.ContainsKey(temp))
                    {
                        if (DateTime.Parse(result_set[temp]["AcquiredDate"]) < DateTime.Parse(current_val["AcquiredDate"]))
                            result_set[temp] = current_val;
                    }
                 else
                    result_set.Add(temp, current_val);
            }
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            foreach (var val in result_set)
                result.Add(val.Value);
            return (result);
        }
       
    }
        



    
}




