using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class PaymentProviderEntity
{
    public short ProviderID { get; set; }

    public string ProviderName { get; set; } = null!;

    public string ProviderType { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<PaymentEntity> Payments { get; set; } = new List<PaymentEntity>();
}
