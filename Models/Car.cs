using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models;

public partial class Car
{
    [Key]
    public int Id { get; set; }

    public int BrandId { get; set; }

    public int ModelId { get; set; }

    public int CategoryId { get; set; }

    [StringLength(4)]
    public string ProductionYear { get; set; } = null!;

    [StringLength(17)]
    public string Vin { get; set; } = null!;

    [StringLength(10)]
    public string LicensePlate { get; set; } = null!;

    public int GearboxTypeId { get; set; }

    public int FuelTypeId { get; set; }

    public int ColorId { get; set; }

    public int StatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("BrandId")]
    [InverseProperty("Cars")]
    public virtual CarBrand Brand { get; set; } = null!;

    [ForeignKey("CategoryId")]
    [InverseProperty("Cars")]
    public virtual CarCategory Category { get; set; } = null!;

    [ForeignKey("ColorId")]
    [InverseProperty("Cars")]
    public virtual Color Color { get; set; } = null!;

    [ForeignKey("FuelTypeId")]
    [InverseProperty("Cars")]
    public virtual FuelType FuelType { get; set; } = null!;

    [ForeignKey("GearboxTypeId")]
    [InverseProperty("Cars")]
    public virtual GearboxType GearboxType { get; set; } = null!;

    [ForeignKey("ModelId")]
    [InverseProperty("Cars")]
    public virtual CarModel Model { get; set; } = null!;

    [InverseProperty("Car")]
    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    [InverseProperty("Car")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    [ForeignKey("StatusId")]
    [InverseProperty("Cars")]
    public virtual CarStatus Status { get; set; } = null!;
}
