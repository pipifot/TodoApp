using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoAuthApp.Models;

namespace TodoAuthApp.Managers
{
    public class TodosManager
    {
        public ICollection<Todo> GetToDos(string userId)
        {
            List<Todo> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Todos.Where(x => x.UserId == userId).ToList();
            }
            return result;
        }
        public void CreateToDo(Todo todo)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Todos.Add(todo);
                db.SaveChanges();
            }
        }
        public Todo GetId(int id)
        {
            Todo todo;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                todo = db.Todos.Find(id);
            }
            return todo;
        }
        public void EditToDo(Todo todo)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Todos.Attach(todo);
                db.Entry(todo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
        public void DeleteToDo(Todo todo)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Todos.Attach(todo);
                if (todo != null)
                {
                    db.Todos.Remove(todo);
                    db.SaveChanges();
                }
               
                
            }
        }
    }
}
