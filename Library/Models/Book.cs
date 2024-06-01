using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        [StringLength(100, ErrorMessage = "Título não pode ter mais de 100 caracteres.")]
        [Display(Name = "Título")]
        public string Title { get; set; } = null!;
        [StringLength(13, ErrorMessage = "ISBN não pode ter mais de 13 caracteres.")]
        [Display(Name = "ISBN")]
        public string Isbn { get; set; } = null!;
        [DataType(DataType.Date)]
        [Display(Name = "Data de Publicação")]
        public DateOnly? PublishDate { get; set; }
        [Range(1, 1000)]
        [Display(Name = "Número de Cópias")]
        public int NumberOfCopies { get; set; }
        [StringLength(50)]
        [Display(Name = "Gênero")]
        public string? Genre { get; set; }
        [Display(Name = "Editora")]
        public int? PublisherId { get; set; }
        public virtual ICollection<Bookauthor> Bookauthors { get; set; } = new List<Bookauthor>();
        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public virtual Publisher? Publisher { get; set; }
    }
}