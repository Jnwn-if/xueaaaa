using NET200703.ZSGC.DTOModel;
using NET200703.ZSGC.POCOModel;
using NET200703.ZSGC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET200703.ZSGC.Controllers
{
    public class BiuGameController : Controller
    {
        [HttpGet]
        // GET: BiuGame
        public ActionResult Index()
        {
            using (var db = new StudentEntiy())
            {
                var list = db.Game.Select(s => new GameViewModel()
                {
                    id = s.id,
                    gTid = s.gTid,
                    gSid = s.gSId,
                    gName = s.gName,
                    gPrice = s.gPrice,
                    gState = s.gState
                }).ToList();

                return View(list);
            }
        }


        [HttpGet]
        public ActionResult Add()
        {
            using (var db = new StudentEntiy())
            {
                ViewBag.Type = Gtype();
                ViewBag.Studio = Studio();
            }
            return View();
        }

        //添加
        [HttpPost]
        public ActionResult Add(AddGameViewModel model)
        {
            //EF添加
            if (ModelState.IsValid)
            {
                var efModle = new Game()
                {
                    id = model.id,
                    gName = model.gName,
                    gTid = model.gTid,
                    gSId = model.gSid,
                    gPrice = model.gPrice,
                    gState = model.gState
                };

                using (var db = new StudentEntiy())
                {
                    db.Entry<Game>(efModle).State = System.Data.Entity.EntityState.Added;
                    if (db.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "添加失败");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "信息有误，请核对信息完整性！");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new StudentEntiy())
            {
                ViewBag.Type = Gtype();
                ViewBag.Studio = Studio();

                var model = db.Game.FirstOrDefault(s => s.id == id);
                if (model != null)
                {
                    var viewModel = new EditListViewModel()
                    {
                        id = model.id,
                        gName = model.gName,
                        gTid = model.gTid,
                        gSid = model.gSId,
                        gPrice = model.gPrice,
                        gState = model.gState
                    };
                    return View(viewModel);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(EditListViewModel viewModel)
        {
            //模型验证
            if (ModelState.IsValid)
            {
                //上下文
                using (var db = new StudentEntiy())
                {
                    //查询出当前列信息
                    var model = db.Game.FirstOrDefault(s => s.id == viewModel.id);
                    if (model != null)
                    {
                        model.gName = viewModel.gName;
                        model.gTid = viewModel.gTid;
                        model.gSId = viewModel.gSid;
                        model.gPrice = viewModel.gPrice;
                        model.gState = viewModel.gState;
                        //提交
                        db.SaveChanges();
                        ViewBag.SaveMsg = "修改成功！";
                    }
                }
            }
            else
            {
                //编辑失败信息
                ModelState.AddModelError("", "失败！请检查信息完整性！");
            }
            ViewBag.Type = Gtype();
            ViewBag.Studio = Studio();
            return View(viewModel);
        }

        public List<SelectListItem> Gtype()
        {
            using (var db = new StudentEntiy())
            {
                var list = db.GType.Select(s => new SelectListItem()
                {
                    Text = s.name,
                    Value = s.id.ToString()
                }).ToList();
                return list;
            }
        }

        public List<SelectListItem> Studio()
        {
            using (var db = new StudentEntiy())
            {
                var list = db.Studio.Select(s => new SelectListItem()
                {
                    Text = s.sName,
                    Value = s.id.ToString()
                }).ToList();
                return list;
            }
        }

        public ActionResult Delete(int id)
        {
            //上下文
            using(var db =new StudentEntiy())
            {
                var result = new ResultModel();
                //查询要删除的列是否存在
                var model = db.Game.FirstOrDefault(s => s.id == id);
                if (model != null)
                {
                    //存在执行：
                    db.Game.Remove(model);
                    if (db.SaveChanges() > 0)
                    {
                        result.IsSuccess = true;
                        result.ErrorMessage = "删除成功";
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.ErrorMessage = "网络繁忙，请稍后尝试！";

                    }
                }
                else
                {
                    result.IsSuccess = true;
                    result.ErrorMessage = "失败，该信息可能已删除！";

                }
                return Json(result);
            }
        }

    }
}