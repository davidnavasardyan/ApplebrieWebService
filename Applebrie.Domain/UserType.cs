using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Applebrie.Domain
{
    public class UserType : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string TypeName { get; set; }

        [StringLength(255)]
        public string Descr { get; set; }

        public ICollection<User> Users { get; set; }

        public UserType()
        {
            Users = new Collection<User>();
        }
    }
}
