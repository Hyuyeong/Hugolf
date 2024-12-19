using System;
using Hugolf.Models;

namespace Hugolf.Repository.IRepository;

public interface ICourseStatusRepository : IRepository<CourseStatus>
{
    void Update(CourseStatus obj);
}
