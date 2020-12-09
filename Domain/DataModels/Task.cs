using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataModels
{
    public class Task
    {
        public Member AssignedMember { get; set; }
        public Guid? AssignedMemberId { get; set; }
        public Guid Id { get; set; }
        public bool IsComplete { get; set; }
        public string Subject { get; set; }
    }
}
