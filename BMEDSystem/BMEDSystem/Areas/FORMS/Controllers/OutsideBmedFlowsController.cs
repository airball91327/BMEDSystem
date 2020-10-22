using MedEue.Filters;
using MedEue.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedEue.Controllers
{
    public class OutsideBmedFlowsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: OutsideBmedFlow
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(string id)
        {
            return PartialView(db.OutsideBmedFlows.Where(f => f.DocId == id));
        }

        public ActionResult NextFlow(string id)
        {
            Assign assign = new Assign();
            assign.DocId = id;
            List<SelectListItem> listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem { Text = "總經理", Value = "總經理" });
            listItem.Add(new SelectListItem { Text = "申請人", Value = "申請人" });
            listItem.Add(new SelectListItem { Text = "協理", Value = "協理" });
            listItem.Add(new SelectListItem { Text = "經理", Value = "經理" });
            listItem.Add(new SelectListItem { Text = "副理", Value = "副理" });
            listItem.Add(new SelectListItem { Text = "工程師", Value = "工程師" });
            listItem.Add(new SelectListItem { Text = "經辦", Value = "經辦" });
            Instrument sdata = db.Instruments.Find(id);
            OutsideBmedFlow of = db.OutsideBmedFlows.Where(f => f.DocId == id && f.Status == "?").FirstOrDefault();
            //AppUser appUser = db.AppUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (of != null)
            {
                assign.ClsNow = of.Cls;
                if (sdata != null)
                {
                    if (of.Cls == "總經理" || of.Cls == "協理" || of.Cls == "申請人")
                    {
                        listItem.Add(new SelectListItem { Text = "結案", Value = "結案" });
                    }
                }

                if (of.Cls == "申請人")
                {
                    listItem.Add(new SelectListItem { Text = "廢除", Value = "廢除" });
                }
            }
            ViewData["FlowCls"] = new SelectList(listItem, "Value", "Text", "");

            List<SelectListItem> listItem3 = new List<SelectListItem>();
            listItem3.Add(new SelectListItem { Text = "測試人", Value = "344066" });
            ViewData["FlowUid"] = new SelectList(listItem3, "Value", "Text", "");

            //List<SelectListItem> listItem4 = new List<SelectListItem>()
            //{
            //    new SelectListItem { Text = "特殊水、電、氣的需求,請提供資料(須會工務部)", Value = "3" },
            //    new SelectListItem { Text = "為游離輻射設備(須會輻安室)", Value = "4" },
            //    new SelectListItem { Text = "儀器保養表,試用一個月以上,須至醫工部拿取保養貼紙於機器上,並提供保養週期與保養紀錄於醫工存查", Value = "5" }
            //};

            //ViewData["Content"] = new SelectList(listItem4, "Value", "Text", "");

            //assign.Hint = "";
            assign.Application = sdata.Application;
            return PartialView(assign);
        }

        [HttpPost]
        [MyErrorHandler]
        public ActionResult NextFlow(Assign assign)
        {
            
            //AppUser appUser = db.AppUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (assign.FlowCls == "結案" || assign.FlowCls == "廢除")
                assign.FlowUid = 0000;
            Instrument instrument = db.Instruments.Find(assign.DocId);

            //審核內容初始化
            if (instrument.Application != "患者自帶")
            {
                assign.item4 = false;
                assign.item5 = false;
                assign.item6 = false;
                assign.item7 = false;
            }
            else
            {
                assign.item1 = false;
                assign.item2 = false;
                assign.item3 = false;
            }


            if (ModelState.IsValid)
            {
                //檢查審核內容是否正確
                if (instrument.Application != "患者自帶")
                {
                    if( assign.item1 == false ||
                        assign.item2 == false ||
                        assign.item3 == false)
                    {
                        throw new Exception("必須全符合規定,才可轉送下一關");
                    }
                }
                else
                {
                    if ((assign.item4 == false ||
                        assign.item5 == false ||
                        assign.item6 == false) &&
                        assign.item7 == false
                       )
                    {
                        throw new Exception("必須全符合規定,否則請點選最後一項");
                    }
                   
                }

                OutsideBmedFlow of = db.OutsideBmedFlows.Where(f => f.DocId == assign.DocId && f.Status == "?").FirstOrDefault();
               
                if (assign.FlowCls == "結案")
                {
                    of.Opinion = "[" + assign.AssignCls + "]";
                    if (!string.IsNullOrEmpty(assign.AssignOpn))
                    {
                        of.Opinion += (Environment.NewLine + assign.AssignOpn);
                    }
                    of.Status = "2";
                    of.Rtt = DateTime.Now;
                    of.Rtp = 0000;
                    of.item1 = assign.item1;
                    of.item2 = assign.item2;
                    of.item3 = assign.item3;
                    of.item4 = assign.item4;
                    of.item5 = assign.item5;
                    of.item6 = assign.item6;
                    of.item7 = assign.item7;
                    
                    db.Entry(of).State = EntityState.Modified;
                    db.SaveChanges();                 
                }
                else if (assign.FlowCls == "廢除")
                {
                    of.Opinion = "[廢除]";
                    if (!string.IsNullOrEmpty(assign.AssignOpn))
                    {
                        of.Opinion += (Environment.NewLine + assign.AssignOpn);
                    }
                    of.Status = "3";
                    of.Rtt = DateTime.Now;
                    of.Rtp = 0000;
                    of.item1 = assign.item1;
                    of.item2 = assign.item2;
                    of.item3 = assign.item3;
                    of.item4 = assign.item4;
                    of.item5 = assign.item5;
                    of.item6 = assign.item6;
                    of.item7 = assign.item7;
                    db.Entry(of).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    //轉送下一關卡
                    of.Opinion = "[" + assign.AssignCls + "]";
                    if (!string.IsNullOrEmpty(assign.AssignOpn))
                    {
                        of.Opinion += (Environment.NewLine + assign.AssignOpn);
                    }
                    of.Status = "1";
                    of.Rtt = DateTime.Now;
                    of.Rtp = 0000;
                    of.item1 = assign.item1;
                    of.item2 = assign.item2;
                    of.item3 = assign.item3;
                    of.item4 = assign.item4;
                    of.item5 = assign.item5;
                    of.item6 = assign.item6;
                    of.item7 = assign.item7;
                    db.Entry(of).State = EntityState.Modified;
                    db.SaveChanges();
                    //
                    OutsideBmedFlow flow = new OutsideBmedFlow();
                    flow.DocId = assign.DocId;
                    flow.StepId = of.StepId + 1;
                    flow.UserId = assign.FlowUid.Value;
                    flow.UserName = "轉下一關"/*db.AppUsers.Find(assign.FlowUid.Value).FullName*/;
                    flow.Status = "?";
                    flow.Cls = assign.FlowCls;
                    flow.Rtt = DateTime.Now;
                    flow.item1 = assign.item1;
                    flow.item2 = assign.item2;
                    flow.item3 = assign.item3;
                    flow.item4 = assign.item4;
                    flow.item5 = assign.item5;
                    flow.item6 = assign.item6;
                    flow.item7 = assign.item7;
                    db.OutsideBmedFlows.Add(flow);
                    db.SaveChanges();                   
                }

                return new JsonResult
                {
                    Data = new { success = true, error = "" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                string msg = "";
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    msg += error.ErrorMessage + Environment.NewLine;
                }
                throw new Exception(msg);
            }
        }

        public ActionResult NextSFlow(string id)
        {
            Assign assign = new Assign();
            assign.DocId = id;
            List<SelectListItem> listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem { Text = "總經理", Value = "總經理" });
            listItem.Add(new SelectListItem { Text = "申請人", Value = "申請人" });
            listItem.Add(new SelectListItem { Text = "協理", Value = "協理" });
            listItem.Add(new SelectListItem { Text = "經理", Value = "經理" });
            listItem.Add(new SelectListItem { Text = "副理", Value = "副理" });
            listItem.Add(new SelectListItem { Text = "工程師", Value = "工程師" });
            listItem.Add(new SelectListItem { Text = "經辦", Value = "經辦" });
            Instrument sdata = db.Instruments.Find(id);
            OutsideBmedFlow of = db.OutsideBmedFlows.Where(f => f.DocId == id && f.Status == "?").FirstOrDefault();
            //AppUser appUser = db.AppUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (of != null)
            {
                assign.ClsNow = of.Cls;
                if (sdata != null)
                {
                    if (of.Cls == "總經理" || of.Cls == "協理" || of.Cls == "申請人")
                    {
                        listItem.Add(new SelectListItem { Text = "結案", Value = "結案" });
                    }
                }

                if (of.Cls == "申請人")
                {
                    listItem.Add(new SelectListItem { Text = "廢除", Value = "廢除" });
                }
            }
            ViewData["FlowCls"] = new SelectList(listItem, "Value", "Text", "");

            List<SelectListItem> listItem3 = new List<SelectListItem>();
            listItem3.Add(new SelectListItem { Text = "測試人", Value = "344066" });
            ViewData["FlowUid"] = new SelectList(listItem3, "Value", "Text", "");

            //List<SelectListItem> listItem4 = new List<SelectListItem>()
            //{
            //    new SelectListItem { Text = "特殊水、電、氣的需求,請提供資料(須會工務部)", Value = "3" },
            //    new SelectListItem { Text = "為游離輻射設備(須會輻安室)", Value = "4" },
            //    new SelectListItem { Text = "儀器保養表,試用一個月以上,須至醫工部拿取保養貼紙於機器上,並提供保養週期與保養紀錄於醫工存查", Value = "5" }
            //};

            //ViewData["Content"] = new SelectList(listItem4, "Value", "Text", "");

            //assign.Hint = "";
            assign.Application = sdata.Application;
            assign.item1 = of.item1;
            assign.item2 = of.item2;
            assign.item3 = of.item3;
            assign.item4 = of.item4;
            assign.item5 = of.item5;
            assign.item6 = of.item6;
            assign.item7 = of.item7;
            return PartialView(assign);
        }

        [HttpPost]
        [MyErrorHandler]
        public ActionResult NextSFlow(Assign assign)
        {

            //AppUser appUser = db.AppUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (assign.FlowCls == "結案" || assign.FlowCls == "廢除")
                assign.FlowUid = 0000;
            Instrument instrument = db.Instruments.Find(assign.DocId);
            if (ModelState.IsValid)
            {
                OutsideBmedFlow of = db.OutsideBmedFlows.Where(f => f.DocId == assign.DocId && f.Status == "?").FirstOrDefault();
                if (assign.FlowCls == "結案")
                {
                    of.Opinion = "[" + assign.AssignCls + "]";
                    if (!string.IsNullOrEmpty(assign.AssignOpn))
                    {
                        of.Opinion += (Environment.NewLine + assign.AssignOpn);
                    }
                    of.Status = "2";
                    of.Rtt = DateTime.Now;
                    of.Rtp = 0000;
                    of.item1 = assign.item1;
                    of.item2 = assign.item2;
                    of.item3 = assign.item3;
                    of.item4 = assign.item4;
                    of.item5 = assign.item5;
                    of.item6 = assign.item6;
                    of.item7 = assign.item7;

                    db.Entry(of).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else if (assign.FlowCls == "廢除")
                {
                    of.Opinion = "[廢除]";
                    if (!string.IsNullOrEmpty(assign.AssignOpn))
                    {
                        of.Opinion += (Environment.NewLine + assign.AssignOpn);
                    }
                    of.Status = "3";
                    of.Rtt = DateTime.Now;
                    of.Rtp = 0000;
                    of.item1 = assign.item1;
                    of.item2 = assign.item2;
                    of.item3 = assign.item3;
                    of.item4 = assign.item4;
                    of.item5 = assign.item5;
                    of.item6 = assign.item6;
                    of.item7 = assign.item7;
                    db.Entry(of).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    //轉送下一關卡
                    of.Opinion = "[" + assign.AssignCls + "]";
                    if (!string.IsNullOrEmpty(assign.AssignOpn))
                    {
                        of.Opinion += (Environment.NewLine + assign.AssignOpn);
                    }
                    of.Status = "1";
                    of.Rtt = DateTime.Now;
                    of.Rtp = 0000;
                    of.item1 = assign.item1;
                    of.item2 = assign.item2;
                    of.item3 = assign.item3;
                    of.item4 = assign.item4;
                    of.item5 = assign.item5;
                    of.item6 = assign.item6;
                    of.item7 = assign.item7;
                    db.Entry(of).State = EntityState.Modified;
                    db.SaveChanges();
                    //
                    OutsideBmedFlow flow = new OutsideBmedFlow();
                    flow.DocId = assign.DocId;
                    flow.StepId = of.StepId + 1;
                    flow.UserId = assign.FlowUid.Value;
                    flow.UserName = "轉下一關"/*db.AppUsers.Find(assign.FlowUid.Value).FullName*/;
                    flow.Status = "?";
                    flow.Cls = assign.FlowCls;
                    flow.Rtt = DateTime.Now;
                    flow.item1 = assign.item1;
                    flow.item2 = assign.item2;
                    flow.item3 = assign.item3;
                    flow.item4 = assign.item4;
                    flow.item5 = assign.item5;
                    flow.item6 = assign.item6;
                    flow.item7 = assign.item7;
                    db.OutsideBmedFlows.Add(flow);
                    db.SaveChanges();
                }

                return new JsonResult
                {
                    Data = new { success = true, error = "" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                string msg = "";
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    msg += error.ErrorMessage + Environment.NewLine;
                }
                throw new Exception(msg);
            }
        }

        [HttpPost]
        [MyErrorHandler]
        public ActionResult TransToMe(string docid)
        {
            Instrument instrument = db.Instruments.Find(docid);
            //AppUser appUser = db.AppUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (ModelState.IsValid)
            {
                string[] s = new string[] { "?", "2" };
                OutsideBmedFlow rf = db.OutsideBmedFlows.Where(f => f.DocId == docid && s.Contains(f.Status)).FirstOrDefault();
                //
                //轉送下一關卡
                rf.Opinion = "[改變流程]" + Environment.NewLine
                    + "流程已經被" + "" + "更改。";
                rf.Status = "1";
                rf.Rtt = DateTime.Now;
                rf.Rtp =123456;
                db.Entry(rf).State = EntityState.Modified;
                db.SaveChanges();
                //
                OutsideBmedFlow flow = new OutsideBmedFlow();
                flow.DocId = docid;
                flow.StepId = rf.StepId + 1;
                flow.UserId = 123456;
                flow.UserName = "王曉明";
                flow.Status = "?";
                flow.Cls = "";
                flow.Rtt = DateTime.Now;
                db.OutsideBmedFlows.Add(flow);
                db.SaveChanges();
                ///Send Mail
               

                return new JsonResult
                {
                    Data = new { success = true, error = "" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

            }
            else
            {
                string msg = "";
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    msg += error.ErrorMessage + Environment.NewLine;
                }
                throw new Exception(msg);
            }
        }
    }
}