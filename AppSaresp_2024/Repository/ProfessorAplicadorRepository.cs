using AppSaresp_2024.Models;
using AppSaresp_2024.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;


namespace AppSaresp_2024.Repository
{
    public class ProfessorAplicadorRepository : IProfessorAplicador
    {
        private readonly string _conexaoMySQL;

        public ProfessorAplicadorRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(ProfessorAplicador professorAplicador)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("update ProfessorAplicador set Nome=@Nome, datanasc=@datanasc, CPF=@CPF, Telefone=@Telefone, RG=@RG WHERE IdProf=@IdProf)", conexao);

                cmd.Parameters.Add("@IdProf", MySqlDbType.VarChar).Value = professorAplicador.IdProf;
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = professorAplicador.Nome;
                cmd.Parameters.Add("@datanasc", MySqlDbType.VarChar).Value = professorAplicador.datanasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = professorAplicador.CPF;
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = professorAplicador.RG;
                cmd.Parameters.Add("@Telenofe", MySqlDbType.VarChar).Value = professorAplicador.Telefone;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(ProfessorAplicador professorAplicador)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into ProfessorAplicadpr(Nome, datanasc, RG, Telefone, CPF) values(@Nome, @datanasc, @RG, @Telefone, @CPF)", conexao);

                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = professorAplicador.Nome;
                cmd.Parameters.Add("@datanasc", MySqlDbType.VarChar).Value = professorAplicador.datanasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = professorAplicador.CPF;
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = professorAplicador.RG;
                cmd.Parameters.Add("@Telenofe", MySqlDbType.VarChar).Value = professorAplicador.Telefone;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int IdProf)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from ProfessorAplicador WHERE IdAluno=@IdProf", conexao);
                cmd.Parameters.AddWithValue("@IdProf", IdProf);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public ProfessorAplicador Login(string Email, string Senha)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("select * from cliente where Telefone = @Telefone and Senha = @Senha", conexao);

                cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                ProfessorAplicador professorAplicador = new ProfessorAplicador();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    professorAplicador.IdProf = Convert.ToInt32(dr["id"]);
                    professorAplicador.Nome = Convert.ToString(dr["Nome"]);
                    professorAplicador.Telefone = Convert.ToInt32(dr["Telefone"]);
                    professorAplicador.CPF = Convert.ToInt32(dr["CPF"]);
                    professorAplicador.RG = Convert.ToInt32(dr["RG"]);
                    professorAplicador.datanasc = Convert.ToDateTime(dr["datanasc"]);
                }
                return professorAplicador;
            }
        }

        public ProfessorAplicador ObterProfessor(int IdProf)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from ProfessorAplicador WHERE IdAluno=@IdAluno", conexao);
                cmd.Parameters.AddWithValue("@IdProf", IdProf);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                ProfessorAplicador professorAplicador = new ProfessorAplicador();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    professorAplicador.IdProf = Convert.ToInt32(dr["id"]);
                    professorAplicador.Nome = Convert.ToString(dr["Nome"]);
                    professorAplicador.Telefone = Convert.ToInt32(dr["Telefone"]);
                    professorAplicador.CPF = Convert.ToInt32(dr["CPF"]);
                    professorAplicador.RG = Convert.ToInt32(dr["RG"]);
                    professorAplicador.datanasc = Convert.ToDateTime(dr["datanasc"]);
                }
                return professorAplicador;
            }
        }

        public IEnumerable<ProfessorAplicador> ObterTodosProfessores()
        {
            List<ProfessorAplicador> profList = new List<ProfessorAplicador>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM ProfessorAplicador", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                conexao.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    profList.Add(
                        new ProfessorAplicador
                        {
                            IdProf = Convert.ToInt32(dr["id"]),
                            Nome = (string)(dr["Nome"]),
                            Telefone = Convert.ToInt32(dr["Telefone"]),
                            CPF = Convert.ToInt32(dr["CPF"]),
                            RG = Convert.ToInt32(dr["RG"]),
                            datanasc = Convert.ToDateTime(dr["datanasc"])
                        });
                }
                return profList;
            }
        }
    }
}
