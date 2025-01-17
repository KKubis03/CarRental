using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models;

public partial class Review
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string Content { get; set; } = null!;

    public int Rating { get; set; }

    public int RentalId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("RentalId")]
    [InverseProperty("Reviews")]
    public virtual Rental Rental { get; set; } = null!;
}
