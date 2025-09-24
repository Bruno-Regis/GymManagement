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
        [Display(Name ="Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Email { get; set; }
        [Phone]
        [Display(Name ="Phone")]
        public string PhoneNumber { get; set; }
        [ForeignKey("Plan")]
        [Display(Name ="Subscribed Plan")]
        public string SubscribedPlanId { get; set; }

    }
}
