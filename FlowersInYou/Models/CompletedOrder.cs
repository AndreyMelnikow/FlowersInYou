using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class CompletedOrder
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public int? IdSize { get; set; }

    public int? IdMaterial { get; set; }

    public decimal Price { get; set; }

    public int? IdAddFlower { get; set; }

    public virtual AddedFlower? IdAddFlowerNavigation { get; set; }

    public virtual Material? IdMaterialNavigation { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Size? IdSizeNavigation { get; set; }
}
