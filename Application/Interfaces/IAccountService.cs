using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        public Account GetAccount(string id);

        public void PutAccount(Account account);

        public void ResetRecords();
    }
}