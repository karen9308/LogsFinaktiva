using LogsFinaktiva.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsFinaktiva.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        #region Repositories
        IEventLogRepository EventLogRepository { get; }
        #endregion
        void Commit();
        Task<int> CommitAsync();
        void BeginTransaction();
        Task BeginTransactionAsync();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
