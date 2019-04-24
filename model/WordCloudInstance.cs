using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace model
{
    public class WordCloudInstance
    {
        [JsonProperty(PropertyName = "distinct elites")]
        public List<string> Tags;
        [JsonProperty(PropertyName = "elite frequencies")]
        public List<double> Frequencies;
    }
}
