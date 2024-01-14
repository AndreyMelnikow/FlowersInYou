using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class Administrator
{
    public int Id { get; set; }

    public int IdStorage { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual Storage IdStorageNavigation { get; set; } = null!;
}
