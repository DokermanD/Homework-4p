using System;
using System.Collections.Generic;

namespace Homework_4p;

public partial class User
{
    public int UserId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<ProductsSale> ProductsSales { get; set; } = new List<ProductsSale>();
}
