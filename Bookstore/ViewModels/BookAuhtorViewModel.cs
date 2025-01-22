using Bookstore.Models;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.ViewModels
{
    public class BookAuhtorViewModel
    {
        public int BookId { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MaxLength(120)]
        [MinLength(5)]
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public int AuthorId { get; set; }
        public List<Author> Authors { get; set; }
    }
}
