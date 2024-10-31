using System.ComponentModel.DataAnnotations;

namespace AppSaresp_2024.Models
{
    public class ProfessorAplicador
    {
        [Display(Name = "Código", Description = "Código")]
        [Required(ErrorMessage = "o Código é obrigatorio")]
        public int? IdProf { get; set; }
        [Display(Name = "Nome completo", Description = "Nome e Sobrenome")]
        [Required(ErrorMessage = "o Nome é obrigatorio")]
        public String Nome { get; set; }
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "o CPF é obrigatorio")]
        public int CPF { get; set; }
        [Display(Name = "RG")]
        [Required(ErrorMessage = "o RG é obrigatorio")]
        public int RG { get; set; }
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "o telefone é obrigatorio")]
        public int Telefone { get; set; }
        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "a data de nascimento é obrigatorio")]
        [DataType(DataType.DateTime)]
        public DateTime datanasc { get; set; }
    }
}
