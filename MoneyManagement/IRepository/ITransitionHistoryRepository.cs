using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagement.IRepository
{
    public interface ITransitionHistory
    {
        Task<ITransitionHistory> GetDataByDay(DateTime date);
    }
}
