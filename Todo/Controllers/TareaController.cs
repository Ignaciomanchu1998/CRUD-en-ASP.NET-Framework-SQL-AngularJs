using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Todo.Dao;
using Todo.Models;
using Todo.Utils;

namespace Todo.Controllers
{
    public class TareaController : Controller
    {
        // GET: Tarea
        private StructureResponse _struct;
        private TareaDao _t;
        public TareaController()
        {
            _struct = new StructureResponse(); _t = new TareaDao();
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> ListTarea()
        {
            _struct = await _t.ListTarea();
            return Json(_struct, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> AddTarea(Tarea data)
        {
            _struct = await _t.AddTarea(data);
            return Json(_struct, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> UpdateTarea(Tarea data)
        {
            _struct = await _t.UpdateTarea(data);
            return Json(_struct, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> DeleteTarea(Tarea data)
        {
            _struct = await _t.DeleteTarea(data);
            return Json(_struct, JsonRequestBehavior.AllowGet);
        }
    }
}