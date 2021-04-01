using System;
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
        public string BMEDKqtyClsUser { get; set; }
        public string BMEDKInOut { get; set; }
        public string BMEDqtyLoc { get; set; }
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
        public string BMEDqtyClsUser { get; set; }
        public string BMEDqtyLoc { get; set; }
    }

    public class QryRepResignListData
    {
        public string qtyReSignDOCID { get; set; }
        public string qtyReSignASSETNO { get; set; }
        public string qtyReSignACCDPT { get; set; }
    }

    public class AssetQryResult
    {
        public string ASSET_NO { get; set; }
        public string NAME_C { get; set; }
        public string ACC_DPT { get; set; }
        public string DELIV_DPT { get; set; }
    }

    public class SystemMsg
    {
        public string MsgCode { get; set; }
        public string MsgString { get; set; }

        public SystemMsg()
        {
            MsgCode = "0";
            MsgString = "成功";
        }
    }
    public class QryRepKeepListData
    {
        public string BMEDqtyType { get; set; }
        public string BMEDqtyDOCID { get; set; }
        public string BMEDqtyASSETNO { get; set; }
        public string BMEDqtyACCDPT { get; set; }
        public string BMEDqtyASSETNAME { get; set; }
        public string BMEDqtyFLOWTYPE { get; set; }
        public string BMEDqtyDPTID { get; set; }
        public string BMEDKqtyKeepResult { get; set; }
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
        public string BMEDqtyClsUser { get; set; }
        public string BMEDqtyLoc { get; set; }
        public string BMEDKInOut { get; set; }
    }

    public class QryVendorData
    {
        public string CONTRACT_NO { get; set; } //合約

        public string VENDOR_NO { get; set; }//廠商代碼

        public string VENDOR_NAME { get; set; } //廠商名稱

        public string PURCHASE_NO { get; set; }//採購編號

        public string ASSET_NO { get; set; } // 財產編號


        public string PLANT_NAME { get; set; } //維修地點

        public string KEEP_YEAR { get; set; }//保固年限

        public string QTY { get; set; }//數量

        public string BRAND { get; set; } //廠牌

        public string MODEL { get; set; }//型號

        public string DELIV_DPT { get; set; }//保管部門

        public string DELIV_NAME { get; set; } //保管部門編號

        public string DPT_COD { get; set; }//部門

        public string DPT_NAME { get; set; }//部門編號
    }

}
