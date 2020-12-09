using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class TaskVm
    {
        public Guid Id { get; set; }
        public bool IsComplete { get; set; }
        public string Subject { get; set; }
        public Guid? AssignedMemberId { get; set; }
        public string AssignedMemberAvtar { get; set; }
    }
}
