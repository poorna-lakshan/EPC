using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;

namespace EPC.Models
{
    [Table("tbl_epc")]
    public class epc_data
    {
        [Key]
        public DateTime time
        {
            get;
            set;
        }

        [Column("QI_BL1_1@PV")]
        public double QI_BL1_1_PV
        {
            get;
            set;

        }

        [Column("QI_BL2_1@PV")]
        public double QI_BL2_1_PV
        {
            get;
            set;

        }

        [Column("QI_BL3_1@PV")]
        public double QI_BL3_1_PV
        {
            get;
            set;

        }
        [Column("QI_BL4_1@PV")]
        public double QI_BL4_1_PV
        {
            get;
            set;

        }
        [Column("QI_BLA_1@PV")]
        public double QI_BLA_1_PV
        {
            get;
            set;

        }
        [Column("QI_BL5_1@PV")]
        public double QI_BL5_1_PV
        {
            get;
            set;

        }
        [Column("QI_BL6_1@PV")]
        public double QI_BL6_1_PV
        {
            get;
            set;

        }
        [Column("QI_BL7_1@PV")]
        public double QI_BL7_1_PV
        {
            get;
            set;

        }
        [Column("QI_NTU_1@PV")]
        public double QI_NTU_1_PV
        {
            get;
            set;

        }
        [Column("QI_BP2_1@PV")]
        public double QI_BP2_1_PV
        {
            get;
            set;

        }
        [Column("QI_FUS_1@PV")]
        public double QI_FUS_1_PV
        {
            get;
            set;

        }
        [Column("QI_F2B@PV")]
        public double QI_F2B_PV
        {
            get;
            set;

        }
        [Column("QI_MUD@PV")]
        public double QI_MUD_PV
        {
            get;
            set;

        }
        [Column("QI_HOT@PV")]
        public double QI_HOT_PV
        {
            get;
            set;

        }
        [Column("QI_BP3@PV")]
        public double QI_BP3_PV
        {
            get;
            set;

        }

    }
}