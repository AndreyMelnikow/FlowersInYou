using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class Zone
{
    public int Id { get; set; }

    public int MinRange { get; set; }

    public int MaxRange { get; set; }

    public string Name { get; set; } = null!;

    public decimal ZoneCost { get; set; }

    public virtual ICollection<ConfirmedOrder> ConfirmedOrder { get; set; } = new List<ConfirmedOrder>();
}
