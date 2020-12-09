using Core.Abstractions.Repositories;
using Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
//using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class TaskRepository : BaseRepository<Guid,Task,TaskRepository>,ITaskRepository
    {
        public TaskRepository(FamilyTaskContext context) : base(context)
        { }

        ITaskRepository IBaseRepository<Guid, Task, ITaskRepository>.Include(string navigationPath, CancellationToken cancellationToken)
        {
            return base.Include(navigationPath, cancellationToken);
        }

        ITaskRepository IBaseRepository<Guid, Task, ITaskRepository>.NoTrack()
        {
            return base.NoTrack();
        }

        ITaskRepository IBaseRepository<Guid, Task, ITaskRepository>.Reset()
        {
            return base.Reset();
        }
    }
}
