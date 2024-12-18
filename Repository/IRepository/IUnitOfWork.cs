using System;

namespace Hugolf.Repository.IRepository;

public interface IUnitOfWork
{
    IMembershipRepository Membership { get; }
    void Save();
}
