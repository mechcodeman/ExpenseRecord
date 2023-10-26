using System.ComponentModel.DataAnnotations;

namespace Expense.Models
{
    public class CreateRequest
    {
        [Required]
        [StringLength(50)]
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
    }
}
