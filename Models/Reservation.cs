using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models;

public partial class Reservation
{
    [Key]
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int CarId { get; set; }

    public int StatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("CarId")]
    [InverseProperty("Reservations")]
    public virtual Car Car { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Reservations")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("Reservations")]
    public virtual ReservationStatus Status { get; set; } = null!;
}
