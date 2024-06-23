using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public partial class Bookauthor
{
    public int BookAuthorId { get; set; }
    [Display(Name = "Livro")]
    [Required(ErrorMessage = "O campo Livro é obrigatório.")]
    public int? BookId { get; set; }
    [Display(Name = "Autor")]
    [Required(ErrorMessage = "O campo Autor é obrigatório.")]
    public int? AuthorId { get; set; }
    [Display(Name = "Autor")]
    public virtual Author? Author { get; set; }
    [Display(Name = "Livro")]
    public virtual Book? Book { get; set; }
}
