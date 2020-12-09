using Core.Abstractions.Repositories;
using Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DataLayer
{
    public class MemberRepository : BaseRepository<Guid, Member, MemberRepository>, IMemberRepository
    {
        public MemberRepository(FamilyTaskContext context) : base(context)
        { }

        IMemberRepository IBaseRepository<Guid, Member, IMemberRepository>.Include(string navigationPath, CancellationToken cancellationToken)
        {
            return base.Include(navigationPath,cancellationToken);
        }

        IMemberRepository IBaseRepository<Guid, Member, IMemberRepository>.NoTrack()
        {
            return base.NoTrack();
        }

        IMemberRepository IBaseRepository<Guid, Member, IMemberRepository>.Reset()
        {
            return base.Reset();
        }

       
    }
}
