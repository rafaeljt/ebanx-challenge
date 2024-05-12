using Application.Queries;

namespace Application.Interfaces
{
    public interface IBalanceService
    {
        public GetBalance GetBalance(GetBalance balance);
    }
}