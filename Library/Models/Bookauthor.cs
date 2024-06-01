using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public partial class Bookauthor
{
    public int BookAuthorId { get; set; }
    [Display(Name = "Livro")]
    public int? BookId { get; set; }
    [Display(Name = "Autor")]
    public int? AuthorId { get; set; }
    public virtual Author? Author { get; set; }
    public virtual Book? Book { get; set; }
}
