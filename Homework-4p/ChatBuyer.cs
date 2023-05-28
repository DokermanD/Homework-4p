using System;
using System.Collections.Generic;

namespace Homework_4p;

public partial class ChatBuyer
{
    public int BuyerId { get; set; }

    public int FkProductId { get; set; }

    public string MessageChat { get; set; } = null!;
}
