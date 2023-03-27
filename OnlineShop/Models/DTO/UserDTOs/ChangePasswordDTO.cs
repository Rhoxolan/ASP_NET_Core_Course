using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineShop.Models.DTO.UserDTOs
{
    public class ChangePasswordDTO
    {
        public string Id { get; set; } = default!;

        public string Email { get; set; } = default!;

        [Required]
        [Display(Name = "New password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = default!;
    }
}
