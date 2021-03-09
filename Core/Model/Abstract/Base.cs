using Newtonsoft.Json;

namespace Core.Model.Abstract
{
    public class Base
    {
        public int Id { get; set; }
        [JsonIgnore]
        public bool Deleted { get; set; }
    }
}
