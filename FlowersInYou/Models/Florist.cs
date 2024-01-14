using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class Florist
{
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<ConfirmedOrder> ConfirmedOrder { get; set; } = new List<ConfirmedOrder>();
}
