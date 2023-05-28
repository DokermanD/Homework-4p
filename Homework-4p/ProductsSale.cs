using System;
using System.Collections.Generic;

namespace Homework_4p;

public partial class ProductsSale
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal ProductPrace { get; set; }

    public int FkUserId { get; set; }

    public virtual User FkUser { get; set; } = null!;
}
