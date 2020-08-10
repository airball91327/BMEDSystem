﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Models
{
    public class QryKeepListData
    {
        public string BMEDKqtyDOCID { get; set; }
        public string BMEDKqtyASSETNO { get; set; }
        public string BMEDKqtyACCDPT { get; set; }
        public string BMEDKqtyASSETNAME { get; set; }
        public string BMEDKqtyFLOWTYPE { get; set; }
        public string BMEDKqtyDPTID { get; set; }
        public string BMEDKqtyKeepResult { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public string BMEDKqtyApplyDateFrom { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public string BMEDKqtyApplyDateTo { get; set; }
        public string BMEDKqtyDateType { get; set; }
        public string BMEDKqtyIsCharged { get; set; }
        public bool BMEDKqtySearchAllDoc { get; set; }
        public string BMEDKqtyEngCode { get; set; }
        public string BMEDKqtyTicketNo { get; set; }
        public string BMEDKqtyVendor { get; set; }
    }

    public class QryRepListData
    {
        public string BMEDqtyDOCID { get; set; }
        public string BMEDqtyASSETNO { get; set; }
        public string BMEDqtyACCDPT { get; set; }
        public string BMEDqtyASSETNAME { get; set; }
        public string BMEDqtyFLOWTYPE { get; set; }
        public string BMEDqtyDPTID { get; set; }
        public string BMEDqtyDealStatus { get; set; }
        public string BMEDqtyTROUBLEDES { get; set; }
        public string BMEDqtyUserId { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public string BMEDqtyApplyDateFrom { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public string BMEDqtyApplyDateTo { get; set; }
        public string BMEDqtyDateType { get; set; }
        public string BMEDqtyIsCharged { get; set; }
        public bool BMEDqtySearchAllDoc { get; set; }
        public string BMEDqtyEngCode { get; set; }
        public string BMEDqtyTicketNo { get; set; }
        public string BMEDqtyVendor { get; set; }
    }
}