using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models;

[Keyless]
public partial class CarFeature
{
    public int CarId { get; set; }

    public int FeatureId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("CarId")]
    public virtual Car Car { get; set; } = null!;

    [ForeignKey("FeatureId")]
    public virtual Feature Feature { get; set; } = null!;
}
