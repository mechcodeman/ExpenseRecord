using System.ComponentModel.DataAnnotations;


namespace Expense.Models
{
    public class Dto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(50)]
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
