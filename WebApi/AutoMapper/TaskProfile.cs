using AutoMapper;
using Domain.Commands;
using Domain.DataModels;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApi.AutoMapper
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTaskCommand, Task>();
            CreateMap<Task, TaskVm>().ForMember(dest => dest.AssignedMemberAvtar, opt => opt.MapFrom(src => src.AssignedMember != null ?src.AssignedMember.Avatar: ""));
            CreateMap<UpdateTaskCommand, Task>();
        }
    }
}
