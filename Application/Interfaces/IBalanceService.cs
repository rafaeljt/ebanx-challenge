using Application.Entities;
using Application.Queries;

namespace Application.Interfaces
{
    public interface IBalanceService
    {
        public Balance GetBalance(GetBalance balance);
    }
}