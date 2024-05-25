using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Bookauthor
{
    public int BookAuthorId { get; set; }

    public int? BookId { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Book? Book { get; set; }
}
