﻿using Domain.Commands;
using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstractions.Services
{
    public interface ITaskService
    {
        Task<CreateTaskCommandResult> CreateTaskCommandHandler(CreateTaskCommand command);
        Task<GetAllTasksQueryResult> GetAllTasksQueryHandler();
        Task<UpdateTaskCommandResult> UpdateTaskCommandHandler(UpdateTaskCommand command);
    }
}
