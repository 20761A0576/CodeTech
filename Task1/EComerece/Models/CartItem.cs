﻿using System;
using System.Collections.Generic;

namespace EComerece.Models;

public partial class CartItem
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;
}
