using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class Material
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Count { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<CompletedOrder> CompletedOrder { get; set; } = new List<CompletedOrder>();

    public virtual ICollection<ConfigurateProduct> ConfigurateProduct { get; set; } = new List<ConfigurateProduct>();
}
