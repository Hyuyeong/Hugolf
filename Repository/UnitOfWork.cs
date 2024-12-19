using System;
using Hugolf.Data;
using Hugolf.Repository.IRepository;

namespace Hugolf.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplictionDbContext _db;
    public IMembershipRepository Membership { get; private set; }
    public ICourseStatusRepository CourseStatus { get; private set; }

    public UnitOfWork(ApplictionDbContext db)
    {
        _db = db;
        Membership = new MembershipRepository(db);
        CourseStatus = new CourseStatusRepository(db);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
