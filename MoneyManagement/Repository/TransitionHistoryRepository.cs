using MoneyManagement.IRepository;
using MoneyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagement.Repository
{
    public class TransitionHistoryRepository : ITransitionHistoryRepository
    {
        private readonly MoneymanagementContext DBContext = new MoneymanagementContext();

        public Task<ITransitionHistoryRepository> GetDataByDay(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
