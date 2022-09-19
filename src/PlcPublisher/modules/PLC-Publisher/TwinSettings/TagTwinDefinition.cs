
using Newtonsoft.Json.Linq;

namespace PLCPublisher.TwinSettings
{
    public class TagTwinDefinition : TagDefinition
    {
        public int PollingInterval { get; set; }

        public JObject Transform { get; set; }
    }
}