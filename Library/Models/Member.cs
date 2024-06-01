using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public partial class Member
{
    public int MemberId { get; set; }
    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
    [Display(Name = "Nome")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Sobrenome é obrigatório")]
    [StringLength(50, ErrorMessage = "Sobrenome deve ter no máximo 50 caracteres")]
    [Display(Name = "Sobrenome")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Endereço de E-Mail é obrigatório")]
    [EmailAddress]
    [MaxLength(100, ErrorMessage = "Endereço de E-Mail deve ter no máximo 100 caracteres")]
    [Display(Name = "Endereço de E-Mail")]
    public string Email { get; set; } = null!;
    [Phone]
    [Display(Name = "Telefone")]
    [MaxLength(20, ErrorMessage = "Telefone deve ter no máximo 20 caracteres")]
    public string? Phone { get; set; }
    [Display(Name = "Ínicio da Associação")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Data de início da associação é obrigatória")]
    public DateOnly MembershipStartDate { get; set; }
    [Display(Name = "Fim da Associação")]
    [DataType(DataType.Date)]
    public DateOnly? MembershipEndDate { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
