using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoAuthApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TodoAuthApp.Managers;
using System.Net;

namespace TodoAuthApp.Controllers
{
    [Authorize]
    public class TodosController : Controller
    {
        private TodosManager db = new TodosManager();
        // GET: Todos
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var todos = db.GetToDos(id);
            return View(todos);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }
            todo.UserId = User.Identity.GetUserId();
            db.CreateToDo(todo);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var todo = db.GetId(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            if (todo.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return View(todo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }
            todo.UserId = User.Identity.GetUserId();
            db.EditToDo(todo);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var todo = db.GetId(id);
            if (todo == null)
            {
                HttpNotFound();
            }
            if(todo.UserId != User.Identity.GetUserId())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return View(todo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Todo todo)
        {
            
            todo.UserId = User.Identity.GetUserId();
            db.DeleteToDo(todo);
            return RedirectToAction("Index");

        }
    }
}