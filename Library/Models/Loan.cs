using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        [Display(Name = "Livro")]
        [Required(ErrorMessage = "O campo Livro é obrigatório.")]
        public int? BookId { get; set; }
        [Required(ErrorMessage = "O campo Membro é obrigatório.")]
        [Display(Name = "Membro")]
        public int? MemberId { get; set; }
        [Required(ErrorMessage = "O campo Data de Empréstimo é obrigatório.")]
        [Display(Name = "Data de Empréstimo")]
        [DataType(DataType.Date)]
        public DateOnly LoanDate { get; set; }
        [Display(Name = "Data de Devolução")]
        [DataType(DataType.Date)]
        public DateOnly? ReturnDate { get; set; }
        [Display(Name = "Livro")]
        public virtual Book? Book { get; set; }
        [Display(Name = "Membro")]
        public virtual Member? Member { get; set; }
    }
}
