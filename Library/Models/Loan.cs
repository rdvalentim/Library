using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        [Display(Name = "Livro")]
        public int? BookId { get; set; }
        [Display(Name = "Membro")]
        public int? MemberId { get; set; }
        [Display(Name = "Data de Empréstimo")]
        [DataType(DataType.Date)]
        public DateOnly LoanDate { get; set; }
        [Display(Name = "Data de Devolução")]
        [DataType(DataType.Date)]
        public DateOnly? ReturnDate { get; set; }
        public virtual Book? Book { get; set; }
        public virtual Member? Member { get; set; }
    }
}
