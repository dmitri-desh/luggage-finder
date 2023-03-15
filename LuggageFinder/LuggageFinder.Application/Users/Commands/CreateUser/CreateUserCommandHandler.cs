using LuggageFinder.Application.Interfaces;
using LuggageFinder.Domain;
using MediatR;

namespace LuggageFinder.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly ILuggageFinderDbContext _dbContext;
        public CreateUserCommandHandler(ILuggageFinderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Role = request.Role
            };

            var entity = await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Entity.Id;
        }
    }
}
