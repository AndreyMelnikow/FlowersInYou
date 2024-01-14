using System;
using System.Collections.Generic;

namespace FlowersInYou.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FullName
    {
        get
        {
            return LastName + " " + FirstName + " " + Patronymic;
        }
    }

    public virtual ICollection<Busket> Buskets { get; set; } = new List<Busket>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
