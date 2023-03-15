using LuggageFinder.Application.Common.Exceptions;
using LuggageFinder.Application.Interfaces;
using LuggageFinder.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LuggageFinder.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly ILuggageFinderDbContext _dbContext;
        public UpdateUserCommandHandler(ILuggageFinderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.Id, cancellationToken);
            if (entity is null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.Phone = request.Phone;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
