using Mosaic.Domain;

namespace Mosaic.Services
{
    public interface IToDoService
    {
        /// <summary>
        /// Returns any to do lists if already exists, creates new if not
        /// TODO replace with proper get by id once Database implemented
        /// </summary>
        /// <returns></returns>
        ToDoList GetList();

        /// <summary>
        /// Adds a task to a To Do list
        /// </summary>
        /// <param name="listId">Id of list to update</param>
        /// <param name="taskDescription">Task description</param>
        /// <returns>Newly created task added to list</returns>
        ToDoTask AddTask(int listId, string taskDescription);


        /// <summary>
        /// Removes Task from a To Do list
        /// </summary>
        /// <param name="listId">Id of list</param>
        /// <param name="taskId">Id of task being removed</param>
        void RemoveTask(int listId, int taskId);

        /// <summary>
        /// Updates a task settings its completed status
        /// </summary>
        /// <param name="listId">Id of list</param>
        /// <param name="taskId">Id of task</param>
        /// <param name="completed">Completed status, true = completed </param>
        /// <returns>task being updated</returns>
        ToDoTask UpdateTask(int listId, int taskId, bool completed);
    }
}
