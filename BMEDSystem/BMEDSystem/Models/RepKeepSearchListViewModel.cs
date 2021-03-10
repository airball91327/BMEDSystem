using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Models
{
    public class RepKeepSearchListViewModel
    {
        [Display(Name = "類別")]
        public string DocType { get; set; }
        [Display(Name = "請修類別")]
        public string RepType { get; set; }
        [Display(Name = "表單編號")]
        public string DocId { get; set; }
        [Display(Name = "財產編號")]
        public string AssetNo { get; set; }
        [Display(Name = "儀器名稱")]
        public string AssetName { get; set; }
        [Display(Name = "廠牌")]
        public string Brand { get; set; }
        [Display(Name = "請修地點")]
        public string PlaceLoc { get; set; }
        [Display(Name = "型號")]
        public string Type { get; set; }
        [Display(Name = "申請部門代號")]
        public string ApplyDpt { get; set; }
        [Display(Name = "成本中心代號")]
        public string AccDpt { get; set; }
        [Display(Name = "成本中心名稱")]
        public string AccDptName { get; set; }
        [Display(Name = "故障描述")]
        public string TroubleDes { get; set; }
        [Display(Name = "處理狀態")]
        public string DealState { get; set; }
        [Display(Name = "處理描述")]
        public string DealDes { get; set; }
        [Display(Name = "費用")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal? Cost { get; set; }
        [Display(Name = "天數")]
        public int? Days { get; set; }
        public string Flg { get; set; }
        public int FlowUid { get; set; }
        [Display(Name = "關卡人員")]
        public string FlowUidName { get; set; }
        [Display(Name = "關卡")]
        public string FlowCls { get; set; }
        [Display(Name = "維修申請日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ApplyDate { get; set; }
        [Display(Name = "完工日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "結案日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? CloseDate { get; set; }
        [Display(Name = "[有][無]費用")]
        public string IsCharged { get; set; }
        [Display(Name = "是否已請購")]
        public string IsPurchase { get; set; }
        public RepairModel repdata { get; set; }

        [Display(Name = "保養方式")]
        public string InOut { get; set; }
        [Display(Name = "保養結果")]
        public string Result { get; set; }
        [Display(Name = "保養描述")]
        public string Memo { get; set; }
        public string Src { get; set; }
        [Display(Name = "保養申請日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? SentDate { get; set; }
        public KeepModel keepdata { get; set; }
    }
}
