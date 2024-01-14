using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public string Address { get; set; } = null!;

    public string? Decription { get; set; }

    public decimal Price { get; set; }

    public double Range { get; set; }

    public bool IsPaid { get; set; }

    public bool IsAccepted { get; set; }

    public virtual ICollection<BusketOrder> BusketOrder { get; set; } = new List<BusketOrder>();

    public virtual ICollection<CompletedOrder> CompletedOrder { get; set; } = new List<CompletedOrder>();

    public virtual ICollection<ConfirmedOrder> ConfirmedOrder { get; set; } = new List<ConfirmedOrder>();
}
