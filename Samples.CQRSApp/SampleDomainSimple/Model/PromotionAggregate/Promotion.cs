using System;

namespace SampleDomainSimple
{
    public class Promotion
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Type { get; set; }
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
