using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace model
{
    public class GenderStatistics
    {
        [JsonProperty(PropertyName = "male")]
        public double Male;
        [JsonProperty(PropertyName = "female")]
        public double Female;
    }
}
