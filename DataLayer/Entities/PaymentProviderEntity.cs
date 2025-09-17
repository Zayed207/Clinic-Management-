namespace DataLayer.Entities
{
    public partial class PaymentProviderEntity
    {
        public short ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string ProviderType { get; set; }
        public string Description { get; set; }

        public ICollection<PaymentEntity> Payments { get; set; }

        public ICollection<AccountEntity> accounts { get; set; }
    }
}
