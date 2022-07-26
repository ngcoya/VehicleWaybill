using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TritonExpress.Models
{
    [Table("Branch")]
    public partial class Branch
    {
        [Key]
        [Column("BranchID")]
        public int BranchId { get; set; }
        [StringLength(255)]
        public string BranchName { get; set; }
        [StringLength(255)]
        public string ArrivalDate { get; set; }
        [StringLength(255)]
        public string DepartureDate { get; set; }
        [Column("WaybillID")]
        public int? WaybillId { get; set; }
        [Column("VehicleID")]
        public int? VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        [InverseProperty("Branches")]
        public virtual Vehicle Vehicle { get; set; }
        [ForeignKey(nameof(WaybillId))]
        [InverseProperty("Branches")]
        public virtual Waybill Waybill { get; set; }
    }
}
