﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EDIS.Models
{
    public partial class BuyEvaluateModel
    {
        [Key]
        [Display(Name = "表單編號")]
        public string DocId { get; set; }
        [NotMapped]
        public string DocSid { get; set; }
        [Display(Name = "申請人代號")]
        public int UserId { get; set; }
        [Display(Name = "申請人姓名")]
        public string UserName { get; set; }
        [Display(Name = "所屬單位")]
        public string Company { get; set; }
        [Display(Name = "聯絡方式")]
        public string Contact { get; set; }
        [Display(Name = "成本中心")]
        public string AccDpt { get; set; }
        [NotMapped]
        public string AccDptNam { get; set; }
        [Display(Name = "設備類別")]
        public string PlantType { get; set; }
        [Display(Name = "設備名稱(中文)")]
        public string PlantCnam { get; set; }
        [Display(Name = "設備名稱(英文)")]
        public string PlantEnam { get; set; }
        [Display(Name = "數量")]
        public int Amt { get; set; }
        [Display(Name = "單位")]
        public string Unit { get; set; }
        [Display(Name = "單價")]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal? Price { get; set; }
        [Display(Name = "總價")]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public decimal? TotalPrice { get; set; }
        [Display(Name = "規格")]
        public string Standard { get; set; }
        [Display(Name = "新機存放地點")]
        public string Place { get; set; }
        [Display(Name = "設備工程師")]
        public int EngId { get; set; }
        [NotMapped]
        public string EngName { get; set; }
        [Display(Name = "採購人員")]
        public int? PurchaserId { get; set; }
        [NotMapped]
        public string PurchaserName { get; set; }
        [Display(Name = "預算編號")]
        public string BudgetId { get; set; }
        public DateTime? AgreeDate { get; set; }
        [NotMapped]
        [Display(Name = "醫工部意見")]
        public string Opinion { get; set; }
        [NotMapped]
        [Display(Name = "小組意見")]
        public string GrpOpin { get; set; }
        [NotMapped]
        [Display(Name = "同意規格")]
        public bool IsAgree { get; set; }
        [Display(Name = "異動人員")]
        public int? Rtp { get; set; }
        [Display(Name = "異動時間")]
        public DateTime? Rtt { get; set; }

        public string GetID(ref ApplicationDbContext db)
        {
            string str = "";
            str += "SELECT MAX(DOCID) DocId FROM BMEDBuyEvaluates ";
            var r = db.BuyEvaluates.FromSql(str).Select(d => d.DocId).ToList();
            string did = "";
            int yymm = (System.DateTime.Now.Year - 1911) * 100 + System.DateTime.Now.Month;
            foreach (string s in r)
            {
                did = s;
            }
            if (did != "")
            {
                if (Convert.ToInt64(did) / 100000 == yymm)
                    did = Convert.ToString(Convert.ToInt64(did) + 1);
                else
                    did = Convert.ToString(yymm * 100000 + 1);
            }
            else
            {
                did = Convert.ToString(yymm * 100000 + 1);
            }
            return did;
        }
    }
}
