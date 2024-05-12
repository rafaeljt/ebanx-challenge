using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Application.Test.Services
{
    public class ResetServiceTests
    {
        [Fact]
        public void Reset()
        {
            // Arrange
            var accountService = new AccountService();
            accountService.PutAccount(new Account()
            {
                Id = "123",
                Balance = 10
            });

            var resetService = new ResetService(Substitute.For<ILogger<ResetService>>(), accountService);

            // Act
            resetService.ResetState();
            
            // Assert
            var account = accountService.GetAccount("123");
            Assert.Null(account);
        }
    }
}