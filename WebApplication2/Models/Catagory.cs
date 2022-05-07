using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Catagory
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name{ get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order Must Be Between 1 and 100 Only!!")]
        public int DisplayOrder { get; set; }
        public DateTime CratemDateTime { get; set; } = DateTime.Now;
    }
}

