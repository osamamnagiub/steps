using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreWebApplication.Model
{
    public class Item
    {
        public int Id { get; set; }

        [Required] [StringLength(200)] public string Title { get; set; }

        [Required] [StringLength(500)] public string Description { get; set; }

        public int StepId { get; set; }
    }
}