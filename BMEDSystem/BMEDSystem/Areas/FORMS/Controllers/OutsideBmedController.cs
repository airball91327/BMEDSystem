using EDIS.Repositories;
using EDIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDIS.Areas.FORMS.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Linq;
using EDIS.Areas.FORMS.Data;
using System.Net;

namespace EDIS.Areas.FORMS.Controllers
{
    public class OutsideBmedController : Controller
    {
        private BMEDDBContext db = new BMEDDBContext();
        // GET:Index
        public ActionResult Create()
        {
            Instrument medeue = new Instrument();
            string docid = "";
            do
            {
                System.Threading.Thread.Sleep(1000);
                docid = GetUseId();
            } while (string.IsNullOrEmpty(docid) || docid.Contains("Error"));

            List<SelectListItem> listItem1 = new List<SelectListItem>();
            //db.AppUsers.ToList()
            //     .ForEach(u => {
            //         listItem.Add(new SelectListItem { Text = u.FullName, Value = u.Id.ToString() });
            //     });
            listItem1.Add(new SelectListItem { Text = "李老王", Value = "344066"});
            ViewData["ToUserId"] = new SelectList(listItem1, "Value", "Text", "");
            //
            List<SelectListItem> listItem2 = new List<SelectListItem>();
            listItem2.Add(new SelectListItem { Text = "陳英才", Value = "789100" });
            ViewData["Personnel"] = new SelectList(listItem2, "Value", "Text", "");
            //
            medeue.DocId = docid;
            medeue.UserId = 123456;
            medeue.UserName = "王曉明";
            medeue.UseUnit = "醫工部";
            medeue.Day = "0";
            medeue.UseDayFrom = DateTime.Now;
            medeue.UseDayTo = DateTime.Now;
            medeue.ApplyDate = DateTime.Now; 
            return View(medeue);
        }

        // POST: MedEqu
        [HttpPost]
        public ActionResult Create(Instrument instrument)
        {
            //檔案上傳確認
            AttainFile attain = db.AttainFiles.Where(p => p.DocId == instrument.DocId).FirstOrDefault();
            if (instrument.Application != "患者自帶" && attain == null)
            {
                throw new Exception("審核內容需附上證明檔案");
            }

            if (instrument.Application == "患者自帶")
            {
                instrument.Vendor = null;
                instrument.Phone = null;
                instrument.Personnel = null;
            }
            else if (instrument.Application != "臨床試驗")
            {
                instrument.ProjectId = null;
                instrument.IRB_NO = null;
                instrument.TrialHost = null;
            }
            else
            {
                instrument.Content = null;
            }
            if (!ModelState.IsValid)
            {
                string msg = "";
                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                {
                    msg += error.ErrorMessage + Environment.NewLine;
                }
                throw new Exception(msg);
            }
            if (instrument.UseDayFrom >= instrument.UseDayTo)
            {
                throw new Exception("使用日期其日期選擇有誤，請重新選擇");
            }

           
            db.Instruments.Add(instrument);

            //設定流程
            OutsideBmedFlow of;
            of = new OutsideBmedFlow();
            of.DocId = instrument.DocId;
            of.StepId = 1;
            of.UserId = instrument.UserId;
            of.UserName = instrument.UserName;
            of.Status = "1";
            of.Cls = "申請人";
            of.Rtp = instrument.UserId;
            of.Rtt = DateTime.Now;
            of.item1 = false;
            of.item2 = false;
            of.item3 = false;
            of.item4 = false;
            of.item5 = false;
            of.item6 = false;
            of.item7 = false;
            db.OutsideBmedFlows.Add(of);
            //
            of = new OutsideBmedFlow();
            of.DocId = instrument.DocId;    
            of.StepId = 2;
            of.UserId = instrument.ToUserId;
            of.UserName = instrument.ToUserName;
            of.Status = "?";
            of.Cls = "主管";
            of.Rtp = instrument.UserId;
            of.Rtt = DateTime.Now;
            of.item1 = false;
            of.item2 = false;
            of.item3 = false;
            of.item4 = false;
            of.item5 = false;
            of.item6 = false;
            of.item7 = false;
            db.OutsideBmedFlows.Add(of);
            db.SaveChanges();
            return RedirectToAction("OutsideBmedEdit", "OutsideBmed",new {@id=instrument.DocId });
        }

