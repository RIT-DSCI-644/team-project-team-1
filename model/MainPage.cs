using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace model
{
    public class MainPage
    {
        [JsonProperty(PropertyName = "word cloud")]
        public MainPageSectionFirst<WordCloudInstance> WordCloud;
        [JsonProperty(PropertyName = "stats")]
        public MainPageSectionSecond Stats;
    }

    public class MainPageSectionFirst<T>
    {
        [JsonProperty(PropertyName = "conservative")]
        public T Conservative;
        [JsonProperty(PropertyName = "liberal")]
        public T Liberal;
    }
    public class MainPageSectionSecond
    {
        [JsonProperty(PropertyName = "gender")]
        public GenderStatistics Gender;
        [JsonProperty(PropertyName = "race")]
        public RaceStatistics Race;
    }
}
