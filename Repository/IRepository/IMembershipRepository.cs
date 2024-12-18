using System;
using Hugolf.Models;

namespace Hugolf.Repository.IRepository;

public interface IMembershipRepository : IRepository<Membership>
{
    void Update(Membership obj);
}
