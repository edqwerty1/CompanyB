using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosaic.Domain
{
    /// <summary>
    /// ToDoList task information 
    /// </summary>
    public class ToDoTask : BaseEntity
    {
        public string Description { get; private set; }

        public bool Completed { get; set; }

        public virtual ToDoList List { get; set; }

        public ToDoTask(string description)
        {
            this.Description = description;
        }
    }
}
