using System;
using Hugolf.Data;
using Hugolf.Models;
using Hugolf.Repository.IRepository;

namespace Hugolf.Repository;

public class CourseStatusRepository : Repository<CourseStatus>, ICourseStatusRepository
{
    private readonly ApplictionDbContext _db;

    public CourseStatusRepository(ApplictionDbContext db)
        : base(db)
    {
        _db = db;
    }

    public void Update(CourseStatus obj)
    {
        _db.CourseStatuses.Update(obj);
    }
}
