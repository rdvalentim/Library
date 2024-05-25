using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public DateOnly? PublishDate { get; set; }

    public int NumberOfCopies { get; set; }

    public string? Genre { get; set; }

    public int? PublisherId { get; set; }

    public virtual ICollection<Bookauthor> Bookauthors { get; set; } = new List<Bookauthor>();

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public virtual Publisher? Publisher { get; set; }
}
