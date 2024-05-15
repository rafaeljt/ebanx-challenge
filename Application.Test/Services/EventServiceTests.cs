using Application.Commands;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Application.Test.Services
{
    public class EventServiceTests
    {
        private readonly ILogger<EventService> _logger = Substitute.For<ILogger<EventService>>();
        private readonly IAccountService _accountService = Substitute.For<IAccountService>();

        private EventService Setup()
        {
            _accountService.GetAccount("1234").Returns(new Account()
            {
                Id = "1234",
                Balance = 10
            });
            _accountService.GetAccount("12345").Returns(new Account()
            {
                Id = "1234",
                Balance = 10
            });
            
            return new EventService(_logger, _accountService);
        }
        
        [Theory]
        [InlineData("123", 10)] // Create account with initial balance
        [InlineData("1234", 20)] // Deposit into existing account
        public void Deposit(string accountId, decimal expectedValue)
        {
            // Arrange
            var service = Setup();
            
            // Act
            var response = service.ProcessEvent(new ProcessEvent()
            {
                Type = EventTypes.Deposit,
                Amount = 10,
                Destination = accountId,

            });

            // Assert
            Assert.Null(response.Origin);
            Assert.Equal(expectedValue, response.Destination.Balance);
            Assert.Equal(accountId, response.Destination.Id);
        }
        
        [Theory]
        [InlineData("123", -1)] // Withdraw from non-existing account
        [InlineData("1234", 0)] // Withdraw from existing account
        public void Withdraw(string accountId, decimal expectedValue)
        {
            // Arrange
            var service = Setup();
            
            // Act
            var response = service.ProcessEvent(new ProcessEvent()
            {
                Type = EventTypes.Withdraw,
                Amount = 10,
                Origin = accountId,
            });

            // Assert
            if (expectedValue < 0)
            {
                Assert.Null(response);
            }
            else
            {
                Assert.Null(response.Destination);
                Assert.Equal(expectedValue, response.Origin.Balance);
                Assert.Equal(accountId, response.Origin.Id);    
            }
            
        }
        
        [Theory]
        [InlineData("1234", "12345", 0, 20)] // Transfer from existing account (201 - not null)
        [InlineData("123", "12345", -1, 10)] // Transfer from non-existing account (404 - null)
        public void Transfer(string origin, string destination, decimal expectedOriginBalance, decimal expectedDestinationBalance)
        {
            // Arrange
            var service = Setup();
            
            // Act
            var response = service.ProcessEvent(new ProcessEvent()
            {
                Type = EventTypes.Transfer,
                Amount = 10,
                Origin = origin,
                Destination = destination
            });

            // Assert
            if (expectedOriginBalance < 0)
            {
                Assert.Null(response);
            }
            else
            {
                Assert.Equal(expectedOriginBalance, response.Origin.Balance);
                Assert.Equal(expectedDestinationBalance, response.Destination.Balance);    
            }
        }
    }
}