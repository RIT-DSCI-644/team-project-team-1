using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace model
{
    public class RaceStatistics
    {
        [JsonProperty(PropertyName = "non-white")]
        public double NonWhite;
        [JsonProperty(PropertyName = "white")]
        public double White;
    }
}
