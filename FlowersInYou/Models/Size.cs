using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class Size
{
    public int Id { get; set; }

    public string Size1 { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<CompletedOrder> CompletedOrder { get; set; } = new List<CompletedOrder>();

    public virtual ICollection<ConfigurateProduct> ConfigurateProduct { get; set; } = new List<ConfigurateProduct>();
}
