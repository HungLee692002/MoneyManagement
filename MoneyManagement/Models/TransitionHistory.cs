using System;
using System.Collections.Generic;

namespace MoneyManagement.Models;

public partial class TransitionHistory
{
    public int Hid { get; set; }

    public string? Title { get; set; }

    public int? Money { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Time { get; set; }

    public int? IsAdd { get; set; }
}
