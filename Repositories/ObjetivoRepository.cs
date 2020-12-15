using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Edux.Repositories
{
    public class ObjetivoRepository : IObjetivoRepository
    {
            private readonly EduxContext _ctx;

            public ObjetivoRepository()
            {
                _ctx = new EduxContext();
            }

            #region Leitura

            public Objetivo BuscarPorId(int id)
            {
                try
                {
                    return _ctx.Objetivo.FirstOrDefault(x => x.IdObjetivo == id); ;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public List<Objetivo> Listar()
            {
                try
                {
                return _ctx.Objetivo
                                    .Include(c => c.AlunoObjetivo)
                                    .Include(y => y.IdCategoriaNavigation)
                                    .ToList();
            }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            #endregion

            #region Gravacao
            public void Adicionar(Objetivo obj)
            {
                try
                {
                    // O contexto recebe o objeto inst do método
                    _ctx.Add(obj);


                    //Salva as alterações no banco de dados Edux
                    _ctx.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            public void Editar(int id, Objetivo obj)
            {
                try
                {
                // BuscarPorId para verificar a existência do usuário informado
                    Objetivo objTemp = BuscarPorId(id);

                    //Se ela não existir é informado que o usuário não foi encontrado
                    if (objTemp == null)
                    {
                        throw new Exception("Objetivo não encontrado");
                    }
                    else
                    {
                        //Caso contrário salva todas as alterações no objeto usuarioTemp
                        objTemp.IdCategoria = obj.IdCategoria;
                        objTemp.Descricao = obj.Descricao;

                        //Atualiza com o id informado
                        _ctx.Objetivo.Update(objTemp);

                        //Salva as alterações no contexto
                        _ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public void Remover(int id)
            {
                try
                {
                    Objetivo objTemp = BuscarPorId(id);

                    //Remove a dica do dbSet
                    _ctx.Objetivo.Remove(objTemp);
                    //Salva as alteráções do contexto
                    _ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            #endregion
    }
}
