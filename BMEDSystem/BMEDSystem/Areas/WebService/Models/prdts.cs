using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Areas.WebService.Models
{
    public class Prdts
    {
        public string PRD_NO { get; set; }
        public string NAME { get; set; }
        public string SNM { get; set; }
        public string INV_NAME { get; set; }
        public string IDX1 { get; set; }
        public string UT { get; set; }
        public string CHK_NUM { get; set; }
        public string CHK_BAT { get; set; }
        public string CHK_INSTALL { get; set; }
        public string USE_PRDMARK { get; set; }
        public string FY_FLAG { get; set; }
        public string SPC_PRD { get; set; }
        public string CHK_TAX { get; set; }
        public string NOT_RTN { get; set; }
        public string STOP { get; set; }
        public string KND { get; set; }
        public string SPC_TAX { get; set; }
        public string SUP1 { get; set; }
    }

    public class WsStock
    {
        public string PRD_NO { get; set; }
        public string PRD_NAME { get; set; }
        public string WH_NO { get; set; }
        public string WH_NM { get; set; }
        public string IDX_NO { get; set; }
        public string IDX_NM { get; set; }
        public string QTY { get; set; }
        public string CUS_NM { get; set; }
    }

    public class PrudoctVModel
    {
        [DisplayName("品項編號")]
        public string PRD_NO { get; set; }  //貨品代號
        [DisplayName("品項名稱")]
        public string NAME { get; set; }    //名稱
        [DisplayName("簡稱")]
        public string SNM { get; set; }
        [DisplayName("發票名稱")]
        public string INV_NAME { get; set; }
        [DisplayName("中類代號")]
        public string IDX1 { get; set; }
        [DisplayName("主單位")]
        public string UT { get; set; }
        [DisplayName("大類")]
        public string KND { get; set; }
        [DisplayName("商品稅率")]
        public string SPC_TAX { get; set; }
        [DisplayName("主供應商")]
        public string SUP1 { get; set; }
        [DisplayName("主供應商統編")]
        public string SUP1_UNI_NO { get; set; }
    }
}
