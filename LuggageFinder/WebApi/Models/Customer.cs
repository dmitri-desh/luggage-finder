namespace WebApi.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}