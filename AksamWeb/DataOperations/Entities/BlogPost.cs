using System.ComponentModel.DataAnnotations;

namespace AksamWeb.DataOperations.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
