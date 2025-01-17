using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models;

public partial class CarBrand
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string CarBrandName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("BrandNavigation")]
    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();

    [InverseProperty("Brand")]
    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
