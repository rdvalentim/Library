using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class Loan
{
    public int LoanId { get; set; }

    public int? BookId { get; set; }

    public int? MemberId { get; set; }

    public DateOnly LoanDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Member? Member { get; set; }
}