        public string GetUseId()
        {
            string yyyymm = Convert.ToString(DateTime.Now.Year * 100 + DateTime.Now.Month);
            string oldDocid = db.Instruments.Select(d => d.DocId).DefaultIfEmpty().Max();
            string newDocid = "";
            if (!string.IsNullOrEmpty(oldDocid))
            {
                if (oldDocid.Substring(0, 6) == yyyymm)
                {
                    newDocid = Convert.ToString(Convert.ToInt32(oldDocid) + 1);
                }
                else
                {
                    newDocid = yyyymm + "0001";
                }
            }
            else
            {
                newDocid = yyyymm + "0001";
            }
            return newDocid;
        }

        [HttpPost]
        public ActionResult GetDay(string UseDayFrom , string UseDayTo)
        {
            
            var action = Convert.ToDateTime(UseDayFrom);

            var end = Convert.ToDateTime(UseDayTo);

            //if (action > end)
            //{
            //    return Json("Error", JsonRequestBehavior.AllowGet);
            //}
            JObject jo = new JObject();
            //TimeSpan Days = new TimeSpan();
            var s =  (end-action).Days;
            var Days = s.ToString();
            return Json(Days);          
        }

        // GET: OutsideBmed/Details/
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Instrument signData = db.Instruments.Find(id);
            if (signData == null)
            {
                return NotFound();
            }
            return PartialView(signData);
        }

        // GET: OutsideBmed/Details/
        public ActionResult NewContent(string id)
        {
            Assign assign = new Assign();
            Instrument data = db.Instruments.Find(id);
            OutsideBmedFlow of = db.OutsideBmedFlows.Where(o => o.DocId == id).OrderBy(o => o.Rtt == data.ApplyDate).ToList().Last();   
            
            assign.item1=of.item1;
            assign.item2=of.item2;
            assign.item3=of.item3;
            assign.item4=of.item4;
            assign.item5=of.item5;
            assign.item6=of.item6;
            assign.item7=of.item7;
            assign.Application = data.Application;
            assign.Content = data.Content;
            return PartialView(assign);
        }

        public async Task<ActionResult> OutsideBmedEdit(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Instrument instrument = await db.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }
            //ViewData["kind"] = kind;

