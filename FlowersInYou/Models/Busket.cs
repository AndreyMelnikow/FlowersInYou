using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class Busket
{
    public int Id { get; set; }

    public int IdConfigurateProduct { get; set; }

    public int IdClient { get; set; }

    public virtual ICollection<BusketOrder> BusketOrders { get; set; } = new List<BusketOrder>();

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual ConfigurateProduct IdConfigurateProductNavigation { get; set; } = null!;
}
