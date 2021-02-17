using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Models
{
    public class RepairPrintVModel
    {
        [Display(Name = "表單編號")]
        public string Docid { get; set; }
        [Display(Name = "申請人代號")]
        public int UserId { get; set; }
        [Display(Name = "申請人姓名")]
        public string UserName { get; set; }
        [Display(Name = "申請人帳號")]
        public string UserAccount { get; set; }
        [Display(Name = "所屬單位")]
        public string Company { get; set; }
        [Display(Name = "聯絡方式")]
        public string Contact { get; set; }
        [Display(Name = "MVPN")]
        public string MVPN { get; set; }
        [Display(Name = "成本中心")]
        public string AccDpt { get; set; }
        public string AccDptNam { get; set; }
        [Display(Name = "維修別")]
        public string RepType { get; set; }
        [Display(Name = "財產編號")]
        public string AssetNo { get; set; }
        [Display(Name = "物品名稱")]
        public string AssetNam { get; set; }
        [Display(Name = "數量")]
        public int Amt { get; set; }
        [Display(Name = "送修儀器附件")]
        public string PlantDoc { get; set; }
        [Display(Name = "放置地點")]
        public string PlaceLoc { get; set; }
        [Display(Name = "申請日期")]
        public DateTime? ApplyDate { get; set; }
        [Display(Name = "故障描述")]
        public string TroubleDes { get; set; }
        [Display(Name = "完工日期")]
        public Nullable<DateTime> EndDate { get; set; }
        [Display(Name = "驗收日期")]
        public Nullable<DateTime> CloseDate { get; set; }
        [Display(Name = "處理描述")]
        public string DealDes { get; set; }
        [Display(Name = "工時")]
        public decimal Hour { get; set; }
        [Display(Name = "維修方式")]
        public string InOut { get; set; }
        [Display(Name = "工程師")]
        public string EngName { get; set; }
        [Display(Name = "驗收人代號")]
        public string DelivEmp { get; set; }
        [Display(Name = "驗收人姓名")]
        public string DelivEmpName { get; set; }
        [Display(Name = "醫工主管")]
        public string EngMgr { get; set; }
        [Display(Name = "醫工主任")]
        public string EngDirector { get; set; }
        [Display(Name = "單位主管")]
        public string DelivMgr { get; set; }
        [Display(Name = "單位主任")]
        public string DelivDirector { get; set; }
        [Display(Name = "單位直屬副院長")]
        public string ViceSuperintendent { get; set; }
    }

    public class KeepPrintVModel
    {
        [Display(Name = "表單編號")]
        public string Docid { get; set; }
        [Display(Name = "申請人代號")]
        public int UserId { get; set; }
        [Display(Name = "申請人姓名")]
        public string UserName { get; set; }
        [Display(Name = "申請人帳號")]
        public string UserAccount { get; set; }
        [Display(Name = "所屬單位")]
        public string Company { get; set; }
        [Display(Name = "聯絡方式")]
        public string Contact { get; set; }
        [Display(Name = "成本中心")]
        public string AccDpt { get; set; }
        public string AccDptNam { get; set; }
        [Display(Name = "維修別")]
        public string RepType { get; set; }
        [Display(Name = "財產編號")]
        public string AssetNo { get; set; }
        [Display(Name = "儀器名稱")]
        public string AssetNam { get; set; }
        [Display(Name = "數量")]
        public int Amt { get; set; }
        [Display(Name = "保養週期")]
        public int? Cycle { get; set; }
        [Display(Name = "放置地點")]
        public string PlaceLoc { get; set; }
        [Display(Name = "送單日期")]
        public DateTime? SentDate { get; set; }
        [Display(Name = "保養結果")]
        public string Result { get; set; }
        [Display(Name = "完工日期")]
        public Nullable<DateTime> EndDate { get; set; }
        [Display(Name = "驗收日期")]
        public Nullable<DateTime> CloseDate { get; set; }
        [Display(Name = "備註")]
        public string Memo { get; set; }
        [Display(Name = "工時")]
        public decimal Hour { get; set; }
        [Display(Name = "維修方式")]
        public string InOut { get; set; }
        [Display(Name = "工程師")]
        public string EngName { get; set; }
        [Display(Name = "驗收人代號")]
        public string DelivEmp { get; set; }
        [Display(Name = "驗收人姓名")]
        public string DelivEmpName { get; set; }
        [Display(Name = "醫工主管")]
        public string EngMgr { get; set; }
        [Display(Name = "醫工主任")]
        public string EngDirector { get; set; }
    }

    public class OutsideBmedPrintVModel
    {
        [Display(Name = "表單編號")]
        public string DocId { get; set; }
        [Display(Name = "申請人代號")]
        public int UserId { get; set; }
        [Display(Name = "申請人姓名")]
        public string UserName { get; set; }
        [Display(Name = "申請人帳號")]
        public string UserAccount { get; set; }
        [Display(Name = "聯絡電話")]
        public string Contact { get; set; }
        [Display(Name = "所屬單位")]
        public string Company { get; set; }
        [Display(Name = "儀器名稱")]
        public string AssetNam { get; set; }
        [Display(Name = "儀器型號")]
        public string Model { get; set; }
        [Display(Name = "儀器序號")]
        public string Serial { get; set; }
        [Display(Name = "用途說明")]
        public string Application { get; set; }
        [Display(Name = "說明")]
        public string Description { get; set; }
        [Display(Name = "計畫編號")]
        public string ProjectId { get; set; }
        [Display(Name = "IRB_NO")]
        public string IRB_NO { get; set; }
        [Display(Name = "試驗主持人")]
        public string TrialHost { get; set; }
        [Display(Name = "廠牌")]
        public string Label { get; set; }
        [Display(Name = "廠商")]
        public string Vendor { get; set; }
        [Display(Name = "廠商電話")]
        public string Phone { get; set; }
        [Display(Name = "使用單位試用人員")]
        public string Personnel { get; set; }

        [Display(Name = "使用開始日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ApplyDate { get; set; }
        
        [Display(Name = "使用結束日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "使用天數")]
        public string Day { get; set; }

        [Display(Name = "工程師")]
        public string EngName { get; set; }
        [Display(Name = "醫工主管")]
        public string EngMgr { get; set; }
        [Display(Name = "醫工承辦")]
        public string EngUndertake { get; set; }
        [Display(Name = "單位主管")]
        public string DelivMgr { get; set; }
        [Display(Name = "結案日期")]
        public Nullable<DateTime> CloseDate { get; set; }
        [Display(Name = "結案人代號")]
        public string DelivEmp { get; set; }
        [Display(Name = "結案人姓名")]
        public string DelivEmpName { get; set; }
        [Display(Name = "審核內容")]
        public string Content { get; set; }
        public bool item1 { get; set; }
        public bool item4 { get; set; }
        public bool item7 { get; set; }
    }
}
