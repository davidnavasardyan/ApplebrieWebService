using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applebrie.Domain
{
    public class User : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public UserType UserType { get; set; }
        [ForeignKey("UserType")]
        public int? UserTypeId { get; set; }

        public UserTitle? Title { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }
        
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string PhoneNbr { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(20)]
        public string PostalCode { get; set; }
    }

    public enum UserTitle
    {
        Dr = 0,
        Miss = 1,
        Mr = 2,
        Mrs = 3,
        Ms = 4,
        Prof = 5,
    }
}
