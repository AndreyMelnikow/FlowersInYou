using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class ConfirmedOrder
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public int IdFlorist { get; set; }

    public int IdCourier { get; set; }

    public int IdZone { get; set; }

    public virtual Courier IdCourierNavigation { get; set; } = null!;

    public virtual Florist IdFloristNavigation { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Zone IdZoneNavigation { get; set; } = null!;
}
