using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Models
{
    public class QryOsbListData
    {
        public string FORMSqtyDOCID { get; set; }
        public string FORMSqtyDPTID { get; set; }
        public string FORMSqtyASSETNAME { get; set; }
        public string FORMSqtyClsUser { get; set; }
        public string FORMSqtyUserId { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public string FORMSqtyApplyDateFrom { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public string FORMSqtyApplyDateTo { get; set; }
        public string FORMSqtyVendor { get; set; }
        public string FORMSqtyFLOWTYPE { get; set; }
        public bool FORMSqtySearchAllDoc { get; set; }
        public string FORMSqtyDateType { get; set; }

    }
}
