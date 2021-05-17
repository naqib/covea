using System.ComponentModel.DataAnnotations;

namespace COVIA.TEC.FrontDesk.Models
{
    public class RequestDto
    {
        [Required]
        public int Age { get; set; }
        [Required]
        public double AssuredSum { get; set; }
    }
}
