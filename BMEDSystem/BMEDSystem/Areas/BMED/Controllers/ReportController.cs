﻿using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using X.PagedList;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly IRepository<DepartmentModel, string> _dptRepo;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;
        private int pageSize = 50;

        public ReportController(ApplicationDbContext context,
                                IRepository<AppUserModel, int> userRepo,
                                IRepository<DepartmentModel, string> dptRepo,
                                CustomUserManager customUserManager,
                                CustomRoleManager customRoleManager)
        {
            _context = context;
            _userRepo = userRepo;
            _dptRepo = dptRepo;
            userManager = customUserManager;
            roleManager = customRoleManager;
        }
        // GET: /BMED/Report
        public IActionResult Index(string rpname)
        {
            if (rpname == "保養完成率統計表")
                return RedirectToAction("FinishRateKeepIndex", "Report", new { rpname = rpname });
            //if (rpname == "儀器設備保養清單")
            //    return RedirectToAction("AssetKeepList");
            ReportQryVModel pv = new ReportQryVModel();
            pv.ReportClass = rpname;

            List<SelectListItem> listItem = new List<SelectListItem>();
            List<SelectListItem> listItem2 = new List<SelectListItem>();
            List<SelectListItem> listItem3 = new List<SelectListItem>();
            SelectListItem li;
            listItem.Add(new SelectListItem { Text = "請選擇", Value = "" });
            _context.Departments.ToList()
                .ForEach(d =>
                {
                    li = new SelectListItem();
                    li.Text = d.Name_C + "(" + d.DptId + ")";
                    li.Value = d.DptId;
                    listItem.Add(li);

                });
            ViewData["ACCDPT"] = new SelectList(listItem, "Value", "Text");

            listItem2.Add( new SelectListItem{ Text = "請選擇", Value = "" });
            listItem2.Add(new SelectListItem { Text = "總院", Value = "總院" });
            listItem2.Add(new SelectListItem { Text = "二林", Value = "L" });
            listItem2.Add(new SelectListItem { Text = "員林", Value = "B" });
            listItem2.Add(new SelectListItem { Text = "南投", Value = "N" });
            listItem2.Add(new SelectListItem { Text = "鹿基", Value = "U" });
            listItem2.Add(new SelectListItem { Text = "雲基", Value = "T" });
            ViewData["Location"] = new SelectList(listItem2, "Value", "Text");

            //問卷名稱
            SelectListItem nameq;
            listItem3.Add(new SelectListItem { Text = "請選擇", Value = "" });
            _context.QuestionnaireMs.ToList()
                .ForEach(q =>
                {
                    nameq = new SelectListItem();
                    nameq.Text = q.Qname;
                    nameq.Value = q.Qname;
                    listItem3.Add(nameq);

                });
            ViewData["Qname"] = new SelectList(listItem3, "Value", "Text");

            return View(pv);
        }

        // GET: /BMED/Report/FinishRateKeepIndex
        public IActionResult FinishRateKeepIndex(string rpname)
        {
            /* Get login user. */
            var ur = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();
            /* Get login user's location. */
            var urLocation = new DepartmentModel(_context).GetUserLocation(ur);
            ViewData["UserLoc"] = urLocation;
            ReportQryVModel pv = new ReportQryVModel();
            pv.ReportClass = rpname;

            List<SelectListItem> listItem2 = new List<SelectListItem>();
            
            listItem2.Add(new SelectListItem { Text = "請選擇", Value = "" });
            listItem2.Add(new SelectListItem { Text = "總院", Value = "總院" });
            listItem2.Add(new SelectListItem { Text = "二林", Value = "L" });
            listItem2.Add(new SelectListItem { Text = "員林", Value = "B" });
            listItem2.Add(new SelectListItem { Text = "南投", Value = "N" });
            listItem2.Add(new SelectListItem { Text = "鹿基", Value = "U" });
            listItem2.Add(new SelectListItem { Text = "雲基", Value = "T" });
            ViewData["Location"] = new SelectList(listItem2, "Value", "Text");

            
            return View(pv);
        }

        // POST: /BMED/Report/FinishRateKeepIndex
        [HttpPost]
        public IActionResult FinishRateKeepIndex(ReportQryVModel v, int page = 1)
        {
            /* Get login user. */
            var usr = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();

            /* Get login user's location. */
            var loc = new DepartmentModel(_context).GetUserLocation(usr);

            if (!string.IsNullOrEmpty(v.Location))
            {
                // Admin & 設備主管才可查詢全單位，其餘Role只可查詢自己單位
                if (userManager.IsInRole(User, "Admin") || userManager.IsInRole(User, "MedMgr")
                    || userManager.IsInRole(User, "MedAssetMgr"))
                {
                    // Do nothing.
                }
                else
                {
                    v.Location = loc;
                }
            }
            else
            {
                v.Location = loc;
            }

            var result = GetFinishRateKeep(v);

            TempData["qry"] = JsonConvert.SerializeObject(v);
            return View("FinishRateKeep", result.ToPagedList(page, pageSize));
        }

        private List<FinishRateKeep> GetFinishRateKeep(ReportQryVModel v)
        {
            var urLocation = v.Location;
            var building = v.Building;
            var isProgress = v.IsProgress;
            //
            int? sendYm = v.SendYm;
            var Medusrs = _context.AppUsers
                .Join(_context.UsersInRoles.Where(r => r.RoleId == 13),
                        u => u.Id,
                        r => r.UserId,
                        (u,r) => u
                );
            var qryFlowEng = _context.BMEDKeepFlows.Where(kf => kf.Status == "?" || kf.Status == "2").Select(kf => kf.DocId)
                                                   .Join(_context.BMEDKeepFlows, id => id, kf => kf.DocId,
                                                   (id, kf) => kf)
                                                   .Where(kf => kf.Cls.Contains("工程師"))
                                                   .OrderByDescending(kf => kf.DocId).ThenByDescending(kf => kf.StepId)
                                                   .GroupBy(kf => kf.DocId).Select(group => group.FirstOrDefault());
            var qryAsset = _context.BMEDAssets.Join(_context.BMEDAssetKeeps, a => a.AssetNo, ak => ak.AssetNo,
                                              (a, ak) => new
                                              {
                                                  asset = a,
                                                  assetkeep = ak
                                              })
                                              .Join(_context.Departments, a => a.asset.DelivDpt, d => d.DptId,
                                              (a, d) => new
                                              { 
                                                  asset = a.asset,
                                                  assetkeep = a.assetkeep,
                                                  delivDptLoc = d.Loc
                                              });
            var qryKeep = _context.BMEDKeeps.Where(k => k.Loc == urLocation).AsQueryable();
            if (!string.IsNullOrEmpty(building))
            {
                if (building == "P")
                {
                    qryAsset = qryAsset.Where(a => a.delivDptLoc == "P");
                }
                else
                {
                    qryAsset = qryAsset.Where(a => a.delivDptLoc != "P");
                }
            }
            if (sendYm != null)
            {
                var year =  (Convert.ToInt32(sendYm.ToString().Substring(0, 3)) + 1911).ToString();
                var month = sendYm.ToString().Substring(3, 2);
                var sendDateFrom = DateTime.Parse(year + "-" + month);
                var sendDateTo = sendDateFrom.AddMonths(1).AddSeconds(-1);
                if (isProgress)
                {
                    sendDateFrom = DateTime.Parse(year + "-01");
                }
                qryKeep = qryKeep.Where(k => k.SentDate >= sendDateFrom && k.SentDate <= sendDateTo);
            }
            var data = qryKeep.Join(_context.BMEDKeepDtls, k => k.DocId, kdtl => kdtl.DocId,
                                (k, kdtl) => new 
                                {
                                    keep = k,
                                    dtl = kdtl
                                })
                                .Join(qryFlowEng, k => k.keep.DocId, f => f.DocId,
                                (k, f) => new
                                {
                                    keep = k.keep,
                                    dtl = k.dtl,
                                    engflow = f
                                })
                                .Join(qryAsset, k => k.keep.AssetNo, a => a.asset.AssetNo,
                                (k, a) => new
                                {
                                    keep = k.keep,
                                    dtl = k.dtl,
                                    engflow = k.engflow,
                                    asset = a.asset,
                                    assetkeep = a.assetkeep
                                })
                                .Join(Medusrs, k => k.engflow.UserId, u => u.Id,
                                (k, u) => new
                                {
                                    keep = k.keep,
                                    dtl = k.dtl,
                                    engflow = k.engflow,
                                    asset = k.asset,
                                    assetkeep = k.assetkeep,
                                    eng = u
                                });
            var engIdList = data.Select(d => d.engflow.UserId).Distinct().ToList();
            var dataToList = data.ToList();
            List<FinishRateKeep> result = new List<FinishRateKeep>();
            FinishRateKeep frk;
            foreach (var engid in engIdList)
            {
                var engData = dataToList.Where(d => d.eng.Id == engid).ToList();
                frk = new FinishRateKeep();
                frk.EngId = engid.ToString();
                frk.EngUserName = engData.FirstOrDefault().eng.UserName;
                frk.EngFullName = engData.FirstOrDefault().eng.FullName;
                frk.SendYm = sendYm != null ? sendYm.ToString() : "";
                //自行
                frk.KeepCount0 = engData.Where(d => d.dtl.InOut == "0").Count();
                frk.KeepEndCount0 = engData.Where(d => d.dtl.InOut == "0" && d.dtl.EndDate.HasValue == true).Count();
                frk.KeepEndRate0 = frk.KeepCount0 == 0 ? "N/A" : ((decimal)frk.KeepEndCount0 / frk.KeepCount0).ToString("P");
                //委外
                frk.KeepCount1 = engData.Where(d => d.dtl.InOut == "1").Count();
                frk.KeepEndCount1 = engData.Where(d => d.dtl.InOut == "1" && d.dtl.EndDate.HasValue == true).Count();
                frk.KeepEndRate1 = frk.KeepCount1 == 0 ? "N/A" : ((decimal)frk.KeepEndCount1 / frk.KeepCount1).ToString("P");
                //租賃
                frk.KeepCount2 = engData.Where(d => d.dtl.InOut == "2").Count();
                frk.KeepEndCount2 = engData.Where(d => d.dtl.InOut == "2" && d.dtl.EndDate.HasValue == true).Count();
                frk.KeepEndRate2 = frk.KeepCount2 == 0 ? "N/A" : ((decimal)frk.KeepEndCount2 / frk.KeepCount2).ToString("P");
                //保固
                frk.KeepCount3 = engData.Where(d => d.dtl.InOut == "3").Count();
                frk.KeepEndCount3 = engData.Where(d => d.dtl.InOut == "3" && d.dtl.EndDate.HasValue == true).Count();
                frk.KeepEndRate3 = frk.KeepCount3 == 0 ? "N/A" : ((decimal)frk.KeepEndCount3 / frk.KeepCount3).ToString("P");
                //總數
                frk.KeepCount = engData.Count();
                frk.KeepEndCount = engData.Where(d => d.dtl.EndDate.HasValue == true).Count();
                frk.KeepEndRate = frk.KeepCount == 0 ? "N/A" : ((decimal)frk.KeepEndCount / frk.KeepCount).ToString("P");
                //高風險
                frk.KeepCountRisk = engData.Where(d => d.asset.HighRisk == "Y").Count();
                frk.KeepEndCountRisk = engData.Where(d => d.asset.HighRisk == "Y" && d.dtl.EndDate.HasValue == true).Count();
                frk.KeepEndRateRisk = frk.KeepCountRisk == 0 ? "N/A" : ((decimal)frk.KeepEndCountRisk / frk.KeepCountRisk).ToString("P");
                result.Add(frk);
            }

            result = result.OrderBy(r => r.EngUserName).ToList();
            return result;
        }

        public IActionResult ExcelFinishRateKeep(ReportQryVModel v)
        {
            var result = GetFinishRateKeep(v);
            //
            ExcelPackage excel = new ExcelPackage();
            var sheet1 = excel.Workbook.Worksheets.Add("保養完成率統計表");
            // Sheet1
            // Title
            sheet1.Cells[1, 1].Value = "負責工程師";
            sheet1.Cells[1, 2].Value = "員工姓名";
            sheet1.Cells[1, 3].Value = "保養起始年月";
            sheet1.Cells[1, 4].Value = "應保養(自行)";
            sheet1.Cells[1, 5].Value = "已保養(自行)";
            sheet1.Cells[1, 6].Value = "完成率(自行)";
            sheet1.Cells[1, 7].Value = "應保養(委外)";
            sheet1.Cells[1, 8].Value = "已保養(委外)";
            sheet1.Cells[1, 9].Value = "完成率(委外)"; 
            sheet1.Cells[1, 10].Value = "應保養(租賃)";
            sheet1.Cells[1, 11].Value = "已保養(租賃)";
            sheet1.Cells[1, 12].Value = "完成率(租賃)";
            sheet1.Cells[1, 13].Value = "應保養(保固)";
            sheet1.Cells[1, 14].Value = "已保養(保固)";
            sheet1.Cells[1, 15].Value = "完成率(保固)";
            sheet1.Cells[1, 16].Value = "應保養";
            sheet1.Cells[1, 17].Value = "已保養";
            sheet1.Cells[1, 18].Value = "完成率";
            sheet1.Cells[1, 19].Value = "應保養(高風險)";
            sheet1.Cells[1, 20].Value = "已保養(高風險)";
            sheet1.Cells[1, 21].Value = "完成率(高風險)";
            //Data
            int startPos = 2;
            foreach (var item in result)
            {
                sheet1.Cells[startPos, 1].Value = item.EngUserName;
                sheet1.Cells[startPos, 2].Value = item.EngFullName;
                sheet1.Cells[startPos, 3].Value = item.SendYm;
                sheet1.Cells[startPos, 4].Value = item.KeepCount0;
                sheet1.Cells[startPos, 5].Value = item.KeepEndCount0;
                sheet1.Cells[startPos, 6].Value = item.KeepEndRate0;
                sheet1.Cells[startPos, 7].Value = item.KeepCount1;
                sheet1.Cells[startPos, 8].Value = item.KeepEndCount1;
                sheet1.Cells[startPos, 9].Value = item.KeepEndRate1;
                sheet1.Cells[startPos, 10].Value = item.KeepCount2;
                sheet1.Cells[startPos, 11].Value = item.KeepEndCount2;
                sheet1.Cells[startPos, 12].Value = item.KeepEndRate2;
                sheet1.Cells[startPos, 13].Value = item.KeepCount3;
                sheet1.Cells[startPos, 14].Value = item.KeepEndCount3;
                sheet1.Cells[startPos, 15].Value = item.KeepEndRate3;
                sheet1.Cells[startPos, 16].Value = item.KeepCount;
                sheet1.Cells[startPos, 17].Value = item.KeepEndCount;
                sheet1.Cells[startPos, 18].Value = item.KeepEndRate;
                sheet1.Cells[startPos, 19].Value = item.KeepCountRisk;
                sheet1.Cells[startPos, 20].Value = item.KeepEndCountRisk;
                sheet1.Cells[startPos, 21].Value = item.KeepEndRateRisk;
                startPos++;
            }

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            var fileName = "FinishRateKeep_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: fileName
            );
        }

        private List<AssetKpScheVModel> AssetKpSche(ReportQryVModel v)
        {
            var urLocation = v.Location;
            //
            TempData["qry2"] = JsonConvert.SerializeObject(v);
            List<AssetKpScheVModel> sv = new List<AssetKpScheVModel>();
            var assetK = _context.BMEDAssetKeeps.Where(x => x.Cycle > 0 );
            //完成保養
            //var dtls = _context.BMEDKeepDtls.Where(d => d.Result == 1);
            var dtls = _context.BMEDKeepDtls.AsQueryable();

            //登入者部門
            var depar = _context.Departments.AsQueryable();
            if (urLocation == "總院")
            {
                depar = _context.Departments.Where(r => r.Loc == "C" || r.Loc == "P" || r.Loc == "K");
            }
            else
            {
                depar = _context.Departments.Where(r => r.Loc == urLocation);
            }

            var datas = _context.BMEDAssets.Where(a => a.DisposeKind != "報廢")
                .Join(  assetK,
                        a => a.AssetNo,
                        k => k.AssetNo,
                        (a, k) => new
                        {
                            asset = a,
                            assetkeep = k
                        }
                )
                .Join(
                    depar,
                    a => a.asset.DelivDpt,
                    d => d.DptId,
                    (a, d) => new
                    {
                        asset = a.asset,
                        assetkeep = a.assetkeep,
                        dept = d
                    })
                .GroupJoin(_context.BMEDKeeps,
                        a => a.asset.AssetNo,
                        k => k.AssetNo,
                        (a, k) => new
                        {
                            asset = a.asset,
                            assetkeep = a.assetkeep,
                            dept = a.dept,
                            keep = k
                        })
                .SelectMany(x => x.keep.DefaultIfEmpty(),
                         (s, k) => new
                         {
                             AssetNo = s.asset.AssetNo,
                             AssetName = s.asset.Cname,
                             DelivDptName = s.dept.Name_C,
                             Brand = s.asset.Brand,
                             Type = s.asset.Type,
                             //aks.DocId = s.dtls == null ? null : s.dtls.DocId;
                             //aks.EDate = s.dtls == null ? null : s.dtls.EndDate == null ? "" : s.dtls.EndDate.Value.ToString("yyyy/MM/dd");
                             KeepYm = s.assetkeep.KeepYm == null ? 0 : s.assetkeep.KeepYm.Value,
                             Cycle = s.assetkeep.Cycle == null ? 0 : s.assetkeep.Cycle.Value,
                             AssetClass = s.asset.AssetClass,
                             Cname = s.asset.Cname,
                             AccDpt = s.asset.AccDpt,
                             DelivDpt = s.asset.DelivDpt,
                             KeepEngId = s.assetkeep.KeepEngId,
                             Sdate = k ==  null ? null : k.SentDate,
                             Name_C = s.dept.Name_C,
                             DocId = k == null ? "" : k.DocId
                         }
                )
                //.Select( s => new
                //{
                //    AssetNo = s.asset.AssetNo,
                //    AssetName = s.asset.Cname,
                //    DelivDptName = s.dept.Name_C,
                //    Brand = s.asset.Brand,
                //    Type = s.asset.Type,
                //    //aks.DocId = s.dtls == null ? null : s.dtls.DocId;
                //    //aks.EDate = s.dtls == null ? null : s.dtls.EndDate == null ? "" : s.dtls.EndDate.Value.ToString("yyyy/MM/dd");
                //    KeepYm = s.assetkeep.KeepYm == null ? 0 : s.assetkeep.KeepYm.Value,
                //    Cycle = s.assetkeep.Cycle == null ? 0 : s.assetkeep.Cycle.Value,
                //    AssetClass = s.asset.AssetClass,
                //    Cname = s.asset.Cname,
                //    AccDpt = s.asset.AccDpt,
                //    DelivDpt = s.asset.DelivDpt,
                //    KeepEngId = s.assetkeep.KeepEngId,
                //    Sdate = s.Sdate.Value.Year,
                //    Name_C = s.dept.Name_C,
                //    DocId = s.DocId
                //})
                //.GroupJoin( dtls,
                //            a => a.DocId,
                //            k => k.DocId,
                //            (a, k) => new
                //            {
                //                asset = a,
                //                dtls = k
                //            })
                //.SelectMany(x => x.dtls.DefaultIfEmpty(),
                //            (a, k) => new
                //            {
                //                asset = a.asset.asset,
                //                assetkeep = a.asset.assetkeep,
                //                dept = a.asset.dept,
                //                sdate = a.asset.Sdate,
                //                dtls = k
                //            })
                ;
            //var data = _context.BMEDAssets
            //   .Join(_context.BMEDAssetKeeps.Where(x => x.Cycle > 0), a => a.AssetNo, k => k.AssetNo,
            //   (a, k) => new
            //   {
            //       asset = a,
            //       assetkeep = k
            //   })
            //   .Join(depar, a => a.asset.DelivDpt, d => d.DptId,
            //   (a, d) => new {
            //       asset = a.asset,
            //       assetkeep = a.assetkeep,
            //       dept = d
            //   });
            //var ds = datas.ToList();
            datas = datas.Where(r => r.AssetClass == (v.AssetClass1 ?? v.AssetClass2));
            //ds = datas.ToList();


            if (!string.IsNullOrEmpty(v.AssetName))
            {
                datas = datas.Where(r => r.Cname.Contains(v.AssetName));
            }
            string acc = v.AccDpt;
            string deliv = v.DelivDpt;
            string ano = v.AssetNo;
            int engid;
            int j = 0;
            int count = 0;
            //DateTime? EDate = null;
            if (!string.IsNullOrEmpty(acc))
                datas = datas.Where(x => x.AccDpt == acc);
            if (!string.IsNullOrEmpty(deliv))
                datas = datas.Where(x => x.DelivDpt == deliv);
            if (!string.IsNullOrEmpty(ano))
                datas = datas.Where(x => x.AssetNo == ano);
            if (!string.IsNullOrEmpty(v.EngId))
            {
                engid = Convert.ToInt32(v.EngId);
                datas = datas.Where(x => x.KeepEngId == engid);
            }
            datas = datas.Where(k => k.Sdate.Value.Year == v.KeepY);
            string[] st = { "2", "?" };
            datas = datas.Join(_context.BMEDKeepFlows.Where(f => st.Contains(f.Status)),
                                d => d.DocId,
                                f => f.DocId,
                                (d, f) => d);
            //var ds = datas.ToList();
            //完工保養單
            var del = dtls
                .Join(datas,
                            k => k.DocId,
                            a => a.DocId,
                            (k, a) => new
                            {
                                DocId = k.DocId,
                                assetNo = a.AssetNo,
                                EndDate = k.EndDate,
                                Sdate = a.Sdate.Value.Month
                            })
                .OrderBy(x => x.DocId)
                .ThenBy( e => e.EndDate)
                .GroupBy(x => x.assetNo)
                .ToDictionary(x => x.Key,
                        x => x.Select(k =>new {
                            DocId = k.DocId,
                            EndDate = k.EndDate,
                            Day = k.Sdate
                }));

            

            //重複資料篩選
            var data = datas
                .Select(s => new
                {
                    AssetNo = s.AssetNo,
                    AssetName = s.Cname,
                    DelivDptName = s.Name_C,
                    Brand = s.Brand,
                    Type = s.Type,
                    //aks.DocId = s.dtls == null ? null : s.dtls.DocId;
                    //aks.EDate = s.dtls == null ? null : s.dtls.EndDate == null ? "" : s.dtls.EndDate.Value.ToString("yyyy/MM/dd");
                    KeepYm = s.KeepYm ,
                    Cycle = s.Cycle,
                    AssetClass = s.AssetClass,
                    Cname = s.Cname,
                    AccDpt = s.AccDpt,
                    DelivDpt = s.DelivDpt,
                    KeepEngId = s.KeepEngId,
                    Sdate = s.Sdate.Value.Year,
                    Name_C = s.Name_C
                })
                .Distinct()
                .OrderBy(x => x.AssetNo).ToList();

            AssetKpScheVModel aks;
            int year = DateTime.Now.Year - 1911 ;
            int yyymm = 0;
            int cycle = 0;
            int y1 = 0;
            int m1 = 0;
            int i = 0;
            count = 0;
            foreach (var s in data)
            {
                aks = new AssetKpScheVModel();
                aks.AssetNo = s.AssetNo;
                aks.AssetName = s.Cname;
                aks.DelivDptName = s.Name_C;
                aks.Brand = s.Brand;
                aks.Type = s.Type;
                count = 0;
                //aks.DocId = s.dtls == null ? null : s.dtls.DocId;
                //aks.EDate = s.dtls == null ? null : s.dtls.EndDate == null ? "" : s.dtls.EndDate.Value.ToString("yyyy/MM/dd");
                yyymm = s.KeepYm ;
                cycle = s.Cycle;
                y1 = yyymm / 100;
                m1 = yyymm % 100;
                if (yyymm > 0 && cycle > 0)
                {
                    j = 0;
                    for (i = 1; i <= 12; i++)
                    {
                        var EDate = del.ContainsKey(aks.AssetNo) == false ? null : del[aks.AssetNo].Where(x => x.Day == i).FirstOrDefault();
                        if (EDate != null) { 
                            switch (i)
                            {
                                case 1:
                                    
                                        aks.JanDocId = EDate.DocId;
                                        aks.JanEDate = EDate.EndDate == null ? "" : EDate.EndDate.Value.ToString("yyyy/MM/dd");
                                    
                                    break;
                                case 2:
                                    
                                        aks.FebDocId = EDate.DocId;
                                        aks.FebEDate = EDate.EndDate == null ? "" : EDate.EndDate.Value.ToString("yyyy/MM/dd");
                                    
                                    break;
                                case 3:
                                        aks.MarDocId = EDate.DocId;
                                        aks.MarEDate = EDate.EndDate == null ? "" : EDate.EndDate.Value.ToString("yyyy/MM/dd");
                                    
                                    break;
                                case 4:
                                    
                                        aks.AprDocId = EDate.DocId;
                                        aks.AprEDate = EDate.EndDate == null ? "" : EDate.EndDate.Value.ToString("yyyy/MM/dd");
                                    
                                    break;
                                case 5:
                                    
                                        aks.MayDocId = EDate.DocId;
                                        aks.MayEDate = EDate.EndDate == null ? "" : EDate.EndDate.Value.ToString("yyyy/MM/dd");
                                    
                                    break;
                                case 6:
                                    
                                        aks.JunDocId = EDate.DocId;
                                        aks.JunEDate = EDate.EndDate == null ? "" : EDate.EndDate.Value.ToString("yyyy/MM/dd");
                                    
                                    break;
                                case 7:
                                    
                                        aks.JulDocId = EDate.DocId;
                                        aks.JulEDate = EDate.EndDate == null ? "" : EDate.EndDate.Value.ToString("yyyy/MM/dd");
                                    
                                    break;
                                case 8:
                                   
                                        aks.AugDocId = EDate.DocId;
                                        aks.AugEDate = EDate.EndDate == null ? "" : EDate.EndDate.Value.ToString("yyyy/MM/dd");
                                    
                                    break;
                                case 9:
                                    
                                        aks.SepDocId = EDate.DocId;
                                        aks.SepEDate = EDate.EndDate == null ? "" : EDate.EndDate.Value.ToString("yyyy/MM/dd");
                                    
                                    break;
                                case 10:
                                    
                                        aks.OctDocId = EDate.DocId;
                                        aks.OctEDate = EDate.EndDate == null ? "" : EDate.EndDate.Value.ToString("yyyy/MM/dd");
                                    
                                    break;
                                case 11:
                                   
                                        aks.NovDocId = EDate.DocId;
                                        aks.NovEDate = EDate.EndDate == null ? "" : EDate.EndDate.Value.ToString("yyyy/MM/dd");
                                    
                                    break;
                                case 12:
                                    
                                        aks.DecDocId = EDate.DocId;
                                        aks.DecEDate = EDate.EndDate == null ? "" : EDate.EndDate.Value.ToString("yyyy/MM/dd");
                                    
                                    break;
                            }
                        }

                        if (((year - y1) * 12 + (i - m1)) % cycle == 0)//哪一月保養
                        {
                            switch (i)
                            {
                                case 1:
                                    aks.Jan = "*" ;
                                    break;
                                case 2:
                                    aks.Feb = "*";
                                    break;
                                case 3:
                                    aks.Mar = "*" ;
                                    break;
                                case 4:
                                    aks.Apr = "*";
                                    break;
                                case 5:
                                    aks.May = "*";
                                    break;
                                case 6:
                                    aks.Jun = "*" ;
                                    break;
                                case 7:
                                    aks.Jul = "*";
                                    break;
                                case 8:
                                    aks.Aug = "*" ;
                                    break;
                                case 9:
                                    aks.Sep = "*" ;
                                    break;
                                case 10:
                                    aks.Oct = "*";
                                    break;
                                case 11:
                                    aks.Nov = "*";
                                    break;
                                case 12:
                                    aks.Dec = "*" ;
                                    break;
                            }
                            
                        }
                    }
                }
                sv.Add(aks);
            }
            
            return sv;
        }

        public IActionResult AssetKpScheExcel(ReportQryVModel v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("財產編號");
            dt.Columns.Add("設備名稱");
            dt.Columns.Add("保管部門");
            dt.Columns.Add("廠牌");
            dt.Columns.Add("型號");
            dt.Columns.Add("工程師");
            dt.Columns.Add("一月");
            dt.Columns.Add("二月");
            dt.Columns.Add("三月");
            dt.Columns.Add("四月");
            dt.Columns.Add("五月");
            dt.Columns.Add("六月");
            dt.Columns.Add("七月");
            dt.Columns.Add("八月");
            dt.Columns.Add("九月");
            dt.Columns.Add("十月");
            dt.Columns.Add("十一月");
            dt.Columns.Add("十二月");
            List<AssetKpScheVModel> mv = AssetKpSche(v);
            var c = (char)10;
            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.AssetNo;
                dw[1] = m.AssetName;
                dw[2] = m.DelivDptName;
                dw[3] = m.Brand;
                dw[4] = m.Type;
                dw[5] = m.EngName;
                dw[6] = m.Jan + '\n' + m.JanDocId;
                dw[7] = m.Feb + '\n' + m.FebDocId;
                dw[8] = m.Mar + '\n' + m.MarDocId;
                dw[9] = m.Apr + '\n' + m.AprDocId;
                dw[10] = m.May + '\n' + m.MayDocId;
                dw[11] = m.Jun + '\n' + m.JunDocId;
                dw[12] = m.Jul + '\n' + m.JulDocId;
                dw[13] = m.Aug + '\n' + m.AugDocId;
                dw[14] = m.Sep + '\n' + m.SepDocId;
                dw[15] = m.Oct + '\n' + m.OctDocId;
                dw[16] = m.Nov + '\n' + m.NovDocId;
                dw[17] = m.Dec + '\n' + m.DecDocId;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("設備保養排程年報");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);
            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "AssetKpSche.xlsx"
            );
        }
        //public void ExcelQA(ReportQryVModel v)
        //{
        //    List<QuestReport> qrlist = QuestAnaly(v);
        //    DataTable dt = new DataTable();
        //    DataRow dw;
        //    //dt.Columns.Add("合約");
        //    dt.Columns.Add("表單編號(請修案號)");
        //    dt.Columns.Add("時間戳記");
        //    //dt.Columns.Add("部門代號");
        //    dt.Columns.Add("申請部門");
        //    //
        //    int cols = 0;
        //    _context.QuestionnaireMs.Where(m => m.Flg == "Y")
        //    .Join(_context.Questionnaires, m => m.VerId, q => q.VerId,
        //    (m, q) => q).OrderBy(q => q.Qid)
        //    .ToList().
        //    ForEach(q =>
        //    {
        //        dt.Columns.Add(q.Qtitle);
        //    });
        //    //
        //    qrlist.ToList()
        //            .ForEach(j =>
        //            {
        //                dw = dt.NewRow();
        //                dw[0] = j.Docid;
        //                //dw[0] = j.ContractNo + j.Contract;
        //                dw[1] = j.TimeStamp;
        //                //dw[2] = j.DptId;
        //                dw[2] = j.DptName;
        //                cols = 3;
        //                foreach (QuestAnswer s in j.Answers)
        //                {
        //                    dw[cols] = s.Answer;
        //                    cols++;
        //                }
        //                dt.Rows.Add(dw);
        //            });
        //    //
        //    ExcelPackage excel = new ExcelPackage();
        //    var workSheet = excel.Workbook.Worksheets.Add("滿意度調查統計表");
        //    workSheet.Cells[1, 1].LoadFromDataTable(dt, true);
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        Response.AddHeader("content-disposition", "attachment;  filename=QuestionAnalysis.xlsx");
        //        excel.SaveAs(memoryStream);
        //        memoryStream.WriteTo(Response.OutputStream);
        //        Response.Flush();
        //        Response.End();
        //    }
        //}

        [HttpPost]
        public IActionResult Index(ReportQryVModel v, int page = 1)
        {
            /* Get login user. */
            var usr = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();

            /* Get login user's location. */
            var loc = new DepartmentModel(_context).GetUserLocation(usr);

            if (!string.IsNullOrEmpty(v.Location)) { 
                // Admin & 設備主管才可查詢全單位，其餘Role只可查詢自己單位
                if (userManager.IsInRole(User, "Admin") || userManager.IsInRole(User, "MedMgr")
                    || userManager.IsInRole(User, "MedAssetMgr"))
                {
                    // Do nothing.
                }
                else
                {
                    v.Location = loc;
                }
            }
            else
            {
                v.Location = loc;
            }

            if (v.Edate != null)
            {
                v.Edate = v.Edate.Value.AddHours(23)
                    .AddMinutes(59)
                    .AddSeconds(59);
            }

            //TempData["qry"] = v; //the TempData serializer currently supports only a limited set of data types for simplicity. It supports a few primitive types such as int, string, and bool, and simple containers of those types, such as lists.
            switch (v.ReportClass)
            {
                case "月故障率統計表":
                    if (v.Edate == null && v.Sdate == null)
                    {
                        return new JsonResult(v)
                        {
                            Value = new { success = false, error = "需選擇一個時間!" }
                        };
                    }
                    return PartialView("MonthFailRate", MonthFailRate(v).ToPagedList(page, pageSize));
                case "月維修清單":
                    if (v.Edate == null || v.Sdate == null)
                    {
                        return new JsonResult(v)
                        {
                            Value = new { success = false, error = "請輸入時間區間!" }
                        };
                    }
                    return PartialView("MonthRepair", MonthRepair(v).ToPagedList(page, pageSize));
                case "月保養清單":
                    if (v.Edate == null || v.Sdate == null)
                    {
                        return new JsonResult(v)
                        {
                            Value = new { success = false, error = "請輸入時間區間!" }
                        };
                    }
                    return PartialView("MonthKeep", MonthKeep(v).ToPagedList(page, pageSize));
                case "各成本中心維修保養統計表":
                    return PartialView("RepairKeep", RepairKeep(v).ToPagedList(page, pageSize));
                case "維修金額統計表":
                    if (v.Edate == null || v.Sdate == null)
                    {
                        return new JsonResult(v)
                        {
                            Value = new { success = false, error = "請輸入時間區間!" }
                        };
                    }
                    return PartialView("RepairCost", RepairCost(v, page));
                case "保養金額統計表":
                    if (v.Edate == null || v.Sdate == null)
                    {
                        return new JsonResult(v)
                        {
                            Value = new { success = false, error = "請輸入時間區間!" }
                        };
                    }
                    return PartialView("KeepCost", KeepCost(v, page));
                case "工作時數統計表":
                    if (v.Edate == null && v.Sdate == null)
                    {
                        return new JsonResult(v)
                        {
                            Value = new { success = false, error = "請輸入時間區間!" }
                        };
                    }
                    return PartialView("DoHrSumMon", DoHrSumMon(v));
                case "未結案清單":
                    return PartialView("UnSignList", UnSignList(v).Take(200));
                case "維修保養履歷":
                    if (string.IsNullOrEmpty(v.AssetNo))
                    {
                        return new JsonResult(v)
                        {
                            Value = new { success = false, error = "請輸入財產編號!" }
                        };
                    }
                    ViewData["Ano"] = v.AssetNo;
                    //if (v.Edate == null)
                    //{
                    //    //if (v.Sdate == null)
                    //    //{
                    //    //    v.Sdate = DateTime.Now.AddYears(-1);
                    //    //}
                    //    v.Edate = DateTime.Now.AddHours(23)
                    //    .AddMinutes(59)
                    //    .AddSeconds(59);
                    //}

                    List<RpKpHistoryVModel> rk = RpKpHistory(v);
                    AssetAnalysis ay = new AssetAnalysis();
                    ay.RepairHour = rk.Where(r => r.DocType == "請修").Select(r => r.Hours).Sum().Value;
                    ay.RepCost = rk.Where(r => r.DocType == "請修").Select(r => r.Cost).Sum().Value;
                    ay.KeepHour = rk.Where(r => r.DocType == "保養").Select(r => r.Hours).Sum().Value;
                    ay.KeepCost = rk.Where(r => r.DocType == "保養").Select(r => r.Cost).Sum().Value;
                    AssetModel at = _context.BMEDAssets.Find(v.AssetNo);
                    if (at != null)
                    {
                        if (at.Cost != null)
                        {
                            if (at.Cost > 0)
                                ay.RepRatio = decimal.Round(ay.RepCost / at.Cost.Value * 100m, 2);
                            else
                                ay.RepRatio = 0;
                        }
                    }
                    else
                    {
                        return new JsonResult(v)
                        {
                            Value = new { success = false, error = "無此財產!" }
                        };
                    }
                    double faildays = 0;
                    double d = 0;
                    rk.Where(r => r.DocType == "請修").ToList()
                        .ForEach(r =>
                        {
                            if (r.EndDate != null)
                            {
                                //if (v.Edate == null)
                                //    v.Edate = DateTime.Now.AddHours(23).AddMinutes(59).AddSeconds(59);

                                //faildays += v.Edate.Value.Subtract(r.ApplyDate).TotalDays;
                                d = r.EndDate.Value.Subtract(r.ApplyDate).TotalDays;
                                if (d > 0)
                                {
                                    if (d <= 1d)
                                        faildays += 1d;
                                    else
                                        faildays += d;
                                }
                            }
                            //else if (v.Edate != null)
                            //{ 
                            //    if(r.EndDate.Value.CompareTo(v.Edate.Value) > 0)
                            //           faildays += v.Edate.Value.Subtract(r.ApplyDate).TotalDays;
                            //    else
                            //    {

                            //        d = r.EndDate.Value.Subtract(r.ApplyDate).TotalDays;
                            //        if (d > 0)
                            //        {
                            //            if (d <= 1d)
                            //                faildays += 1d;
                            //            else
                            //                faildays += d;
                            //        }

                            //    }
                            //}
                        });

                    if (v.Sdate == null && v.Edate == null)
                    {
                        ay.ProperRate = null;
                    }
                    else if (v.Sdate == null && v.Edate != null)
                    {
                        ay.ProperRate = null;
                    }
                    else if (v.Sdate != null && v.Edate == null)
                    {
                        v.Edate = DateTime.Now.AddHours(23)
                        .AddMinutes(59)
                        .AddSeconds(59);
                        ay.ProperRate = decimal.Round(100m -
                        Convert.ToDecimal(faildays / v.Edate.Value.Subtract(v.Sdate.Value).TotalDays) * 100m, 2);

                    }
                    else {
                        ay.ProperRate = decimal.Round(100m -
                        Convert.ToDecimal(faildays / v.Edate.Value.Subtract(v.Sdate.Value).TotalDays) * 100m, 2);
                    }
                    
                    //decimal.Round(Convert.ToDecimal(faildays / v.Edate.Value.Subtract(v.Sdate.Value).TotalDays)*100m, 2);
                    ViewData["Analysis"] = ay;
                    return PartialView("RpKpHistory", rk);
                case "設備妥善率統計表":
                    if (v.Sdate == null)
                    {
                        if (v.Edate == null)
                        {
                            v.Edate = DateTime.Now
                            .AddHours(23)
                            .AddMinutes(59)
                            .AddSeconds(59);
                        }
                        v.Sdate =  new DateTime();
                    }
                    else if (v.Edate == null)
                    {
                        v.Edate = DateTime.Now
                            .AddHours(23)
                            .AddMinutes(59)
                            .AddSeconds(59);
                    }
                    return PartialView("AssetProperRate", AssetProperRate(v, page));
                case "重複故障清單":
                    return PartialView("RepeatFail", RepeatFail(v));
                case "維修保養零件統計表":
                    return PartialView("RepKeepStok", RepKeepStok(v));
                //case "維修保養零件(廠牌)統計表":
                case "廠商支出統計表":
                    return PartialView("RpKpStokBd", RpKpStokBd(v));
                case "零件帳務清單":
                    return PartialView("StokCost", StokCost(v));
                case "列管報廢清單":
                    return PartialView("ScrapAsset", ScrapAsset(v).ToPagedList(page, pageSize));
                case "分攤費用清單":
                    if (v.Edate == null || v.Sdate == null)
                    {
                        return new JsonResult(v)
                        {
                            Value = new { success = false, error = "請輸入時間區間!" }
                            //return NotFound("請輸入時間區間!");
                        };
                    }
                    return PartialView("ReKeShCosCheck", ReKeShCosCheck(v).ToPagedList(page, pageSize));
                case "超過五日案件清單":
                    if (v.Edate == null || v.Sdate == null)
                    {
                        return new JsonResult(v)
                        {
                            Value = new { success = false, error = "時間區間皆都需選擇!" }
                        };
                    }
                    return PartialView("CaseOverFive", CaseOverFive(v).ToPagedList(page, pageSize));
                case "滿意度調查統計表":
                    if (v.Qname == null)
                    {
                        return new JsonResult(v)
                        {
                            Value = new { success = false, error = "請選擇問卷名稱!" }
                            //return NotFound("請輸入時間區間!");
                        };
                    }
                    return PartialView("QuestionAnalysis", QuestAnaly(v).ToPagedList(page, pageSize));
                //case "儀器設備保養清單":
                    //    return PartialView("AssetKeepList", AssetKeepList(v));
            }

            return View();
        }

        public IActionResult ExcelKeepCost(ReportQryVModel v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("單位代號");
            dt.Columns.Add("單位名稱");
            dt.Columns.Add("應保養");
            dt.Columns.Add("已保養");
            dt.Columns.Add("保養達成率");
            dt.Columns.Add("保養費用");

            int kcnt = 0;
            int kent = 0;
            int rcnt = 0;
            int rent = 0;
            List<RepairKeepVModel> mv = KeepCostAll(v); 
            mv.ForEach(m =>
            {
                rcnt += m.RepairAmt;
                rent += m.RpEndAmt;
                kcnt += m.KeepAmt;
                kent += m.KpEndAmt;

                dw = dt.NewRow();
                dw[0] = m.CustId;
                dw[1] = m.CustNam;
                dw[2] = m.KeepAmt;
                dw[3] = m.KpEndAmt;
                dw[4] = m.KeepFinishedRate;
                dw[5] = m.KeepCost;
                
                dt.Rows.Add(dw);
            });

            dw = dt.NewRow();

            dw[2] = "保養總件數：" + kcnt;

            if (kcnt != 0)
            {
                dw[3] = "保養完成率：" + Decimal.Round(kent / kcnt * 100m, 2);
            }
            else
            {
                dw[3] = "";
            }

            dt.Rows.Add(dw);
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("保養金額統計表");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "MonthKeep.xlsx"
            );
        }

        public IActionResult ExcelRepairCost(ReportQryVModel v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("單位代號");
            dt.Columns.Add("單位名稱");
            dt.Columns.Add("維修件數");
            dt.Columns.Add("已維修");
            dt.Columns.Add("維修達成率");
            dt.Columns.Add("維修費用");

            int kcnt = 0;
            int kent = 0;
            int rcnt = 0;
            int rent = 0;
            List<RepairKeepVModel> mv = RepairCostAll(v);
            mv.ForEach(m =>
            {
                rcnt += m.RepairAmt;
                rent += m.RpEndAmt;
                kcnt += m.KeepAmt;
                kent += m.KpEndAmt;

                dw = dt.NewRow();
                dw[0] = m.CustId;
                dw[1] = m.CustNam;
                dw[2] = m.RepairAmt;
                dw[3] = m.RpEndAmt;
                dw[4] = m.RepFinishedRate;
                dw[5] = m.RepCost;

                dt.Rows.Add(dw);
            });

            dw = dt.NewRow();

            dw[2] = "保養總件數：" + kcnt;

            if (kcnt != 0)
            {
                dw[3] = "保養完成率：" + Decimal.Round(kent / kcnt * 100m, 2);
            }
            else
            {
                dw[3] = "";
            }

            dt.Rows.Add(dw);
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("維修金額統計表");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "MonthKeep.xlsx"
            );
        }

        public IActionResult ExcelAssetProperRate(ReportQryVModel v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("財產編號");
            dt.Columns.Add("設備名稱");
            dt.Columns.Add("廠牌");
            dt.Columns.Add("型號");
            dt.Columns.Add("成本中心");
            dt.Columns.Add("機齡");
            dt.Columns.Add("處分性質");
            dt.Columns.Add("維修日數");
            dt.Columns.Add("維修次數");
            dt.Columns.Add("妥善率");

            List<ProperRate> mv = AssetProperRateAll(v); //List<ProperRate> mv = AssetProperRate(v);
            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.AssetNo;
                dw[1] = m.AssetName;
                dw[2] = m.Brand;
                dw[3] = m.Type;
                dw[4] = m.AccDpt + m.AccDptNam;
                dw[5] = m.AircraftY;
                dw[6] = m.DisposeKind;
                dw[7] = m.RepairDays;
                dw[8] = m.RepairCnts;
                dw[9] = m.AssetProperRate;

                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("設備妥善率統計");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }
            

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "AssetProperRate.xlsx"
            );
        }

        /// <summary>
        /// Get scrap asset list by query conditions.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private List<ScrapAsset> ScrapAsset(ReportQryVModel v)
        {
            TempData["qry"] = JsonConvert.SerializeObject(v);
            string[] status = new[] { "申請人", "驗收人","單位主管" };

            var urLocation = v.Location;
            /* Get assets by user's location. */
            var bmedAssets = GetAssetsByLoc(urLocation);

            //var repair = _context.BMEDRepairs.ToList();
            // 報廢案件
            var repairDtl = _context.BMEDRepairDtls.Where(rd => rd.DealState == 4)
                                                   .Where(rd => rd.CloseDate != null);
            //非報廢設備
            var asstes = bmedAssets.Where(a => a.DisposeKind != "報廢");
            //列管財產
            var repair = _context.BMEDRepairs
                        .Where(re => re.AssetNo.Length > 6 )
                        .Join( asstes,
                                        r => r.AssetNo,
                                        a => a.AssetNo,
                                        (r,a) => r);

            // Query Conditions.條件篩選
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                repair = repair.Where(r => r.AccDpt == v.AccDpt);
            }
            if (!string.IsNullOrEmpty(v.AssetNo))
            {
                repair = repair.Where(r => r.AssetNo == v.AssetNo);
            }
            if (v.Sdate != null )
            {
                repairDtl = repairDtl.Where(rd => rd.CloseDate >= v.Sdate);
            }
            if (v.Edate != null)
            {
                repairDtl = repairDtl.Where(rd => rd.CloseDate <= v.Edate);
            }

            //列管財產join報廢案件
            var result = repair.Join(repairDtl, 
                                     r => r.DocId, 
                                     rd => rd.DocId,
                                    (r, rd) => new
                                    {
                                        dtl = rd,
                                        repair = r
                                    });
            //
            List<ScrapAsset> sa = new List<ScrapAsset>();
            DepartmentModel dpt;
            AppUserModel usr;
            //RepairFlowModel rf;

            //關卡:單位開單者的案件
            var flow = _context.BMEDRepairFlows
                .Join(result ,
                      r => r.DocId,
                      t => t.repair.DocId,
                      (r,t) => new { rf = r , rt = t}
                      )
                .OrderByDescending(r => r.rf.StepId)
                .Where(r => status.Contains(r.rf.Cls));

            //目前最後關卡人員名稱與異動時間
            var flowuf = flow.Join(_context.AppUsers,
                             r => r.rf.UserId,
                             u => u.Id,
                             (r, u) => new { 
                                 DocId = r.rf.DocId,
                                 Rtt = r.rf.Rtt,
                                 UserName = u.UserName + u.FullName
                             }
                 )
                 .GroupBy(x => x.DocId)
                 .ToDictionary(x => x.Key,
                               x => x);

            

            //關卡:申醫工主管的案件
            var flowMgr = _context.BMEDRepairFlows
                .Join(result,
                      r => r.DocId,
                      t => t.repair.DocId,
                      (r, t) => new { rf = r, rt = t }
                      )
                .OrderByDescending(r => r.rf.StepId)
                .Where(r => r.rf.Cls.Contains("醫工主管"));


            //目前最後關卡人員名稱與異動時間
            var flowMgruf = flowMgr.Join(_context.AppUsers,
                             r => r.rf.UserId,
                             u => u.Id,
                             (r, u) => new {
                                 DocId = r.rf.DocId,
                                 Rtt = r.rf.Rtt,
                                 UserName = u.UserName + u.FullName
                                 
                             }
                 )
                 .GroupBy(x => x.DocId)
                 .ToDictionary(x => x.Key,
                               x => x);

           

           

            foreach (var item in result)
            {
                ScrapAsset s = new ScrapAsset();
                s.Loc = item.repair.Loc;
                s.DocId = item.repair.DocId;
                s.ApplyDate = item.repair.ApplyDate;
                s.DptId = item.repair.DptId;
                dpt = _context.Departments.Find(item.repair.DptId);
                s.DptName = dpt == null ? "" : dpt.Name_C;
                s.AccDpt = item.repair.AccDpt;
                dpt = _context.Departments.Find(item.repair.AccDpt);
                s.AccDptName = dpt == null ? "" : dpt.Name_C;
                usr = _context.AppUsers.Find(item.repair.UserId);
                s.UserName = usr == null ? "" : usr.UserName;
                s.UserFullName = usr == null ? "" : usr.FullName;
                s.Amt = item.repair.Amt;
                s.AssetType = "列管";
                s.AssetNo = item.repair.AssetNo;
                s.AssetName = item.repair.AssetName;
                s.TroubleDes = item.repair.TroubleDes;
                s.DealState = "報廢";
                s.DealDes = item.dtl.DealDes;
                s.EndDate = item.dtl.EndDate;
                usr = _context.AppUsers.Find(item.repair.EngId);
                s.EngName = usr == null ? "" : usr.UserName + usr.FullName;
                s.Hour = item.dtl.Hour;
                s.RepType = "維修";
                s.CloseDate = item.dtl.CloseDate;
                s.CloseTicketDate = null;
                s.FlowDptAcceptTime = null;
                s.MedMgrAcceptTime = null;
                //rf = _context.BMEDRepairFlows.Where(r => r.DocId == item.repair.DocId).OrderBy(r => r.StepId)
                //                             .Where(r => r.Cls.Contains("申請人") || r.Cls.Contains("驗收人") || r.Cls.Contains("單位主管")).LastOrDefault();
                //usr = rf == null ? null : _context.AppUsers.Find(rf.Rtp);
                //s.FlowDptUser = usr == null ? "" : usr.UserName + usr.FullName;
                s.FlowDptUser = flowuf.ContainsKey(item.repair.DocId) == false ? "" :  flowuf[item.repair.DocId].Select(x => x.UserName).FirstOrDefault();

                //if (rf != null)
                //{
                //    s.FlowDptAcceptTime = rf.Rtt;
                //}
                if (flowuf.ContainsKey(item.repair.DocId) != false)
                {
                   s.FlowDptAcceptTime = flowuf[item.repair.DocId].Select(x => x.Rtt).FirstOrDefault();
                }      
                //rf = _context.BMEDRepairFlows.Where(r => r.DocId == item.repair.DocId)
                //                             .Where(r => r.Cls.Contains("醫工主管")).LastOrDefault();
                //usr = rf == null ? null : _context.AppUsers.Find(rf.Rtp);
                //s.MedMgr = usr == null ? "" : usr.UserName + usr.FullName;
                s.MedMgr = flowMgruf.ContainsKey(item.repair.DocId) == false ? "" : flowMgruf[item.repair.DocId].Select(x => x.UserName).FirstOrDefault();

                //if (rf != null)
                //{
                //    s.MedMgrAcceptTime = rf.Rtt;
                //}
                if(flowMgruf.ContainsKey(item.repair.DocId) != false)
                { 
                     s.MedMgrAcceptTime = flowMgruf[item.repair.DocId].Select(x => x.Rtt).FirstOrDefault();
                }
                sa.Add(s);
            }
            return sa;
        }
        //
        public IActionResult ExcelScrapAssetList(ReportQryVModel v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("表單編號");
            dt.Columns.Add("送單日期");
            dt.Columns.Add("申請部門");
            dt.Columns.Add("申請部門名稱");
            dt.Columns.Add("成本中心");
            dt.Columns.Add("成本中心名稱");
            dt.Columns.Add("申請人");
            dt.Columns.Add("申請人姓名");
            dt.Columns.Add("數量");
            dt.Columns.Add("財產類別");
            dt.Columns.Add("財產編號");
            dt.Columns.Add("財產名稱");
            dt.Columns.Add("故障情形");
            dt.Columns.Add("處理狀況");
            dt.Columns.Add("處理描述");
            dt.Columns.Add("完工日期");
            dt.Columns.Add("工程師");
            dt.Columns.Add("維修工時");
            dt.Columns.Add("維修別");
            dt.Columns.Add("完帳日/結案日");
            dt.Columns.Add("關帳日");
            dt.Columns.Add("使用單位");
            dt.Columns.Add("使用單位同意時間");
            dt.Columns.Add("醫工主管");
            dt.Columns.Add("醫工主管同意時間");

            List<ScrapAsset> mv = ScrapAsset(v);
            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.DocId;
                dw[1] = m.ApplyDate;
                dw[2] = m.DptId;
                dw[3] = m.DptName;
                dw[4] = m.AccDpt;
                dw[5] = m.AccDptName;
                dw[6] = m.UserName;
                dw[7] = m.UserFullName;
                dw[8] = m.Amt;
                dw[9] = m.AssetType;
                dw[10] = m.AssetNo;
                dw[11] = m.AssetName;
                dw[12] = m.TroubleDes;
                dw[13] = m.DealState;
                dw[14] = m.DealDes;
                dw[15] = m.EndDate;
                dw[16] = m.EngName;
                dw[17] = m.Hour;
                dw[18] = m.RepType;
                dw[19] = m.CloseDate;
                dw[20] = m.CloseTicketDate;
                dw[21] = m.FlowDptUser;
                dw[22] = m.FlowDptAcceptTime;
                dw[23] = m.MedMgr;
                dw[24] = m.MedMgrAcceptTime;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("列管報廢清單");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "ExcelScrapAssetList.xlsx"
            );
        }

        private IPagedList<ProperRate> AssetProperRate(ReportQryVModel v, int page = 1)
        {
            var urLocation = v.Location;
            //
            TempData["qry"] = JsonConvert.SerializeObject(v);
            var days = v.Edate.Value.Subtract(v.Sdate.Value).TotalDays;
            //double faildays = 0;
            //double dd = 0;
            // int cnt = 0;
            List<ProperRate> sv = new List<ProperRate>();
            ProperRate pr;
            //依照院區區分設備
            var bmedAssets = GetAssetsByLoc(urLocation);
            //
            var test = _context.BMEDRepairs
                     .Where(r => r.ApplyDate >= v.Sdate && r.ApplyDate <= v.Edate)
                     .Join(_context.BMEDRepairDtls.Where(d => d.EndDate != null),
                             r => r.DocId,
                             d => d.DocId,
                             (r, d) => new { repair = r, d.EndDate }
                          );

            var cnt = test
                .Select(x => new { AssetNo = x.repair.AssetNo,
                                   AccDpt = x.repair.AccDpt })
                .ToList()
                .GroupBy(x => x.AssetNo)
                .ToDictionary(x => x.Key, x => x.Count());



            var assets = bmedAssets
             .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
             .Where(a => a.DisposeKind == "正常")
             .GroupJoin( test, 
                         d => d.AssetNo,
                         b => b.repair.AssetNo,
                         (assetD, repairA) => new { assetD = assetD, repairA = repairA }
                         )
             .GroupJoin(_context.Departments, 
                         d => d.assetD.AccDpt, 
                         b => b.DptId,
                         (assetM, depart) => new { assetM = assetM, depart = depart }
                         )
             .SelectMany(x => x.depart.DefaultIfEmpty(), 
                              (o, g) => new { assetM = o.assetM.assetD ,depart = g})
             .ToList();

           

         //var t = assets
         //   .GroupJoin(test, d => d._assetM.AssetNo, b => b.repair.AssetNo,
         //   (assetD, repairA) => new { assetD = assetD, repairA = repairA })
         //    .SelectMany(x => x.repairA.DefaultIfEmpty(), (o, g) =>
         //             new { _assetD = o.assetD, _repairA = g })
         //   .ToList();
               //.ForEach(r =>
               //     {
               //         if (r.assetD.EndDate.Value.CompareTo(v.Edate.Value) > 0)
               //         {
               //             faildays += v.Edate.Value.Subtract(r.assetD.repair.ApplyDate).TotalDays;
               //         }
               //         else
               //         {
               //             dd = r.assetD.EndDate.Value.Subtract(r.assetD.repair.ApplyDate).TotalDays;
               //             if (dd > 0)
               //             {
               //                 if (dd <= 1d)
               //                     faildays += 1d;
               //                 else
               //                     faildays += dd;
               //             }
               //         }
               //         cnt++;
               //     });




            //
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                assets = assets.Where(a => a.assetM.AccDpt == v.AccDpt).ToList();
            }
            if (!string.IsNullOrEmpty(v.AssetNo))
            {
                assets = assets.Where(a => a.assetM.AssetNo == v.AssetNo).ToList();
            }

            //var failday = assets
            //    .Select(x => new { eday = x._assetM.repairA.Where(r => r.EndDate != null).Select(re => re.EndDate),
            //                       aday = x._assetM.repairA.Select(re => re.repair.ApplyDate),
            //                       AssetNo = x._assetM.assetD.AssetNo
            //                     }
            //    )
            //    .ToList();

            var failday = test
                .Where(t => t.EndDate != null)
                .Select(x => new {
                    AssetNo = x.repair.AssetNo,
                    fday = x.EndDate.Value.Subtract(x.repair.ApplyDate).TotalDays,
                    })
                .ToList()
                .GroupBy(x => x.AssetNo)
                .ToDictionary(x => x.Key, x => x.Select(f => f.fday).Sum());

            foreach (var asset in assets)
            {
                pr = new ProperRate();
                pr.AssetNo = asset.assetM.AssetNo;
                pr.AssetName = asset.assetM.Cname;
                pr.Brand = asset.assetM.Brand;
                pr.Type = asset.assetM.Type;
                pr.AccDpt = asset.assetM.AccDpt;
                //var dpt = _context.Departments.Find(asset.AccDpt);
                pr.AccDptNam = asset.depart == null ? "" : asset.depart.Name_C;
                //faildays = 0;
                //dd = 0;
                //cnt = 0;
                //var de = asset._assetM.repairA.Select(re => re.EndDate).FirstOrDefault();
                //var ra = asset._assetM.repairA.Select(re => re.repair.ApplyDate).FirstOrDefault();
                //_context.BMEDRepairs.Where(r => r.AssetNo == asset._assetM.assetD.AssetNo)
                //    .Where(r => r.ApplyDate >= v.Sdate && r.ApplyDate <= v.Edate)
                //    .Join(_context.BMEDRepairDtls.Where(d => d.EndDate != null), r => r.DocId, d => d.DocId,
                //    (r, d) => new { repair = r, d.EndDate })
                //    .ToList()
                //    .ForEach(r =>
                //    {
                //if (de != null) { 
                //    if (de.Value.CompareTo(v.Edate.Value) > 0)
                //    {
                //        faildays += v.Edate.Value.Subtract(ra).TotalDays;
                //    }
                //    else
                //    {
                //        dd = de.Value.Subtract(ra).TotalDays;
                //        if (dd > 0)
                //        {
                //            if (dd <= 1d)
                //                faildays += 1d;
                //            else
                //                faildays += dd;
                //        }
                //    }
                //    //cnt++;
                //}
                //    });

                pr.RepairCnts = cnt.ContainsKey(pr.AssetNo) == false ? 0 : cnt[pr.AssetNo];
                pr.RepairDays = failday.ContainsKey(pr.AssetNo) == false ? 0 : failday[pr.AssetNo];
                pr.AssetProperRate = decimal.Round(100m -
                        Convert.ToDecimal(pr.RepairDays / days) * 100m, 2);
                sv.Add(pr);
            }

            
            //
            var pageCount = sv.ToPagedList(page, pageSize).PageCount;
            pageCount = pageCount == 0 ? 1 : pageCount; // If no page.
            if (sv.ToPagedList(page, pageSize).Count <= 0)  //If the page has no items.
                return sv.ToPagedList(pageCount, pageSize);
            return sv.ToPagedList(page, pageSize);

            //return sv;
        }

        private List<ProperRate> AssetProperRateAll(ReportQryVModel v)
        {
           var urLocation = v.Location;
            //
            TempData["qry"] = JsonConvert.SerializeObject(v);
            var days = v.Edate.Value.Subtract(v.Sdate.Value).TotalDays;
            //double faildays = 0;
            //double dd = 0;
            //int cnt = 0;
            DateTime ago = new DateTime();
            List<ProperRate> sv = new List<ProperRate>();
            ProperRate pr;
            //依照院區區分設備
            var bmedAssets = GetAssetsByLoc(urLocation);
            //
            var test = _context.BMEDRepairs.Where(r => r.ApplyDate >= v.Sdate && r.ApplyDate <= v.Edate)
                     .Join(_context.BMEDRepairDtls.Where(d => d.EndDate != null), r => r.DocId, d => d.DocId,
                     (r, d) => new { repair = r, d.EndDate }).ToList();

            var cnt = test
               .GroupBy(x => x.repair.AssetNo)
               .ToDictionary(x => x.Key, x => x.Count());

            var failday = test
               .Where(t => t.EndDate != null)
               .Select(x => new {
                   AssetNo = x.repair.AssetNo,
                   fday = x.EndDate.Value.Subtract(x.repair.ApplyDate).TotalDays,
               })
               .ToList()
               .GroupBy(x => x.AssetNo)
               .ToDictionary(x => x.Key, x => x.Select(f => f.fday).Sum());

            var assets = bmedAssets
             .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
             .Where(a => a.DisposeKind == "正常")
             .GroupJoin(test, d => d.AssetNo, b => b.repair.AssetNo,
             (assetD, repairA) => new { assetD = assetD, repairA = repairA })
             .ToList()
             .GroupJoin(_context.Departments, d => d.assetD.AccDpt, b => b.DptId,
             (assetM, depart) => new { assetM = assetM, depart = depart })
             .SelectMany(x => x.depart.DefaultIfEmpty(), (o, g) =>
                      new { _assetM = o.assetM, _depart = g })
             .ToList();


            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                assets = assets.Where(a => a._assetM.assetD.AccDpt == v.AccDpt).ToList();
            }
            if (!string.IsNullOrEmpty(v.AssetNo))
            {
                assets = assets.Where(a => a._assetM.assetD.AssetNo == v.AssetNo)
                    .ToList();
            }

            foreach (var asset in assets)
            {

                pr = new ProperRate();
                pr.AssetNo = asset._assetM.assetD.AssetNo;
                pr.AssetName = asset._assetM.assetD.Cname;
                pr.Brand = asset._assetM.assetD.Brand;
                pr.Type = asset._assetM.assetD.Type;
                pr.AccDpt = asset._assetM.assetD.AccDpt;
                pr.AccDptNam = asset._depart == null ? "" : asset._depart.Name_C;
                pr.RepairCnts = cnt.ContainsKey(pr.AssetNo) == false ? 0 :cnt[pr.AssetNo];
                pr.RepairDays = failday.ContainsKey(pr.AssetNo) == false ? 0 : failday[pr.AssetNo];
                pr.AssetProperRate = decimal.Round(100m -
                        Convert.ToDecimal(pr.RepairDays / days) * 100m, 2);
                pr.DisposeKind = asset._assetM.assetD.DisposeKindC;
                //if (!String.IsNullOrEmpty(asset._assetM.assetD.AccDate.))
                //{

                //}
                //ago = 
                if (!string.IsNullOrEmpty(asset._assetM.assetD.AccDate.ToString()))
                    pr.AircraftY = (DateTime.Now.Year - asset._assetM.assetD.AccDate.Value.Year).ToString();
                else
                    pr.AircraftY = "";
                sv.Add(pr);
            }
            return sv;
        }

        public IActionResult ExcelAssetKeepList(ReportQryVModel v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("財產編號");
            dt.Columns.Add("儀器名稱");
            dt.Columns.Add("廠牌");
            dt.Columns.Add("規格");
            dt.Columns.Add("型號");
            dt.Columns.Add("保養方式");
            dt.Columns.Add("成本中心名稱");
            dt.Columns.Add("存放地點");
            dt.Columns.Add("起始年月");
            dt.Columns.Add("週期");
            dt.Columns.Add("工程師");
            dt.Columns.Add("保固起始日");
            dt.Columns.Add("保固終止日");
            dt.Columns.Add("合約起始日");
            dt.Columns.Add("合約終止日");
            dt.Columns.Add("備註");

            List<AssetKeepListVModel> mv = AssetKeepList(v);
            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.AssetNo;
                dw[1] = m.AssetName;
                dw[2] = m.Brand;
                dw[3] = m.Standard;
                dw[4] = m.Type;
                dw[5] = m.InOut;
                dw[6] = m.AccDptName;
                dw[7] = m.LeaveSite;
                dw[8] = m.YYYMM;
                dw[9] = m.Cycle;
                dw[10] = m.EngName;
                dw[11] = m.WartySt;
                dw[12] = m.WartyEd;
                dw[13] = m.Sdate;
                dw[14] = m.Edate;
                dw[15] = m.Note;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("儀器設備保養清單");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "AssetKeepList.xlsx"
            );
        }
        public List<AssetKeepListVModel> AssetKeepList(ReportQryVModel v)
        {
            var urLocation = v.Location;
            //
            TempData["qry2"] = JsonConvert.SerializeObject(v);
            List<AssetKeepListVModel> lst = new List<AssetKeepListVModel>();
            var data = _context.BMEDAssets.Join(_context.BMEDAssetKeeps, at => at.AssetNo, k => k.AssetNo,
                (at, k) => new
                {
                    asset = at,
                    assetkeep = k
                }).Join(_context.Departments, at => at.asset.AccDpt, d => d.DptId,
                (at, d) => new {
                    asset = at.asset,
                    assetkeep = at.assetkeep,
                    dept = d
                }).Join(_context.Departments, at => at.asset.DelivDpt, d => d.DptId,
                (at, d) => new {
                    asset = at.asset,
                    assetkeep = at.assetkeep,
                    dept = d,
                    delivDpt = d
                });
            if (urLocation == "總院")
            {
                data = data.Where(r => r.dept.Loc == "C" || r.dept.Loc == "P" || r.dept.Loc == "K");
            }
            else
            {
                data = data.Where(r => r.dept.Loc == urLocation);
            }
            data = data.Where(r => r.asset.AssetClass == (v.AssetClass1 ?? v.AssetClass2));
            string acc = v.AccDpt;
            string deliv = v.DelivDpt;
            string ano = v.AssetNo;
            string aname = v.AssetName;
            int? keepYm = v.KeepYm;

            int engid;
            if (!string.IsNullOrEmpty(acc))
            {
                data = data.Where(x => x.asset.AccDpt == acc);
            }
            if (!string.IsNullOrEmpty(deliv))   //保管部門
            {
                data = data.Where(x => x.asset.DelivDpt == deliv);
            }    
            if (!string.IsNullOrEmpty(ano)) //財產編號
                data = data.Where(x => x.asset.AssetNo == ano);
            if (!string.IsNullOrEmpty(aname)) //財產名稱關鍵字
                data = data.Where(x => x.asset.Cname.Contains(aname));
            if (!string.IsNullOrEmpty(v.EngId))
            {
                engid = Convert.ToInt32(v.EngId);
                data = data.Where(x => x.assetkeep.KeepEngId == engid);
            }
            if (keepYm != null)
            {
                data = data.Where(x => x.assetkeep.KeepYm == keepYm);
            }
            AssetKeepListVModel ak;
            foreach (var item in data.ToList())
            {
                ak = new AssetKeepListVModel();
                ak.AssetNo = item.asset.AssetNo;
                ak.AssetName = item.asset.Cname;
                ak.Brand = item.asset.Brand;
                ak.Standard = item.asset.Standard;
                ak.Type = item.asset.Type;
                ak.InOut = item.assetkeep.InOut;
                ak.AccDptName = "(" + item.dept.DptId + ")" + item.dept.Name_C;
                ak.DelivDptName = "(" + item.delivDpt.DptId + ")" + item.delivDpt.Name_C;
                ak.LeaveSite = item.asset.LeaveSite;
                ak.YYYMM = item.assetkeep.KeepYm;
                ak.Cycle = item.assetkeep.Cycle;
                ak.EngName = item.assetkeep.KeepEngName;
                //ak.WartySt = item.asset.WartySt;
                //ak.WartyEd = item.asset.WartyEd;
                //ak.Sdate = item.contract == null ? "" : item.contract.Sdate.ToString("yyyy/MM/dd");
                //ak.Edate = item.contract == null ? "" : item.contract.Edate.ToString("yyyy/MM/dd");
                ak.Note = item.asset.Note;
                lst.Add(ak);
            }
            return lst;
        }

        public List<AssetKeepListVModel> GetAssetKeepList()
        {
            AssetKeepListVModel a;
            List<AssetKeepListVModel> lst = new List<AssetKeepListVModel>();
            _context.BMEDAssets.Join(_context.BMEDAssetKeeps, at => at.AssetNo, k => k.AssetNo,
                (at, k) => new
                {
                    asset = at,
                    assetkeep = k
                }).Join(_context.Departments, at => at.asset.AccDpt, d => d.DptId,
                (at, d) => new {
                    asset = at.asset,
                    assetkeep = at.assetkeep,
                    dept = d
                })
                //.GroupJoin(_context.Contracts, at => at.assetkeep.ContractNo, c => c.ContractNo,
                //(at, c) => new
                //{
                //    at.asset,
                //    at.assetkeep,
                //    at.dept,
                //    contract = c
                //}).SelectMany(c => c.contract.DefaultIfEmpty(),
                //(x, y) => new
                //{
                //    x.asset,
                //    x.assetkeep,
                //    x.dept,
                //    contract = y
                //})
                .ToList().ForEach(x =>
                {
                    a = new AssetKeepListVModel();
                    a.AssetNo = x.asset.AssetNo;
                    a.AssetName = x.asset.Cname;
                    a.Brand = x.asset.Brand;
                    a.Standard = x.asset.Standard;
                    a.Type = x.asset.Type;
                    a.InOut = x.assetkeep.InOut;
                    a.AccDptName = x.dept.Name_C;
                    a.LeaveSite = x.asset.LeaveSite;
                    //a.WartySt = x.asset.WartySt;
                    //a.WartyEd = x.asset.WartyEd;
                    //a.Sdate = x.contract == null ? "" : x.contract.Sdate.ToString("yyyy/MM/dd");
                    //a.Edate = x.contract == null ? "" : x.contract.Edate.ToString("yyyy/MM/dd");
                    a.Note = x.asset.Note;
                    lst.Add(a);
                });

            return lst;
        }

        //private List<QuestReport> QuestAnaly(ReportQryVModel v)
        //{
        //    List<QuestReport> qlist = new List<QuestReport>();
        //    QuestReport qr;
        //    List<QuestMain> qm = _context.QuestMains.ToList();
        //    if (v.Sdate != null)
        //        qm = qm.Where(s => s.Rtt >= v.Sdate).ToList();
        //    if (v.Edate != null)
        //        qm = qm.Where(s => s.Rtt <= v.Edate).ToList();
        //    qm.ForEach(m =>
        //    {
        //        qr = new QuestReport();
        //        qr.Docid = m.Docid;
        //        qr.TimeStamp = m.Rtt.ToString("yyyy/MM/dd");
        //        qr.ContractNo = m.ContractNo;
        //        qr.Contract = "";
        //        qr.DptId = m.CustId;
        //        qr.DptName = m.CustNam;
        //        qr.Answers = _context.QuestAnswers.Where(a => a.Docid == m.Docid)
        //                     .OrderBy(a => a.Qid).ToList();
        //        if (qr.Answers.Count > 0)
        //            qlist.Add(qr);
        //    });
        //    return qlist;
        //}

        public IActionResult Index2(string rpname)
        {
            ReportQryVModel pv = new ReportQryVModel();
            pv.ReportClass = rpname;

            List<SelectListItem> listItem2 = new List<SelectListItem>();
            listItem2.Add(new SelectListItem { Text = "請選擇", Value = "" });
            listItem2.Add(new SelectListItem { Text = "總院", Value = "總院" });
            listItem2.Add(new SelectListItem { Text = "二林", Value = "L" });
            listItem2.Add(new SelectListItem { Text = "員林", Value = "B" });
            listItem2.Add(new SelectListItem { Text = "南投", Value = "N" });
            listItem2.Add(new SelectListItem { Text = "鹿基", Value = "U" });
            listItem2.Add(new SelectListItem { Text = "雲基", Value = "T" });
            ViewData["Location"] = new SelectList(listItem2, "Value", "Text");

            return View(pv);
        }
        public IActionResult Index3(string rpname)
        {
            ReportQryVModel pv = new ReportQryVModel();
            pv.ReportClass = rpname;
            List<SelectListItem> listItem = new List<SelectListItem>();
            List<SelectListItem> listItem2 = new List<SelectListItem>();
            List<SelectListItem> listItem3 = new List<SelectListItem>();

            SelectListItem li;
            /* 處理工程師查詢的下拉選單 */
            var engs = roleManager.GetUsersInRole("MedEngineer").ToList();
            foreach (string l in engs)
            {
                var u = _context.AppUsers.Where(ur => ur.UserName == l).FirstOrDefault();
                if (u != null)
                {
                    listItem.Add(new SelectListItem
                    {
                        Text = u.FullName + "(" + u.UserName + ")",
                        Value = u.Id.ToString()
                    });
                }
            }
            ViewData["BMEDEngs"] = new SelectList(listItem, "Value", "Text");
            //
            _context.Departments.ToList()
                .ForEach(d =>
                {
                    li = new SelectListItem();
                    li.Text = d.Name_C;
                    li.Value = d.DptId;
                    listItem2.Add(li);

                });
            ViewData["ACCDPT"] = new SelectList(listItem2, "Value", "Text");
            ViewData["DELIVDPT"] = new SelectList(listItem2, "Value", "Text");
            
            listItem3.Add(new SelectListItem { Text = "請選擇", Value = "" });
            listItem3.Add(new SelectListItem { Text = "總院", Value = "總院" });
            listItem3.Add(new SelectListItem { Text = "二林", Value = "L" });
            listItem3.Add(new SelectListItem { Text = "員林", Value = "B" });
            listItem3.Add(new SelectListItem { Text = "南投", Value = "N" });
            listItem3.Add(new SelectListItem { Text = "鹿基", Value = "U" });
            listItem3.Add(new SelectListItem { Text = "雲基", Value = "T" });
            ViewData["Location"] = new SelectList(listItem3, "Value", "Text");

            return View(pv);
        }
        [HttpPost]
        public IActionResult Index3(ReportQryVModel v ,int page = 1 )
        {
            TempData["qry2"] = v;
            /* Get login user. */
            var usr = _userRepo.Find(u => u.UserName == this.User.Identity.Name).FirstOrDefault();

            /* Get login user's location. */
            var loc = new DepartmentModel(_context).GetUserLocation(usr);

            if (!string.IsNullOrEmpty(v.Location))
            {
                // Admin & 設備主管才可查詢全單位，其餘Role只可查詢自己單位
                if (userManager.IsInRole(User, "Admin") || userManager.IsInRole(User, "MedMgr")
                    || userManager.IsInRole(User, "MedAssetMgr"))
                {
                    // Do nothing.
                }
                else
                {
                    v.Location = loc;
                }
            }
            else
            {
                v.Location = loc;
            }
            switch (v.ReportClass)
            {
                case "儀器設備保養清單":
                    return PartialView("AssetKeepList", AssetKeepList(v));
                case "設備保養排程年報":
                    if (string.IsNullOrEmpty(v.KeepY.ToString()))
                    {
                        v.KeepY = DateTime.Now.Year ;
                    }
                    return PartialView("AssetKpSche", AssetKpSche(v).ToPagedList(page, pageSize));

            }
            return View();
        }
        public IActionResult ExcelRpKpHistory(ReportQryVModel v)
        {
            //
            ExcelPackage excel = new ExcelPackage();
            var sheet1 = excel.Workbook.Worksheets.Add("儀器基本資料");
            //Sheet1
            AssetModel asset = _context.BMEDAssets.Find(v.AssetNo);
            if (asset != null)
            {
                asset.DelivDptName = _context.Departments.Find(asset.DelivDpt).Name_C;
                asset.AccDptName = _context.Departments.Find(asset.AccDpt).Name_C;
            }
            sheet1.Cells[1, 1].Value = "儀器基本資料";
            sheet1.Cells[1, 2].Value = "財產編號";
            sheet1.Cells[2, 2].Value = asset.AssetNo;
            sheet1.Cells[1, 3].Value = "成本中心";
            sheet1.Cells[2, 3].Value = asset.AccDptName;
            sheet1.Cells[1, 4].Value = "廠牌";
            sheet1.Cells[2, 4].Value = asset.Brand;
            sheet1.Cells[1, 5].Value = "型號";
            sheet1.Cells[2, 5].Value = asset.Type;
            sheet1.Cells[1, 6].Value = "中文名稱";
            sheet1.Cells[2, 6].Value = asset.Cname;
            sheet1.Cells[1, 7].Value = "取得金額";
            sheet1.Cells[2, 7].Value = asset.Cost;
            sheet1.Cells[1, 8].Value = "取得日期";
            sheet1.Cells[2, 8].Value = asset.BuyDate == null ? "" : asset.BuyDate.Value.ToString("yyyy/MM/dd"); ;
            //sheet1.Cells[1, 9].Value = "耐用年限";
            //sheet1.Cells[2, 9].Value = asset.UseLife == null ? "" : asset.UseLife.Value.ToString();
            //sheet2
            var sheet2 = excel.Workbook.Worksheets.Add("維修保養履歷");
            List<RpKpHistoryVModel> sv = new List<RpKpHistoryVModel>();
            List<RpKpHistoryVModel> sv2 = new List<RpKpHistoryVModel>();
            var ss = new[] { "?", "2" };
            sv = _context.BMEDAssets.Where(a => a.AssetNo == v.AssetNo)
                .Join(_context.BMEDRepairs, a => a.AssetNo, r => r.AssetNo,
                (a, r) => new
                {
                    DocType = "請修",
                    DocId = r.DocId,
                    AssetNo = a.AssetNo,
                    AssetName = a.Cname,
                    ApplyDate = r.ApplyDate,
                    TroubleDes = r.TroubleDes
                }).Join(_context.BMEDRepairFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                    (r, f) => r).Join(_context.BMEDRepairDtls, r => r.DocId, d => d.DocId,
                (r, d) => new
                {
                    DocType = "請修",
                    DocId = r.DocId,
                    AssetNo = r.AssetNo,
                    AssetName = r.AssetName,
                    ApplyDate = r.ApplyDate,
                    TroubleDes = r.TroubleDes,
                    DealDes = d.DealDes,
                    EndDate = d.EndDate,
                    Hours = d.Hour,
                    Cost = d.Cost
                }).Join(_context.BMEDRepairEmps.Join(_context.AppUsers, r => r.UserId, a => a.Id,
                (r, a) => new
                {
                    DocId = r.DocId,
                    UserName = a.FullName
                }), d => d.DocId, e => e.DocId,
                (d, e) => new RpKpHistoryVModel
                {
                    DocType = "請修",
                    DocId = d.DocId,
                    AssetNo = d.AssetNo,
                    AssetName = d.AssetName,
                    ApplyDate = d.ApplyDate,
                    TroubleDes = d.TroubleDes,
                    DealDes = d.DealDes,
                    EndDate = d.EndDate,
                    Hours = d.Hours,
                    Cost = d.Cost,
                    EngName = e.UserName
                }).ToList();
            //
            sv2 = _context.BMEDAssets.Where(a => a.AssetNo == v.AssetNo)
                .Join(_context.BMEDKeeps, a => a.AssetNo, r => r.AssetNo,
                (a, r) => new
                {
                    DocType = "保養",
                    DocId = r.DocId,
                    AssetNo = a.AssetNo,
                    AssetName = a.Cname,
                    ApplyDate = r.SentDate,
                    TroubleDes = ""
                }).Join(_context.BMEDKeepFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                    (r, f) => r).Join(_context.BMEDKeepDtls, r => r.DocId, d => d.DocId,
                (r, d) => new
                {
                    DocType = r.DocType,
                    DocId = r.DocId,
                    AssetNo = r.AssetNo,
                    AssetName = r.AssetName,
                    ApplyDate = r.ApplyDate,
                    TroubleDes = r.TroubleDes,
                    DealDes = d.Memo,
                    EndDate = d.EndDate,
                    Hours = d.Hours,
                    Cost = d.Cost
                })
                //.GroupJoin(_context.BMEDKeepResults,
                //        r => r.DealDes.ToString(),
                //        d => d.Id.ToString(),
                //         (r, d) => new { keep = r, deal = d }
                // )
                // .SelectMany(x => x.deal.DefaultIfEmpty(),
                //    (r, d) => new
                //    {
                //        DocType = "保養",
                //        DocId = r.keep.DocId,
                //        AssetNo = r.keep.AssetNo,
                //        AssetName = r.keep.AssetName,
                //        ApplyDate = r.keep.ApplyDate,
                //        TroubleDes = "",
                //        DealDes = d == null ? "" : d.Title,
                //        EndDate = r.keep.EndDate,
                //        Hours = r.keep.Hours,
                //        Cost = r.keep.Cost
                //    }
                //)
                .Join(_context.BMEDKeepEmps.Join(_context.AppUsers, r => r.UserId, a => a.Id,
                (r, a) => new
                {
                    DocId = r.DocId,
                    UserName = a.FullName
                }), d => d.DocId, e => e.DocId,
                (d, e) => new RpKpHistoryVModel
                {
                    DocType = d.DocType,
                    DocId = d.DocId,
                    AssetNo = d.AssetNo,
                    AssetName = d.AssetName,
                    ApplyDate = d.ApplyDate.Value,
                    TroubleDes = d.TroubleDes,
                    DealDes = Convert.ToString(d.DealDes),
                    EndDate = d.EndDate,
                    Hours = d.Hours,
                    Cost = d.Cost,
                    EngName = e.UserName
                }).ToList();

            sv.AddRange(sv2);

            if (v.Sdate != null)
                sv = sv.Where(s => s.ApplyDate >= v.Sdate).ToList();
            if (v.Edate != null)
                sv = sv.Where(s => s.ApplyDate <= v.Edate).ToList();
            //Title
            //sheet2.Cells[1, 1].Value = "表單類別";
            //sheet2.Cells[1, 2].Value = "表單編號";
            //sheet2.Cells[1, 3].Value = "送單日期";
            //sheet2.Cells[1, 4].Value = "完工日期";
            //sheet2.Cells[1, 5].Value = "工程師";
            //sheet2.Cells[1, 6].Value = "工時";
            //sheet2.Cells[1, 7].Value = "費用";
            //sheet2.Cells[1, 8].Value = "故障原因";
            //sheet2.Cells[1, 9].Value = "處理情形";
            //

            sheet2.Cells[1, 1].Value = "表單類別";
            sheet2.Cells[1, 2].Value = "表單編號";
            sheet2.Cells[1, 3].Value = "財產編號";
            sheet2.Cells[1, 4].Value = "設備名稱";
            sheet2.Cells[1, 5].Value = "送單日期";
            sheet2.Cells[1, 6].Value = "完工日期";
            sheet2.Cells[1, 7].Value = "工程師";
            sheet2.Cells[1, 8].Value = "維修時數";
            sheet2.Cells[1, 9].Value = "維修金額";
            sheet2.Cells[1, 10].Value = "故障狀態";
            sheet2.Cells[1, 11].Value = "處理情形";
            //Data
            int startPos = 2;
            foreach(var item in sv)
            {
                sheet2.Cells[startPos, 1].Value = item.DocType;
                sheet2.Cells[startPos, 2].Value = item.DocId;
                sheet2.Cells[startPos, 3].Value = item.AssetNo;
                sheet2.Cells[startPos, 4].Value = item.AssetName;
                sheet2.Cells[startPos, 5].Value = item.ApplyDate.ToString("yyyy/MM/dd");
                sheet2.Cells[startPos, 6].Value = item.EndDate.Value.ToString("yyyy/MM/dd");
                sheet2.Cells[startPos, 7].Value = item.EngName;
                sheet2.Cells[startPos, 8].Value = item.Hours;
                sheet2.Cells[startPos, 9].Value = item.Cost;
                sheet2.Cells[startPos, 10].Value = item.TroubleDes;
                sheet2.Cells[startPos, 11].Value = item.DealDes;
                startPos++;
            }
            //sheet3
            if (v.Edate == null)
            {
                if (v.Sdate == null)
                {
                    v.Sdate = DateTime.Now.AddYears(-1);
                }
                v.Edate = DateTime.Now.AddHours(23)
                .AddMinutes(59)
                .AddSeconds(59);
            }

            List<RpKpHistoryVModel> rk = RpKpHistory(v);
            AssetAnalysis ay = new AssetAnalysis();
            ay.RepairHour = rk.Where(r => r.DocType == "請修").Select(r => r.Hours).Sum().Value;
            ay.RepCost = rk.Where(r => r.DocType == "請修").Select(r => r.Cost).Sum().Value;
            ay.KeepHour = rk.Where(r => r.DocType == "保養").Select(r => r.Hours).Sum().Value;
            ay.KeepCost = rk.Where(r => r.DocType == "保養").Select(r => r.Cost).Sum().Value;
            AssetModel at = _context.BMEDAssets.Find(v.AssetNo);
            if (at != null)
            {
                if (at.Cost != null)
                {
                    if (at.Cost > 0)
                        ay.RepRatio = decimal.Round(ay.RepCost / at.Cost.Value * 100m, 2);
                    else
                        ay.RepRatio = 0;
                }
            }
            double faildays = 0;
            double day = 0;
            rk.Where(r => r.DocType == "請修").ToList()
                .ForEach(r =>
                {
                    if (r.EndDate == null)
                    {
                        faildays += v.Edate.Value.Subtract(r.ApplyDate).TotalDays;
                    }
                    else if (r.EndDate.Value.CompareTo(v.Edate.Value) > 0)
                    {
                        faildays += v.Edate.Value.Subtract(r.ApplyDate).TotalDays;
                    }
                    else
                    {
                        day = r.EndDate.Value.Subtract(r.ApplyDate).TotalDays;
                        if (day > 0)
                        {
                            if (day <= 1d)
                                faildays += 1d;
                            else
                                faildays += day;
                        }
                    }
                });
            ay.ProperRate = decimal.Round(100m -
                Convert.ToDecimal(faildays / v.Edate.Value.Subtract(v.Sdate.Value).TotalDays) * 100m, 2);
            //
            var sheet3 = excel.Workbook.Worksheets.Add("總計");
            sheet3.Cells[1, 1].Value = "總計";
            sheet3.Cells[1, 2].Value = "維修時數";
            sheet3.Cells[2, 2].Value = ay.RepairHour;
            sheet3.Cells[1, 3].Value = "保養時數";
            sheet3.Cells[2, 3].Value = ay.KeepHour;
            sheet3.Cells[1, 4].Value = "維修金額";
            sheet3.Cells[2, 4].Value = ay.RepCost;
            sheet3.Cells[1, 5].Value = "保養金額";
            sheet3.Cells[2, 5].Value = ay.KeepCost;
            sheet3.Cells[1, 6].Value = "妥善率";
            sheet3.Cells[2, 6].Value = ay.ProperRate;
            sheet3.Cells[1, 7].Value = "維修比";
            sheet3.Cells[2, 7].Value = ay.RepRatio;
            sheet3.Cells[3, 1].Value = "備註：維修比 = 維修總金額/取得金額。";

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "RpKpHistory.xlsx"
            );
        }
        private List<RpKpHistoryVModel> RpKpHistory(ReportQryVModel v)
        {
            var urLocation = v.Location;
            TempData["qry"] = JsonConvert.SerializeObject(v);
            List<RpKpHistoryVModel> sv = new List<RpKpHistoryVModel>();
            List<RpKpHistoryVModel> sv2 = new List<RpKpHistoryVModel>();
            if (string.IsNullOrEmpty(v.AssetNo))
                return sv;
            var ss = new[] { "?", "2" };
            //依照院區區分設備
            List<AssetModel> bmedAssets = GetAssetsByLoc(urLocation);
            //

            //維修工程師
            var repairE = _context.BMEDRepairEmps
                        .Join(_context.AppUsers, r => r.UserId, a => a.Id,
                        (r, a) => new
                        {
                            DocId = r.DocId,
                            UserName = "(" + a.UserName + ")" + a.FullName
                        });

            //財編申請單
            var bmedA = _context.BMEDRepairs.Where(a => a.AssetNo == v.AssetNo);

            sv = bmedA
                .Join(_context.BMEDRepairFlows.Where(f => ss.Contains(f.Status))
                        , r => r.DocId
                        , f => f.DocId,
                        (r, f) => r)
                .Join(  _context.BMEDRepairDtls, 
                        r => r.DocId, 
                        d => d.DocId,
                        (r, d) => new
                        {
                          DocType = "請修",
                          DocId = r.DocId,
                          AssetNo = r.AssetNo,
                          AssetName = r.AssetName,
                          ApplyDate = r.ApplyDate,
                          TroubleDes = r.TroubleDes,
                          DealDes = d.DealState,
                          EndDate = d.EndDate,
                          Hours = d.Hour,
                          Cost = d.Cost
                        }
                     )
                .GroupJoin( _context.BMEDDealStatuses,
                        r => r.DealDes,
                        d => d.Id,
                        (r,d) => new { bemd = r, deal = d }
                )
                .SelectMany( x => x.deal.DefaultIfEmpty(),
                    (r,d) => new
                    {
                        DocType = "請修",
                        DocId = r.bemd.DocId,
                        AssetNo = r.bemd.AssetNo,
                        AssetName = r.bemd.AssetName,
                        ApplyDate = r.bemd.ApplyDate,
                        TroubleDes = r.bemd.TroubleDes,
                        DealDes = d == null ? "" : d.Title,
                        EndDate = r.bemd.EndDate,
                        Hours = r.bemd.Hours,
                        Cost = r.bemd.Cost
                    }
                )
                .GroupJoin(  repairE,
                        d => d.DocId, e => e.DocId,
                        (d, e) => new { bemd = d , repaire = e})
                .SelectMany( x => x.repaire.DefaultIfEmpty(),
                            (d, e) => new RpKpHistoryVModel
                            {
                                DocType = "請修",
                                DocId = d.bemd.DocId,
                                AssetNo = d.bemd.AssetNo,
                                AssetName = d.bemd.AssetName,
                                ApplyDate = d.bemd.ApplyDate,
                                TroubleDes = d.bemd.TroubleDes,
                                DealDes = d.bemd.DealDes,
                                EndDate = d.bemd.EndDate,
                                Hours = d.bemd.Hours,
                                Cost = d.bemd.Cost,
                                EngName = e.UserName
                            })
                .OrderBy(s => s.DocId)
                .ToList();

            //保養工程師
            var keepE = _context.BMEDKeepEmps
                        .Join(_context.AppUsers,
                                r => r.UserId,
                                a => a.Id,
                                (r, a) => new
                                {
                                    DocId = r.DocId,
                                    UserName = "(" + a.UserName + ")" + a.FullName
                                }
                             );

            sv2 = _context.BMEDKeeps
                .Where(a => a.AssetNo == v.AssetNo)
                .Join(  _context.BMEDKeepFlows.Where(f => ss.Contains(f.Status)), 
                        r => r.DocId, 
                        f => f.DocId,
                        (r, f) => r)
                .Join(  _context.BMEDKeepDtls, 
                        r => r.DocId, 
                        d => d.DocId,
                        (r, d) => new
                        {
                            DocType = "保養",
                            DocId = r.DocId,
                            AssetNo = r.AssetNo,
                            AssetName = r.AssetName,
                            ApplyDate = r.SentDate,
                            TroubleDes = "",
                            DealDes = d.Result,
                            EndDate = d.EndDate,
                            Hours = d.Hours,
                            Cost = d.Cost
                        }
                 )
                 .GroupJoin( _context.BMEDKeepResults,
                        r => r.DealDes.ToString(),
                        d => d.Id.ToString(),
                         (r, d) => new { keep = r, deal = d }
                 )
                 .SelectMany(x => x.deal.DefaultIfEmpty(),
                    (r, d) => new
                    {
                        DocType = "保養",
                        DocId = r.keep.DocId,
                        AssetNo = r.keep.AssetNo,
                        AssetName = r.keep.AssetName,
                        ApplyDate = r.keep.ApplyDate,
                        TroubleDes = "",
                        DealDes = d == null ? "" : d.Title,
                        EndDate = r.keep.EndDate,
                        Hours = r.keep.Hours,
                        Cost = r.keep.Cost
                    }
                )
                 .GroupJoin(keepE,
                        d => d.DocId, e => e.DocId,
                        (d, e) => new { keep = d, repaire = e })
                 .SelectMany(x => x.repaire.DefaultIfEmpty(),
                            (d, e) => new RpKpHistoryVModel
                            {
                                DocType = d.keep.DocType,
                                DocId = d.keep.DocId,
                                AssetNo = d.keep.AssetNo,
                                AssetName = d.keep.AssetName,
                                ApplyDate = d.keep.ApplyDate.Value,
                                TroubleDes = d.keep.TroubleDes,
                                DealDes = Convert.ToString(d.keep.DealDes),
                                EndDate = d.keep.EndDate,
                                Hours = d.keep.Hours,
                                Cost = d.keep.Cost,
                                EngName = e.UserName
                            })
                .OrderBy(s => s.DocId)
                .ToList();

            sv.AddRange(sv2);

            if (v.Sdate != null)
                sv = sv.Where(s => s.ApplyDate >= v.Sdate).ToList();
            if (v.Edate != null)
                sv = sv.Where(s => s.ApplyDate <= v.Edate).ToList();

            return sv;
        }

        public List<UnSignListVModel> UnSignList(ReportQryVModel v)
        {
            var urLocation = v.Location;
            var dslist = _context.BMEDDealStatuses.ToList();
            var fflist = _context.BMEDFailFactors.ToList();
            //if (v.Sdate == null || v.Edate == null)
            //{
            //    throw new Exception("請選擇一段時間區間!");
            //}
            //
            List<UnSignListVModel> sv = new List<UnSignListVModel>();
            List<UnSignListVModel> sv1 = new List<UnSignListVModel>();
            List<UnSignListVModel> sv2 = new List<UnSignListVModel>();
            TempData["qry"] = JsonConvert.SerializeObject(v);


            _context.BMEDRepairFlows.Where(f => f.Status == "?")
            .Join(_context.BMEDRepairDtls.Where(d => d.CloseDate == null),
            f => f.DocId,
            rd => rd.DocId,
            (f, rd) => new
            {
                f.DocId,
                f.UserId,
                f.Cls,
                rd.Cost,
                rd.EndDate,
                rd.CloseDate,
                rd.FailFactor,
                rd.DealDes,
                rd.DealState,
                rd.InOut
            })
            .Join(_context.BMEDRepairs.Where(r => r.Loc == urLocation),
            rd => rd.DocId,
            k => k.DocId,
            (rd, k) => new
            {
                rd.DocId,
                rd.UserId,
                rd.Cls,
                k.AccDpt,
                k.ApplyDate,
                k.AssetNo,
                k.AssetName,
                k.PlantClass,
                rd.Cost,
                rd.EndDate,
                rd.CloseDate,
                rd.FailFactor,
                rd.DealDes,
                rd.DealState,
                k.TroubleDes,
                rd.InOut
            })//.Where(k => k.ApplyDate >= v.Sdate && k.ApplyDate <= v.Edate)
            //.Join(_context.BMEDAssets, k => k.AssetNo, at => at.AssetNo,
            //(k, at) => new
            //{
            //    k.DocId,
            //    k.UserId,
            //    k.Cls,
            //    k.AccDpt,
            //    k.ApplyDate,
            //    k.AssetNo,
            //    at.Cname,
            //    k.Cost,
            //    k.EndDate,
            //    k.CloseDate,
            //    k.TroubleDes,
            //    k.FailFactor,
            //    k.DealDes,
            //    k.DealState,
            //    at.Type,
            //    at.AssetClass
            //})
             .Join(_context.Departments, k => k.AccDpt, c => c.DptId,
            (k, c) => new
            {
                k.DocId,
                k.UserId,
                k.Cls,
                k.AccDpt,
                k.ApplyDate,
                k.AssetNo,
                k.AssetName,
                k.PlantClass,
                k.Cost,
                k.EndDate,
                k.CloseDate,
                k.TroubleDes,
                k.FailFactor,
                k.DealDes,
                k.DealState,
                k.InOut,
                c.Name_C
            })
            .Join(_context.AppUsers, k => k.UserId, u => u.Id,
            (k, u) => new UnSignListVModel
            {
                DocTyp = "請修",
                DocId = k.DocId,
                AccDpt = k.AccDpt,
                AccDptNam = k.Name_C,
                AssetNo = k.AssetNo,
                AssetName = k.AssetName,
                Type = "",
                ApplyDate = k.ApplyDate,
                EndDate = k.EndDate,
                TroubleDes = k.TroubleDes,
                FailFactor = fflist.Where(d => d.Id == k.FailFactor).FirstOrDefault().Title,
                DealDes = k.DealDes,
                DealState = dslist.Where(d => d.Id == k.DealState).FirstOrDefault().Title,
                InOut = k.InOut,
                EngNam = null,
                EngNamNo = null,
                ClsEmp = u.FullName,
                ClsEmpNo = u.UserName,
                AssetClass = k.PlantClass
            })
            //.ToList()
            .GroupJoin(_context.BMEDAssets
                .Join(_context.AppUsers, 
                    b => b.AssetEngId, 
                    u => u.Id,
                    (b, u) => new { b, u}), 
              u => u.AssetNo, 
              p => p.b.AssetNo,
              (u, p) => new { u, p})
            .SelectMany(x => x.p.DefaultIfEmpty(),
            (o, g) => new { data = o.u, g})
            //.Distinct()
            .ToList()
            .ForEach(y => {
                y.data.EngNam = y.g == null ? "" : y.g.u.FullName ;
                y.data.EngNamNo = y.g == null ? "" : y.g.u.UserName;
                sv1.Add(y.data);
            });

            sv1.GroupJoin(_context.BMEDRepairCosts.GroupBy(x => x.DocId).Select(x => new { docid = x.Key , cost = x.Sum(y => y.TotalCost)}),
                s => s.DocId, c => c.docid, (s, c) => new { s, c }).SelectMany(x => x.c.DefaultIfEmpty(),
                (o, g) => new { data = o.s, g }).ToList()
                .ForEach( d => {
                    d.data.Cost = d.g == null ? 0 : d.g.cost;
                    sv.Add(d.data);
                });
            //
            //foreach (UnSignListVModel s in sv)
            //{
            //    RepairEmpModel kp = _context.BMEDRepairEmps.Where(p => p.DocId == s.DocId).ToList()
            //       .FirstOrDefault();
            //    if (kp != null)
            //    {
            //        s.EngNam = _context.AppUsers.Find(kp.UserId).FullName;
            //    }
            //    List<RepairCostModel> lk = _context.BMEDRepairCosts.Where(r => r.DocId == s.DocId).ToList();
            //    if (lk != null)
            //        s.Cost = lk.Sum(r => r.TotalCost);
            //}
            //保養
            string str = "";
            str += "SELECT '保養' AS DOCTYP,B.DOCID,B.ASSETNO, B.ASSETNAME,F.TYPE,B.SENTDATE AS APPLYDATE, D.FULLNAME AS CLSEMP,";
            str += "D.USERNAME AS CLSEMPNO,B.ACCDPT,E.NAME_C AS ACCDPTNAM, C.ENDDATE, ";// CONVERT(varchar, C.RESULT) AS DEALSTATE,C.INOUT, ";
            str += "CASE C.RESULT WHEN 1 THEN '功能正常' WHEN 2 THEN '預防處理' WHEN 3 THEN '異常處理' WHEN 4 THEN '維修時保養' WHEN 5 THEN '退件' ";
            str += "ELSE '' END AS DEALSTATE, ";
            str += "CASE C.INOUT WHEN '0' THEN '自行' WHEN '1' THEN '委外' WHEN '2' THEN '租賃' WHEN '3'THEN '保固' WHEN '4' THEN '借用' ";
            str += "ELSE '' END AS INOUT, ";
            str += "C.COST, G.KeepEngName AS ENGNAM,U2.USERNAME AS ENGNAMNO, C.MEMO AS FAILFACTOR, CONVERT(varchar, B.CYCLE) AS TroubleDes, ";
            str += "C.MEMO AS DEALDES, F.ASSETCLASS ";
            str += "FROM BMEDKEEPFLOWS AS A JOIN BMEDKEEPS AS B ON A.DOCID = B.DOCID ";
            str += "JOIN BMEDKEEPDTLS AS C ON B.DOCID = C.DOCID ";
            str += "JOIN APPUSERS AS D ON A.USERID = D.ID ";
            str += "JOIN DEPARTMENTS AS E ON B.ACCDPT = E.DPTID "; ;
            str += "LEFT JOIN BMEDASSETS AS F ON B.AssetNo = F.AssetNo ";
            str += "LEFT JOIN BMEDASSETKEEPS AS G ON B.AssetNo = G.AssetNo ";
            str += "LEFT JOIN APPUSERS AS U2 ON G.KeepEngId = U2.ID ";
            str += "LEFT JOIN BMEDKEEPEMPS AS H ON A.DOCID = H.DOCID ";
            str += "LEFT JOIN APPUSERS AS U ON H.USERID = U.ID ";
            str += "WHERE A.STATUS = '?' AND B.LOC = @D3 ";
            sv2 = _context.UnSignListVModelQuery.FromSql(str,
                new SqlParameter("D3", urLocation)).ToList();
            sv.AddRange(sv2);
            if (v.Sdate != null)
            {
                sv = sv.Where(s => s.ApplyDate >= v.Sdate).ToList();
            }
            if (v.Edate != null)
            {
                sv = sv.Where(s => s.ApplyDate <= v.Edate).ToList();
            }
           
            
            sv = sv.Where(m => m.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1)).ToList();
            //
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                sv = sv.Where(vv => vv.AccDpt == v.AccDpt).ToList();
            }
            //
            return sv;
        }

        public IActionResult ExcelUS(ReportQryVModel v)
        {
            string str = "";
            str += "類別,表單編號,送單日期,完工日期,財產編號,設備名稱,型號,成本中心,成本中心名稱,";
            str += "故障描述/保養週期,故障原因,處理狀況/保養結果,保養方式,處理描述,費用,工程師代碼,工程師,現在關卡人員代碼,現在關卡人員";
            DataTable dt = new DataTable();
            DataRow dw;
            str.Split(new char[] { ',' }).ToList()
                .ForEach(s =>
                {
                    dt.Columns.Add(s);
                });
            List<UnSignListVModel> uv = UnSignList(v);
            
            uv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.DocTyp;
                dw[1] = m.DocId;
                dw[2] = m.ApplyDate.ToString("yyyy/MM/dd");
                dw[3] = m.EndDate == null ? "" : m.EndDate.Value.ToString("yyyy/MM/dd");
                dw[4] = m.AssetNo;
                dw[5] = m.AssetName;
                dw[6] = m.Type;
                dw[7] = m.AccDpt;
                dw[8] = m.AccDptNam;
                dw[9] = m.TroubleDes;
                dw[10] = m.FailFactor;
                dw[11] = m.DealState;
                dw[12] = m.InOut;
                dw[13] = m.DealDes;
                dw[14] = m.Cost;
                dw[15] = m.EngNamNo;
                dw[16] = m.EngNam;
                dw[17] = m.ClsEmpNo;
                dw[18] = m.ClsEmp;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("未結案清單");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "UnSignList.xlsx"
            );
        }


        public List<DoHrSumMonVModel> DoHrSumMon(ReportQryVModel v)
        {
            
            var urLocation = v.Location;
            //
            List<DoHrSumMonVModel> mv = new List<DoHrSumMonVModel>();
            DoHrSumMonVModel dv;
            TempData["qry"] = JsonConvert.SerializeObject(v);

            List<UserHour> query = _context.BMEDRepairDtls.Where(d => d.EndDate >= v.Sdate)
                .Where(d => d.EndDate <= v.Edate)
                .Join(_context.BMEDRepairs.Where(r => r.Loc == urLocation), rd => rd.DocId, r => r.DocId,
                (rd, r) => new
                {
                    rd.DocId,
                    rd.Hour,
                    rd.EndDate,
                    rd.InOut,
                    r.ApplyDate,
                    r.AccDpt,
                    r.AssetNo,
                    r.PlantClass
                })
                //.Join(_context.BMEDAssets, k => k.AssetNo, c => c.AssetNo,
                //(k, c) => new
                //{
                //    k.DocId,
                //    k.Hour,
                //    k.EndDate,
                //    k.InOut,
                //    k.ApplyDate,
                //    k.AccDpt,
                //    c.AssetClass
                //})
                .Join(_context.Departments, k => k.AccDpt, c => c.DptId,
            (k, c) => new
            {
                k.DocId,
                k.Hour,
                k.EndDate,
                k.InOut,
                k.ApplyDate,
                //k.AssetClass,
                k.AccDpt,
                k.PlantClass,
                k.AssetNo
            }).Join(_context.BMEDRepairEmps, rd => rd.DocId, re => re.DocId,
                (rd, re) => new UserHour
                {
                    Uid = re.UserId,
                    Hour = rd.Hour,
                    InOut = rd.InOut,
                    AssetClass = "",
                    ApplyDate = rd.ApplyDate,
                    EndDate = rd.EndDate.Value,
                    AccDpt = rd.AccDpt,
                    AssetNo = rd.AssetNo
                })
            //.Where(m => m.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
            .ToList();
            //
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                query = query.Where(vv => vv.AccDpt == v.AccDpt).ToList();
            }
            //
            List<UserHour> queryK = _context.BMEDKeepDtls.Where(d => d.EndDate >= v.Sdate)
                .Where(d => d.EndDate <= v.Edate)
                .Join(  _context.BMEDKeeps.Where(r => r.Loc == urLocation), 
                        rd => rd.DocId, 
                        r => r.DocId,
                        (rd, r) => new
                        {
                            rd.DocId,
                            rd.Hours,
                            rd.EndDate,
                            rd.InOut,
                            r.SentDate,
                            r.AccDpt,
                            r.AssetNo,
                            r.PlaceLoc
                        })
                //.Join(_context.BMEDAssets, k => k.AssetNo, c => c.AssetNo,
                //(k, c) => new
                //{
                //    k.DocId,
                //    k.Hour,
                //    k.EndDate,
                //    k.InOut,
                //    k.ApplyDate,
                //    k.AccDpt,
                //    c.AssetClass
                //})
                .Join(_context.Departments, 
                        k => k.AccDpt,
                        c => c.DptId,
                        (k, c) => new
                        {
                            k.DocId,
                            k.Hours,
                            k.EndDate,
                            k.InOut,
                            k.SentDate,
                            //k.AssetClass,
                            k.AccDpt,
                            k.PlaceLoc,
                            k.AssetNo
                        })  
                .Join(_context.BMEDKeepEmps, rd => rd.DocId, re => re.DocId,
                (rd, re) => new UserHour
                {
                    Uid = re.UserId,
                    Hour = rd.Hours,
                    InOut = rd.InOut,
                    AssetClass = "",
                    ApplyDate = rd.SentDate,
                    EndDate = rd.EndDate.Value,
                    AccDpt = rd.AccDpt,
                    AssetNo = rd.AssetNo
                })
            //.Where(m => m.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
            .ToList();
            //
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                query = query.Where(vv => vv.AccDpt == v.AccDpt).ToList();
            }

            //維修單數
            var cases = query.GroupBy(j => j.Uid)
                             .ToDictionary(x => x.Key, x => x.Count());
            //維修時數
            var hourR = query.GroupBy(j => j.Uid)
                             .ToDictionary(x => x.Key, x => x.Select(h => h.Hour).DefaultIfEmpty(0).Sum());
            //五日完修率
            var asset1 = query
                                 .Where(g1 => g1.EndDate.Subtract(Convert.ToDateTime(g1.ApplyDate)).Days < 5)
                                 .GroupBy(x => x.Uid)
                                 .ToDictionary(x => x.Key, x => x.Count());
            var asset5 = query
                                 .Where(g1 => g1.EndDate.Subtract(Convert.ToDateTime(g1.ApplyDate)).Days >= 5)
                                 .GroupBy(x => x.Uid)
                                 .ToDictionary(x => x.Key, x => x.Count());
            //五日完修率(高風險)
            var asset = query.Join(_context.BMEDAssets,
                                        q => q.AssetNo,
                                        a => a.AssetNo,
                                        (q, a) => new { que = q, asset = a })
                                 .Where(x => x.asset.HighRisk == "Y");
            var assetHigh1 = asset
                                 .Where(g1 => g1.que.EndDate.Subtract(Convert.ToDateTime(g1.que.ApplyDate)).Days < 5)
                                 .Select(x => x.que.Uid)
                                 .GroupBy(x => x)
                                 .ToDictionary(x => x.Key, x => x.Count());
            var assetHigh5 = asset
                                 .Where(g1 => g1.que.EndDate.Subtract(Convert.ToDateTime(g1.que.ApplyDate)).Days >= 5)
                                 .Select(x => x.que.Uid)
                                 .GroupBy(x => x)
                                 .ToDictionary(x => x.Key, x => x.Count());
            //Keep Over 5 Day Case
            var keepOver5 = queryK
                                .Where(g1 => g1.EndDate.Subtract(Convert.ToDateTime(g1.ApplyDate)).Days >= 5)
                                .GroupBy(x => x.Uid)
                                .ToDictionary(x => x.Key, x => x.Count());
            //維修時數
            var hourK = queryK.GroupBy(j => j.Uid)
                             .ToDictionary(x => x.Key, x => x.Select(h => h.Hour).DefaultIfEmpty(0).Sum());
            //
            query.AddRange(queryK);
            //
            IEnumerable<IGrouping<int, UserHour>> rt = query.GroupBy(j => j.Uid);
            //
            //無財編件數
            var Unrt = query.Where(q => q.AssetNo != "99999")
                .GroupBy(j => j.Uid)
                .ToDictionary(x => x.Key, x => x.Count()); 
            
            int case1 = 0;
            int case5 = 0;
            int abc = 0;
            DateTime sd = v.Edate.Value.AddMonths(-3);
            AppUserModel ur;

            var fullName = rt.GroupJoin(_context.AppUsers,
                                        r => r.Key,
                                        urs => urs.Id,
                                        (r ,urs) => new { querys = r , users = urs}
                                        )
                            .SelectMany( x => x.users.DefaultIfEmpty() , 
                                        (r, urs) => new { _querys = r, _users = urs.UserName })
                            .GroupBy( x => x._querys.querys.Key)
                            .ToDictionary( x => x.Key , x => x.Select( f => f._users));

            var repairD = _context.BMEDRepairDtls
                        .Where(d => d.EndDate >= sd)
                        .Where(d => d.EndDate <= v.Edate)
                        .Join(_context.BMEDRepairEmps,
                                rd => rd.DocId,
                                re => re.DocId,
                                (rd, re) => re.UserId
                                );


            //三個月維修總件數
            var case3M = repairD.Join(rt,
                                        c => c,
                                        g => g.Key,
                                        (c, g) => g.Key
                                     )
                                .GroupBy(x => x)
                                .ToDictionary(x => x.Key, x => x.Count());

            //三個月維修無財編總件數
            var UnrepairD = _context.BMEDRepairDtls
                        .Where(d => d.EndDate >= sd)
                        .Where(d => d.EndDate <= v.Edate)
                        .Where(d => d.AssetNo != "99999")
                        .Join(_context.BMEDRepairEmps,
                                rd => rd.DocId,
                                re => re.DocId,
                                (rd, re) => re.UserId
                                );

            var Uncase3M = UnrepairD.Join(rt,
                                        c => c,
                                        g => g.Key,
                                        (c, g) => g.Key
                                     )
                                       .GroupBy(x => x)
                                .ToDictionary(x => x.Key, x => x.Count());

            //dv.Fail3MRate
            var obs = _context.BMEDRepairDtls
                 .Where(d => d.EndDate >= sd)
                 .Where(d => d.EndDate <= v.Edate)
                 .Where(d => d.AssetNo != "99999")
                 .Join(_context.BMEDRepairs,
                     rd => rd.DocId, r => r.DocId,
                     (rd, r) => new
                     {
                         rd.DocId,
                         r.AssetNo
                     })
             .Join(_context.BMEDRepairEmps,
                     rd => rd.DocId,
                     re => re.DocId,
                     (rd, re) => new UserAsset
                     {
                         Uid = re.UserId,
                         AssetNo = rd.AssetNo
                     })
             .Join(rt,
                     u => u.Uid,
                     g => g.Key,
                     (u, g) => new
                     {
                         AssetNo = u.AssetNo,
                         Key = g.Key
                     })
             .GroupBy(j => j.Key)
             .ToDictionary(x => x.Key, x=> x.GroupBy(j => j.AssetNo));

            //dv.Fail1MRat
            var obss = _context.BMEDRepairDtls
                .Where(d => d.EndDate >= v.Sdate)
                .Where(d => d.EndDate <= v.Edate)
                .Where(d => d.AssetNo != "99999")
                .Join(_context.BMEDRepairs, rd => rd.DocId, r => r.DocId,
                (rd, r) => new
                {
                    rd.DocId,
                    r.AssetNo
                })
                .Join(_context.BMEDRepairEmps, rd => rd.DocId, re => re.DocId,
                (rd, re) => new UserAsset
                {
                    Uid = re.UserId,
                    AssetNo = rd.AssetNo
                })
                .Join(rt,
                     u => u.Uid,
                     g => g.Key,
                     (u, g) => new
                     {
                         AssetNo = u.AssetNo,
                         Key = g.Key
                     })
             .GroupBy(j => j.Key)
             .ToDictionary(x => x.Key, x => x.GroupBy(j => j.AssetNo));

           


            foreach (var g in rt)
            {
                case1 = 0;
                case5 = 0;
                dv = new DoHrSumMonVModel();
                dv.FullName = fullName.ContainsKey(g.Key) == false ? "" : fullName[g.Key].FirstOrDefault();
                dv.UserNam = (ur = _context.AppUsers.Find(g.Key)) == null ? "" : ur.FullName;
                dv.Cases = g.Count();
                dv.RCases = cases.ContainsKey(g.Key) == false ? 0 : cases[g.Key];
                dv.KCases = dv.Cases - dv.RCases;
                dv.Hours = g.Sum(s => s.Hour);
                dv.HoursR = hourR.ContainsKey(g.Key) == false ? 0 : hourR[g.Key];
                dv.HoursK = hourK.ContainsKey(g.Key) == false ? 0 : hourK[g.Key];
                //case1 = g.Where(g1 => g1.EndDate.Subtract(Convert.ToDateTime(g1.ApplyDate)).Days < 5).Count();
                //case5 = g.Where(g1 => g1.EndDate.Subtract(Convert.ToDateTime(g1.ApplyDate)).Days >= 5).Count();
                //dv.OverFive = case5;
                //if (case1 + case5 > 0)
                //{
                //    dv.OverFiveRate = Decimal.Round(Convert.ToDecimal(case1) /
                //            Convert.ToDecimal(case1 + case5), 2);
                //}
                //else
                //    dv.OverFiveRate = 0m;
                case1 = asset1.ContainsKey(g.Key) == false ? 0 : asset1[g.Key];
                case5 = asset5.ContainsKey(g.Key) == false ? 0 : asset5[g.Key]; ;
                dv.OverFive = case5;
                if (case1 + case5 > 0)
                {
                    dv.OverFiveRate = Decimal.Round(Convert.ToDecimal(case1) /
                            Convert.ToDecimal(case1 + case5), 2);
                }
                else
                    dv.OverFiveRate = 0m;
                //
                case1 = assetHigh1.ContainsKey(g.Key) == false ? 0 : assetHigh1[g.Key];
                case5 = assetHigh5.ContainsKey(g.Key) == false ? 0 : assetHigh5[g.Key]; 
                dv.OverFiveHigh = case5;
                if (case1 + case5 > 0)
                {
                    dv.OverFiveRateHigh = Decimal.Round(Convert.ToDecimal(case1) /
                            Convert.ToDecimal(case1 + case5), 2);
                }
                else
                    dv.OverFiveRateHigh = 0m;
                //
                dv.OverFiveKeep = keepOver5.ContainsKey(g.Key) == false ? 0 : keepOver5[g.Key];

                //dv.Case3M = _context.BMEDRepairDtls.Where(d => d.EndDate >= sd)
                //.Where(d => d.EndDate <= v.Edate)
                //.Join(_context.BMEDRepairEmps, rd => rd.DocId, re => re.DocId,
                //(rd, re) => new
                //{
                //    re.UserId
                //}).Where(re => re.UserId == g.Key).Count();

                dv.Case3M = case3M.ContainsKey(g.Key) == false ? 0 : case3M[g.Key];

                var unCase3M = Uncase3M.ContainsKey(g.Key) == false ? 0 : Uncase3M[g.Key];
                var unCase = Unrt.ContainsKey(g.Key) == false ? 0 : Unrt[g.Key];

                //dv.Fail3MRate
                //IEnumerable<IGrouping<string, UserAsset>> ob = _context.BMEDRepairDtls
                //    .Where(d => d.EndDate >= sd)
                //    .Where(d => d.EndDate <= v.Edate)
                //    .Join(_context.BMEDRepairs
                //        .Where(r => r.Loc == urLocation),
                //        rd => rd.DocId, r => r.DocId,
                //        (rd, r) => new
                //        {
                //            rd.DocId,
                //            r.AssetNo
                //        })
                //.Join(_context.BMEDRepairEmps,
                //        rd => rd.DocId,
                //        re => re.DocId,
                //        (rd, re) => new UserAsset
                //        {
                //            Uid = re.UserId,
                //            AssetNo = rd.AssetNo
                //        })
                //.Where(re => re.Uid == g.Key)
                //.GroupBy(j => j.AssetNo);


                //abc = 0;
                //foreach (var q in ob)
                //{
                //    if (q.Count() >= 2)
                //        abc += q.Count();
                //}
                var oob = obs.ContainsKey(g.Key) == false ? null : obs[g.Key];
                abc = 0;
                if (oob != null) { 
                    foreach (var q in oob)
                    {
                        if (q.Count() >= 2)
                            abc += q.Count();
                    }
                }

                if (unCase3M > 0)
                    dv.Fail3MRate = Decimal.Round(Convert.ToDecimal(abc) / Convert.ToDecimal(unCase3M), 2);
                else
                    dv.Fail3MRate = 0m;

                //ob = _context.BMEDRepairDtls
                //.Where(d => d.EndDate >= v.Sdate)
                //.Where(d => d.EndDate <= v.Edate)
                //.Join(_context.BMEDRepairs, rd => rd.DocId, r => r.DocId,
                //(rd, r) => new
                //{
                //    rd.DocId,
                //    r.AssetNo
                //})
                //.Join(_context.BMEDRepairEmps, rd => rd.DocId, re => re.DocId,
                //(rd, re) => new UserAsset
                //{
                //    Uid = re.UserId,
                //    AssetNo = rd.AssetNo
                //}).Where(re => re.Uid == g.Key).GroupBy(re => re.AssetNo);
                //abc = 0;
                //foreach (var q in ob)
                //{
                //    if (q.Count() >= 2)
                //        abc += q.Count();
                //}

                oob = obss.ContainsKey(g.Key) == false ? null : obss[g.Key];
                abc = 0;
                if(oob != null) { 
                    foreach (var q in oob)
                    {
                        if (q.Count() >= 2)
                            abc += q.Count();
                    }
                }


                if (unCase > 0)
                    dv.Fail1MRate = Decimal.Round(Convert.ToDecimal(abc) / Convert.ToDecimal(unCase), 2);
                else
                    dv.Fail1MRate = 0m;
                //
                if (unCase > 0)
                    dv.SelfRate = Decimal.Round(g.Where(x => x.InOut == "內修").Count() / Convert.ToDecimal(unCase), 2);
                else
                    dv.SelfRate = 0m;
                mv.Add(dv);

                unCase = 0;
                unCase3M = 0;
            }
            //
            mv = mv.OrderBy(m => m.FullName).ToList();
            return mv;
        }
        public IActionResult DoHrSumMonExcel(ReportQryVModel v)
        {
            //sheet
            ExcelPackage excel = new ExcelPackage();
            var sheet = excel.Workbook.Worksheets.Add("工作時數統計表");

            List<DoHrSumMonVModel> doHrSums = DoHrSumMon(v);

            sheet.Cells[1, 1].Value = "編號";
            sheet.Cells[1, 2].Value = "姓名";
            sheet.Cells[1, 3].Value = "工作時數";
            //sheet.Cells[1, 4].Value = "點數";
            sheet.Cells[1, 4].Value = "件數";
            //sheet.Cells[1, 6].Value = "轉撥計價";
            sheet.Cells[1, 5].Value = "超過五天件數";
            sheet.Cells[1, 6].Value = "五日完修率";
            sheet.Cells[1, 7].Value = "五日完修率(高風險)";
            sheet.Cells[1, 8].Value = "自修率";
            sheet.Cells[1, 9].Value = "重複故障率";
            sheet.Cells[1, 10].Value = "三個月維修總數";
            sheet.Cells[1, 11].Value = "三個月重複故障率";

            //Data
            int startPos1 = 2;
            int startPos2 = 3;
            int startPos3 = 4;
            int Sum = doHrSums.Count();
            int CasesSum = 0;
            decimal? HoursSum = 0;
            int OverFiveSum = 0;
            decimal OverFiveRateSum = 0;
            decimal OverFiveRateHighSum = 0;
            decimal SelfRateSum = 0;
            decimal Fail1MRateSum = 0;
            int Case3MSum = 0;
            decimal Fail3MRateSum = 0;

            foreach (var item in doHrSums)
            {
                sheet.Cells[startPos1, 1].Value = item.FullName;
                sheet.Cells[startPos1, 2].Value = item.UserNam;
                sheet.Cells[startPos1 + 1, 2].Value = "維修";
                sheet.Cells[startPos1 + 2, 2].Value = "保養";
                sheet.Cells[startPos1, 3].Value = item.Hours;
                HoursSum += (item.Hours == null ? 0 : item.Hours);
                //sheet.Cells[startPos1, 4].Value = 0;
                sheet.Cells[startPos1, 4].Value = item.Cases;
                CasesSum += item.Cases;
                //sheet.Cells[startPos1, 6].Value = item.Costs;
                sheet.Cells[startPos1, 5].Value = item.OverFive + item.OverFiveKeep;
                OverFiveSum += (item.OverFive + item.OverFiveKeep);
                sheet.Cells[startPos1, 6].Value = item.OverFiveRate;
                OverFiveRateSum += item.OverFiveRate;
                sheet.Cells[startPos1, 7].Value = item.OverFiveRateHigh;
                OverFiveRateHighSum += item.OverFiveRateHigh;
                sheet.Cells[startPos1, 8].Value = item.SelfRate;
                SelfRateSum += item.SelfRate;
                sheet.Cells[startPos1, 9].Value = item.Fail1MRate;
                Fail1MRateSum += item.Fail1MRate;
                sheet.Cells[startPos1, 10].Value = item.Case3M;
                Case3MSum += item.Case3M;
                sheet.Cells[startPos1, 11].Value = item.Fail3MRate;
                Fail3MRateSum += item.Fail3MRate;
                startPos1 += 3;
            }

            //總計

            startPos1++;

            sheet.Cells[startPos1, 3].Value = "工作時數";

            sheet.Cells[startPos1, 4].Value = "件數";

            sheet.Cells[startPos1, 5].Value = "超過五日件數";

            sheet.Cells[startPos1, 6].Value = "五日完成率";

            sheet.Cells[startPos1, 7].Value = "五日完成率(高風險)";

            sheet.Cells[startPos1, 8].Value ="自修率";

            sheet.Cells[startPos1, 9].Value = "重複故障率";

            sheet.Cells[startPos1, 10].Value = "三個月維修總數";

            sheet.Cells[startPos1, 11].Value = "三個月重複故障率";


            startPos1++;

                sheet.Cells[startPos1, 1].Value = "合計";

                sheet.Cells[startPos1, 3].Value = HoursSum;

                sheet.Cells[startPos1, 4].Value = CasesSum;

                sheet.Cells[startPos1, 5].Value = OverFiveSum;

                sheet.Cells[startPos1, 6].Value = Decimal.Round(OverFiveRateSum / Sum, 2);

                sheet.Cells[startPos1, 7].Value = Decimal.Round(OverFiveRateHighSum / Sum, 2);

                sheet.Cells[startPos1, 8].Value = Decimal.Round(SelfRateSum / Sum, 2);

                sheet.Cells[startPos1, 9].Value = Decimal.Round(Fail1MRateSum / Sum, 2);

                sheet.Cells[startPos1, 10].Value = Case3MSum;

                sheet.Cells[startPos1, 11].Value = Decimal.Round(Fail3MRateSum / Sum, 2);

            decimal? HoursRSum = 0;
            int RCasesSum = 0;
            int OverFiveRSum = 0;

            foreach (var item in doHrSums)
            {
                sheet.Cells[startPos2, 3].Value = item.HoursR;
                HoursRSum += (item.HoursR == null ? 0 : item.HoursR);
                //sheet.Cells[startPos2, 4].Value = 0;
                sheet.Cells[startPos2, 4].Value = item.RCases;
                RCasesSum += item.RCases;
                //sheet.Cells[startPos2, 6].Value = item.Costs;
                sheet.Cells[startPos2, 5].Value = item.OverFive;
                startPos2 += 3;
                OverFiveRSum += item.OverFive;
            }

            decimal? HoursKSum = 0;
            int KCasesSum = 0;
            int OverFiveKeepSum = 0;

            foreach (var item in doHrSums)
            {
                sheet.Cells[startPos3, 3].Value = item.HoursK;
                HoursKSum += (item.HoursK == null ? 0 : item.HoursK);
                // sheet.Cells[startPos3, 4].Value = 0;
                sheet.Cells[startPos3, 4].Value = item.KCases;
                KCasesSum += item.KCases;
                // sheet.Cells[startPos3, 6].Value = item.Costs;
                sheet.Cells[startPos3, 5].Value = item.OverFiveKeep;
                OverFiveKeepSum += item.OverFiveKeep;
                startPos3 += 3;
            }

            //維修總計
            startPos1+=2;

            sheet.Cells[startPos1, 2].Value = "維修";

            sheet.Cells[startPos1, 3].Value = HoursRSum;

            sheet.Cells[startPos1, 4].Value = RCasesSum;

            sheet.Cells[startPos1, 5].Value = OverFiveRSum;

            //保養總計
            startPos1 ++;

            sheet.Cells[startPos1, 2].Value = "保養";

            sheet.Cells[startPos1, 3].Value = HoursKSum;

            sheet.Cells[startPos1, 4].Value = KCasesSum;

            sheet.Cells[startPos1, 5].Value = OverFiveKeepSum;



            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "DoHrSumMon.xlsx"
            );
        }
        /* 故障率 = 維修總件數/設備總數 */
        public List<MonthFailRateVModel> MonthFailRate(ReportQryVModel v)
        {
            TempData["qry"] = JsonConvert.SerializeObject(v);

            List<MonthFailRateVModel> mv = new List<MonthFailRateVModel>();
            List<DepartmentModel> accdpts = new List<DepartmentModel>();
            List<DepartmentModel> delivdpts = new List<DepartmentModel>();
            List<AssetModel> assets = new List<AssetModel>();
            string[] ss = new string[] { "?", "2" };
            int RepairAmt = 0;
            int PlantAmt = 0;
            var repairs = _context.BMEDRepairs.Where(r => r.ApplyDate >= v.Sdate && r.ApplyDate <= v.Edate)
                   .Join(_context.BMEDRepairFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                   (r, f) => r);
            if (!string.IsNullOrEmpty(v.AccDpt) && !string.IsNullOrEmpty(v.DelivDpt))
            {
                assets = _context.BMEDAssets.Where(a => a.DisposeKind != "報廢")
                        .Where(a => a.AccDpt == v.AccDpt)
                        .Where(a => a.DelivDpt == v.DelivDpt)
                        .Where(m => m.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                        .ToList();

                var count1 = assets.Count();
                var count2 = assets.Join(repairs, a => a.AssetNo, r => r.AssetNo,
                    (a, r) => r).Count();

                decimal num1 = decimal.Round(count1, 4);
                decimal num2 = decimal.Round(count2, 4);

                mv.Add(new MonthFailRateVModel
                {
                    CustId = v.AccDpt,
                    CustNam = _context.Departments.Find(v.AccDpt).Name_C,
                    PlantAmt = count1,
                    RepairAmt = count2,
                    FailRate = decimal.Round(num2 / num1, 4).ToString("P")
                });
                return mv;
            }
            else if (!string.IsNullOrEmpty(v.AccDpt))
            {
                assets = _context.BMEDAssets
                    .Where(a => a.DisposeKind != "報廢")
                    .Where(a => a.AccDpt == v.AccDpt)
                    .Where(m => m.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                    .ToList();

                var count1 = assets.Count();

                var count2 = assets.Join(repairs, a => a.AssetNo, r => r.AssetNo,
                    (a, r) => r).Count();

                decimal num1 = decimal.Round(count1, 4);
                decimal num2 = decimal.Round(count2, 4);

                mv.Add(new MonthFailRateVModel
                {
                    CustId = v.AccDpt,
                    CustNam = _context.Departments.Find(v.AccDpt).Name_C,
                    PlantAmt = count1,
                    RepairAmt = count2,
                    FailRate = decimal.Round(num2 / num1, 4).ToString("P")
                });
                return mv;
            }
            else if (!string.IsNullOrEmpty(v.DelivDpt))
            {
                assets = _context.BMEDAssets.Where(a => a.DisposeKind != "報廢")
                    .Where(a => a.DelivDpt == v.DelivDpt)
                    .Where(m => m.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                    .ToList();

                var count1 = assets.Count();
                var count2 = assets.Join(repairs, a => a.AssetNo, r => r.AssetNo,
                    (a, r) => r).Count();

                decimal num1 = decimal.Round(count1, 4);
                decimal num2 = decimal.Round(count2, 4);

                mv.Add(new MonthFailRateVModel
                {
                    CustId = v.DelivDpt,
                    CustNam = _context.Departments.Find(v.AccDpt).Name_C,
                    PlantAmt = count1,
                    RepairAmt = count2,
                    FailRate = decimal.Round(num2 / num1, 4).ToString("P")
                });
                return mv;
            }
            //
            var urLocation = v.Location;
            //
          
            
            //計算時間區間
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            if (v.Sdate == null && v.Edate != null)
            {
                endDate = v.Edate.Value;
                startDate = endDate.AddYears(-1).AddDays(6);
            }
            else if (v.Sdate != null && v.Edate == null)
            {
                endDate = v.Sdate.Value;
                startDate = endDate.AddYears(-1).AddDays(6);
            }
            else
            {
                endDate = v.Edate.Value;
                startDate = v.Sdate.Value;
            }
            int totalMins = 0;
            TimeSpan ts;
            ts = endDate - startDate;
            totalMins = Convert.ToInt32(ts.TotalMinutes);

            // Get assets by user's location.
            assets = GetAssetsByLoc(urLocation);
            
            //var ass = _context.BMEDAssets.Join(_context.Departments, a => a.DelivDpt, d => d.DptId,
            //                                    (a, d) => new
            //                                    {
            //                                        asset = a,
            //                                        dept = d
            //                                    })
            //                                    .Where(r => r.dept.Loc == "C" )
            //                                    .Select(r => r.asset);

            if (!string.IsNullOrEmpty(v.AccDpt))    // Get AccDpt assets.
            {
                assets = assets.Where(a => a.AccDpt == v.AccDpt).ToList();
            }
            if (!string.IsNullOrEmpty(v.AssetClass1))
            {
                assets = assets.Where(a => a.AssetClass == v.AssetClass1).ToList();
            }
            if (!string.IsNullOrEmpty(v.AssetClass2))
            {
                assets = assets.Where(a => a.AssetClass == v.AssetClass2).ToList();
            }
            if (!string.IsNullOrEmpty(v.AssetClass3))
            {
                assets = assets.Where(a => a.AssetClass == v.AssetClass3).ToList();
            }
            //var data = assets.Join(_context.Departments.ToList(), a => a.AccDpt, d => d.DptId,
            //    (a, d) => new { a, dpt = d.Name_C }).ToList();

            var data = assets.Join(_context.Departments.ToList(), a => a.AccDpt, d => d.DptId,
              (a, d) => new { a, dpt = d });

            //設備歸屬單位
            //var data = assets.Join(_context.Departments.ToList(), a => a.AccDpt, d => d.DptId,
            //   (a, d) => new { a, dpt = d }).ToList();

            //單位去抓
            var datas = data.GroupBy(rep => rep.dpt.DptId)
                            .ToDictionary(o => o.Key, o => o.Count());


            var repairDs = repairs.Join(
                                        data, rp => rp.AssetNo,
                                        d => d.a.AssetNo,
                                        (rp, d) => new { repairD =  rp ,
                                                         asset = d.a, 
                                                         accdpt = d.dpt
                                                       }
                                       ).ToList();

            var repairDos = repairDs.Join(_context.BMEDRepairDtls
                                           , r => r.repairD.DocId, rd => rd.DocId,
                                           (r, rd) => new
                                           {
                                               repair = r,
                                               repairDtl = rd
                                           })
                                    .Where(r => r.repairDtl.EndDate != null).ToList();

            var repairDocs = repairDos.GroupBy(rep => rep.repair.accdpt.DptId)
                                      .ToDictionary(o => o.Key, o => o.Count());

            //var repairDocMins = repairDs.Join(_context.BMEDRepairDtls, r => r.DocId, rd => rd.DocId,
            //                               (r, rd) => new {
            //                                   repair = r,
            //                                   repairDtl = rd
            //                               }).Where(r => r.repairDtl.EndDate != null)
            //                               .GroupBy(rep => rep.repair.AssetNo)
            //                               .ToDictionary(o => o.Key, o => o.Select(x => x.repairDtl.EndDate.Value - x.repair.ApplyDate));
            //                               //repairDtl.EndDate.Value.AddDays(1) - o.repair.ApplyDate););

            var dept = data.Select(d => d.dpt).Distinct();

            foreach (var item in dept.ToList())
            {
                PlantAmt = datas.ContainsKey(item.DptId) == false ? 0 : datas[item.DptId];
                RepairAmt = repairDocs.ContainsKey(item.DptId) == false ? 0 : repairDocs[item.DptId];

                //Have PlantAmt Count
                if (PlantAmt > 0) { 
                    MonthFailRateVModel m = new MonthFailRateVModel();
                    //var repairDocss = _context.BMEDRepairs.Where(r => r.AssetNo == item.a.AssetNo)
                    //                           .Join(_context.BMEDRepairDtls, r => r.DocId, rd => rd.DocId,
                    //                           (r, rd) => new
                    //                           {
                    //                               repair = r,
                    //                               repairDtl = rd
                    //                           }).Where(r => r.repairDtl.EndDate != null).ToList();
                    //if (repairDocss.Count() > 0)
                    //{
                    //    foreach (var r in repairDocss)
                    //    {
                    //        TimeSpan ts2 = r.repairDtl.EndDate.Value.AddDays(1) - r.repair.ApplyDate;
                    //        repairMins += Convert.ToInt32(ts2.TotalMinutes);
                    //    }
                    //}

                   
                    //if (repairD > 0)
                    //{
                    //   var ts2 = repairDocMins.ContainsKey(item.a.AssetNo) == false ? null : repairDocMins[item.a.AssetNo];
                    //   repairMins += Convert.ToInt32(ts2.Select(t => t.TotalMinutes).FirstOrDefault().ToString());//TotalMinutes
                    //}
                    //
                    m.RepairAmt = RepairAmt;
                    m.PlantAmt = PlantAmt;
                    decimal num1 = decimal.Round(RepairAmt , 4);
                    decimal num2 = decimal.Round(PlantAmt  , 4);

                    m.FailRate = decimal.Round(num1 / num2, 4).ToString("P");
                    
                    //m.AssetNo = item.a.AssetNo;
                    //m.Cname = item.a.Cname;
                    m.CustId = item.DptId;
                    //var dpt = _context.Departments.Find(m.CustId);
                    m.CustNam = item.Name_C;
                    //m.RepairMins = repairMins;
                    //m.TotalMins = totalMins;
                    //m.FailRate = decimal.Round(m.RepairMins / m.TotalMins, 4).ToString("P");
                    mv.Add(m);
                }
            }

            return mv;
        }

        //public List<MonthFailRateVModel> MonthFailRate(ReportQryVModel v)
        //{

        //    List<MonthFailRateVModel> mv = new List<MonthFailRateVModel>();
        //    MonthFailRateVModel m;

        //    foreach (Department p in _context.Departments.ToList())
        //    {
        //        m = new MonthFailRateVModel();
        //        m.CustId = p.DptId;
        //        m.CustNam = p.Name_C;
        //        m.RepairAmt =
        //            _context.BMEDRepairDtls.Where(d => d.EndDate >= v.Sdate)
        //            .Where(d => d.EndDate <= v.Edate)
        //            .Join(_context.BMEDRepairs, rd => rd.DocId, r => r.DocId,
        //            (rd, r) => new
        //            {
        //                rd.DocId,
        //                r.AccDpt,
        //                r.AssetNo
        //            }).Join(_context.BMEDAssets.Where(r => r.AccDpt == p.DptId)
        //            .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
        //            .Where(a => a.DisposeKind == "正常"), rd => rd.AssetNo, r => r.AssetNo,
        //            (rd, r) => new
        //            {
        //                rd.DocId,
        //                r.AccDpt,
        //                r.AssetClass
        //            }).Count();
        //        //
        //        m.PlantAmt = _context.BMEDAssets.Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
        //            .Where(r => r.AccDpt == p.DptId)
        //            .Where(a => a.DisposeKind == "正常")
        //            .Count();
        //        if (m.PlantAmt > 0)
        //            m.FailRate = decimal.Round(Convert.ToDecimal(m.RepairAmt) / Convert.ToDecimal(m.PlantAmt) * 100m, 2);
        //        else
        //            m.FailRate = 0m;
        //        mv.Add(m);
        //    }
        //    if (!string.IsNullOrEmpty(v.AccDpt))
        //    {
        //        mv = mv.Where(vv => vv.CustId == v.AccDpt).ToList();
        //    }
        //    return mv;
        //}

        public IActionResult ExcelMR(ReportQryVModel v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("類別");
            dt.Columns.Add("表單編號");
            dt.Columns.Add("請修日期");
            dt.Columns.Add("完工日期");
            dt.Columns.Add("財產編號");
            dt.Columns.Add("設備名稱");
            dt.Columns.Add("成本中心");
            dt.Columns.Add("部門名稱");
            dt.Columns.Add("故障描述");
            dt.Columns.Add("故障原因");
            dt.Columns.Add("處理描述");
            dt.Columns.Add("維修方式");
            dt.Columns.Add("工程師代號");
            dt.Columns.Add("工程師");
            dt.Columns.Add("目前關卡人員");
            dt.Columns.Add("維修總工時");
            dt.Columns.Add("維修費用");
            dt.Columns.Add("基數");
            dt.Columns.Add("數量");
            dt.Columns.Add("關帳年月");
            dt.Columns.Add("處理狀況");
            dt.Columns.Add("放置地點");
            dt.Columns.Add("[是][否]為器械");
            dt.Columns.Add("[是][否]為資安事件");
            dt.Columns.Add("資料別");
            List<MonthRepairVModel> mv = MonthRepair(v);
            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = "請修";
                dw[1] = m.DocId;
                dw[2] = m.ApplyDate.ToString("yyyy/MM/dd");
                dw[3] = m.EndDate != null ? m.EndDate.Value.ToString("yyyy/MM/dd") : "";
                dw[4] = m.AssetNo;
                dw[5] = m.AssetNam;
                dw[6] = m.AccDpt;
                dw[7] = m.AccDptNam;
                dw[8] = m.TroubleDes;
                dw[9] = m.FailFactor;
                dw[10] = m.DealDes;
                dw[11] = m.InOut;
                dw[12] = m.EngNam;
                dw[13] = m.EngNam;
                dw[14] = m.ClsNam;
                dw[15] = m.Hour;
                dw[16] = m.Cost;
                dw[17] = m.Shares;
                dw[18] = m.Amt;
                dw[19] = m.ShutDateYm;
                dw[20] = m.DealState;
                dw[21] = m.PlaceLoc;
                dw[22] = m.IsInstrument;
                dw[23] = m.IsSecurity;
                dw[24] = m.StockType;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("月維修清單");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "MonthRepair.xlsx"
            );
        }

        public List<MonthRepairVModel> MonthRepair(ReportQryVModel v)
        {
            TempData["qry"] = JsonConvert.SerializeObject(v);
            List<MonthRepairVModel> mv = new List<MonthRepairVModel>();

            var urLocation = v.Location;
            //
            var data = _context.BMEDRepairs.AsQueryable();
            var repairDtls = _context.BMEDRepairDtls.AsQueryable();
            var assets = _context.BMEDAssets.Join(_context.BMEDAssetKeeps, a => a.AssetNo, ak => ak.AssetNo,
                                (a, ak) => new
                                {
                                    asset = a,
                                    assetkeep = ak
                                }).AsQueryable();
            var dateType = v.DateType;
            if (dateType == "申請日")
            {
                if (v.Sdate != null)
                    data = data.Where(r => r.ApplyDate >= v.Sdate);
                if (v.Edate != null)
                    data = data.Where(r => r.ApplyDate <= v.Edate);
            }
            else
            {
                if (v.Sdate != null)
                    repairDtls = repairDtls.Where(r => r.EndDate != null).Where(r => r.EndDate >= v.Sdate);
                if (v.Edate != null)
                    repairDtls = repairDtls.Where(r => r.EndDate != null).Where(r => r.EndDate <= v.Edate);
            }
            mv = repairDtls
           .Join(data.Where(r => r.Loc == urLocation), rd => rd.DocId, k => k.DocId,
           (rd, k) => new
           {
               rd.DocId,
               k.AccDpt,
               k.ApplyDate,
               k.AssetNo,
               rd.Cost,
               rd.EndDate,
               rd.FailFactor,
               rd.DealDes,
               rd.DealState,
               k.TroubleDes,
               rd.InOut,
               k.AssetName,
               rd.Hour,
               k.PlantClass,
               rd.ShutDate,
               k.PlaceLoc,
               k.Amt
           })
           .Join(_context.Departments, k => k.AccDpt, c => c.DptId,
           (k, c) => new
           {
               k.DocId,
               k.AccDpt,
               c.Name_C,
               ApplyDate = k.ApplyDate,
               k.AssetNo,
               Cost = k.Cost,
               EndDate = k.EndDate,
               
               k.FailFactor,
               k.TroubleDes,
               k.DealDes,
               k.DealState,
               k.InOut,
               k.AssetName,
               k.Hour,
               k.PlantClass,
               k.ShutDate,
               k.PlaceLoc,
               k.Amt
           })
           .GroupJoin(_context.BMEDRepairEmps, k => k.DocId, ke => ke.DocId,
            (k, ke) => new { k, ke })
            .SelectMany(oi => oi.ke.DefaultIfEmpty(),
            (k, ke) => new
           {
               k.k.DocId,
               k.k.AccDpt,
               k.k.Name_C,
               k.k.ApplyDate,
               k.k.AssetNo,
               k.k.Cost,
               k.k.EndDate,
               k.k.TroubleDes,
               k.k.FailFactor,
               k.k.DealDes,
               k.k.DealState,
               k.k.InOut,
               ke.UserId,
               k.k.AssetName,
               k.k.Hour,
               k.k.PlantClass,
               k.k.ShutDate,
               k.k.PlaceLoc,
               k.k.Amt
           })
           .GroupJoin(_context.BMEDDealStatuses, k => k.DealState, d => d.Id,
            (k, d) => new { k, d })
            .SelectMany(oi => oi.d.DefaultIfEmpty(),
            (k, d) => new
            {
                k.k.DocId,
                k.k.AccDpt,
                k.k.Name_C,
                k.k.ApplyDate,
                k.k.AssetNo,
                k.k.Cost,
                k.k.EndDate,
                k.k.TroubleDes,
                k.k.FailFactor,
                k.k.DealDes,
                k.k.DealState,
                k.k.InOut,
                k.k.UserId,
                k.k.AssetName,
                k.k.Hour,
                k.k.PlantClass,
                k.k.ShutDate,
                DealTitle = d.Title,
                k.k.PlaceLoc,
                k.k.Amt
            })
            .GroupJoin(_context.BMEDFailFactors, k => k.FailFactor, f => f.Id,
            (k, f) => new { k, f })
            .SelectMany(oi => oi.f.DefaultIfEmpty(),
            (k, f) => new
            {
                k.k.DocId,
                k.k.AccDpt,
                k.k.Name_C,
                k.k.ApplyDate,
                k.k.AssetNo,
                k.k.Cost,
                k.k.EndDate,
                k.k.TroubleDes,
                k.k.FailFactor,
                k.k.DealDes,
                k.k.DealState,
                k.k.InOut,
                k.k.UserId,
                k.k.AssetName,
                k.k.Hour,
                k.k.PlantClass,
                k.k.ShutDate,
                k.k.DealTitle,
                FailTitle = f.Title,
                k.k.PlaceLoc,
                k.k.Amt
            })
            .GroupJoin(assets, k => k.AssetNo, a => a.asset.AssetNo,
            (k, a) => new { k, a })
            .SelectMany(oi => oi.a.DefaultIfEmpty(),
            (k, a) => new
            {
                k.k.DocId,
                k.k.AccDpt,
                k.k.Name_C,
                k.k.ApplyDate,
                k.k.AssetNo,
                k.k.Cost,
                k.k.EndDate,
                k.k.TroubleDes,
                k.k.FailFactor,
                k.k.DealDes,
                k.k.DealState,
                k.k.InOut,
                k.k.UserId,
                k.k.AssetName,
                k.k.Hour,
                k.k.PlantClass,
                k.k.ShutDate,
                k.k.DealTitle,
                k.k.FailTitle,
                a.asset,
                a.assetkeep,
                k.k.PlaceLoc,
                k.k.Amt
            })
            .Join(_context.BMEDRepairFlows.Where(f => f.Status == "?" || f.Status == "2")
            , k => k.DocId, 
              kf => kf.DocId,
             (k, kf) => new
             {
                repairV = k,
                kf
            })
            .GroupJoin(_context.AppUsers, k => k.kf.UserId, u => u.Id,
            (k, u) => new { k, u })
            .SelectMany(ui => ui.u.DefaultIfEmpty(),
            (k, u) => new
            {
                k.k.repairV.DocId,
                k.k.repairV.AccDpt,
                k.k.repairV.Name_C,
                k.k.repairV.ApplyDate,
                k.k.repairV.AssetNo,
                //k.k.Cname,
                k.k.repairV.Cost,
                k.k.repairV.EndDate,
                k.k.repairV.TroubleDes,
                k.k.repairV.FailFactor,
                k.k.repairV.DealDes,
                k.k.repairV.DealState,
                k.k.repairV.InOut,
                //k.k.Type,
                //k.k.AssetClass,
                k.k.repairV.UserId,
                u.FullName,
                k.k.repairV.AssetName,
                k.k.repairV.Hour,
                k.k.repairV.PlantClass,
                //kf.UserId
            })
            .GroupJoin(_context.BMEDRepairCosts, k => k.DocId, c => c.DocId,
            (k, cost) => new { k, cost })
            .SelectMany(c => c.cost.DefaultIfEmpty(),
            (k, c) => new
            {
                k.k.DocId,
                k.k.AccDpt,
                k.k.Name_C,
                k.k.ApplyDate,
                k.k.AssetNo,
                //k.k.Cname,
                k.k.Cost,
                k.k.EndDate,
                k.k.TroubleDes,
                k.k.FailFactor,
                k.k.DealDes,
                k.k.DealState,
                k.k.InOut,
                //k.k.Type,
                //k.k.AssetClass,
                k.k.UserId,
                k.k.FullName,
                k.k.AssetName,
                k.k.Hour,
                k.k.PlantClass,
                StockType = c.StockType  == "2" ? "發票" : c.StockType == "0" ? "庫存":""
                //kf.UserId
            })
            .GroupJoin(_context.BMEDRepairDtls, k => k.DocId, d => d.DocId,
            (k, dtl) => new { k, dtl })
            .SelectMany(d => d.dtl.DefaultIfEmpty(),
            (k, d) => new
            {
                k.k.DocId,
                k.k.AccDpt,
                k.k.Name_C,
                k.k.ApplyDate,
                k.k.AssetNo,
                //k.k.Cname,
                k.k.Cost,
                k.k.EndDate,
                k.k.TroubleDes,
                k.k.FailFactor,
                k.k.DealDes,
                k.k.DealState,
                k.k.InOut,
                //k.k.Type,
                //k.k.AssetClass,
                k.k.UserId,
                k.k.FullName,
                k.k.AssetName,
                k.k.Hour,
                k.k.PlantClass,
                k.k.StockType,
                d.IsInstrument,
                d.IsSecurity
                //kf.UserId
            })
            .GroupJoin(_context.AppUsers, k => k.UserId, u => u.Id,
            (k, u) => new { k, u })
            .SelectMany(ui => ui.u.DefaultIfEmpty(),
            (k, u) => new MonthRepairVModel
           {
               DocId = k.k.DocId,
               AccDpt = k.k.AccDpt,
               AccDptNam = k.k.Name_C,
               ApplyDate = k.k.ApplyDate,
               AssetNo = k.k.AssetNo == "000" ? "無財編" : k.k.AssetNo,
               AssetNam = k.k.AssetName,
               Cost = k.k.Cost,
               EndDate = k.k.EndDate,
               FailFactor = Convert.ToString(k.k.FailFactor),
               DealDes = k.k.DealDes,
               DealState = Convert.ToString(k.k.DealState),
               InOut = k.k.InOut,
               TroubleDes = k.k.TroubleDes,
               Type = "",
               EngNamNo = u.UserName,
               EngNam =  u.FullName,
               ClsNam = k.k.FullName,
               AssetClass = "",
               Hour = k.k.Hour,
               PlantClass = k.k.PlantClass,
                IsInstrument = k.k.IsInstrument,
                IsSecurity = k.k.IsSecurity,
                StockType = k.k.StockType
            })
            //.Where(m => m.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
            .GroupJoin(_context.BMEDFailFactors, m => m.FailFactor.ToString(), f => f.Id.ToString(),
            (m, f) => new { m, f })
            .SelectMany(fa => fa.f.DefaultIfEmpty(),
            (m, f) => new
            {
                m.m.DocId,
                m.m.AccDpt,
                m.m.AccDptNam,
                m.m.ApplyDate,
                m.m.AssetNo,
                m.m.AssetNam,
                m.m.Cost,
                m.m.EndDate,
                f.Title,
                m.m.DealDes,
                m.m.DealState,
                m.m.InOut,
                m.m.TroubleDes,
                m.m.Type,
                m.m.EngNam,
                m.m.ClsNam,
                m.m.AssetClass,
                m.m.Hour,
                m.m.PlantClass,
                m.m.IsInstrument,
                m.m.IsSecurity,
                m.m.StockType,
                m.m.EngNamNo
            })
            .GroupJoin(_context.BMEDDealStatuses, m => m.DealState, d => d.Id.ToString(),
            (m, d) => new { m, d })
            .SelectMany(ds => ds.d.DefaultIfEmpty(),
            (m, d) => new MonthRepairVModel
            {
                DocId = m.m.DocId,
                AccDpt = m.m.AccDpt,
                AccDptNam = m.m.AccDptNam,
                ApplyDate = m.m.ApplyDate,
                AssetNo = m.m.AssetNo,
                AssetNam = m.m.AssetNam,
                Cost = m.m.Cost,
                EndDate = m.m.EndDate,
                FailFactor = m.m.Title,
                DealDes = m.m.DealDes,
                DealState = d.Title,
                InOut = m.m.InOut,
                TroubleDes = m.m.TroubleDes,
                Type = m.m.Type,
                EngNam = m.m.EngNam,
                ClsNam = m.m.ClsNam,
                AssetClass = m.m.AssetClass,
                Hour = m.m.Hour,
                PlantClass = m.m.PlantClass,
                IsInstrument = m.m.IsInstrument,
                IsSecurity = m.m.IsSecurity,
                StockType = m.m.StockType,
                EngNamNo = m.m.EngNamNo
            })
            .ToList();

            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                mv = mv.Where(vv => vv.AccDpt == v.AccDpt).ToList();
            }
            return mv;
        }

        public IActionResult ExcelMK(ReportQryVModel v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("類別");
            dt.Columns.Add("表單編號");
            dt.Columns.Add("送單日期");
            dt.Columns.Add("完工日期");
            dt.Columns.Add("財產編號");
            dt.Columns.Add("儀器名稱");
            dt.Columns.Add("成本中心");
            dt.Columns.Add("成本中心名稱");
            dt.Columns.Add("意見描述");
            dt.Columns.Add("保養結果");
            dt.Columns.Add("保養方式");
            dt.Columns.Add("工程師");
            dt.Columns.Add("保養週期");
            dt.Columns.Add("保養工時");
            dt.Columns.Add("保養費用");
            dt.Columns.Add("計算基數");
            dt.Columns.Add("關帳年月");
            dt.Columns.Add("存放地點");

            List<MonthKeepVModel> mv = MonthKeep(v);
            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = "保養";
                dw[1] = m.DocId;
                dw[2] = m.SentDate.ToString("yyyy/MM/dd");
                dw[3] = m.EndDate != null ? m.EndDate.Value.ToString("yyyy/MM/dd") : "";
                dw[4] = m.AssetNo;
                dw[5] = m.AssetNam;
                dw[6] = m.AccDpt;
                dw[7] = m.AccDptNam;
                dw[8] = m.DealDes;
                dw[9] = m.Result;
                dw[10] = m.InOut;
                dw[11] = m.EngNam;
                dw[12] = m.Cycle;
                dw[13] = m.Hours;
                dw[14] = m.Cost;
                dw[15] = Convert.ToDecimal(m.Shares);
                dw[16] = m.ShutDateYm;
                dw[17] = m.LeaveSite;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("月保養清單");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "MonthKeep.xlsx"
            );
        }
        public List<MonthKeepVModel> MonthKeep(ReportQryVModel v)
        {

            var urLocation = v.Location;
            //
            TempData["qry"] = JsonConvert.SerializeObject(v);
            List<MonthKeepVModel> mv = new List<MonthKeepVModel>();
            string s = "";
            var data = _context.BMEDKeeps.AsQueryable();
            var keepDtls = _context.BMEDKeepDtls
                            .Join(_context.BMEDKeepFlows.Where(f => f.Status == "?" || f.Status == "2"),
                                  d => d.DocId,
                                  kf => kf.DocId,
                                 (d, kf) => d);
            var assets = _context.BMEDAssets.Join(_context.BMEDAssetKeeps, a => a.AssetNo, ak => ak.AssetNo,
                                            (a, ak) => new
                                            {
                                                asset = a,
                                                assetkeep = ak
                                            }).AsQueryable();
            var dateType = v.DateType;
            if (dateType == "申請日")
            {
                if (v.Sdate != null)
                    data = data.Where(k => k.SentDate >= v.Sdate);
                if (v.Edate != null)
                    data = data.Where(k => k.SentDate <= v.Edate);
            }
            else
            {
                if (v.Sdate != null)
                    keepDtls = keepDtls.Where(k => k.EndDate != null).Where(k => k.EndDate >= v.Sdate);
                if (v.Edate != null)
                    keepDtls = keepDtls.Where(k => k.EndDate != null).Where(k => k.EndDate <= v.Edate);
            }

            keepDtls
           .Join(data.Where(r => r.Loc == urLocation), rd => rd.DocId, k => k.DocId,
           (rd, k) => new
           {
               rd.DocId,
               k.AccDpt,
               k.SentDate,
               k.AssetNo,
               k.AssetName,
               k.Cycle,
               rd.Cost,
               rd.EndDate,
               rd.ShutDate,
               rd.Memo,
               rd.InOut,
               rd.Result,
               rd.Hours
           })
           .Join(_context.Departments, k => k.AccDpt, c => c.DptId,
           (k, c) => new
           {
               k.DocId,
               k.AccDpt,
               c.Name_C,
               SentDate = k.SentDate.Value,
               k.AssetNo,
               k.Cycle,
               Cost = k.Cost == null ? 0 : k.Cost.Value,
               EndDate = k.EndDate.Value,
               ShutDate = k.ShutDate.Value,
               k.Memo,
               k.InOut,
               k.AssetName,
               k.Result,
               k.Hours
           })
           .GroupJoin(_context.BMEDKeepEmps, k => k.DocId, ke => ke.DocId,
            (k, ke) => new { k, ke })
            .SelectMany(oi => oi.ke.DefaultIfEmpty(),
            (k, ke) => new
            {
                k.k.DocId,
                k.k.AccDpt,
                k.k.Name_C,
                k.k.SentDate,
                k.k.AssetNo,
                k.k.AssetName,
                k.k.Cycle,
                k.k.Cost,
                k.k.EndDate,
                k.k.ShutDate,
                k.k.Memo,
                k.k.InOut,
                k.k.Result,
                k.k.Hours,
                ke.UserId
            })
            .GroupJoin(_context.BMEDKeepResults, k => k.Result, ke => ke.Id,
            (k, ke) => new { k, ke })
            .SelectMany(oi => oi.ke.DefaultIfEmpty(),
            (k, ke) => new
            {
                k.k.DocId,
                k.k.AccDpt,
                k.k.Name_C,
                k.k.SentDate,
                k.k.AssetNo,
                k.k.AssetName,
                k.k.Cycle,
                k.k.Cost,
                k.k.EndDate,
                k.k.ShutDate,
                k.k.Memo,
                k.k.InOut,
                k.k.Result,
                k.k.Hours,
                k.k.UserId,
                ke.Title
            })
            .GroupJoin(assets, k => k.AssetNo, a => a.asset.AssetNo,
            (k, a) => new { k, a })
            .SelectMany(oi => oi.a.DefaultIfEmpty(),
            (k, a) => new
            {
                k.k.DocId,
                k.k.AccDpt,
                k.k.Name_C,
                k.k.SentDate,
                k.k.AssetNo,
                k.k.AssetName,
                k.k.Cycle,
                k.k.Cost,
                k.k.EndDate,
                k.k.ShutDate,
                k.k.Memo,
                k.k.InOut,
                k.k.Result,
                k.k.Hours,
                k.k.UserId,
                k.k.Title,
                a.asset,
                a.assetkeep
            })
            .GroupJoin(_context.AppUsers, k => k.UserId, u => u.Id,
            (k, u) => new { k, u })
            .SelectMany(ui => ui.u.DefaultIfEmpty(),
            (k, u) => new MonthKeepVModel
            {
                DocId = k.k.DocId,
                AccDpt = k.k.AccDpt,
                AccDptNam = k.k.Name_C,
                SentDate = k.k.SentDate,
                AssetNo = k.k.AssetNo,
                AssetNam = k.k.AssetName,
                Cycle = k.k.Cycle,
                Cost = k.k.Cost,
                EndDate = k.k.EndDate,
                DealDes = k.k.Memo,
                InOut = k.k.InOut,
                Result = k.k.Title,
                Hours = k.k.Hours,
                Shares = k.k.asset != null ? k.k.asset.Shares : 0,
                ShutDateYm = k.k.ShutDate != null ? (k.k.ShutDate.Year - 1911).ToString() + k.k.ShutDate.Month.ToString("mm") : "",
                AssetClass = "",
                EngNam = "(" + u.UserName + ")" + u.FullName,
                LeaveSite = k.k.asset != null ? k.k.asset.LeaveSite : "",
            })
            //.Where(m => m.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
            .ToList()
            .ForEach(m =>
            {
                switch (m.InOut)
                {
                    case "0":
                        s = "自行";
                        break;
                    case "1":
                        s = "委外";
                        break;
                    case "2":
                        s = "租賃";
                        break;
                    case "3":
                        s = "保固";
                        break;
                    case "4":
                        s = "借用";
                        break;
                }
                m.InOut = s;
                mv.Add(m);
            });
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                mv = mv.Where(vv => vv.AccDpt == v.AccDpt).ToList();
            }
            //Sort
            mv = mv.OrderBy(m => m.DocId).ToList();
            return mv;
        }
        public IActionResult MonthFailRateExcel(ReportQryVModel v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("單位代號");
            dt.Columns.Add("單位名稱");
            dt.Columns.Add("故障率");
            dt.Columns.Add("設備件數");
            dt.Columns.Add("維修件數");
           
            List<MonthFailRateVModel> mv = MonthFailRate(v);
            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.CustId;
                dw[1] = m.CustNam;
                dw[2] = m.FailRate;
                dw[3] = m.PlantAmt;
                dw[4] = m.RepairAmt;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("月故障率統計表");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "MonthFailRate.xlsx"
            );
        }

        public List<RepairKeepVModel> RepairKeep(ReportQryVModel v)
        {
            var urLocation = v.Location;
            // Get departments by location.
            var departments = GetDepartmentsByLoc(urLocation);
            //
            List<RepairKeepVModel> mv = new List<RepairKeepVModel>();
            RepairKeepVModel m;
            int rcnt = 0;
            int kcnt = 0;
            decimal tolcost = 0m;
            var ss = new[] { "?", "2" };
            //
            var repairF = _context.BMEDRepairFlows
                          .Where(f => ss.Contains(f.Status));
            //
            var assets = _context.BMEDAssets
                          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                          .GroupJoin(departments, 
                                a => a.AccDpt,
                                p => p.DptId,
                                (a ,p) => new { asset = a , dep = p})
                          .SelectMany( x => x.dep.DefaultIfEmpty() , 
                                       (a, p) => new { asset = a.asset, dep = p });

            var repairs = _context.BMEDRepairs.Where(r => r.Loc == urLocation)
                        .Where(r => r.ApplyDate >= v.Sdate)
                        .Where(r => r.ApplyDate <= v.Edate)
                        .Join(repairF,
                              r => r.DocId,
                              f => f.DocId,
                              (r, f) => r)
                        .Join(assets,
                               rd => rd.AssetNo,
                               r => r.asset.AssetNo,
                               (rd, r) => new { rep = rd , aet = r});

            var repairsCount = repairs
                             .GroupBy(x => x.aet.asset.AccDpt)
                             .ToDictionary(x => x.Key, x => x.Count());

            

            var repairDtls = _context.BMEDRepairDtls.Where(d => d.EndDate != null);

            var repairsRcnt = repairs
                            .Join(repairDtls,
                                  rd => rd.rep.DocId, 
                                  r => r.DocId,
                                  (rd, r) => rd)
                            .GroupBy(x => x.aet.asset.AccDpt)
                            .ToDictionary( x => x.Key ,
                                           x => x.Count());

            var costs = _context.BMEDRepairCosts.Where(c => c.TotalCost > 0);

            var repairC = repairs
                        .Join(
                              costs, 
                              rd => rd.rep.DocId, 
                              c => c.DocId,
                              (rd, c) => new { repc = rd , cost = c })
                        .GroupBy(x => x.repc.aet.asset.AccDpt)
                        .ToDictionary( x => x.Key , x => x.Select(c => c.cost.TotalCost).DefaultIfEmpty(0).Sum());

            //保養
            var KeepF = _context.BMEDKeepFlows
                          .Where(f => ss.Contains(f.Status));

          
            var keeps = _context.BMEDKeeps.Where(r => r.Loc == urLocation)
                        .Where(r => r.SentDate >= v.Sdate)
                        .Where(r => r.SentDate <= v.Edate)
                        .Join(KeepF,
                              r => r.DocId,
                              f => f.DocId,
                              (r, f) => r)
                        .Join(assets,
                               kd => kd.AssetNo,
                               r => r.asset.AssetNo,
                               (kd, r) => new { kep = kd, ast = r });

            var keepsCount = keeps
                             .GroupBy(x => x.ast.asset.AccDpt)
                             .ToDictionary(x => x.Key, x => x.Count());



            var keepDtls = _context.BMEDKeepDtls.Where(d => d.EndDate != null);

            var keepsRcnt = keeps
                            .Join(keepDtls,
                                  rd => rd.kep.DocId,
                                  r => r.DocId,
                                  (rd, r) => rd)
                            .GroupBy(x => x.ast.asset.AccDpt)
                            .ToDictionary(x => x.Key,
                                           x => x.Count());

            var costKs = _context.BMEDKeepCosts.Where(c => c.TotalCost > 0);
            
            var keepC = keeps
                        .Join(
                              costKs,
                              kd => kd.kep.DocId,
                              c => c.DocId,
                              (rd, c) => new { kepc = rd, cost = c })
                        .GroupBy(x => x.kepc.ast.asset.AccDpt)
                        .ToDictionary(x => x.Key, x => x.Select(c => c.cost.TotalCost).DefaultIfEmpty(0).Sum());


            foreach (DepartmentModel p in departments)
            {
                m = new RepairKeepVModel();
                m.CustId = p.DptId;
                m.CustNam = p.Name_C;
                rcnt = 0;
                kcnt = 0;
                tolcost = 0m;
               
                //List<RepairModel> rs = _context.BMEDRepairs.Where(r => r.Loc == urLocation)
                //    .Where(r => r.ApplyDate >= v.Sdate)
                //    .Where(r => r.ApplyDate <= v.Edate)
                //    .Join(_context.BMEDRepairFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                //    (r, f) => r)
                //    .Join(_context.BMEDAssets
                //          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                //          .Where(r => r.AccDpt == p.DptId), rd => rd.AssetNo, r => r.AssetNo,
                //          (rd, r) => rd).ToList();
                //
                //rcnt = rs.Join(_context.BMEDRepairDtls.Where(d => d.EndDate != null),
                //          rd => rd.DocId, r => r.DocId,
                //          (rd, r) => rd).ToList().Count();
                //m.RpEndAmt = rcnt;
                m.RpEndAmt = repairsRcnt.ContainsKey(p.DptId) == false ? 0 : repairsRcnt[p.DptId];
                //m.RepairAmt = rs.Count();
                m.RepairAmt = repairsCount.ContainsKey(p.DptId) == false ? 0 : repairsCount[p.DptId];
                if (rcnt > 0)
                {
                    m.RepFinishedRate =
                        decimal.Round(Convert.ToDecimal(rcnt) / Convert.ToDecimal(m.RepairAmt) * 100m, 2);
                }
                else
                    m.RepFinishedRate = 0m;
                //目前沒有維護費用所以先省略
                tolcost = 0m;
                //tolcost = rs.Join(_context.BMEDRepairCosts.Where(c => c.TotalCost > 0), rd => rd.DocId, c => c.DocId,
                //         (rd, c) => c).Select(c => c.TotalCost).DefaultIfEmpty(0).Sum();
                tolcost = repairC.ContainsKey(p.DptId) == false ? 0 : repairC[p.DptId];

                m.RepCost = tolcost;
                //
                //List<KeepModel> ks = _context.BMEDKeeps.Where(r => r.Loc == urLocation)
                //    .Where(r => r.SentDate >= v.Sdate)
                //   .Where(r => r.SentDate <= v.Edate)
                //   .Join(_context.BMEDKeepFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                //   (r, f) => r).Join(_context.BMEDAssets
                //          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                //          .Where(r => r.AccDpt == p.DptId), rd => rd.AssetNo, r => r.AssetNo,
                //          (rd, r) => rd).ToList();

                //kcnt = ks.Join(_context.BMEDKeepDtls.Where(d => d.EndDate != null),
                //          rd => rd.DocId, r => r.DocId,
                //          (rd, r) => rd).ToList()
                //          .Count();
                //m.KpEndAmt = kcnt;
                m.KpEndAmt = keepsRcnt.ContainsKey(p.DptId) == false ? 0 : keepsRcnt[p.DptId]; 
                //m.KeepAmt = ks.Count();
                m.KeepAmt = keepsCount.ContainsKey(p.DptId) == false ? 0 : keepsCount[p.DptId];
                if (kcnt > 0)
                {
                    m.KeepFinishedRate =
                        decimal.Round(Convert.ToDecimal(kcnt) / Convert.ToDecimal(m.KeepAmt) * 100m, 2);
                }
                else
                    m.KeepFinishedRate = 0m;
                tolcost = 0m;
                //tolcost = ks.Join(_context.BMEDKeepCosts.Where(c => c.TotalCost > 0), rd => rd.DocId, c => c.DocId,
                //          (rd, c) => c).Select(c => c.TotalCost).DefaultIfEmpty(0).Sum();
                tolcost = keepC.ContainsKey(p.DptId) == false ? 0 : keepC[p.DptId];

                m.KeepCost = tolcost;
                mv.Add(m);
            }
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                mv = mv.Where(vv => vv.CustId == v.AccDpt).ToList();
            }
            return mv;
        }
        public IPagedList<RepairKeepVModel> RepairCost(ReportQryVModel v, int page = 1)
        {
            var urLocation =v.Location;
            //
            List<RepairKeepVModel> mv = new List<RepairKeepVModel>();
            RepairKeepVModel m;
            int rcnt = 0;
            int kcnt = 0;
            decimal tolcost = 0m;
            var ss = new[] { "?", "2" };
            TempData["qry"] = JsonConvert.SerializeObject(v);

            var assets = _context.BMEDAssets.Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                          .Join(_context.Departments, c => c.AccDpt, d => d.DptId,
                          (asset, dpt) => asset);
            var repairM = _context.BMEDRepairs
                    .Where(r => r.Loc == urLocation)
                    .Where(r => r.ApplyDate >= v.Sdate)
                    .Where(r => r.ApplyDate <= v.Edate)
                    .Join(_context.BMEDRepairFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId, 
                    (r, f) => r)
                    .Join(assets, rd => rd.AssetNo, r => r.AssetNo,
                          (rd, r) => new { rd = rd, r = r });

            var rs = repairM.GroupBy(g => g.r.AccDpt)
                    //.Select(g => new { Country = g.Key, CustCount = g.Count() })
                    .ToDictionary(o => o.Key, o => o.Count());

            var repairDtl = repairM.Join(_context.BMEDRepairDtls.Where(d => d.EndDate != null), rm => rm.rd.DocId, rdl => rdl.DocId,
                                    (rm, rdl) => new { rm = rm, rdl = rdl })
                                    .GroupBy(g => g.rm.r.AccDpt)
                                    //.Select(g => new { Country = g.Key, CustCount = g.Count() })
                                    .ToDictionary(o => o.Key, o => o.Count());
           
            var tols = repairM.GroupJoin(_context.BMEDRepairCosts.Where(c => c.TotalCost > 0),
                                         d => d.rd.DocId,
                                         c => c.DocId, 
                                         (d, c) => new { repM = d, repCost = c }
                                         )
                              .SelectMany(s => s.repCost.Select(c => c.TotalCost).DefaultIfEmpty(0).DefaultIfEmpty(),
                                          (r, c) => new { repM = r.repM, repCost = c }
                                         )
                              .GroupBy(g => g.repM.r.AccDpt)
                              .ToDictionary(o => o.Key, o => o.Select(c => c.repCost).Sum());

            var keepM = _context.BMEDKeeps.Where(r => r.Loc == urLocation)
                                          .Where(r => r.SentDate >= v.Sdate)
                                          .Where(r => r.SentDate <= v.Edate)
                                          .Join(_context.BMEDKeepFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                                          (r, f) => r)
                                          .Join(assets, rd => rd.AssetNo, r => r.AssetNo, 
                                          (rd, r) => new { rd = rd, r = r });

            var km = keepM.GroupBy(g => g.r.AccDpt)
                     .ToDictionary(o => o.Key, o => o.Count());

            var repairDk = keepM.Join(_context.BMEDKeepDtls.Where(d => d.EndDate != null),
                          rm => rm.rd.DocId, rdl => rdl.DocId,
                          (rm, rdl) => new { rm = rm, rdl = rdl })
                     .GroupBy(g => g.rm.r.AccDpt)
                    .ToDictionary(o => o.Key, o => o.Count());
            var keeptols = keepM.GroupJoin(
                                _context.BMEDKeepCosts.Where(c => c.TotalCost > 0)
                                , d => d.rd.DocId
                                , c => c.DocId
                                , (d, c) => new { repM = d, repCost = c })
                              .SelectMany(s => s.repCost.Select(c => c.TotalCost).DefaultIfEmpty(0).DefaultIfEmpty(),
                              (r, c) => new { repM = r.repM, repCost = c })
                              .GroupBy(g => g.repM.r.AccDpt)
                              .ToDictionary(o => o.Key, o => o.Select(c => c.repCost).Sum());



            foreach (DepartmentModel p in _context.Departments.ToList())
            {
                m = new RepairKeepVModel();
                m.CustId = p.DptId;
                m.CustNam = p.Name_C;
                rcnt = 0;
                kcnt = 0;
                tolcost = 0m;
                
                //var ss = new[] { "?", "2" };
                //var sr = _context.BMEDRepairs.Where(r => r.Loc == urLocation)
                //    .Where(r => r.ApplyDate >= v.Sdate)
                //    .Where(r => r.ApplyDate <= v.Edate)
                //    .Join(_context.BMEDRepairFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                //    (r, f) => r).Join(_context.BMEDAssets
                //          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                //          .Where(r => r.AccDpt == p.DptId)
                //          , rd => rd.AssetNo, r => r.AssetNo,
                //          (rd, r) => rd);
                //
                //rcnt = sr.Join(_context.BMEDRepairDtls.Where(d => d.EndDate != null),
                //          rd => rd.DocId, r => r.DocId,
                //          (rd, r) => rd).Count();

                rcnt = repairDtl.ContainsKey(p.DptId) == false ? 0 : repairDtl[p.DptId];
                m.RpEndAmt = rcnt;
                //m.RepairAmt = rs.Count();
                m.RepairAmt = rs.ContainsKey(p.DptId) == false ? 0 : rs[p.DptId];
                if (rcnt > 0)
                {
                    m.RepFinishedRate =
                        decimal.Round(Convert.ToDecimal(rcnt) / Convert.ToDecimal(m.RepairAmt) * 100m, 2);
                }
                else
                    m.RepFinishedRate = 0m;
                //目前沒有維護費用所以先省略
                tolcost = 0m;
                //tolcost = sr.Join(_context.BMEDRepairCosts.Where(c => c.TotalCost > 0), rd => rd.DocId, c => c.DocId,
                //         (rd, c) => c).Select(c => c.TotalCost).DefaultIfEmpty(0).Sum();
                tolcost = tols.ContainsKey(p.DptId) == false ? 0 : tols[p.DptId];
                m.RepCost = tolcost;
                //
                //List<KeepModel> ks = _context.BMEDKeeps.Where(r => r.Loc == urLocation)
                //    .Where(r => r.SentDate >= v.Sdate)
                //   .Where(r => r.SentDate <= v.Edate)
                //   .Join(_context.BMEDKeepFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                //   (r, f) => r).Join(_context.BMEDAssets
                //          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                //          .Where(r => r.AccDpt == p.DptId), rd => rd.AssetNo, r => r.AssetNo,
                //          (rd, r) => rd).ToList();

                ////kcnt = ks.Join(_context.BMEDKeepDtls.Where(d => d.EndDate != null),
                //          rd => rd.DocId, r => r.DocId,
                //          (rd, r) => rd).ToList()
                //          .Count();
                kcnt = repairDk.ContainsKey(p.DptId) == false ? 0 : repairDk[p.DptId];
                m.KpEndAmt = kcnt;
                //m.KeepAmt = ks.Count();
                m.KeepAmt = km.ContainsKey(p.DptId) == false ? 0 : km[p.DptId];

                if (kcnt > 0)
                {
                    m.KeepFinishedRate =
                        decimal.Round(Convert.ToDecimal(kcnt) / Convert.ToDecimal(m.KeepAmt) * 100m, 2);
                }
                else
                    m.KeepFinishedRate = 0m;
                tolcost = 0m;
                //tolcost = ks.Join(_context.BMEDKeepCosts.Where(c => c.TotalCost > 0), rd => rd.DocId, c => c.DocId,
                //          (rd, c) => c).Select(c => c.TotalCost).DefaultIfEmpty(0).Sum();

                tolcost = keeptols.ContainsKey(p.DptId) == false ? 0 : keeptols[p.DptId];

                m.KeepCost = tolcost;
                mv.Add(m);
            }
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                mv = mv.Where(vv => vv.CustId == v.AccDpt)
                       .OrderBy(c => c.CustNam)
                       .ThenBy(t => t.CustId).ToList();
            }

            //
            var pageCount = mv.ToPagedList(page, pageSize).PageCount;
            pageCount = pageCount == 0 ? 1 : pageCount; // If no page.
            if (mv.ToPagedList(page, pageSize).Count <= 0)  //If the page has no items.
                return mv.ToPagedList(pageCount, pageSize);
            return mv.ToPagedList(page, pageSize);

            //return mv;
        }

        public List<RepairKeepVModel> RepairCostAll(ReportQryVModel v)
        {
            var urLocation = v.Location;
            //
            List<RepairKeepVModel> mv = new List<RepairKeepVModel>();
            RepairKeepVModel m;
            int rcnt = 0;
            int kcnt = 0;
            decimal tolcost = 0m;
            var ss = new[] { "?", "2" };
            TempData["qry"] = JsonConvert.SerializeObject(v);

            var repairM = _context.BMEDRepairs
                    .Where(r => r.Loc == urLocation)
                    .Where(r => r.ApplyDate >= v.Sdate)
                    .Where(r => r.ApplyDate <= v.Edate)
                    .Join(_context.BMEDRepairFlows
                            .Where(f => ss.Contains(f.Status))
                            , r => r.DocId
                            , f => f.DocId
                            , (r, f) => r
                            )
                    .Join(_context.BMEDAssets
                          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                          .Join(_context.Departments
                                  , c => c.AccDpt
                                  , d => d.DptId
                                  , (bd, cd) => bd)
                          , rd => rd.AssetNo
                          , r => r.AssetNo,
                          (rd, r) => new { rd = rd, r = r });

            var rs = repairM.GroupBy(g => g.r.AccDpt)
                    .ToDictionary(o => o.Key, o => o.Count());

            var repairDtl = repairM.Join(_context.BMEDRepairDtls.Where(d => d.EndDate != null),
                          rm => rm.rd.DocId, rdl => rdl.DocId,
                          (rm, rdl) => new { rm = rm, rdl = rdl })
                     .GroupBy(g => g.rm.r.AccDpt)
                    .ToDictionary(o => o.Key, o => o.Count());


            var tols = repairM.GroupJoin(
                                _context.BMEDRepairCosts.Where(c => c.TotalCost > 0)
                                , d => d.rd.DocId
                                , c => c.DocId
                                , (d, c) => new { repM = d, repCost = c })
                              .SelectMany(s => s.repCost.Select(c => c.TotalCost).DefaultIfEmpty(0).DefaultIfEmpty(),
                              (r, c) => new { repM = r.repM, repCost = c })
                              .GroupBy(g => g.repM.r.AccDpt)
                              .ToDictionary(o => o.Key, o => o.Select(c => c.repCost).Sum());

            var keepM = _context.BMEDKeeps.Where(r => r.Loc == urLocation)
                    .Where(r => r.SentDate >= v.Sdate)
                   .Where(r => r.SentDate <= v.Edate)
                   .Join(_context.BMEDKeepFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                   (r, f) => r).Join(_context.BMEDAssets
                          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                         .Join(_context.Departments
                                  , c => c.AccDpt
                                  , d => d.DptId
                                  , (bd, cd) => bd)
                          , rd => rd.AssetNo
                          , r => r.AssetNo,
                          (rd, r) => new { rd = rd, r = r });

            var km = keepM.GroupBy(g => g.r.AccDpt)
                     .ToDictionary(o => o.Key, o => o.Count());

            var repairDk = keepM.Join(_context.BMEDKeepDtls.Where(d => d.EndDate != null),
                          rm => rm.rd.DocId, rdl => rdl.DocId,
                          (rm, rdl) => new { rm = rm, rdl = rdl })
                     .GroupBy(g => g.rm.r.AccDpt)
                    .ToDictionary(o => o.Key, o => o.Count());
            var keeptols = keepM.GroupJoin(
                                _context.BMEDKeepCosts.Where(c => c.TotalCost > 0)
                                , d => d.rd.DocId
                                , c => c.DocId
                                , (d, c) => new { repM = d, repCost = c })
                              .SelectMany(s => s.repCost.Select(c => c.TotalCost).DefaultIfEmpty(0).DefaultIfEmpty(),
                              (r, c) => new { repM = r.repM, repCost = c })
                              .GroupBy(g => g.repM.r.AccDpt)
                              .ToDictionary(o => o.Key, o => o.Select(c => c.repCost).Sum());



            foreach (DepartmentModel p in _context.Departments.ToList())
            {
                m = new RepairKeepVModel();
                m.CustId = p.DptId;
                m.CustNam = p.Name_C;
                rcnt = 0;
                kcnt = 0;
                tolcost = 0m;
                rcnt = repairDtl.ContainsKey(p.DptId) == false ? 0 : repairDtl[p.DptId];
                m.RpEndAmt = rcnt;
                m.RepairAmt = rs.ContainsKey(p.DptId) == false ? 0 : rs[p.DptId];
                if (rcnt > 0)
                {
                    m.RepFinishedRate =
                        decimal.Round(Convert.ToDecimal(rcnt) / Convert.ToDecimal(m.RepairAmt) * 100m, 2);
                }
                else
                    m.RepFinishedRate = 0m;
                //目前沒有維護費用所以先省略
                tolcost = 0m;
                tolcost = tols.ContainsKey(p.DptId) == false ? 0 : tols[p.DptId];
                m.RepCost = tolcost;
                kcnt = repairDk.ContainsKey(p.DptId) == false ? 0 : repairDk[p.DptId];
                m.KpEndAmt = kcnt;
                m.KeepAmt = km.ContainsKey(p.DptId) == false ? 0 : km[p.DptId];

                if (kcnt > 0)
                {
                    m.KeepFinishedRate =
                        decimal.Round(Convert.ToDecimal(kcnt) / Convert.ToDecimal(m.KeepAmt) * 100m, 2);
                }
                else
                    m.KeepFinishedRate = 0m;
                tolcost = 0m;
                tolcost = keeptols.ContainsKey(p.DptId) == false ? 0 : keeptols[p.DptId];

                m.KeepCost = tolcost;
                mv.Add(m);
            }
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                mv = mv.Where(vv => vv.CustId == v.AccDpt)
                       .OrderBy(c => c.CustNam)
                       .ThenBy(t => t.CustId).ToList();
            }

            return mv;
        }

        public IPagedList<RepairKeepVModel> KeepCost(ReportQryVModel v, int page = 1)
        {
            var urLocation = v.Location;
            //
            List<RepairKeepVModel> mv = new List<RepairKeepVModel>();
            RepairKeepVModel m;
            int rcnt = 0;
            int kcnt = 0;
            decimal tolcost = 0m;
            var ss = new[] { "?", "2" };
            TempData["qry"] = JsonConvert.SerializeObject(v);
            //維修
            var repairF = _context.BMEDRepairs
                    .Where(r => r.Loc == urLocation)
                    .Where(r => r.ApplyDate >= v.Sdate)
                    .Where(r => r.ApplyDate <= v.Edate)
                    .Join(_context.BMEDRepairFlows
                            .Where(f => ss.Contains(f.Status))
                            , r => r.DocId
                            , f => f.DocId
                            , (r, f) => r
                            )
                    .Join(_context.BMEDAssets
                          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                          .Join(_context.Departments
                                  , c => c.AccDpt
                                  , d => d.DptId
                                  , (bd, cd) => bd)
                          , rd => rd.AssetNo
                          , r => r.AssetNo,
                          (rd, r) => new { rd = rd, r = r });

            var sr = repairF.GroupBy(g => g.r.AccDpt)
                    .ToDictionary(o => o.Key, o => o.Count());

            var repairDtl = repairF.Join(_context.BMEDRepairDtls.Where(d => d.EndDate != null),
                          rm => rm.rd.DocId, rdl => rdl.DocId,
                          (rm, rdl) => new { rm = rm, rdl = rdl })
                     .GroupBy(g => g.rm.r.AccDpt)
                    //.Select(g => new { Country = g.Key, CustCount = g.Count() })
                    .ToDictionary(o => o.Key, o => o.Count());


            var tols = repairF.GroupJoin(
                                _context.BMEDRepairCosts.Where(c => c.TotalCost > 0)
                                , d => d.rd.DocId
                                , c => c.DocId
                                , (d, c) => new { repM = d, repCost = c })
                              .SelectMany(s => s.repCost.Select(c => c.TotalCost).DefaultIfEmpty(0).DefaultIfEmpty(),
                              (r, c) => new { repM = r.repM, repCost = c })
                              .GroupBy(g => g.repM.r.AccDpt)
                              .ToDictionary(o => o.Key, o => o.Select(c => c.repCost).Sum());
            //保養
            var keepM = _context.BMEDKeeps.Where(r => r.Loc == urLocation)
                   .Where(r => r.SentDate >= v.Sdate)
                   .Where(r => r.SentDate <= v.Edate)
                   .Join(_context.BMEDKeepFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                   (r, f) => r).Join(_context.BMEDAssets
                          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                         .Join(_context.Departments
                                  , c => c.AccDpt
                                  , d => d.DptId
                                  , (bd, cd) => bd)
                          , rd => rd.AssetNo
                          , r => r.AssetNo,
                          (rd, r) => new { rd = rd, r = r });

            var km = keepM.GroupBy(g => g.r.AccDpt)
                     .ToDictionary(o => o.Key, o => o.Count());

            var repairDk = keepM.Join(_context.BMEDKeepDtls.Where(d => d.EndDate != null),
                          rm => rm.rd.DocId, rdl => rdl.DocId,
                          (rm, rdl) => new { rm = rm, rdl = rdl })
                     .GroupBy(g => g.rm.r.AccDpt)
                    .ToDictionary(o => o.Key, o => o.Count());
            var keeptols = keepM.GroupJoin(
                                _context.BMEDKeepCosts.Where(c => c.TotalCost > 0)
                                , d => d.rd.DocId
                                , c => c.DocId
                                , (d, c) => new { repM = d, repCost = c })
                              .SelectMany(s => s.repCost.Select(c => c.TotalCost).DefaultIfEmpty(0).DefaultIfEmpty(),
                              (r, c) => new { repM = r.repM, repCost = c })
                              .GroupBy(g => g.repM.r.AccDpt)
                              .ToDictionary(o => o.Key, o => o.Select(c => c.repCost).Sum());



            foreach (DepartmentModel p in _context.Departments.ToList())
            {
                m = new RepairKeepVModel();
                m.CustId = p.DptId;
                m.CustNam = p.Name_C;
                rcnt = 0;
                kcnt = 0;
                tolcost = 0m;
                //var ss = new[] { "?", "2" };
                //維修
                //List<RepairModel> rs = _context.BMEDRepairs.Where(r => r.Loc == urLocation)
                //    .Where(r => r.ApplyDate >= v.Sdate)
                //    .Where(r => r.ApplyDate <= v.Edate)
                //    .Join(_context.BMEDRepairFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                //    (r, f) => r).Join(_context.BMEDAssets
                //          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                //          .Where(r => r.AccDpt == p.DptId), rd => rd.AssetNo, r => r.AssetNo,
                //          (rd, r) => rd).ToList();
                //
                //rcnt = rs.Join(_context.BMEDRepairDtls.Where(d => d.EndDate != null),
                //          rd => rd.DocId, r => r.DocId,
                //          (rd, r) => rd).ToList().Count();
                rcnt = repairDtl.ContainsKey(p.DptId) == false ? 0 : repairDtl[p.DptId];

                m.RpEndAmt = rcnt;
                //m.RepairAmt = rs.Count();
                m.RepairAmt = sr.ContainsKey(p.DptId) == false ? 0 : sr[p.DptId];

                if (rcnt > 0)
                {
                    m.RepFinishedRate =
                        decimal.Round(Convert.ToDecimal(rcnt) / Convert.ToDecimal(m.RepairAmt) * 100m, 2);
                }
                else
                    m.RepFinishedRate = 0m;
                //目前沒有維護費用所以先省略
                tolcost = 0m;
                //tolcost = rs.Join(_context.BMEDRepairCosts.Where(c => c.TotalCost > 0), rd => rd.DocId, c => c.DocId,
                //         (rd, c) => c).Select(c => c.TotalCost).DefaultIfEmpty(0).Sum();
                tolcost = tols.ContainsKey(p.DptId) == false ? 0 : tols[p.DptId];
                m.RepCost = tolcost;
                //保養
                //List<KeepModel> ks = _context.BMEDKeeps.Where(r => r.Loc == urLocation)
                //    .Where(r => r.SentDate >= v.Sdate)
                //   .Where(r => r.SentDate <= v.Edate)
                //   .Join(_context.BMEDKeepFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                //   (r, f) => r).Join(_context.BMEDAssets
                //          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                //          .Where(r => r.AccDpt == p.DptId), rd => rd.AssetNo, r => r.AssetNo,
                //          (rd, r) => rd).ToList();

                //kcnt = ks.Join(_context.BMEDKeepDtls.Where(d => d.EndDate != null),
                //          rd => rd.DocId, r => r.DocId,
                //          (rd, r) => rd).ToList()
                //          .Count();

                kcnt = repairDk.ContainsKey(p.DptId) == false ? 0 : repairDk[p.DptId];
                m.KpEndAmt = kcnt;
                //m.KeepAmt = ks.Count();
                m.KeepAmt = km.ContainsKey(p.DptId) == false ? 0 : km[p.DptId];

                if (kcnt > 0)
                {
                    m.KeepFinishedRate =
                        decimal.Round(Convert.ToDecimal(kcnt) / Convert.ToDecimal(m.KeepAmt) * 100m, 2);
                }
                else
                    m.KeepFinishedRate = 0m;
                tolcost = 0m;
                //tolcost = ks.Join(_context.BMEDKeepCosts.Where(c => c.TotalCost > 0), rd => rd.DocId, c => c.DocId,
                //          (rd, c) => c).Select(c => c.TotalCost).DefaultIfEmpty(0).Sum();
                tolcost = keeptols.ContainsKey(p.DptId) == false ? 0 : keeptols[p.DptId];
                m.KeepCost = tolcost;
                mv.Add(m);
            }
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                mv = mv.Where(vv => vv.CustId == v.AccDpt)
                    .OrderBy(c => c.CustNam)
                    .ThenBy(t => t.CustId)
                    .ToList();
            }

            //
            var pageCount = mv.ToPagedList(page, pageSize).PageCount;
            pageCount = pageCount == 0 ? 1 : pageCount; // If no page.
            if (mv.ToPagedList(page, pageSize).Count <= 0)  //If the page has no items.
                return mv.ToPagedList(pageCount, pageSize);
            return mv.ToPagedList(page, pageSize);

            //return mv;
        }

        public List<RepairKeepVModel> KeepCostAll(ReportQryVModel v)
        {
            var urLocation = v.Location;
            //
            List<RepairKeepVModel> mv = new List<RepairKeepVModel>();
            RepairKeepVModel m;
            int rcnt = 0;
            int kcnt = 0;
            decimal tolcost = 0m;
            var ss = new[] { "?", "2" };

            //維修
            var repairF = _context.BMEDRepairs
                    .Where(r => r.Loc == urLocation)
                    .Where(r => r.ApplyDate >= v.Sdate)
                    .Where(r => r.ApplyDate <= v.Edate)
                    .Join(_context.BMEDRepairFlows
                            .Where(f => ss.Contains(f.Status))
                            , r => r.DocId
                            , f => f.DocId
                            , (r, f) => r
                            )
                    .Join(_context.BMEDAssets
                          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                          .Join(_context.Departments
                                  , c => c.AccDpt
                                  , d => d.DptId
                                  , (bd, cd) => bd)
                          , rd => rd.AssetNo
                          , r => r.AssetNo,
                          (rd, r) => new { rd = rd, r = r });

            var sr = repairF.GroupBy(g => g.r.AccDpt)
                    .ToDictionary(o => o.Key, o => o.Count());

            var repairDtl = repairF.Join(_context.BMEDRepairDtls.Where(d => d.EndDate != null),
                          rm => rm.rd.DocId, rdl => rdl.DocId,
                          (rm, rdl) => new { rm = rm, rdl = rdl })
                     .GroupBy(g => g.rm.r.AccDpt)
                    .ToDictionary(o => o.Key, o => o.Count());


            var tols = repairF.GroupJoin(
                                _context.BMEDRepairCosts.Where(c => c.TotalCost > 0)
                                , d => d.rd.DocId
                                , c => c.DocId
                                , (d, c) => new { repM = d, repCost = c })
                              .SelectMany(s => s.repCost.Select(c => c.TotalCost).DefaultIfEmpty(0).DefaultIfEmpty(),
                              (r, c) => new { repM = r.repM, repCost = c })
                              .GroupBy(g => g.repM.r.AccDpt)
                              .ToDictionary(o => o.Key, o => o.Select(c => c.repCost).Sum());
            //保養
            var keepM = _context.BMEDKeeps.Where(r => r.Loc == urLocation)
                   .Where(r => r.SentDate >= v.Sdate)
                   .Where(r => r.SentDate <= v.Edate)
                   .Join(_context.BMEDKeepFlows.Where(f => ss.Contains(f.Status)), r => r.DocId, f => f.DocId,
                   (r, f) => r).Join(_context.BMEDAssets
                          .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                         .Join(_context.Departments
                                  , c => c.AccDpt
                                  , d => d.DptId
                                  , (bd, cd) => bd)
                          , rd => rd.AssetNo
                          , r => r.AssetNo,
                          (rd, r) => new { rd = rd, r = r });

            var km = keepM.GroupBy(g => g.r.AccDpt)
                     .ToDictionary(o => o.Key, o => o.Count());

            var repairDk = keepM.Join(_context.BMEDKeepDtls.Where(d => d.EndDate != null),
                          rm => rm.rd.DocId, rdl => rdl.DocId,
                          (rm, rdl) => new { rm = rm, rdl = rdl })
                     .GroupBy(g => g.rm.r.AccDpt)
                    .ToDictionary(o => o.Key, o => o.Count());
            var keeptols = keepM.GroupJoin(
                                _context.BMEDKeepCosts.Where(c => c.TotalCost > 0)
                                , d => d.rd.DocId
                                , c => c.DocId
                                , (d, c) => new { repM = d, repCost = c })
                              .SelectMany(s => s.repCost.Select(c => c.TotalCost).DefaultIfEmpty(0).DefaultIfEmpty(),
                              (r, c) => new { repM = r.repM, repCost = c })
                              .GroupBy(g => g.repM.r.AccDpt)
                              .ToDictionary(o => o.Key, o => o.Select(c => c.repCost).Sum());



            foreach (DepartmentModel p in _context.Departments.ToList())
            {
                m = new RepairKeepVModel();
                m.CustId = p.DptId;
                m.CustNam = p.Name_C;
                rcnt = 0;
                kcnt = 0;
                tolcost = 0m;
                //var ss = new[] { "?", "2" };
                //維修
                  rcnt = repairDtl.ContainsKey(p.DptId) == false ? 0 : repairDtl[p.DptId];

                m.RpEndAmt = rcnt;
                //m.RepairAmt = rs.Count();
                m.RepairAmt = sr.ContainsKey(p.DptId) == false ? 0 : sr[p.DptId];

                if (rcnt > 0)
                {
                    m.RepFinishedRate =
                        decimal.Round(Convert.ToDecimal(rcnt) / Convert.ToDecimal(m.RepairAmt) * 100m, 2);
                }
                else
                    m.RepFinishedRate = 0m;
                //目前沒有維護費用所以先省略
                tolcost = 0m;
                 tolcost = tols.ContainsKey(p.DptId) == false ? 0 : tols[p.DptId];
                m.RepCost = tolcost;
                //保養
               
                kcnt = repairDk.ContainsKey(p.DptId) == false ? 0 : repairDk[p.DptId];
                m.KpEndAmt = kcnt;
                //m.KeepAmt = ks.Count();
                m.KeepAmt = km.ContainsKey(p.DptId) == false ? 0 : km[p.DptId];

                if (kcnt > 0)
                {
                    m.KeepFinishedRate =
                        decimal.Round(Convert.ToDecimal(kcnt) / Convert.ToDecimal(m.KeepAmt) * 100m, 2);
                }
                else
                    m.KeepFinishedRate = 0m;
                tolcost = 0m;
                tolcost = keeptols.ContainsKey(p.DptId) == false ? 0 : keeptols[p.DptId];
                m.KeepCost = tolcost;
                mv.Add(m);
            }
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                mv = mv.Where(vv => vv.CustId == v.AccDpt)
                    .OrderBy(c => c.CustNam)
                    .ThenBy(t => t.CustId)
                    .ToList();
            }
            return mv;
        }

        public IActionResult ExcelRF(ReportQryVModel v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("財產編號");
            dt.Columns.Add("表單編號");
            //dt.Columns.Add("請修日期");
            dt.Columns.Add("單位名稱");
            //dt.Columns.Add("設備財編");
            dt.Columns.Add("設備名稱");
            //dt.Columns.Add("設備型號");
            dt.Columns.Add("故障描述");
            dt.Columns.Add("故障原因");
            dt.Columns.Add("處理描述");
            dt.Columns.Add("完工日期");
            dt.Columns.Add("工程師");
            List<RepeatFailVModel> mv = RepeatFail(v);
            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.AssetNo;
                dw[1] = m.DocId;
                //dw[2] = m.ApplyDate.ToString("yyyy/MM/dd");
                dw[2] = m.AccDptNam;
                //dw[3] = m.AssetNo;
                dw[3] = m.AssetNam;
                //dw[4] = m.Type;
                dw[4] = m.TroubleDes;
                dw[5] = m.FailFactor;
                dw[6] = m.DealDes;
                dw[7] = m.EndDate.ToString("yyyy/MM/dd");
                dw[8] = m.EngNam;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("重複故障清單");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "RepeatFail.xlsx"
            );
        }
        public List<RepeatFailVModel> RepeatFail(ReportQryVModel v)
        {
            var urLocation = v.Location;
            //
            List<RepeatFailVModel> mv = new List<RepeatFailVModel>();
            List<RepeatFailVModel> mv2 = new List<RepeatFailVModel>();
            RepeatFailVModel m;
            RepairModel r;
            RepairEmpModel p;
            AssetModel a;
            DepartmentModel o;
            TempData["qry"] = JsonConvert.SerializeObject(v);

            List<RepairDtlModel> rdtl = _context.BMEDRepairDtls.Where(d => d.EndDate >= v.Sdate)
                .Where(d => d.EndDate <= v.Edate)
                .Join(_context.BMEDRepairs,
                        d => d.DocId,
                        re => re.DocId,
                        (d,re) => new { dtls = d,repait = re})
                .Join(_context.BMEDAssets.Where(at => at.AssetNo != "99999"),
                        d => d.repait.AssetNo,
                        at => at.AssetNo,
                        (d, at) => d.dtls)
                .ToList();

            var rdtlF = rdtl.GroupJoin( _context.BMEDFailFactors,
                                        d => d.FailFactor,
                                        f => f.Id,
                                        (d, f) => new { repairD = d, failF = f }
                                      )
                            .SelectMany( f => f.failF.DefaultIfEmpty(),
                                         (d, f) => new {_repairD = d.repairD.FailFactor, _failF = f.Title })
                            .GroupBy( x => x._repairD)
                            .ToDictionary( x => x.Key , x => x.Select(xf => xf._failF));

            //
            var repairU = _context.BMEDRepairs.Where(i => i.Loc == urLocation);

            var repairD = repairU
                            .Join( rdtl ,
                                   d => d.DocId,
                                   rd => rd.DocId,
                                   (d,rd) => new { repairs = d }
                            )
                            .GroupBy( x => x.repairs.DocId)
                            .ToDictionary(x => x.Key, x => x.Select(xo => xo.repairs));

            //
            //var departO = _context.BMEDRepairs
            //                        .GroupBy(rp => rp.AccDpt)
            //                        .Select(g => g.First());

            var repairO = _context.Departments
                            .Join( repairU,
                                   d => d.DptId,
                                   rd => rd.AccDpt,
                                   (d, rd) => new { depart = d.Name_C, DocId = rd.DocId }
                            )
                            .GroupBy(x => x.DocId)
                            .ToDictionary(x => x.Key, x => x.Select( xo => xo.depart));

            //
           //var departA = _context.BMEDRepairs
           //                         .GroupBy(rp => rp.AssetNo)
           //                         .Select(g => g.First());

            var repairA = _context.BMEDAssets
                            .Join(_context.BMEDRepairs,
                                   d => d.AssetNo,
                                   rd => rd.AssetNo,
                                   (d, rd) => new { asset = d, DocId = rd.DocId }
                                  )
                            .GroupBy(x => x.DocId)
                            .ToDictionary(x => x.Key, x => x.Select(xo => xo.asset));

            //維修工程師
            //var departP = rdtl.GroupBy(rp => rp.DocId)
            //                  .Select(g => g.First());

            //var repairP = _context.BMEDRepairEmps
            //                .Join(departP,
            //                       d => d.DocId,
            //                       rd => rd.DocId,
            //                       (d, rd) => new { repairE = d, repairs = rd }
            //                      )
            //                .Join(_context.AppUsers,
            //                        d => d.repairE.UserId,
            //                        usr => usr.Id,
            //                        (d, usr) => new
            //                        {
            //                            DocId = d.repairE.DocId,
            //                            FullName = usr.FullName
            //                        }
            //                )
            //                .GroupBy(x => x.DocId)
            //                .ToDictionary(x => x.Key, x => x.Select(xo => xo.FullName));

            foreach (RepairDtlModel rd in rdtl)
            {
                m = new RepeatFailVModel();
                m.DocId = rd.DocId;
                m.DealDes = rd.DealDes;
                m.EndDate = rd.EndDate.Value;
                m.Cost = rd.Cost;
                m.FailFactor = rdtlF.ContainsKey(rd.FailFactor) == false ? null : rdtlF[rd.FailFactor].FirstOrDefault();//Convert.ToString(rd.FailFactor);
                //r = _context.BMEDRepairs
                //    .Where(i => i.Loc == urLocation)
                //    .Where(i => i.DocId == rd.DocId)
                //    .ToList()
                //    .FirstOrDefault();
                //if (r != null)
                //{
                //    m.TroubleDes = r.TroubleDes;
                //    m.CustId = r.AccDpt;
                //    o = _context.Departments.Where(c => c.DptId == r.AccDpt).ToList().FirstOrDefault();
                //    if (o != null)
                //        m.CustNam = o.Name_C;

                //    m.ApplyDate = r.ApplyDate;
                //    m.AssetNo = r.AssetNo;
                //    a = _context.BMEDAssets.Where(s => s.AssetNo == r.AssetNo)
                //            .Where(s => s.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1)).FirstOrDefault();
                //    if (a != null)
                //    {
                //        m.AssetNam = a.Cname;
                //        m.Type = a.Type;
                //    }
                //}

                if (repairD.ContainsKey(rd.DocId) != false)
                {
                    m.TroubleDes = repairD[rd.DocId].FirstOrDefault().TroubleDes;
                    m.AccDptNo = repairD[rd.DocId].FirstOrDefault().AccDpt;
                    //if (o != null)
                    //    m.CustNam = o.Name_C;

                    m.ApplyDate = repairD[rd.DocId].FirstOrDefault().ApplyDate;
                    m.AssetNo = repairD[rd.DocId].FirstOrDefault().AssetNo;
                    m.AssetNam = repairA.ContainsKey(rd.DocId) == false ? repairD[rd.DocId].FirstOrDefault().AssetName : repairA[rd.DocId].FirstOrDefault().Cname;
                    
                }
                m.AccDptNam = repairO.ContainsKey(rd.DocId) == false ? null : repairO[rd.DocId].FirstOrDefault();
                m.EngNam = repairA.ContainsKey(rd.DocId) == false ? "":repairA[rd.DocId].FirstOrDefault().AssetEngName;

                //p = _context.BMEDRepairEmps.Where(e => e.DocId == rd.DocId).ToList().FirstOrDefault();


                //if (p != null)
                //{
                //    AppUserModel u = _context.AppUsers.Find(p.UserId);
                //    m.EngNam = u.FullName;
                //}
                if (repairD.ContainsKey(rd.DocId) != false)
                {
                    mv2.Add(m);
                }
            }
            IEnumerable<IGrouping<string, RepeatFailVModel>> query = mv2.GroupBy(s => s.AssetNo);
            foreach (var group in query)
            {
                if (group.ToList().Count >= 2)
                {
                    foreach (RepeatFailVModel l in group)
                    {
                        mv.Add(l);
                    }
                }
            }
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                mv = mv.Where(vv => vv.AccDptNo == v.AccDpt).ToList();
            }
            return mv;
        }

        

        public List<RepKeepStokVModel> RepKeepStok(ReportQryVModel v)
        {
            var urLocation = v.Location;
            //
            List<RepKeepStokVModel> mv = new List<RepKeepStokVModel>();
            List<Cust> cv;
            cv =
           _context.BMEDRepairDtls.Where(d => d.CloseDate >= v.Sdate &&
               d.CloseDate <= v.Edate)
               .Join(_context.BMEDRepairs.Where(r => r.Loc == urLocation), rd => rd.DocId, r => r.DocId,
               (rd, r) => new
               {
                   rd.DocId,
                   r.AccDpt,
                   r.AssetNo
               }).Join(_context.BMEDAssets, rd => rd.AssetNo, r => r.AssetNo,
               (rd, r) => new
               {
                   rd.DocId,
                   r.AccDpt,
                   r.AssetClass
               }).Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
               .Join(_context.Departments, rd => rd.AccDpt, c => c.DptId,
               (rd, c) => new Cust
               {
                   CustId = c.DptId,
                   CustNam = c.Name_C
               }).Union(
          _context.BMEDKeepDtls.Where(d => d.CloseDate >= v.Sdate &&
              d.CloseDate <= v.Edate)
              .Join(_context.BMEDKeeps.Where(r => r.Loc == urLocation), rd => rd.DocId, r => r.DocId,
              (rd, r) => new
              {
                  rd.DocId,
                  r.AccDpt,
                  r.AssetNo
              }).Join(_context.BMEDAssets, rd => rd.AssetNo, r => r.AssetNo,
               (rd, r) => new
               {
                   rd.DocId,
                   r.AccDpt,
                   r.AssetClass
               }).Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
              .Join(_context.Departments, rd => rd.AccDpt, c => c.DptId,
              (rd, c) => new Cust
              {
                  CustId = c.DptId,
                  CustNam = c.Name_C
              })).ToList();
            if (cv.Count() > 0)
            {
                cv = cv.GroupBy(g => g.CustId).Select(group => group.FirstOrDefault()).ToList();
            }

            RepKeepStokVModel m;
            int rcnt = 0;
            int kcnt = 0;
            decimal tolcost = 0m;
            List<RepTotalPrice> pp = new List<RepTotalPrice>();

            //維修金額
            var repair = _context.BMEDRepairDtls.Where(d => d.CloseDate >= v.Sdate &&
                d.CloseDate <= v.Edate)
                .Join(_context.BMEDRepairs, 
                        rd => rd.DocId, 
                        r => r.DocId,
                        (rd, r) => new
                        {
                            rd.DocId,
                            r.AccDpt
                        })
                .Join(cv,
                      d => d.AccDpt,
                      c => c.CustId,
                      (d, c) => c
                )
                .GroupBy(x => x.CustId)
                .ToDictionary(x => x.Key, x => x.Count());
                //.Where(r => r.AccDpt == co.CustId).Count();

            var repairD = _context.BMEDRepairDtls
                .Where(d => d.CloseDate >= v.Sdate && d.CloseDate <= v.Edate)
                .Join(_context.BMEDRepairs, 
                        rd => rd.DocId, 
                        r => r.DocId,
                        (rd, r) => new
                        {
                            rd.DocId,
                            r.AccDpt
                        })
                //.Where(r => r.AccDpt == co.CustId)
                .Join(cv,
                      d => d.AccDpt,
                      c => c.CustId,
                      (d, c) => new { red = d , cust = c}
                )
                .Join(_context.BMEDRepairCosts, 
                        rd => rd.red.DocId, 
                        c => c.DocId,
                        (rd, c) => new RepTotalPrice
                        {
                            DocId = rd.cust.CustId,
                            totalprice = c.TotalCost
                        })
                .GroupBy( x => x.DocId)
                .ToDictionary( x => x.Key , x => x.Select( c => c.totalprice).DefaultIfEmpty(0).Sum());
            //保養金額
            var keep = _context.BMEDKeepDtls
                .Where(d => d.CloseDate >= v.Sdate && d.CloseDate <= v.Edate)
                .Join(_context.BMEDKeeps,
                        rd => rd.DocId,
                        r => r.DocId,
                        (rd, r) => new
                        {
                            rd.DocId,
                            r.AccDpt
                        })
                .Join(cv,
                      d => d.AccDpt,
                      c => c.CustId,
                      (d, c) => c
                )
                .GroupBy(x => x.CustId)
                .ToDictionary(x => x.Key, x => x.Count());
            //.Where(r => r.AccDpt == co.CustId).Count();

   
            var keepD = _context.BMEDKeepDtls
                .Where(d => d.CloseDate >= v.Sdate && d.CloseDate <= v.Edate)
                .Join(_context.BMEDKeeps,
                        rd => rd.DocId,
                        r => r.DocId,
                        (rd, r) => new
                        {
                            rd.DocId,
                            r.AccDpt
                        })
                //.Where(r => r.AccDpt == co.CustId)
                .Join(cv,
                      d => d.AccDpt,
                      c => c.CustId,
                      (d, c) => new { red = d, cust = c }
                )
                .Join(_context.BMEDKeepCosts,
                        rd => rd.red.DocId,
                        c => c.DocId,
                        (rd, c) => new RepTotalPrice
                        {
                            DocId = rd.cust.CustId,
                            totalprice = c.TotalCost
                        })
                .GroupBy(x => x.DocId)
                .ToDictionary(x => x.Key, x => x.Select(c => c.totalprice).DefaultIfEmpty(0).Sum());

            foreach (Cust co in cv)
            {
                rcnt = 0;
                tolcost = 0m;
                pp.Clear();
                m = new RepKeepStokVModel();
                m.CustId = co.CustId;
                m.CustNam = co.CustNam;
                //rcnt = _context.BMEDRepairDtls.Where(d => d.CloseDate >= v.Sdate &&
                //d.CloseDate <= v.Edate)
                //.Join(_context.BMEDRepairs, rd => rd.DocId, r => r.DocId,
                //(rd, r) => new
                //{
                //    rd.DocId,
                //    r.AccDpt
                //}).Where(r => r.AccDpt == co.CustId).Count();
                rcnt = repair.ContainsKey(co.CustId) == false ? 0 : repair[co.CustId];

                //pp = _context.BMEDRepairDtls.Where(d => d.CloseDate >= v.Sdate &&
                //d.CloseDate <= v.Edate)
                //.Join(_context.BMEDRepairs, rd => rd.DocId, r => r.DocId,
                //(rd, r) => new
                //{
                //    rd.DocId,
                //    r.AccDpt
                //}).Where(r => r.AccDpt == co.CustId).Join(_context.BMEDRepairCosts, rd => rd.DocId, c => c.DocId,
                //(rd, c) => new RepTotalPrice
                //{
                //    DocId = rd.DocId,
                //    totalprice = c.TotalCost
                //}).ToList();
                //if (pp.Count > 0)
                //    tolcost = pp.Sum(p => p.totalprice);

                tolcost = repairD.ContainsKey(co.CustId) == false ? 0 : repairD[co.CustId];
                m.RepairAmt = rcnt;
                m.RepairCost = tolcost;
                //
                kcnt = 0;
                tolcost = 0;
               // kcnt = _context.BMEDKeepDtls.Where(d => d.CloseDate >= v.Sdate &&
               // d.CloseDate <= v.Edate)
               //.Join(_context.BMEDKeeps, rd => rd.DocId, r => r.DocId,
               //(rd, r) => new
               //{
               //    rd.DocId,
               //    r.AccDpt
               //}).Where(r => r.AccDpt == co.CustId).Count();
               // pp.Clear();
               // pp = _context.BMEDKeepDtls.Where(d => d.CloseDate >= v.Sdate &&
               // d.CloseDate <= v.Edate)
               // .Join(_context.BMEDKeeps, rd => rd.DocId, r => r.DocId,
               // (rd, r) => new
               // {
               //     rd.DocId,
               //     r.AccDpt
               // }).Where(r => r.AccDpt == co.CustId).Join(_context.BMEDKeepCosts, rd => rd.DocId, c => c.DocId,
               // (rd, c) => new RepTotalPrice
               // {
               //     DocId = rd.DocId,
               //     totalprice = c.TotalCost
               // }).ToList();
               // if (pp.Count > 0)
               //     tolcost = pp.Sum(p => p.totalprice);

                kcnt = keep.ContainsKey(co.CustId) == false ? 0 : keep[co.CustId];
                tolcost = keepD.ContainsKey(co.CustId) == false ? 0 : keepD[co.CustId];

                m.KeepAmt = kcnt;
                m.KeepCost = tolcost;
                //
                m.TotalAmt = m.RepairAmt + m.KeepAmt;
                m.TotalCost = m.RepairCost + m.KeepCost;
                mv.Add(m);
            }
            //
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                mv = mv.Where(vv => vv.CustId == v.AccDpt).ToList();
            }
            //
            return mv;
        }

        public List<RpKpStokBdVModel> RpKpStokBd(ReportQryVModel v)
        {
            var urLocation = v.Location;
            //
            List<RpKpStokBdVModel> sv = new List<RpKpStokBdVModel>();
            List<RpKpStokBdVModel> sv2 = new List<RpKpStokBdVModel>();
            RpKpStokBdVModel rb;
            var rps = _context.BMEDRepairDtls.Where(d => d.CloseDate != null).Where(d => d.CloseDate >= v.Sdate &&
                d.CloseDate <= v.Edate)
                .Join(_context.BMEDRepairs.Where(r => r.Loc == urLocation), rd => rd.DocId, r => r.DocId,
                (rd, r) => new
                {
                    rd.DocId,
                    r.AccDpt,
                    r.AssetNo,
                })
                //.Join(_context.BMEDAssets, rd => rd.AssetNo, r => r.AssetNo,
                //(rd, r) => new
                //{
                //    rd.DocId,
                //    rd.AccDpt,
                //    r.AssetClass
                //})
                //.Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                .Join(_context.Departments, rd => rd.AccDpt, c => c.DptId,
                (rd, c) => new
                {
                    rd.DocId,
                    CustId = c.DptId,
                    CustNam = c.Name_C
                })
                .Join(_context.BMEDRepairCosts, rd => rd.DocId, rc => rc.DocId,
                (rd, rc) => new
                {
                    DocTyp = "請修",
                    rd.CustId,
                    rd.CustNam,
                    rc.PartNo,
                    rc.Qty,
                    rc.TotalCost
                }).ToList();

            var ksp = _context.BMEDKeepDtls.Where(d => d.CloseDate != null).Where(d => d.CloseDate >= v.Sdate &&
                d.CloseDate <= v.Edate)
                .Join(_context.BMEDKeeps.Where(r => r.Loc == urLocation), rd => rd.DocId, r => r.DocId,
                (rd, r) => new
                {
                    rd.DocId,
                    r.AccDpt,
                    r.AssetNo
                })
                .Join(_context.BMEDAssets, rd => rd.AssetNo, r => r.AssetNo,
                (rd, r) => new
                {
                    rd.DocId,
                    rd.AccDpt,
                    r.AssetClass
                })
                .Where(r => r.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1))
                .Join(_context.Departments, rd => rd.AccDpt, c => c.DptId,
                (rd, c) => new
                {
                    rd.DocId,
                    //c.GroupId,
                    CustId = c.DptId,
                    CustNam = c.Name_C
                })
                .Join(_context.BMEDKeepCosts, rd => rd.DocId, rc => rc.DocId,
                (rd, rc) => new
                {
                    DocTyp = "保養",
                    rd.CustId,
                    rd.CustNam,
                    rc.PartNo,
                    rc.Qty,
                    rc.TotalCost
                }).ToList();
                
                var scv = rps.Union(ksp).GroupBy(rd => rd.CustId).ToList();

            foreach (var a in scv)
            {
                //var scv2 = a.Where(z => z.DocTyp == "請修")
                //    .Join(_context.BMEDDeptStocks, x => x.PartNo, d => d.StokNo,
                //    (x, d) => new
                //    {
                //        d.Brand,
                //        x.TotalCost
                //    }).GroupBy(x => x.Brand).ToList();
                var scv2 = a.Where(z => z.DocTyp == "請修")
                    .Join(_context.BMEDDeptStocks, x => x.PartNo, d => d.StockNo,
                    (x, d) => new
                    {
                        d.Brand,
                        d.StockNo,
                        d.StockName,
                        x.Qty,
                        x.TotalCost
                    })
                    .GroupBy(x => new { x.Brand, x.StockNo, x.StockName })
                    .ToList();

                foreach (var b in scv2)
                {
                    rb = new RpKpStokBdVModel();
                    rb.CustId = a.Key;
                    rb.CustNam = _context.Departments.Find(a.Key).Name_C;
                    rb.DocTyp = "請修";
                    rb.Brand = b.Key.Brand;
                    rb.StokNo = b.Key.StockNo;
                    rb.StokNam = b.Key.StockName;
                    rb.Amt = b.Sum(x => x.Qty);
                    rb.Up1000 = b.Where(x => x.TotalCost >= 1000).Sum(x => x.TotalCost);
                    rb.Dn1000 = b.Where(x => x.TotalCost < 1000).Sum(x => x.TotalCost);
                    rb.Cost = b.Sum(x => x.TotalCost);
                    sv.Add(rb);
                }
                //
                scv2.Clear();
                scv2 = a.Where(z => z.DocTyp == "保養")
                    .Join(_context.BMEDDeptStocks, x => x.PartNo, d => d.StockNo,
                    (x, d) => new
                    {
                        d.Brand,
                        d.StockNo,
                        d.StockName,
                        x.Qty,
                        x.TotalCost
                    }).GroupBy(x => new { x.Brand, x.StockNo, x.StockName }).ToList();
                foreach (var b in scv2)
                {
                    rb = new RpKpStokBdVModel();
                    rb.CustId = a.Key;
                    rb.CustNam = _context.Departments.Find(a.Key).Name_C;
                    rb.DocTyp = "保養";
                    rb.Brand = b.Key.Brand;
                    rb.StokNo = b.Key.StockNo;
                    rb.StokNam = b.Key.StockName;
                    rb.Amt = b.Sum(x => x.Qty);
                    rb.Up1000 = b.Where(x => x.TotalCost >= 1000).Sum(x => x.TotalCost);
                    rb.Dn1000 = b.Where(x => x.TotalCost < 1000).Sum(x => x.TotalCost);
                    rb.Cost = b.Sum(x => x.TotalCost);
                    sv.Add(rb);
                }
                //sv.Add(rb);
            }
            //
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                sv = sv.Where(vv => vv.CustId == v.AccDpt).ToList();
            }
            //
            return sv;
        }

        public IActionResult ExcelSC(ReportQryVModel v)
        {
            string str = "";
            str += "類別,表單編號,送單日期,完工日期,財產編號,設備名稱,型號,成本中心,成本中心名稱,";
            str += "故障描述/保養週期,故障原因,處理描述,零件廠牌,料號,零件名稱,數量,單價,合計,結案日,工程師";
            DataTable dt = new DataTable();
            DataRow dw;
            str.Split(new char[] { ',' }).ToList()
                .ForEach(s =>
                {
                    dt.Columns.Add(s);
                });
            List<StokCostVModel> uv = StokCost(v);
            uv = uv.Where(sv => sv.TotalPrice > 0 ).ToList();
            uv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.DocTyp;
                dw[1] = m.DocId;
                dw[2] = m.ApplyDate;
                dw[3] = m.EndDate;
                dw[4] = m.AssetNo;
                dw[5] = m.AssetNam;
                dw[6] = m.Type;
                dw[7] = m.AccDpt;
                dw[8] = m.AccDptNam;
                dw[9] = m.TroubleDes;
                dw[10] = m.FailFactor;
                dw[11] = m.DealDes;
                dw[12] = m.Brand;
                dw[13] = m.StokNo;
                dw[14] = m.StokNam;
                dw[15] = m.Qty;
                dw[16] = m.Price;
                dw[17] = m.TotalPrice;
                dw[18] = m.CloseDate;
                dw[19] = m.EngNam;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("零件帳務清單");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "StokCost.xlsx"
            );
        }
        public List<StokCostVModel> StokCost(ReportQryVModel v)
        {
            var urLocation = v.Location;
            //
            TempData["qry"] = JsonConvert.SerializeObject(v);
            List<StokCostVModel> sv = new List<StokCostVModel>();
            List<StokCostVModel> sv2 = new List<StokCostVModel>();


            var repairD = _context.BMEDRepairDtls.AsQueryable();
                            //.Where(d => d.EndDate >= v.Sdate && d.EndDate <= v.Edate);
            if (v.Sdate != null)
            {
                repairD = repairD.Where(d => d.EndDate >= v.Sdate);
            }

            if (v.Edate != null)
            {
                repairD = repairD.Where(d => d.EndDate <= v.Edate);
            }

            var repair = _context.BMEDRepairs.Where(r => r.Loc == urLocation);
            //var costs = _context.BMEDRepairCosts.ToList();
            //if (!string.IsNullOrEmpty(v.VendorName))
            //{
            //    costs = costs.Where(c => c.VendorName == v.VendorName).ToList();
            //}

            //if (!string.IsNullOrEmpty(v.VendorUniteNo))
            //{
            //    costs = costs.Where(c => c.VendorName == v.VendorUniteNo).ToList();
            //}

            sv = repairD
            .Join(repair, rd => rd.DocId, k => k.DocId,
            (rd, k) => new
            {
                rd.DocId,
                k.AccDpt,
                k.ApplyDate,
                k.AssetNo,
                k.AssetName,
                rd.Cost,
                rd.EndDate,
                rd.CloseDate,
                rd.FailFactor,
                rd.DealDes,
                k.TroubleDes,
                k.PlantClass
            })
            //.Join(_context.BMEDAssets, k => k.AssetNo, at => at.AssetNo,
            //(k, at) => new
            //{
            //    k.DocId,
            //    k.AccDpt,
            //    k.ApplyDate,
            //    k.AssetNo,
            //    at.Cname,
            //    k.Cost,
            //    k.EndDate,
            //    k.CloseDate,
            //    k.FailFactor,
            //    k.TroubleDes,
            //    k.DealDes,
            //    at.Type,
            //    at.AssetClass
            //})
            .GroupJoin(_context.BMEDRepairCosts, k => k.DocId, rc => rc.DocId,
            (k, rc) => new { k, rc })
            .SelectMany(oi => oi.rc.DefaultIfEmpty(),
           (k, rc) => new
           {
               k.k.DocId,
               k.k.AccDpt,
               k.k.ApplyDate,
               k.k.AssetNo,
               k.k.AssetName,
               k.k.PlantClass,
               //k.k.Cname,
               k.k.Cost,
               k.k.EndDate,
               k.k.CloseDate,
               k.k.FailFactor,
               k.k.TroubleDes,
               k.k.DealDes,
               //k.k.Type,
               //k.k.AssetClass,
               PartNo = rc != null ? (rc.PartNo != null ? rc.PartNo : ""):"",
               PartNam = rc != null ? (rc.PartName != null ? rc.PartName : ""): "",
               Qty = rc != null ? rc.Qty : 0,
               Price = rc != null ? rc.Price : 0,
               TotalCost = rc != null ? rc.TotalCost : 0,
               VendorId = rc != null ? (rc.VendorId != null ? rc.VendorId : null) : null
           })
             .GroupJoin(_context.BMEDVendors, k => k.VendorId, vr => vr.VendorId,
            (k, vr) => new { k, vr })
            .SelectMany(oi => oi.vr.DefaultIfEmpty(),
           (k, vr) => new
           {
               k.k.DocId,
               k.k.AccDpt,
               k.k.ApplyDate,
               k.k.AssetNo,
               k.k.AssetName,
               k.k.PlantClass,
               //k.k.Cname,
               k.k.Cost,
               k.k.EndDate,
               k.k.CloseDate,
               k.k.FailFactor,
               k.k.TroubleDes,
               k.k.DealDes,
               //k.k.Type,
               //k.k.AssetClass,
               PartNo = k.k.PartNo,
               PartNam =k.k.PartNam,
               Qty = k.k.Qty,
               Price = k.k.Price,
               TotalCost = k.k.TotalCost,
               VendorName = vr == null ? "" : vr.VendorName,
               UniteNo = vr == null ? "" : vr.UniteNo
           })
             .Join(_context.Departments, k => k.AccDpt, c => c.DptId,
            (k, c) => new
            {
                k.DocId,
                k.AccDpt,
                k.ApplyDate,
                k.AssetNo,
                k.AssetName,
                k.PlantClass,
                //k.Cname,
                k.Cost,
                k.EndDate,
                k.CloseDate,
                k.FailFactor,
                k.TroubleDes,
                k.DealDes,
                //k.Type,
                k.PartNo,
                k.PartNam,
                //k.AssetClass,
                k.Qty,
                k.Price,
                k.TotalCost,
                c.Name_C,
                k.VendorName,
                k.UniteNo
            })
             .Join(_context.BMEDRepairEmps, k => k.DocId, ke => ke.DocId,
            (k, ke) => new
            {
                k.DocId,
                k.AccDpt,
                k.ApplyDate,
                k.AssetNo,
                k.AssetName,
                k.PlantClass,
                //k.Cname,
                k.Cost,
                k.EndDate,
                k.CloseDate,
                k.FailFactor,
                k.TroubleDes,
                k.DealDes,
                //k.Type,
                k.PartNo,
                k.PartNam,
                //k.AssetClass,
                k.Qty,
                k.Price,
                k.TotalCost,
                k.Name_C,
                ke.UserId,
                k.VendorName,
                k.UniteNo
            })
            .Join(_context.AppUsers, k => k.UserId, u => u.Id,
            (k, u) => new StokCostVModel
            {
                DocTyp = "請修",
                DocId = k.DocId,
                AccDpt = k.AccDpt,
                AccDptNam = k.Name_C,
                AssetNo = k.AssetNo,
                AssetNam = k.AssetName,
                Type = "",
                ApplyDate = k.ApplyDate,
                EndDate = k.EndDate,
                CloseDate = k.CloseDate,
                FailFactor = Convert.ToString(k.FailFactor),
                TroubleDes = k.TroubleDes,
                DealDes = k.DealDes,
                StokNo = k.PartNo,
                StokNam = k.PartNam,
                Qty = k.Qty,
                Price = k.Price,
                TotalPrice = k.TotalCost,
                EngNam = u.FullName,
                AssetClass = "",
                VendorName = k.VendorName,
                VendorUniteNo = k.UniteNo
            }).ToList();
            //
            var svs = sv.GroupJoin( _context.BMEDRepairCosts,
                                s => s.DocId,
                                r => r.DocId,
                                (s , r) => new { costV = s , repsirC = r})
                        .SelectMany( x => x.repsirC.DefaultIfEmpty()
                                     ,(s , r) => new { _costV = s , _repsirC = r })
                        .GroupBy( x => x._costV.costV.DocId)
                        .ToDictionary( x => x.Key , x => x.Select(xr => xr._repsirC.TotalCost))
                        ;
            foreach (StokCostVModel s in sv)
            {
                if (s.StokNo != "") 
                    s.Cost = svs[s.DocId].Sum(r => r);
                    //s.Cost = _context.BMEDRepairCosts.Where(r => r.DocId == s.DocId).Sum(r => r.TotalCost);
            
            }
            //保養

            var keeps = _context.BMEDKeeps.Where(r => r.Loc == urLocation);
            //var costK = _context.BMEDKeepCosts.ToList();
            var KeepD = _context.BMEDKeepDtls.ToList();
            //.Where(d => d.EndDate >= v.Sdate && d.EndDate <= v.Edate);
            if (v.Sdate != null)
            {
                KeepD = KeepD.Where(d => d.EndDate >= v.Sdate).ToList();
            }

            if (v.Edate != null)
            {
                KeepD = KeepD.Where(d => d.EndDate <= v.Edate).ToList();
            }


            sv2 = KeepD
           .Join(keeps, rd => rd.DocId, k => k.DocId,
           (rd, k) => new
           {
               rd.DocId,
               k.AccDpt,
               k.SentDate,
               k.AssetNo,
               k.AssetName,
               rd.Cost,
               rd.EndDate,
               rd.CloseDate,
               rd.Result,
               k.Cycle
           })
           .Join(_context.BMEDAssets, k => k.AssetNo, at => at.AssetNo,
           (k, at) => new
           {
               k.DocId,
               k.AccDpt,
               k.SentDate,
               k.AssetNo,
               k.AssetName,
               at.Cname,
               k.Cost,
               k.EndDate,
               k.CloseDate,
               k.Result,
               k.Cycle,
               at.Type,
               at.AssetClass
           })
            .GroupJoin(_context.BMEDKeepCosts, k => k.DocId, rc => rc.DocId,
            (k, rc) => new { k, rc })
            .SelectMany(oi => oi.rc.DefaultIfEmpty(),
           (k, rc) => new
           {
               k.k.DocId,
               k.k.AccDpt,
               k.k.SentDate,
               k.k.AssetNo,
               k.k.AssetName,
               k.k.Cname,
               k.k.Cost,
               k.k.EndDate,
               k.k.CloseDate,
               k.k.Result,
               k.k.Cycle,
               k.k.Type,
               k.k.AssetClass,
               PartNo = rc != null ? (rc.PartNo != null ? rc.PartNo : "") : "",
               PartNam = rc != null ? (rc.PartName != null ? rc.PartName : "") : "",
               Qty = rc != null ? rc.Qty : 0,
               Price = rc != null ? rc.Price : 0,
               TotalCost = rc != null ? rc.TotalCost : 0,
               VendorId = rc != null ? (rc.VendorId != null ? rc.VendorId : null) : null,
           })
              .GroupJoin(_context.BMEDVendors, k => k.VendorId, vr => vr.VendorId,
            (k, vr) => new { k, vr })
            .SelectMany(oi => oi.vr.DefaultIfEmpty(),
           (k, vr) => new
           {
               k.k.DocId,
               k.k.AccDpt,
               k.k.SentDate,
               k.k.AssetNo,
               k.k.AssetName,
               k.k.Cname,
               k.k.Cost,
               k.k.EndDate,
               k.k.CloseDate,
               k.k.Result,
               k.k.Cycle,
               k.k.Type,
               k.k.AssetClass,
               PartNo = k.k.PartNo,
               PartNam = k.k.PartNam,
               Qty = k.k.Qty,
               Price = k.k.Price,
               TotalCost = k.k.TotalCost,
               VendorName = vr == null ? "" : vr.VendorName,
               UniteNo = vr == null ? "" : vr.UniteNo
           })
            .Join(_context.Departments, k => k.AccDpt, c => c.DptId,
           (k, c) => new
           {
               k.DocId,
               k.AccDpt,
               k.SentDate,
               k.AssetNo,
               k.AssetName,
               k.Cname,
               k.Cost,
               k.EndDate,
               k.CloseDate,
               k.Result,
               k.Cycle,
               k.Type,
               k.PartNo,
               k.PartNam,
               k.Qty,
               k.Price,
               k.TotalCost,
               k.AssetClass,
               //c.GroupId,
               c.Name_C,
               k.VendorName,
               k.UniteNo
           })
            .GroupJoin(_context.BMEDKeepEmps, k => k.DocId, ke => ke.DocId,
           (k, ke) => new { k, ke })
            .SelectMany(ee => ee.ke.DefaultIfEmpty(),
           (k, ke) => new
           {
               k.k.DocId,
               k.k.AccDpt,
               k.k.SentDate,
               k.k.AssetNo,
               k.k.AssetName,
               k.k.Cname,
               k.k.Cost,
               k.k.EndDate,
               k.k.CloseDate,
               k.k.Result,
               k.k.Cycle,
               k.k.Type,
               k.k.PartNo,
               k.k.PartNam,
               k.k.Qty,
               k.k.Price,
               k.k.TotalCost,
               k.k.Name_C,
               k.k.AssetClass,
               k.k.VendorName,
               k.k.UniteNo,
               UserId = ke != null ? ke.UserId : 0
           })
           .GroupJoin(_context.AppUsers, k => k.UserId, u => u.Id,
           (k, u) => new { k, u })
            .SelectMany(ee => ee.u.DefaultIfEmpty(),
           (k, u) => new StokCostVModel
           {
               DocTyp = "保養",
               DocId = k.k.DocId,
               AccDpt = k.k.AccDpt,
               AccDptNam = k.k.Name_C,
               AssetNo = k.k.AssetNo,
               AssetNam = k.k.AssetName,
               Type = "",
               ApplyDate = k.k.SentDate.Value,
               EndDate = k.k.EndDate,
               CloseDate = k.k.CloseDate,
               DealDes = Convert.ToString(k.k.Result),
               StokNo = k.k.PartNo,
               StokNam = k.k.PartNam,
               Qty = k.k.Qty,
               Price = k.k.Price,
               TotalPrice = k.k.TotalCost,
               EngNam = u.Id != 0 ? u.FullName : "",
               AssetClass = "",
               VendorName = k.k.VendorName,
               VendorUniteNo = k.k.UniteNo
           }).ToList();
            //
            var sv2sum = sv2.GroupJoin(_context.BMEDKeepCosts,
                                s => s.DocId,
                                r => r.DocId,
                                (s, r) => new { costV = s, repsirC = r })
                        .SelectMany(x => x.repsirC.DefaultIfEmpty()
                                     , (s, r) => new { _costV = s, _repsirC = r })
                        .GroupBy(x => x._costV.costV.DocId)
                        .ToDictionary(x => x.Key, x => x.Select(xr => xr._repsirC.TotalCost));

            foreach (StokCostVModel s in sv2)
            {
                switch (s.DealDes)
                {
                    case "1":
                        s.DealDes = "功能正常";
                        break;
                    case "2":
                        s.DealDes = "預防處理";
                        break;
                    case "3":
                        s.DealDes = "異常處理";
                        break;
                    case "4":
                        s.DealDes = "維修時保養";
                        break;
                    case "5":
                        s.DealDes = "退件";
                        break;
                }
                s.TroubleDes = _context.BMEDKeeps.Find(s.DocId).Cycle.ToString();
                s.FailFactor = "";
                if (s.StokNo != "")
                    s.Cost = sv2sum[s.DocId].Sum(r => r);
                // s.Cost = _context.BMEDKeepCosts.Where(r => r.DocId == s.DocId).Sum(r => r.TotalCost);
            }
            sv.AddRange(sv2);
            //sv = sv.Where(s => s.AssetClass == (v.AssetClass1 == null ? (v.AssetClass2 == null ? v.AssetClass3 : v.AssetClass2) : v.AssetClass1)).ToList();
            sv = sv.GroupJoin(_context.BMEDDeptStocks, s => s.StokNo, d => d.StockNo,
                (s, d) => new { s, d })
                .SelectMany(k => k.d.DefaultIfEmpty(),
                (k, u) => new StokCostVModel
                {
                    DocTyp = k.s.DocTyp,
                    DocId = k.s.DocId,
                    AccDpt = k.s.AccDpt,
                    AccDptNam = k.s.AccDptNam,
                    AssetNo = k.s.AssetNo,
                    AssetNam = k.s.AssetNam,
                    Type = k.s.Type,
                    ApplyDate = k.s.ApplyDate,
                    EndDate = k.s.EndDate,
                    CloseDate = k.s.CloseDate,
                    DealDes = k.s.DealDes,
                    FailFactor = k.s.FailFactor,
                    TroubleDes = k.s.TroubleDes,
                    StokNo = k.s.StokNo,
                    StokNam = k.s.StokNam,
                    Qty = k.s.Qty,
                    Price = k.s.Price,
                    TotalPrice = k.s.TotalPrice,
                    EngNam = k.s.EngNam,
                    AssetClass = k.s.AssetClass,
                    Brand = u == null ? "" : u.Brand,
                    VendorName = k.s.VendorName,
                    VendorUniteNo = k.s.VendorUniteNo
                })
                .GroupJoin(_context.BMEDFailFactors, s => s.FailFactor, f => f.Id.ToString(),
                (s, f) => new { s, f })
                .SelectMany(k => k.f.DefaultIfEmpty(),
                (k, ft) => new StokCostVModel
                {
                    DocTyp = k.s.DocTyp,
                    DocId = k.s.DocId,
                    AccDpt = k.s.AccDpt,
                    AccDptNam = k.s.AccDptNam,
                    AssetNo = k.s.AssetNo,
                    AssetNam = k.s.AssetNam,
                    Type = k.s.Type,
                    ApplyDate = k.s.ApplyDate,
                    EndDate = k.s.EndDate,
                    CloseDate = k.s.CloseDate,
                    DealDes = k.s.DealDes,
                    FailFactor = ft != null ? ft.Title : "其他",
                    TroubleDes = k.s.TroubleDes,
                    StokNo = k.s.StokNo,
                    StokNam = k.s.StokNam,
                    Qty = k.s.Qty,
                    Price = k.s.Price,
                    TotalPrice = k.s.TotalPrice,
                    EngNam = k.s.EngNam,
                    AssetClass = k.s.AssetClass,
                    Brand = k.s.Brand,
                    VendorName = k.s.VendorName,
                    VendorUniteNo = k.s.VendorUniteNo
                })
                .ToList();
            //
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                sv = sv.Where(vv => vv.AccDpt == v.AccDpt).ToList();
            }
            if (!string.IsNullOrEmpty(v.StockName))
            {
                sv = sv.Where(vv => !string.IsNullOrEmpty(vv.StokNam)).ToList();
                sv = sv.Where(vv => vv.StokNam.Contains(v.StockName)).ToList();
            }
            if (!string.IsNullOrEmpty(v.VendorName))
            {
                sv = sv.Where(c => c.VendorName.Contains(v.VendorName)).ToList();
            }

            if (!string.IsNullOrEmpty(v.VendorUniteNo))
            {
                sv = sv.Where(c => c.VendorUniteNo == v.VendorUniteNo).ToList();
            }
            //
            return sv;
        }

        public List<ReKeShCosCheckVModel> ReKeShCosCheck(ReportQryVModel v)
        {
            TempData["qry"] = JsonConvert.SerializeObject(v);
            List<ReKeShCosCheckVModel> mv;
            ReKeShCosCheckVModel rc;
            mv = new List<ReKeShCosCheckVModel>();
            var conn = _context.Database.GetDbConnection();
            string Sdate = DateTime.Parse(v.Sdate.ToString()).ToString("yyyy-MM-dd");
            string Edate = DateTime.Parse(v.Edate.ToString()).ToString("yyyy-MM-dd");



            //SqlParameter[] paras = new SqlParameter[]
            //{
            //    new SqlParameter("@Sdate",Convert.ToDateTime(Sdate)),
            //    new SqlParameter("@Edate",Convert.ToDateTime(Edate))
            //};
            string query = "";
            
            if (v.Location == "總院")
            {
                query = @"use [BMEDDB]
                    select * from (
                    select x.AccDpt as '成本中心代號', x.CustNam as '成本中心名稱', 
                    IIf(y.RepAmt is null,0,y.RepAmt) as '請修件數', x.keepcost as '管理/保養價值',
                     IIf(z.零件支出 is null, 0, z.零件支出) as '零件支出', 
                     (IIf(y.RepAmt is null,0,y.RepAmt)*50 + x.keepcost+ IIf(z.零件支出 is null, 0, z.零件支出)) as '合計', x.GroupId
                    from (
                    select a.AccDpt, c.Name_C CustNam, c.Loc GroupId, SUM(IIf(b.Cost is null, 0, b.Cost)) as keepcost
                    from BMEDAssets as a join BMEDAssetKeeps as b
                    on a.AssetNo = b.AssetNo left join Departments as c
                    on a.AccDpt = c.DptId
                    where a.AssetClass like '醫%' and c.Loc in ('K','C','P')
                    group by a.AccDpt, c.Name_C, c.Loc) as x left join
                    (
                    select Count(a.Docid) as RepAmt, a.AccDpt
                    from BMEDRepairs as a join BMEDRepairFlows as c
                    on a.Docid = c.Docid 
                    where (a.ApplyDate >= '" + Sdate + @"')
                    and c.Status in ('?','2')
                    group by a.AccDpt) as y
                    on x.AccDpt = y.AccDpt left join
                    (
                    select a.AccDpt, Sum(IIf(c.Cost is null, 0, c.Cost)) as '零件支出'
                    from BMEDRepairs as a join BMEDRepairDtls as c
                    on a.Docid = c.Docid 
                    where (c.EndDate  <= '" + Edate + @"')
                    group by a.AccDpt) as z
                    on x.AccDpt = z.AccDpt
                    ) as w
                    where w.成本中心代號 not in (select [成本中心代號] from [dbo].[排除部門單位])
                    order by w.成本中心代號";
            }
            else {
                query = @"use [BMEDDB]
                    select * from (
                    select x.AccDpt as '成本中心代號', x.CustNam as '成本中心名稱', 
                    IIf(y.RepAmt is null,0,y.RepAmt) as '請修件數', x.keepcost as '管理/保養價值',
                     IIf(z.零件支出 is null, 0, z.零件支出) as '零件支出', 
                     (IIf(y.RepAmt is null,0,y.RepAmt)*50 + x.keepcost+ IIf(z.零件支出 is null, 0, z.零件支出)) as '合計', x.GroupId
                    from (
                    select a.AccDpt, c.Name_C CustNam, c.Loc GroupId, SUM(IIf(b.Cost is null, 0, b.Cost)) as keepcost
                    from BMEDAssets as a join BMEDAssetKeeps as b
                    on a.AssetNo = b.AssetNo left join Departments as c
                    on a.AccDpt = c.DptId
                    where a.AssetClass like '醫%' and c.Loc in ('" + v.Location + @"')
                    group by a.AccDpt, c.Name_C, c.Loc
                    ) as x left join
                    (
                    select Count(a.Docid) as RepAmt, a.AccDpt
                    from BMEDRepairs as a join BMEDRepairFlows as c
                    on a.Docid = c.Docid 
                    where (a.ApplyDate >= '" + Sdate + @"')
                    and c.Status in ('?','2')
                    group by a.AccDpt
                    ) as y
                    on x.AccDpt = y.AccDpt left join
                    (
                    select a.AccDpt, Sum(IIf(c.Cost is null, 0, c.Cost)) as '零件支出'
                    from BMEDRepairs as a join BMEDRepairDtls as c
                    on a.Docid = c.Docid 
                    where (c.EndDate  <= '" + Edate + @"')
                    group by a.AccDpt) as z
                    on x.AccDpt = z.AccDpt
                    ) as w
                    where w.成本中心代號 not in (select [成本中心代號] from [dbo].[排除部門單位])
                    order by w.成本中心代號";
            }

            try
            {
                //open database line
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = query;
                var reader = command.ExecuteReader();

                //DataTable dt = new DataTable();
                

                while (reader.Read())
                {
                    rc = new ReKeShCosCheckVModel();
                    
                    rc.AccDpt = reader.GetString(0); 
                    rc.CustNam = reader.GetString(1);
                    rc.RepAmt = reader.GetInt32(2);
                    rc.Keepcost = reader.GetInt32(3);
                    rc.Partexp = reader.GetDecimal(4) <= 0 ? 0 : (int)Math.Round(reader.GetDecimal(4), 0, MidpointRounding.AwayFromZero);
                    rc.Sum = reader.GetDecimal(5) <= 0 ? 0 : (int)Math.Round(reader.GetDecimal(5), 0, MidpointRounding.AwayFromZero);

                    mv.Add(rc);
                }

                // Call Close when done reading.
                reader.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }

            return mv;
        }

        public IActionResult ExcelReKeShCosCheckList(ReportQryVModel v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("成本中心");
            dt.Columns.Add("成本中心名稱");
            dt.Columns.Add("請修件數");
            dt.Columns.Add("管理/保養價值");
            dt.Columns.Add("零件支出");
            dt.Columns.Add("合計");

            List<ReKeShCosCheckVModel> mv = ReKeShCosCheck(v);

            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.AccDpt;
                dw[1] = m.CustNam;
                dw[2] = m.RepAmt;
                dw[3] = m.Keepcost;
                dw[4] = m.Partexp;
                dw[5] = m.Sum;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("分攤費用清單");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "ExcelReKeShCosCheckList.xlsx"
            );
        }

        //超過五日案件
        public List<CaseOverFiveVModel> CaseOverFive(ReportQryVModel v)
        {
            List<CaseOverFiveVModel> mv = new List<CaseOverFiveVModel>();
            CaseOverFiveVModel dv;
            TempData["qry"] = JsonConvert.SerializeObject(v);

            //院區維修單
            var repairs = _context.BMEDRepairs
                        .Where(r => r.Loc == v.Location)
                        .Where(r => r.ApplyDate >= v.Sdate);
            
            var query = _context.BMEDRepairDtls
                 .Where(d => d.EndDate <= v.Edate)
                 .Join(repairs,
                         rd => rd.DocId,
                         r => r.DocId,
                 (rd, r) => new
                 {
                     rd.DocId,
                     rd.FailFactor,
                     EndDate = rd.EndDate.Value,
                     rd.InOut,
                     rd.DealDes,
                     rd.DealState,
                     r.ApplyDate,
                     r.AccDpt,
                     r.AssetNo,
                     r.PlantClass,
                     r.EngId,
                     r.TroubleDes,
                     r.AssetName
                 })
                 .Join(_context.AppUsers,
                         rd => rd.EngId,
                         r => r.Id,
                 (rd, u) => new
                 {
                     rd.DocId,
                     rd.FailFactor,
                     rd.EndDate,
                     rd.InOut,
                     rd.DealDes,
                     rd.DealState,
                     rd.ApplyDate,
                     rd.AccDpt,
                     rd.AssetNo,
                     rd.PlantClass,
                     rd.EngId,
                     rd.TroubleDes,
                     rd.AssetName,
                     u.FullName
                 })
                 .Join(_context.Departments,
                         rd => rd.AccDpt,
                         r => r.DptId,
                 (rd, d) => new
                 {
                     rd.DocId,
                     rd.FailFactor,
                     rd.EndDate,
                     rd.InOut,
                     rd.DealDes,
                     rd.DealState,
                     rd.ApplyDate,
                     rd.AccDpt,
                     rd.AssetNo,
                     rd.PlantClass,
                     rd.EngId,
                     rd.TroubleDes,
                     rd.AssetName,
                     rd.FullName,
                     d.Name_C
                 })
                 .Join(_context.BMEDDealStatuses,
                         rd => rd.DealState,
                         r => r.Id,
                 (rd, dl) => new
                 {
                     rd.DocId,
                     rd.FailFactor,
                     rd.EndDate,
                     rd.InOut,
                     rd.DealDes,
                    //rd.DealState,
                    rd.ApplyDate,
                     rd.AccDpt,
                     rd.AssetNo,
                     rd.PlantClass,
                     rd.EngId,
                     rd.TroubleDes,
                     rd.AssetName,
                     rd.FullName,
                     rd.Name_C,
                     dl.Title
                 })
                 .Where(g1 => g1.EndDate.Subtract(Convert.ToDateTime(g1.ApplyDate)).Days > 5);
           // query = qu.Where(r => r.AssetClass == (v.AssetClass1 ?? v.AssetClass2));


            //
            if (!string.IsNullOrEmpty(v.AccDpt))
            {
                query = query.Where(vv => vv.AccDpt == v.AccDpt);
            }
            //
            if (!string.IsNullOrEmpty(v.Manage))
            {
                if (v.Manage == "固資")
                {
                    query = query.Where(vv => vv.AssetNo.Length <= 6  && vv.AssetNo != "99999");
                }
                if (v.Manage == "列管")
                {
                    query = query.Where(vv => vv.AssetNo.Length > 6 || vv.AssetNo == "99999");
                }
            }

            foreach (var g in query.ToList())
            {
                dv = new CaseOverFiveVModel();
                dv.DocId = g.DocId;
                dv.AssetNo = g.AssetNo;
                dv.AccDpt = g.AccDpt;
                dv.AccDptName = g.Name_C;
                dv.AssetName = g.AssetName;
                dv.TroubleDes = g.TroubleDes;
                dv.DealState = g.Title;
                dv.DealDes = g.DealDes;
                dv.SDate = g.ApplyDate;
                dv.EDate = g.EndDate;
                dv.EngName = g.FullName;
                dv.Days = dv.EDate.Subtract(dv.SDate).Days - 4;
                mv.Add(dv);
            }
            //
            return mv;
        }

        public IActionResult ExcelCaseOverFiveList(ReportQryVModel v)
        {
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("表單編號");
            dt.Columns.Add("財產編號");
            dt.Columns.Add("成本中心");
            dt.Columns.Add("成本中心名稱");
            dt.Columns.Add("設備名稱");
            dt.Columns.Add("故障情形");
            dt.Columns.Add("處理狀況");
            dt.Columns.Add("工程師");
            dt.Columns.Add("請修日期");
            dt.Columns.Add("完工日期");
            dt.Columns.Add("超過天數");
            


            List<CaseOverFiveVModel> mv = CaseOverFive(v);
            mv.ForEach(m =>
            {
                dw = dt.NewRow();
                dw[0] = m.DocId;
                dw[1] = m.AssetNo;
                dw[2] = m.AccDpt;
                dw[3] = m.AccDptName;
                dw[4] = m.AssetName;
                dw[5] = m.TroubleDes;
                dw[6] = m.DealState;
                dw[7] = m.EngName;
                dw[8] = m.SDate.ToString("yyyy/MM/dd");
                dw[9] = m.EDate.ToString("yyyy/MM/dd");
                dw[10] = m.Days;
                dt.Rows.Add(dw);
            });
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("超過五日案件清單");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "ExcelCaseOverFiveList.xlsx"
            );
        }


        public IActionResult EffectRatio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EffectRatio(EffectRatio effectRatio)
        {
            if (ModelState.IsValid)
            {
                effectRatio.TotalInRepCases =
                _context.BMEDRepairDtls.Where(d => d.EndDate >= effectRatio.Sdate && d.EndDate <= effectRatio.Edate)
                .Where(d => d.InOut == "內修").Count();
                effectRatio.TotalKeepCases =
                    _context.BMEDKeeps.Where(d => d.SentDate >= effectRatio.Sdate && d.SentDate <= effectRatio.Edate)
                    .Count();
                effectRatio.FiveDaysInRepCases =
                    _context.BMEDRepairDtls.Where(d => d.EndDate >= effectRatio.Sdate && d.EndDate <= effectRatio.Edate)
                    .Where(d => d.InOut == "內修")
                    .Join(_context.BMEDRepairs, r => r.DocId, d => d.DocId,
                    (r, d) => new
                    {
                        Edate = r.EndDate.Value,
                        Adate = d.ApplyDate
                    }).Where(f => f.Adate >= f.Edate.Date.AddDays(-7)).Count();
                effectRatio.KpFinishedCases =
                    _context.BMEDKeeps.Where(d => d.SentDate >= effectRatio.Sdate && d.SentDate <= effectRatio.Edate)
                    .Join(_context.BMEDKeepDtls.Where(k => k.EndDate != null), d => d.DocId, k => k.DocId,
                    (d, k) => k).Count();
                effectRatio.FiveInRepRatio = 0m;
                if (effectRatio.TotalInRepCases > 0)
                {
                    effectRatio.FiveInRepRatio =
                        Convert.ToDecimal(effectRatio.FiveDaysInRepCases) / Convert.ToDecimal(effectRatio.TotalInRepCases);
                }
                effectRatio.KeepFinishedRatio = 0m;
                if (effectRatio.TotalKeepCases > 0)
                {
                    effectRatio.KeepFinishedRatio =
                        Convert.ToDecimal(effectRatio.KpFinishedCases) / Convert.ToDecimal(effectRatio.TotalKeepCases);
                }
            }

            return View(effectRatio);
        }

        public IActionResult PrintRpKpHistory(ReportQryVModel v)
        {
            ViewData["Ano"] = v.AssetNo;

            List<RpKpHistoryVModel> rk = RpKpHistory(v);
            AssetAnalysis ay = new AssetAnalysis();
            ay.RepairHour = rk.Where(r => r.DocType == "請修").Select(r => r.Hours).Sum().Value;
            ay.RepCost = rk.Where(r => r.DocType == "請修").Select(r => r.Cost).Sum().Value;
            ay.KeepHour = rk.Where(r => r.DocType == "保養").Select(r => r.Hours).Sum().Value;
            ay.KeepCost = rk.Where(r => r.DocType == "保養").Select(r => r.Cost).Sum().Value;
            AssetModel at = _context.BMEDAssets.Find(v.AssetNo);
            if (at != null)
            {
                if (at.Cost != null)
                {
                    if (at.Cost > 0)
                        ay.RepRatio = decimal.Round(ay.RepCost / at.Cost.Value * 100m, 2);
                    else
                        ay.RepRatio = 0;
                }
            }
            else
            {
                return new JsonResult(v)
                {
                    Value = new { success = false, error = "無此財產!" }
                };
            }
            double faildays = 0;
            double d = 0;
            rk.Where(r => r.DocType == "請修").ToList()
                .ForEach(r =>
                {
                    //if (r.EndDate == null)
                    //{
                    //    faildays += v.Edate.Value.Subtract(r.ApplyDate).TotalDays;
                    //}
                    //else if (v.Edate != null)
                    //{
                    //    if (r.EndDate.Value.CompareTo(v.Edate.Value) > 0)
                    //        faildays += v.Edate.Value.Subtract(r.ApplyDate).TotalDays;
                    //    else
                    //    {

                    //        d = r.EndDate.Value.Subtract(r.ApplyDate).TotalDays;
                    //        if (d > 0)
                    //        {
                    //            if (d <= 1d)
                    //                faildays += 1d;
                    //            else
                    //                faildays += d;
                    //        }

                    //    }
                    //}
                    if (r.EndDate != null)
                    {
                        d = r.EndDate.Value.Subtract(r.ApplyDate).TotalDays;
                        if (d > 0)
                        {
                            if (d <= 1d)
                                faildays += 1d;
                            else
                                faildays += d;
                        }
                    }


                });

            if (v.Sdate == null && v.Edate == null)
            {
                ay.ProperRate = null;
            }
            else if (v.Sdate == null && v.Edate != null)
            {
                ay.ProperRate = null;
            }
            else if (v.Sdate != null && v.Edate == null)
            {
                v.Edate = DateTime.Now.AddHours(23)
                .AddMinutes(59)
                .AddSeconds(59);
                ay.ProperRate = decimal.Round(100m -
                Convert.ToDecimal(faildays / v.Edate.Value.Subtract(v.Sdate.Value).TotalDays) * 100m, 2);

            }
            else
            {
                ay.ProperRate = decimal.Round(100m -
                Convert.ToDecimal(faildays / v.Edate.Value.Subtract(v.Sdate.Value).TotalDays) * 100m, 2);
            }

            ViewData["Analysis"] = ay;
            return PartialView(rk);
        }


        
        /// <summary>
        /// Get Assets by location, according to asset's delivDpt.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<AssetModel> GetAssetsByLoc(string location)
        {
            List<AssetModel> bmedAssets = null;
            string[] s = new string[] { "C", "P" ,"K" };

            if (location == "總院")
            {
                var depar = _context.Departments.Where(r => s.Contains(r.Loc));

                bmedAssets = _context.BMEDAssets.Join(  depar, 
                                                        a => a.DelivDpt, 
                                                        d => d.DptId,
                                                        (a, d) => a
                                                     )
                                                .Where(a => a.DisposeKind != "報廢")
                                                .ToList();
            }
            else
            { 
                var depar = _context.Departments.Where(r => r.Loc == location);

                bmedAssets = _context.BMEDAssets.Join(depar, a => a.DelivDpt, d => d.DptId,
                                (a, d) => a )
                              .Where(a => a.DisposeKind != "報廢")
                              .ToList();
            }
            return bmedAssets;
        }

        private List<QuestReport> QuestAnaly(ReportQryVModel v)
        {
            TempData["qry"] = JsonConvert.SerializeObject(v);
            List<QuestReport> qlist = new List<QuestReport>();
            QuestReport qr;
            List<QuestMain> qm = _context.QuestMains.ToList();
            if (v.Sdate != null)
                qm = qm.Where(s => s.Rtt >= v.Sdate).ToList();
            if (v.Edate != null)
                qm = qm.Where(s => s.Rtt <= v.Edate).ToList();
            if (v.AccDpt != null)
                qm = qm.Where(s => s.CustId == v.AccDpt).ToList();
            if (v.Qname != null)
                qm = qm.Where(s => s.Qtitle == v.Qname).ToList();
            // Contract c = null;
            qm.ForEach(m =>
            {
                qr = new QuestReport();
                qr.TimeStamp = m.Rtt.ToString("yyyy/MM/dd");
                //qr.Contract = m.ContractNo == null ? "" :
                //(c = db.Contracts.Find(m.ContractNo)) == null ? "" : c.ContractName;
                qr.Qname = m.Qtitle;
                qr.DptId = m.CustId;
                qr.DptName = m.CustNam;
                qr.Answers = _context.QuestAnswers.Where(a => a.Docid == m.Docid)
                             .OrderBy(a => a.Qid).ToList();
                //if (c != null && qr.Answers.Count > 0)
                //    qlist.Add(qr);
                if (qr.Answers.Count > 0)
                    qlist.Add(qr);
            });
            return qlist;
        }

        public IActionResult ExcelQA(ReportQryVModel v)
        {
            List<QuestReport> qrlist = QuestAnaly(v);
            DataTable dt = new DataTable();
            DataRow dw;
            dt.Columns.Add("時間戳記");
            dt.Columns.Add("問卷名稱");
            dt.Columns.Add("部門代號");
            dt.Columns.Add("部門名稱");
            //
            int cols = 0;
            _context.QuestionnaireMs.Where(m => m.Flg == "Y" && m.Qname == v.Qname)
            .Join(_context.Questionnaires.Where(q => q.Required == "Y"), m => m.VerId, q => q.VerId,
            (m, q) => q).OrderBy(q => q.Qid)
            .ToList().
            ForEach(q =>
            {
                dt.Columns.Add(q.Qtitle);
            });
            //
            qrlist.ToList()
                    .ForEach(j =>
                    {
                        dw = dt.NewRow();
                        dw[0] = j.TimeStamp;
                        dw[1] = j.Qname;
                        dw[2] = j.DptId;
                        dw[3] = j.DptName;
                        cols = 4;
                        foreach (QuestAnswer s in j.Answers)
                        {
                            dw[cols] = s.Answer;
                            cols++;
                        }
                        dt.Rows.Add(dw);
                    });
            //
            //
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("滿意度問卷統計表");
            workSheet.Cells[1, 1].LoadFromDataTable(dt, true);

            // Generate the Excel, convert it into byte array and send it back to the controller.
            byte[] fileContents;
            fileContents = excel.GetAsByteArray();

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "滿意度調查統計表.xlsx"
            );
        }

        /// <summary>
        /// Get Departments by location.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartmentsByLoc(string location)
        {
            List<DepartmentModel> departments = null;
            if (location == "總院")
            {
                departments = _context.Departments.Where(d => d.Loc == "C" || d.Loc == "P" || d.Loc == "K").ToList();
            }
            else
            {
                departments = _context.Departments.Where(d => d.Loc == location).ToList();
            }
            return departments;
        }

        
    }
}