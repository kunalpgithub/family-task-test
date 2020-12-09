using Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Core.Abstractions.Repositories
{
    public interface ITaskRepository:IBaseRepository<Guid,Task,ITaskRepository>
    {
        
    }
}
