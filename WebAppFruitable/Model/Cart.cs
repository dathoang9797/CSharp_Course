﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFruitable.Model;

[Table("Cart")]
public class Cart
{
    public int CartId { get; set; }
    [MaxLength(32)] public string? CartCode { get; set; }
    public int ProductId { get; set; }
    public short Quantity { get; set; }
    [MaxLength(32)] public string? MemberId { get; set; }
    public Product? Product { get; set; }
    public Member? Member { get; set; }
}

public class CartFrom
{
    public int ProductId { get; set; }
    public short Quantity { get; set; }
}