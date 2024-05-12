using Application.Entities;
using Application.Interfaces;
using Application.Queries;
using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Application.Test.Queries
{
    public class GetBalanceTests
    {
        [Theory]
        [InlineData("123", 10)]
        [InlineData("1234", null)]
        public void GetBalance(string accountId, long expectedBalance)
        {
            // Arrange
            var accountService = Substitute.For<IAccountService>();
            accountService.GetAccount("123").Returns(new Account()
            {
                Balance = 10
            });
            
            var balanceService = new BalanceService(Substitute.For<ILogger<BalanceService>>(), accountService);

            // Act
            var balance = balanceService.GetBalance(new GetBalance(accountId));

            // Assert
            Assert.Equal(balance?.Value, expectedBalance > 0 ? expectedBalance : null);
        }
        
    }
}