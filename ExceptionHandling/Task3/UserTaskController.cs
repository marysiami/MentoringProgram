using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            var task = _taskService.CreateTask(description);

            try
            {
                _taskService.AddTaskForUser(userId, task);
            }
            catch (Exception e)
            {
                model.AddAttribute("action_result", e.Message);
                return false;
            }

            return true;
        }

    }
}