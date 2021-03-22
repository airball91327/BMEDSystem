using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using EDIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EDIS.Areas.BMED.Controllers
{
    [Area("BMED")]
    [Authorize]
    public class QuestionnaireController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<AppUserModel, int> _userRepo;
        private readonly IRepository<DepartmentModel, string> _dptRepo;
        private readonly IRepository<DocIdStore, string[]> _dsRepo;
        private readonly IEmailSender _emailSender;
        private readonly CustomUserManager userManager;
        private readonly CustomRoleManager roleManager;
        private int pageSize = 50;
        private readonly IHostingEnvironment _hostingEnvironment;

        public QuestionnaireController(ApplicationDbContext context,
                              IRepository<AppUserModel, int> userRepo,
                              IRepository<DepartmentModel, string> dptRepo,
                              IRepository<DocIdStore, string[]> dsRepo,
                              IEmailSender emailSender,
                              IHostingEnvironment hostingEnvironment,
                              CustomUserManager customUserManager,
                              CustomRoleManager customRoleManager)
        {
            _context = context;
            _userRepo = userRepo;
            _dptRepo = dptRepo;
            _dsRepo = dsRepo;
            _emailSender = emailSender;
            _hostingEnvironment = hostingEnvironment;
            userManager = customUserManager;
            roleManager = customRoleManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult List(int? id)
        {
            ViewData["verid"] = id;
            var que = _context.Questionnaires.Where(q => q.VerId == id).ToList();
            if (que == null)
            {
                return StatusCode(404);
            }
            return View(que);
        }

        public ActionResult Create(int? id)
        {
           
            if (id == null)
            {
                return StatusCode(404);
            }
            string s = id.ToString();
            Questionnaire q = new Questionnaire();
            var que = _context.Questionnaires.Where(u => u.VerId == id);

            int cnt = que.Select(u => u.Qid).DefaultIfEmpty(0).Max();
            q.VerId = Convert.ToInt32(s);
            q.Qid = cnt + 1;

            return View(q);
        }

        // POST: /Questionnaire/Create

        [HttpPost]
        public ActionResult Create(Questionnaire questionnaire)
        {
            if (ModelState.IsValid)
            {
                _context.Questionnaires.Add(questionnaire);
                _context.SaveChanges();

                return RedirectToAction("List", new { id = questionnaire.VerId });
            }

            return View(questionnaire);
        }

        public IActionResult Delete(int? id, int? qid )
        {
            if (id == null || qid == null)
            {
                return StatusCode(404);
            }

            Questionnaire questionnaire = _context.Questionnaires.Find(id,qid);

            if (questionnaire == null)
            {
                return StatusCode(404);
            }
            return View(questionnaire);
        }

        // POST: MedEngMgt/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id = 0, int qid = 0 )
        {
           
            Questionnaire questionnaire = _context.Questionnaires.Find(id, qid);
            
            if (questionnaire == null)
            {
                return StatusCode(404);
            }

            int verId = questionnaire.VerId;
            _context.Questionnaires.Remove(questionnaire);
            _context.SaveChanges();
            return RedirectToAction("List",new { id = verId });
        }

        public ActionResult Preview(int id)
        {
            DateTime dd = DateTime.Now;
            string yyyymm = Convert.ToString(dd.Year * 100 + dd.Month);

            var evalVM = new Evaluation();
            QuestMain main = new QuestMain();
            main.Docid = GetID();
            main.YYYYmm = yyyymm;
            main.Rtt = DateTime.Now;
            _context.QuestMains.Add(main);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                //ModelState.AddModelError("", e.Message);
                return Content(e.Message);
            }
            //
            evalVM.Qname = _context.QuestionnaireMs.Find(id).Qname;
            evalVM.Docid = main.Docid;
            evalVM.YYYYmm = yyyymm;
            //evalVM.CustId = main.CustId;
            //evalVM.CustNam = main.CustNam;

            List<Questionnaire> ql =
                _context.Questionnaires.Where(qt => qt.VerId == id && qt.Required == "Y").ToList();
            Question q;
            int i = 1;
            foreach (Questionnaire a in ql)
            {
                q = new Question();
                q.ID = id;
                q.QID = a.Qid;
                q.QuestionText = "(" + Convert.ToString(i) + ") " + a.Qtitle;
                q.Typ = a.Typ;
                evalVM.Questions.Add(q);
                i++;
            }
            //
            List<SelectListItem> listItem = new List<SelectListItem>();
            List<SelectListItem> listItem2 = new List<SelectListItem>();
            SelectListItem li;
            _context.Departments.ToList()
                .ForEach(d =>
                {
                    li = new SelectListItem();
                    li.Text = d.Name_C;
                    li.Value = d.DptId;
                    listItem.Add(li);

                });
            ViewData["Dept"] = new SelectList(listItem, "Value", "Text");
            
            return View(evalVM);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult New(Evaluation model)
        {
            if (model.Questions.Where(q => q.SelectedAnswer == null && q.Typ == "select").Count() > 0)
            {
                throw new Exception("尚有項目未圈選!!");
            }
            if (model.Questions.Where(q => q.SelectedAnswer == null && q.Typ == "text").Count() > 0)
            {
                throw new Exception("尚有項目未填寫!!");
            }

            if (ModelState.IsValid)
            {
                QuestMain main = _context.QuestMains.Find(model.Docid);
                main.CustId = model.CustId;
                main.CustNam = _context.Departments.Find(model.CustId).Name_C;
                main.ContractNo = model.ContractNo;
                _context.Entry(main).State = EntityState.Modified;
                //
                List<QuestAnswer> at = _context.QuestAnswers.Where(a => a.Docid == model.Docid).ToList();
                QuestAnswer ar;
                foreach (QuestAnswer w in at)
                {
                    if (w != null)
                        _context.QuestAnswers.Remove(w);
                }
                foreach (var q in model.Questions)
                {
                    // Save the data 
                    ar = new QuestAnswer();
                    ar.Docid = model.Docid;
                    ar.VerId = q.ID;
                    ar.Qid = q.QID;
                    ar.Answer = q.SelectedAnswer;
                    _context.QuestAnswers.Add(ar);
                }
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

                return new JsonResult(at)
                {
                    Value = new { success = true, error = "" }
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

        public ActionResult Preview2(int id)
        {
            DateTime dd = DateTime.Now;
            string yyyymm = Convert.ToString(dd.Year * 100 + dd.Month);

            var evalVM = new Evaluation();
           
            
            //
            evalVM.Qname = _context.QuestionnaireMs.Find(id).Qname;
            //evalVM.Docid = main.Docid;
            evalVM.YYYYmm = yyyymm;
            //evalVM.CustId = main.CustId;
            //evalVM.CustNam = main.CustNam;

            List<Questionnaire> ql =
                _context.Questionnaires.Where(qt => qt.VerId == id && qt.Required == "Y").ToList();
            Question q;
            int i = 1;
            foreach (Questionnaire a in ql)
            {
                q = new Question();
                q.ID = id;
                q.QID = a.Qid;
                q.QuestionText = "(" + Convert.ToString(i) + ") " + a.Qtitle;
                q.Typ = a.Typ;
                evalVM.Questions.Add(q);
                i++;
            }
            //
            List<SelectListItem> listItem = new List<SelectListItem>();
            List<SelectListItem> listItem2 = new List<SelectListItem>();
            SelectListItem li;
            _context.Departments.ToList()
                .ForEach(d =>
                {
                    li = new SelectListItem();
                    li.Text = d.Name_C;
                    li.Value = d.DptId;
                    listItem.Add(li);

                });
            ViewData["Dept"] = new SelectList(listItem, "Value", "Text");

            return View(evalVM);
        }

        public string GetID()
        {
            string did = "";
            try
            {
                DocIdStore ds = new DocIdStore();
                ds.DocType = "滿意度調查";
                string s = _dsRepo.Find(x => x.DocType == "滿意度調查").Select(x => x.DocId).Max();
                int yymmdd = (System.DateTime.Now.Year - 1911) * 10000 + (System.DateTime.Now.Month) * 1000 + System.DateTime.Now.Day;
                if (!string.IsNullOrEmpty(s))
                {
                    did = s;
                }
                if (did != "")
                {
                    if (Convert.ToInt64(did) / 1000 == yymmdd)
                        did = Convert.ToString(Convert.ToInt64(did) + 1);
                    else
                        did = Convert.ToString(yymmdd * 1000 + 1);
                    ds.DocId = did;
                    _dsRepo.Update(ds);
                }
                else
                {
                    did = Convert.ToString(yymmdd * 100 + 1);
                    ds.DocId = did;
                    // 二次確認資料庫內沒該資料才新增。
                    var dataIsExist = _dsRepo.Find(x => x.DocType == "滿意度調查");
                    if (dataIsExist.Count() == 0)
                    {
                        _dsRepo.Create(ds);
                    }
                }
            }
            catch (Exception e)
            {
                RedirectToAction("Preview", "Questionnaire", new { Area = "BMED" });
            }
            return did;
        }

    }
}