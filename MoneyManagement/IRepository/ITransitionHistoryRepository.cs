namespace MoneyManagement.IRepository
{
    public interface ITransitionHistoryRepository
    {
        Task<ITransitionHistoryRepository> GetDataByDay(DateTime date);
    }
}
