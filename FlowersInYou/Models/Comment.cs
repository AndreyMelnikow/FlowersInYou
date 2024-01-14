using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int Rate { get; set; }

    public string? Text { get; set; }

    public int IdClient { get; set; }

    public int? IdProduct { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Product? IdProductNavigation { get; set; }
}
