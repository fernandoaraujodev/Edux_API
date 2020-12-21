using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Repositories
{
    public class RankingRepository : IRankingRepository
    {
        RankingContext conexao = new RankingContext();

        SqlCommand cmd = new SqlCommand();

        public List<Ranking> Listar()
        {
            try
            {
                cmd.Connection = conexao.Conectar();
 
                cmd.CommandText = "EXEC RankingCurtida";

                SqlDataReader dados = cmd.ExecuteReader();

                List<Ranking> rank = new List<Ranking>();


                while (dados.Read())
                {

                    rank.Add(
                            new Ranking()
                            {
                                Posicao = Convert.ToInt32(dados.GetValue(0)),
                                IdUsuario = Convert.ToInt32(dados.GetValue(1)),
                                Pontos = Convert.ToInt32(dados.GetValue(2))
                               

                            }
                        );
                }

                conexao.Desconectar();

                return rank;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Ranking> ListarNota()
        {
            try
            {
                cmd.Connection = conexao.Conectar();

                cmd.CommandText = "EXEC RankingNota";

                SqlDataReader dados = cmd.ExecuteReader();

                List<Ranking> rank = new List<Ranking>();


                while (dados.Read())
                {

                    rank.Add(
                            new Ranking()
                            {
                                Posicao = Convert.ToInt32(dados.GetValue(0)),
                                IdUsuario = Convert.ToInt32(dados.GetValue(1)),
                                Pontos = Convert.ToInt32(dados.GetValue(2))


                            }
                        );
                }

                conexao.Desconectar();

                return rank;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Ranking> ListarObjOcultos()
        {
            try
            {
                cmd.Connection = conexao.Conectar();

                cmd.CommandText = "EXEC RankingObjOcultos";

                SqlDataReader dados = cmd.ExecuteReader();

                List<Ranking> rank = new List<Ranking>();


                while (dados.Read())
                {

                    rank.Add(
                            new Ranking()
                            {
                                Posicao = Convert.ToInt32(dados.GetValue(0)),
                                IdUsuario = Convert.ToInt32(dados.GetValue(1)),
                                Pontos = Convert.ToInt32(dados.GetValue(2))


                            }
                        );
                }

                conexao.Desconectar();

                return rank;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Ranking> ListarObjConcluidos()
        {
            try
            {
                cmd.Connection = conexao.Conectar();

                cmd.CommandText = "EXEC RankingObjConcluidos";

                SqlDataReader dados = cmd.ExecuteReader();

                List<Ranking> rank = new List<Ranking>();


                while (dados.Read())
                {

                    rank.Add(
                            new Ranking()
                            {
                                Posicao = Convert.ToInt32(dados.GetValue(0)),
                                IdUsuario = Convert.ToInt32(dados.GetValue(1)),
                                Pontos = Convert.ToInt32(dados.GetValue(2))


                            }
                        );
                }

                conexao.Desconectar();

                return rank;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
