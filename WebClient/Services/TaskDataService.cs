using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebClient.Abstractions;
using WebClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using Domain.ViewModel;
using Core.Extensions.ModelConversion;
using Domain.Queries;

namespace WebClient.Services
{
    public class TaskDataService: ITaskDataService
    {
        private readonly HttpClient httpClient;
        public TaskDataService(IHttpClientFactory clientFactory)
        {
            httpClient = clientFactory.CreateClient("FamilyTaskAPI");
            Tasks = new List<TaskVm>();
            LoadTasks();
        }

        public List<TaskVm> Tasks { get; private set; }
        public TaskVm SelectedTask { get; private set; }

        public event EventHandler TasksUpdated;
        public event EventHandler TaskSelected;
        public event EventHandler<string> TaskFailed;

        public void SelectTask(Guid id)
        {
            SelectedTask = Tasks.SingleOrDefault(t => t.Id == id);
            //TasksUpdated?.Invoke(this, null);
        }

        public async Task CompleteTask(Guid id)
        {
            var completeTask = Tasks.FirstOrDefault(x => x.Id == id);
            completeTask.IsComplete = true;
            var result = await Update(completeTask.ToUpdateTaskCommand());
            if (result != null)
            {
                await RefreshTask();
            }
            TaskFailed?.Invoke(this, "Unable to complete task");
            TasksUpdated?.Invoke(this, null);
        }

        private async void LoadTasks()
        {
            Tasks = (await GetAllTasks()).Payload;
            TasksUpdated?.Invoke(this, null);
        }

        public async Task AddTask(TaskVm model)
        {
            var result = await Create(model.ToCreateTaskCommand());
            if (result != null)
            {
                await RefreshTask();
                return;
            }
            TaskFailed?.Invoke(this, "Unable to create task");
            

        }

        private async Task<CreateTaskCommandResult> Create(CreateTaskCommand command)
        {
            return await httpClient.PostJsonAsync<CreateTaskCommandResult>("tasks", command);
        }

        private async Task<GetAllTasksQueryResult> GetAllTasks()
        {
            return await httpClient.GetJsonAsync<GetAllTasksQueryResult>("tasks");
        }
        private async Task<UpdateTaskCommandResult> Update(UpdateTaskCommand command)
        {
            return await httpClient.PutJsonAsync<UpdateTaskCommandResult>($"tasks/{command.Id}",command);
        }

        public async Task AssignTask(Guid memberId)
        {
            SelectedTask.AssignedMemberId = memberId;
            var result = await Update(SelectedTask.ToUpdateTaskCommand());
            if (result != null)
            {
                await RefreshTask();
                return;
            }
            TaskFailed?.Invoke(this, "Unable to create task");
        }

        private async Task RefreshTask() {
            var updatedTasks = (await GetAllTasks()).Payload;
            if (updatedTasks != null)
            {
                Tasks = updatedTasks.ToList();
                TasksUpdated?.Invoke(this, null);
                return;
            }
            TaskFailed?.Invoke(this, "Error while refreshing task list.");
        }
    }
}