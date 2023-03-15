using LuggageFinder.Domain;
using MediatR;

namespace LuggageFinder.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Role? Role { get; set; }
    }
}
