using SourceGenSampleAPI.Attributes;

namespace SourceGenAPI.Models
{
    [MapModel]
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [MapModelIgnore]
        public string SecereId { get; set; }
    }
}
