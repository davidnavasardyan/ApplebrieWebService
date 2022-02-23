using Applebrie.Domain;

namespace Applebrie.Application.Users
{
    public class UserDTO : BaseEntity
    {
        public Guid Id { get; set; }
        public UserType UserType { get; set; }
        public int? UserTypeId { get; set; }
        public UserTitle? Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNbr { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
