using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Count { get; set; }

    public string? Description { get; set; }

    public byte[]? Photo { get; set; }

    public int IdProductType { get; set; }

    public string? ShortDescription { get; set; }

    public string? Dimensions { get; set; }

    public decimal? StartPrice { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<CompletedOrder> CompletedOrder { get; set; } = new List<CompletedOrder>();

    public virtual ICollection<ConfigurateProduct> ConfigurateProduct { get; set; } = new List<ConfigurateProduct>();

    public virtual ProductType IdProductTypeNavigation { get; set; } = null!;

    public virtual ICollection<StorageProduct> StorageProducts { get; set; } = new List<StorageProduct>();
}
