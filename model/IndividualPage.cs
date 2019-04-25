using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace model
{
    public class IndividualPage
    {
        [JsonProperty(PropertyName = "word clouds")]
        public IndividualPageSectionFirst WordCloud;
        [JsonProperty(PropertyName = "stats")]
        public IndividualPageSectionSecond Stats;
    }

    public class IndividualPageSectionFirst
    {
        [JsonProperty(PropertyName = "distinct words")]
        public List<string> DistinctWords;
        [JsonProperty(PropertyName = "word frequencies")]
        public List<double> WordFrequencies;
        [JsonProperty(PropertyName = "distinct twitter handles")]
        public List<string> DistinctTwitterHandles;
        [JsonProperty(PropertyName = "twitter handle frequencies")]
        public List<double> TwitterHandleFrequencies;
        [JsonProperty(PropertyName = "distinct hashtags")]
        public List<string> DistinctHashtags;
        [JsonProperty(PropertyName = "hashtag frequencies")]
        public List<double> HashtagFrequencies;
    }
    public class IndividualPageSectionSecond
    {
        [JsonProperty(PropertyName = "name")]
        public string Name;
        [JsonProperty(PropertyName = "age")]
        public double Age;
        [JsonProperty(PropertyName = "gender")]
        public string Gender;
        [JsonProperty(PropertyName = "position")]
        public string Position;
        [JsonProperty(PropertyName = "number of followers")]
        public double NumberOfFollowers;
        [JsonProperty(PropertyName = "total number of tweets")]
        public double TotalNumberOfTweets;
        [JsonProperty(PropertyName = "number of distinct words used")]
        public int NumberOfDistinctWordsUsed;
        [JsonProperty(PropertyName = "top 5 words")]
        public List<string> TopFiveWords;
        [JsonProperty(PropertyName = "bottom 5 words")]
        public List<string> BottomFiveWords;
        [JsonProperty(PropertyName = "retweet history")]
        public List<double> RetweetHistory;
        [JsonProperty(PropertyName = "average retweet count")]
        public decimal AverageRetweetCount;
        [JsonProperty(PropertyName = "tweets with media history")]
        public List<bool> TweetsWithMediaHistory;
        [JsonProperty(PropertyName = "percent of tweets with media")]
        public decimal PercentOfTweetsWithMedia;
    }
}
