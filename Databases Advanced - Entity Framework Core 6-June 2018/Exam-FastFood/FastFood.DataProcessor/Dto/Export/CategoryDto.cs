namespace FastFood.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class CategoryDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlArray("MostPopularItem")]
        public MostPopularItemDto[] MostPopularItem { get; set; }
    }
}
