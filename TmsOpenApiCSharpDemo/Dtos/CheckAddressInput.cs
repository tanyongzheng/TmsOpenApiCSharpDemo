namespace TmsOpenApiCSharpDemo.Dtos
{
    public class CheckAddressInput
    {
        public string ToName { get; set; }
        public string ToCompany { get; set; }
        public string ToCountryCode { get; set; }
        public int? ToCountryId { get; set; }
        public string ToAddress1 { get; set; }
        public string ToAddress2 { get; set; }
        //public string ToAddress3 { get; set; }
        public string ToProvince { get; set; }
        public string ToCity { get; set; }
        public string ToPostCode { get; set; }
        public string ToContact { get; set; }
        public string ChannelCode { get; set; }
    }
}