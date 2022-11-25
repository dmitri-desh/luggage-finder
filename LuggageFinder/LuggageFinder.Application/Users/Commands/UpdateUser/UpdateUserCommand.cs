using LuggageFinder.Domain;
using MediatR;

namespace LuggageFinder.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
