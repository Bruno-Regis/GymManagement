using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagement.Models
{
    [Table("Members")]
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required field")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [ForeignKey("Plan")]
        public string SubscribedPlanId { get; set; }

    }
}
