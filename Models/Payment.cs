using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models;

public partial class Payment
{
    [Key]
    public int Id { get; set; }

    public int RentalId { get; set; }

    public int? DiscountId { get; set; }

    [Column(TypeName = "money")]
    public decimal FinalAmount { get; set; }

    public int StatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PaymentDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("DiscountId")]
    [InverseProperty("Payments")]
    public virtual Discount? Discount { get; set; }

    [ForeignKey("RentalId")]
    [InverseProperty("Payments")]
    public virtual Rental Rental { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("Payments")]
    public virtual PaymentStatus Status { get; set; } = null!;
}
