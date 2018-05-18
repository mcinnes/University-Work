using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JSONTest
{
    public class Quiz
    {
        [JsonProperty("id")]
	    public string id { get; set; }
        
        [JsonProperty("title")]
	    public string title { get; set; }
        
        [JsonProperty("questions")]        
	    public List<Question> questions { get; set; }
        
        [JsonProperty("questionsPerPage")]
	    public List<int?> questionsPerPage { get; set; }
        
        [JsonProperty("score")]
	    public int? score { get; set; }
        
    }
}
