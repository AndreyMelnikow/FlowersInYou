using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class BusketOrder
{
    public int Id { get; set; }

    public int IdBuscket { get; set; }

    public int IdOrder { get; set; }

    public virtual Busket IdBusketNavigation { get; set; } = null!;

    public virtual Order? IdOrderNavigation { get; set; } = null!;
}
