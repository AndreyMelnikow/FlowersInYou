using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class StorageProduct
{
    public int Id { get; set; }

    public int IdStorage { get; set; }

    public int IdProduct { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Storage IdStorageNavigation { get; set; } = null!;
}
