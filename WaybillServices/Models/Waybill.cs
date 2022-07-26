using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WaybillServices.Models
{
    [Table("Waybill")]
    public partial class Waybill
    {
        public Waybill()
        {
            Branches = new HashSet<Branch>();
        }

        [Key]
        [Column("WaybillID")]
        public int WaybillId { get; set; }
        [StringLength(255)]
        public string CurrentBranch { get; set; }
        [StringLength(255)]
        public string ArrivalDate { get; set; }
        [StringLength(255)]
        public string DepartureDate { get; set; }
        [Column("VehicleID")]
        public int? VehicleId { get; set; }
        [StringLength(255)]
        public string TotWeight { get; set; }
        [StringLength(255)]
        public string Dimensions { get; set; }

        [ForeignKey(nameof(VehicleId))]
        [InverseProperty("Waybills")]
        public virtual Vehicle Vehicle { get; set; }
        [InverseProperty(nameof(Branch.Waybill))]
        public virtual ICollection<Branch> Branches { get; set; }
    }
}
