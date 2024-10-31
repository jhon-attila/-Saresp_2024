using AppSaresp_2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSaresp_2024.Repository.Contract
{
    public interface IProfessorAplicador
    {
        ProfessorAplicador Login(string Email, string Senha);

        void Cadastrar(ProfessorAplicador professorAplicador);
        void Atualizar(ProfessorAplicador professorAplicador);
        void Excluir(int IdProf);
        ProfessorAplicador ObterProfessor(int IdProf);
        IEnumerable<ProfessorAplicador> ObterTodosProfessores();
    }
}
