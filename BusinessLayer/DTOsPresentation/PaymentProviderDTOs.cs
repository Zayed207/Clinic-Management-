namespace DataLayer.Entities
{
    public partial class PaymentProviderRequestDTOs
    {
      
        public string ProviderName { get; set; }
        public string ProviderType { get; set; }
        public string Description { get; set; }

       
    }

    public partial class PaymentProviderRsponseDTOs
    {
        public short ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string ProviderType { get; set; }
        public string Description { get; set; }


    }
}
