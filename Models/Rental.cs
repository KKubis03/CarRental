using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models;

public partial class Rental
{
    [Key]
    public int Id { get; set; }

    public int CarId { get; set; }

    public int CustomerId { get; set; }

    [Column(TypeName = "money")]
    public decimal BaseAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("CarId")]
    [InverseProperty("Rentals")]
    public virtual Car Car { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Rentals")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Rental")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [InverseProperty("Rental")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
