using System;
using System.Linq;
using Mosaic.Domain;
using System.Collections.Generic;

namespace Mosaic.Services.Implementation
{
    public class ToDoService : IToDoService
    {
        // Replace with persistence repository
        private static ToDoList list;

        /// <inheritdoc />
        public ToDoList GetList()
        {
            list = list ?? new ToDoList { Id = 1 };

            if (list.Tasks == null)
            {
                list.AddTask(new ToDoTask("An example Task"));
            }

            return list;
        }

        /// <inheritdoc />
        public ToDoTask AddTask(int listId, string taskDescription)
        {
            ToDoTask task = new ToDoTask(taskDescription);
            list.AddTask(task);
            return task;
        }

        /// <inheritdoc />
        public void RemoveTask(int listId, int taskId)
        {
            list.RemoveTask(taskId);
        }

        /// <inheritdoc />
        public ToDoTask UpdateTask(int listId, int taskId, bool completed)
        {
            var task = list.Tasks.FirstOrDefault(t => t.Id == taskId);

            task.Completed = completed;
            return task;
        }
    }
}
