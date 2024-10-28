﻿using System;
using System.Collections.Generic;

namespace ThuchanhQuanLyNhaHang.Models;

public partial class InventoryExit
{
    public int ExitId { get; set; }

    public DateOnly ExitDate { get; set; }

    public string? Description { get; set; }

    public string RecipientName { get; set; } = null!;

    public virtual ICollection<ExitDetail> ExitDetails { get; set; } = new List<ExitDetail>();
}
