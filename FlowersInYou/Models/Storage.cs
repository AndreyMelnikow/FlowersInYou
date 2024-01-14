using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class Storage
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Capacity { get; set; } = null!;

    public virtual ICollection<Administrator> Administrators { get; set; } = new List<Administrator>();

    public virtual ICollection<StorageProduct> StorageProducts { get; set; } = new List<StorageProduct>();
}
