using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TritonExpress.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Branches = new HashSet<Branch>();
            Waybills = new HashSet<Waybill>();
        }

        [Key]
        [Column("VehicleID")]
        public int VehicleId { get; set; }
        [StringLength(255)]
        public string VehicleMake { get; set; }
        [StringLength(255)]
        public string VehicleModel { get; set; }
        [StringLength(255)]
        public string VehicleColor { get; set; }
        [StringLength(255)]
        public string Registration { get; set; }

        [InverseProperty(nameof(Branch.Vehicle))]
        public virtual ICollection<Branch> Branches { get; set; }
        [InverseProperty(nameof(Waybill.Vehicle))]
        public virtual ICollection<Waybill> Waybills { get; set; }
    }
}