            return View(instrument);
        }

        // GET: Instrument/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Instrument instrument = await db.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }
            return View(instrument);
        }

        // GET: OutsideBmed/Details/
        public ActionResult PreviewData(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Instrument signData = db.Instruments.Find(id);
            if (signData == null)
            {
                return NotFound();
            }
            return View(signData);
        }

        //姓名關鍵查詢
        //public JsonResult GetUsersByKeyname(string keyname)
        //{
        //    List<AppUser> ul;
        //    List<UserList> us = new List<UserList>();
        //    string s = "";
        //    ul = db.AppUsers.Where(p => p.FullName.Contains(keyname)).ToList();
        //    foreach (AppUser f in ul)
        //    {
        //        UserList u = new UserList();
        //        u.uid = f.Id;
        //        u.uname = "(" + f.UserName + ")" + f.FullName;
        //        us.Add(u);
        //    }
        //    s = JsonConvert.SerializeObject(us);
        //    return Json(s, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult QryData()
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem { Text = "醫工部", Value = "醫工部" });
            ViewData["UseUnit"] = new SelectList(listItem, "Value", "Text", "");
            return View();
        }
        [HttpPost]
        public ActionResult QryData(FormCollection fc)
        {
            string sdate = fc["Sdate"];
            string edate = fc["Edate"];
            string name = fc["Name"];
            string model = fc["Model"];
            string serial = fc["Serial"];
            string useUnit = fc["UseUnit"];
            string label = fc["Label"];

            List<OutsideBmedListModel> sv = new List<OutsideBmedListModel>();
            string[] s = new string[] { "?", "2" };
            string s2 = "";
            DateTime dt;
            int uid = 123456;
            db.OutsideBmedFlows.Where(f => f.UserId == uid).Select(f => f.DocId)
                .Join(db.Instruments, t => t, d => d.DocId, (t, d) => d)
                .Join(db.OutsideBmedFlows.Where(f => s.Contains(f.Status)), d => d.DocId, f => f.DocId,
                (d, f) => new
                {
                    leave = d,
                    leaveflow = f
                }).ToList()
                .ForEach(item =>
                {
                    switch (item.leaveflow.Status)
                    {
                        case "?":
                            s2 = "流程中";
                            break;
                        case "2":
                            s2 = "已結案";
                            break;
                        case "-":
                            s2 = "會簽中";
                            break;
                    };
                    sv.Add(new OutsideBmedListModel
                    {
                        DocType = "外部醫療儀器申請",
                        DocId = item.leave.DocId,
                        UserName = item.leave.UserName,
                        Topic = item.leave.Description,
                        ApplyDate = item.leave.ApplyDate,
                        Rtt = item.leave.ApplyDate,
                        Status = s2,
                        UseDayFrom = item.leave.UseDayFrom,
                        UseDayTo = item.leave.UseDayTo,
                        Name = item.leave.Name,
                        Model = item.leave.Model,
                        Serial = item.leave.Serial,
                        Label = item.leave.Label,
                        UseUnit = item.leave.UseUnit
                    });

                });
            if (!string.IsNullOrEmpty(name))
            {
               
                    sv = sv.Where(v => v.Name.Contains(name)).ToList();
                
            }
            if (!string.IsNullOrEmpty(model))
            {

                sv = sv.Where(v => v.Model.Contains(model)).ToList();
                
                
            }
            if (!string.IsNullOrEmpty(serial))
            {
               
                    sv = sv.Where(v => v.Serial.Contains(serial)).ToList();
                
            }
            if (!string.IsNullOrEmpty(label))
            {
                
                    sv = sv.Where(v => v.Label.Contains(label)).ToList();
                
            }
            if (!string.IsNullOrEmpty(useUnit))
            {
                
                    sv = sv.Where(v => v.UseUnit == useUnit).ToList();
                
            }
            if (!string.IsNullOrEmpty(sdate))
            {
                if (DateTime.TryParse(sdate, out dt))
                {
                    sv = sv.Where(v => v.UseDayFrom >= dt).ToList();
                }
            }
            if (!string.IsNullOrEmpty(edate))
            {
                if (DateTime.TryParse(edate, out dt))
                {
                    sv = sv.Where(v => v.UseDayTo <= dt).ToList();
                }
            }
            return PartialView("QryDataList", sv);
        }

        public ActionResult QryDataList()
        {
            List<OutsideBmedListModel> sv = new List<OutsideBmedListModel>();
            string[] s = new string[] { "?", "2" };
            string s2 = "";
           // DateTime dt;
            int uid = 123456;
            db.OutsideBmedFlows.Where(f => f.UserId == uid).Select(f => f.DocId)
                .Join(db.Instruments, t => t, d => d.DocId, (t, d) => d)
                .Join(db.OutsideBmedFlows.Where(f => s.Contains(f.Status)), d => d.DocId, f => f.DocId,
                (d, f) => new
                {
                    leave = d,
                    leaveflow = f
                }).ToList()
                .ForEach(item =>
                {
                    switch (item.leaveflow.Status)
                    {
                        case "?":
                            s2 = "流程中";
                            break;
                        case "2":
                            s2 = "已結案";
                            break;
                        case "-":
                            s2 = "會簽中";
                            break;
                    };
                    sv.Add(new OutsideBmedListModel
                    {
                        DocType = "外部醫療儀器申請",
                        DocId = item.leave.DocId,
                        UserName = item.leave.UserName,
                        Topic = item.leave.Description,
                        ApplyDate = item.leave.ApplyDate,
                        Rtt = item.leave.ApplyDate,
                        Status = s2,
                        UseDayFrom = item.leave.UseDayFrom,
                        UseDayTo = item.leave.UseDayTo,
                        Name = item.leave.Name,
                        Model = item.leave.Model,
                        Serial = item.leave.Serial,
                        Label = item.leave.Label,
                        UseUnit = item.leave.UseUnit
                    });

                });

            return PartialView(sv);
        }

        // GET: OutsideBemd/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Instrument instrument= await db.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }
            return View(instrument);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            //SignData signData = await db.SignDatas.FindAsync(id);
            //db.SignDatas.Remove(signData);
          
            string[] ss = new string[] { "?", "2", "-" };
            OutsideBmedFlow of = await db.OutsideBmedFlows.Where(s => s.DocId == id)
                .Where(s => ss.Contains(s.Status)).FirstOrDefaultAsync();
            of.Status = "3";
            of.Rtp = 123456;
            of.Rtt = DateTime.Now;
            db.Entry(of).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}