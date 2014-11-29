using Mosaic.Domain;
using Mosaic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mosaic.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoService toDoService;
        public HomeController(IToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        // Home/Index       
        /// <summary>
        /// default route, returns and displays To Do List 
        /// </summary>
        /// <returns>Index view</returns>
        public ActionResult Index()
        {
            ToDoList task = toDoService.GetList();
            return View(task);
        }

        /// <summary>
        /// Returns partial view displaying to do list
        /// Called via unobtrusive ajax request
        /// </summary>
        /// <returns>GetToDoList view</returns>
        public PartialViewResult GetToDoList()
        {
            var list = toDoService.GetList();
            
            return PartialView(list);
        }

        /// <summary>
        /// Adds and creates a task that is added to To Do List
        /// </summary>
        /// <param name="listId">Id of list to add task to</param>
        /// <param name="taskDescription">Task description</param>
        /// <returns>Index view</returns>
        [HttpPost]
        public RedirectResult AddTask(int listId, string taskDescription)
        {
            PartialView(toDoService.AddTask(listId, taskDescription));
            return Redirect("Index");
        }

        /// <summary>
        /// Removes task from To Do list
        /// </summary>
        /// <param name="listId">Id of list to remove task from</param>
        /// <param name="taskId">Id of task to remove</param>
        /// <returns>ToDoTask view</returns>
        [HttpPost]
        public RedirectResult RemoveTask(int listId, int taskId)
        {
            toDoService.RemoveTask(listId, taskId);
            return Redirect("GetToDoList");
        }

        /// <summary>
        /// Updates a Task, setting its completed status
        /// </summary>
        /// <param name="listId">Id of list task is on</param>
        /// <param name="taskId">Id of task to updated</param>
        /// <param name="completed">Completed status</param>
        /// <returns>ToDoTask view</returns>
        [HttpPost]
        public PartialViewResult SetCompleted(int listId, int taskId, bool completed)
        {
            var task = toDoService.UpdateTask(listId, taskId, completed);
            return PartialView("ToDoTask", task);
        }
    }
}