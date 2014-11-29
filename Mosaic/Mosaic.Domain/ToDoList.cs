using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
namespace Mosaic.Domain
{
    /// <summary>
    /// To Do List Entity
    /// Used to persist To Do lists
    /// </summary>
    [Description("To Do List")]
    public class ToDoList : BaseEntity
    {
        public virtual ICollection<ToDoTask> Tasks { get; private set; }


        public void AddTask(ToDoTask task)
        {
            if (Tasks == null)
                Tasks = new HashSet<ToDoTask>();
            // Normally EF would take care of Ids, temp code for demo 
            // #TODO replace
            var lastTask = Tasks.OrderBy(t => -t.Id).FirstOrDefault();
            task.Id = (lastTask == null ? 0 : lastTask.Id) + 1;
            // Again EF should take care of this
            task.List = this;

            Tasks.Add(task);
        }

        public void RemoveTask(int taskId)
        {
            if (Tasks == null)
                return;

            var taskToRemove = Tasks.FirstOrDefault(t => t.Id == taskId);

            if (taskToRemove != null)
                Tasks.Remove(taskToRemove);


        }
    }
}
