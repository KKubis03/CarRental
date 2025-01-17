using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models;

public partial class Discount
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string DiscountName { get; set; } = null!;

    public int DiscountPercentage { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("Discount")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
