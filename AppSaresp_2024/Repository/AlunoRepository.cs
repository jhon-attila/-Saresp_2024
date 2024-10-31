using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace AppSaresp_2024.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _conexaoMySQL;

        public AlunoRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Aluno aluno)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("update Aluno set Nome=@Nome, datanasc=@datanasc, Turma=@Turma, Email=@Email, Serie=@Serie WHERE IdAluno=@IdAluno)", conexao);

                cmd.Parameters.Add("@IdAluno", MySqlDbType.VarChar).Value = aluno.IdAluno;
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = aluno.Nome;
                cmd.Parameters.Add("@datanasc", MySqlDbType.VarChar).Value = aluno.datanasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@Turma", MySqlDbType.VarChar).Value = aluno.Turma;
                cmd.Parameters.Add("@Serie", MySqlDbType.VarChar).Value = aluno.Serie;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = aluno.Email;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(Aluno aluno)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into Aluno(Nome, datanasc, Turma, Email, Serie) values(@Nome, @datanasc, @Turma, @Email, @Serie)", conexao);

                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = aluno.Nome;
                cmd.Parameters.Add("@datanasc", MySqlDbType.VarChar).Value = aluno.datanasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@Turma", MySqlDbType.VarChar).Value = aluno.Turma;
                cmd.Parameters.Add("@Serie", MySqlDbType.VarChar).Value = aluno.Serie;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = aluno.Email;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int IdAluno)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from Aluno WHERE IdAluno=@IdAluno", conexao);
                cmd.Parameters.AddWithValue("@IdAluno", IdAluno);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Aluno Login(string Email, string Senha)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("select * from Aluno where Email = @email and Senha = @Senha", conexao);

                    cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
                    cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Aluno aluno = new Aluno();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    aluno.IdAluno = Convert.ToInt32(dr["id"]);
                    aluno.Nome = Convert.ToString(dr["Nome"]);
                    aluno.Email = Convert.ToString(dr["Email"]);
                    aluno.Serie = Convert.ToInt32(dr["Serie"]);
                    aluno.Turma = Convert.ToString(dr["Turma"]);
                    aluno.datanasc = Convert.ToDateTime(dr["datanasc"]);
                }
                return aluno;
            }
            
        }

        public Aluno ObterAluno(int IdAluno)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Aluno WHERE IdAluno=@IdAluno", conexao);
                cmd.Parameters.AddWithValue("@IdAluno", IdAluno);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Aluno aluno = new Aluno();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    aluno.IdAluno = Convert.ToInt32(dr["id"]);
                    aluno.Nome = Convert.ToString(dr["Nome"]);
                    aluno.Email = Convert.ToString(dr["Email"]);
                    aluno.Serie = Convert.ToInt32(dr["Serie"]);
                    aluno.Turma = Convert.ToString(dr["Turma"]);
                    aluno.datanasc = Convert.ToDateTime(dr["datanasc"]);
                }
                return aluno;
            }
        }

        public IEnumerable<Aluno> ObterTodosAlunos()
        {
            List<Aluno> aluList = new List<Aluno>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Aluno", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    aluList.Add(
                        new Aluno
                        {
                        IdAluno = Convert.ToInt32(dr["id"]),
                        Nome = (string)(dr["Nome"]),
                        Email = Convert.ToString(dr["Email"]),
                        Serie = Convert.ToInt32(dr["Serie"]),
                        Turma = Convert.ToString(dr["Turma"]),
                        datanasc = Convert.ToDateTime(dr["datanasc"])
                    });
                }
                return aluList;
            }
        }
    }
}
