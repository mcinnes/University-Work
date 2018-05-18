using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JSONTest
{
    public class Question
    {
    [JsonProperty("id")]
    public int id { get; set; }
    
    [JsonProperty("text")]
    public string text { get; set; }
    
    [JsonProperty("type")]
    public string type { get; set; }
    
    [JsonProperty("help")]
    public string help { get; set; }
    
    [JsonProperty("options")]
    public List<string> options { get; set; }
    
    [JsonProperty("optionVisuals")]
    public List<string> optionVisuals { get; set; }
    
    [JsonProperty("start")]
    public int? start { get; set; }
    
    [JsonProperty("end")]
    public double? end { get; set; }
    
    [JsonProperty("increment")]
    public double? increment { get; set; }
    
    [JsonProperty("gradientStart")]
    public string gradientStart { get; set; }
    
    [JsonProperty("gradientEnd")]
    public string gradientEnd { get; set; }
    
    [JsonProperty("validate")]
    public string validate { get; set; }
    
    [JsonProperty("answer")]
    public object answer { get; set; }
    
    [JsonProperty("weighting")]
    public int? weighting { get; set; }
    }
}
