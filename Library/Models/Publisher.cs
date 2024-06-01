using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public partial class Publisher
{
    public int PublisherId { get; set; }
    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
    [Display(Name = "Nome")]
    public string Name { get; set; } = null!;
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
