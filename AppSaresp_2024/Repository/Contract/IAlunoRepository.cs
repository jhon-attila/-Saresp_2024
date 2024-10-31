using AppSaresp_2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AppSaresp_2024.Repository.Contract
{ 
public interface IAlunoRepository
{
        Aluno Login(string Email,  string Senha);

        void Cadastrar(Aluno aluno);
        void Atualizar(Aluno aluno);
        void Excluir(int IdAluno);
        Aluno ObterAluno(int IdAluno);
        IEnumerable<Aluno> ObterTodosAlunos();
    }
}
