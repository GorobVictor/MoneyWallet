using Newtonsoft.Json;
using System;

namespace Core.Model.Abstract
{
    public class Date : Base
    {
        [JsonIgnore]
        public DateTime CreatedWhen { get; set; }
        [JsonIgnore]
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime UpdatedWhen { get; set; }
        [JsonIgnore]
        public int UpdatedBy { get; set; }
    }
}
