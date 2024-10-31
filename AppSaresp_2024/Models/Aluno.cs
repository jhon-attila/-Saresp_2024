using System.ComponentModel.DataAnnotations;

namespace AppSaresp_2024.Models
{
    public class Aluno
    {
        [Display(Name = "Código", Description ="Código")]
        [Required(ErrorMessage = "o Código é obrigatorio")]
        public int? IdAluno { get; set; }
        [Display(Name = "Nome completo", Description = "Nome e Sobrenome")]
        [Required(ErrorMessage = "o Nome é obrigatorio")]
        public String Nome { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "o Email é obrigatorio")]
        public string Email { get; set; }
        [Display(Name = "Serie")]
        [Required(ErrorMessage = "a serie é obrigatorio")]
        public int Serie { get; set; }
        [Display(Name = "Turma")]
        [Required(ErrorMessage = "a Turma é obrigatorio")]
        public String Turma { get; set; }
        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "a data de nascimento é obrigatorio")]
        [DataType(DataType.DateTime)]
        public DateTime datanasc { get; set; }

    }
}
