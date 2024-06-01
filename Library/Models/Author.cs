using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public partial class Author
    {
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Display(Name = "Nome")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; } = null!;
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateOnly? BirthDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data de Falecimento")]
        public DateOnly? DeathDate { get; set; }
        public virtual ICollection<Bookauthor> Bookauthors { get; set; } = new List<Bookauthor>();
    }
}
