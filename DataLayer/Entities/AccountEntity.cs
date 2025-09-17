namespace DataLayer.Entities
{
    public class AccountEntity
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public short AccountProviderID_FK { get; set; }
        public PaymentProviderEntity PaymentProvider { get; set; }


        public ICollection<PaymentEntity> PaymentsFrom { get; set; }
        public ICollection<PaymentEntity> PaymentsTo { get; set; }
    }
}
