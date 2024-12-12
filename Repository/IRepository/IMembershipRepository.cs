using System;
using Hugolf.Models;

namespace Hugolf.Repository.IRepository;

public interface IMembershipRepository
{
    void Update(Membership obj);
}
