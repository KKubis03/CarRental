using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models;

public partial class CarModel
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string CarModelName { get; set; } = null!;

    public int Brand { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("Brand")]
    [InverseProperty("CarModels")]
    public virtual CarBrand BrandNavigation { get; set; } = null!;

    [InverseProperty("Model")]
    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
