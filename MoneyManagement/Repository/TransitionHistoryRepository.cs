using MoneyManagement.IRepository;
using MoneyManagement.Models;

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
