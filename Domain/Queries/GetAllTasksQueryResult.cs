using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries
{
    public class GetAllTasksQueryResult
    {
        public List<TaskVm> Payload { get; set; }
    }
}
