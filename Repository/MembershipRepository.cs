using System;
using System.Linq.Expressions;
using Hugolf.Data;
using Hugolf.Models;
using Hugolf.Repository.IRepository;

namespace Hugolf.Repository;

public class MembershipRepository : Repository<Membership>, IMembershipRepository
{
    private readonly ApplictionDbContext _db;

    public MembershipRepository(ApplictionDbContext db)
        : base(db)
    {
        _db = db;
    }

    public void Update(Membership obj)
    {
        _db.Memberships.Update(obj);
    }
}
