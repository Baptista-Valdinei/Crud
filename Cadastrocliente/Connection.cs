using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Cadastrocliente
{

        public class Connection
        {
            SqlConnection Conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);           

            public bool ExecutaComando(string pSql)
            {
                try
                {

                    using (SqlCommand Comando = new SqlCommand(pSql, Conexao))
                    {
                        Conexao.Open();
                        Comando.ExecuteNonQuery();
                        Conexao.Close();
                        return true;

                    }

                }
                catch (SqlException)
                {
                    if (Conexao.State != ConnectionState.Closed)
                    {
                        Conexao.Close();
                    }
                    return false;
                }


            }

            public DataTable ExecutaConsulta(string pSql)
            {
                try
                {
                    using (SqlCommand Comando = new SqlCommand(pSql, Conexao))
                    {
                        using (SqlDataAdapter Adaptador = new SqlDataAdapter(Comando))
                        {
                            using (DataTable Tabela = new DataTable())
                            {
                                Conexao.Open();
                                Adaptador.Fill(Tabela);
                                Conexao.Close();
                                return Tabela;
                            }

                        }
                    }

                }
                catch (SqlException)
                {
                    if (Conexao.State != ConnectionState.Closed)
                    {
                        Conexao.Close();
                    }
                    return null;
                }
            }

            public bool ExecutaLogin(string pSql)
            {
                try
                {
                    using (SqlCommand Comando = new SqlCommand(pSql, Conexao))
                    {
                        Conexao.Open();
                        SqlDataReader Com = Comando.ExecuteReader();
                        if (Com.Read())
                        {
                            Conexao.Close();
                            return true;
                        }
                        else
                        {
                            Conexao.Close();
                            return false;
                        }
                    }



                }
                catch (SqlException)
                {

                    if (Conexao.State != ConnectionState.Closed)
                    {
                        Conexao.Close();
                    }
                    return false;
                }


            }

        }
    }

