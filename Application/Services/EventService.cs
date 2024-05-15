using Application.Commands;
using Application.Entities;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class EventService : IEventService
    {
        private readonly ILogger<EventService> _logger;
        private readonly IAccountService _accountService;

        public EventService(ILogger<EventService> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public ProcessedEvent ProcessEvent(ProcessEvent @event)
        {
            _logger.LogInformation("Processing event");

            return @event.Type switch
            {
                "deposit" => Deposit(@event),
                "withdraw" => Withdraw(@event),
                "transfer" => Transfer(@event),
                _ => null
            };
        }

        private ProcessedEvent Deposit(ProcessEvent @event)
        {
            var account = _accountService.GetAccount(@event.Destination);

            if (account == null)
            {
                account = new Account()
                {
                    Id = @event.Destination
                };
                _accountService.PutAccount(account);
            }

            account.Balance += @event.Amount;
            return new ProcessedEvent()
            {
                Destination = new Account()
                {
                    Id = account.Id,
                    Balance = account.Balance
                }
            };
        }

        private ProcessedEvent Withdraw(ProcessEvent @event)
        {
            var account = _accountService.GetAccount(@event.Origin);
            
            if (account == null)
            {
                return null;
            }

            account.Balance -= @event.Amount;
            return new ProcessedEvent()
            {
                Origin = new Account()
                {
                    Id = account.Id,
                    Balance = account.Balance
                }
            };
        }
        
        private ProcessedEvent Transfer(ProcessEvent @event)
        {
            var origin = _accountService.GetAccount(@event.Origin);
            
            if (origin == null)
            {
                return null;
            }
            
            var destination = _accountService.GetAccount(@event.Destination);
            
            if (destination == null)
            {
                destination = new Account()
                {
                    Id = @event.Destination
                };
                _accountService.PutAccount(destination);
            }

            origin.Balance -= @event.Amount;
            destination.Balance += @event.Amount;

            return new ProcessedEvent()
            {
                Origin = new Account()
                {
                  Id  = origin.Id,
                  Balance = origin.Balance
                },
                Destination = new Account()
                {
                    Id = destination.Id,
                    Balance = destination.Balance
                }
            };
        }
    }
    
}