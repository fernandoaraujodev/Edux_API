using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EduxContext _ctx;

        public UsuarioRepository()
        {
            _ctx = new EduxContext();
        }

        #region Leitura

        public Usuario BuscarPorId(int id)
        {
            try
            {
                return _ctx.Usuario.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Usuario> Listar()
        {
            try
            {
                return _ctx.Usuario
                    .Include(c => c.AlunoTurma)
                    .Include(y => y.ProfessorTurma)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravacao
        public void Adicionar(Usuario usuario)
        {
            try
            {
                // O contexto recebe o objeto inst do método
                _ctx.Add(usuario);


                //Salva as alterações no banco de dados Edux
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, Usuario usuario)
        {
            try
            {
                // BuscarPorId para verificar a existência do usuário informado
                Usuario usuarioTemp = BuscarPorId(id);

                //Se ela não existir é informado que o usuário não foi encontrado
                if (usuarioTemp == null)
                {
                    throw new Exception("Usuário não encontrado");
                }
                else
                {
                    //Caso contrário salva todas as alterações no objeto usuarioTemp
                    usuarioTemp.Nome = usuario.Nome;
                    usuarioTemp.Email = usuario.Email;
                    usuarioTemp.Senha = usuario.Senha;
                    usuarioTemp.DataUltimoAcesso = usuario.DataUltimoAcesso;


                    //Atualiza com o id informado
                    _ctx.Usuario.Update(usuarioTemp);

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
                //Usa o método BuscarPorId para verificar a existência da instituição informada
                Usuario usuarioTemp = BuscarPorId(id);

                //Se ela não existir é informado que a instituição não foi encontrada
                if (usuarioTemp == null)
                {
                    throw new Exception("Usuário não encontrado");
                }
                else
                {
                    //Remove a instituição informada do contexto
                    _ctx.Usuario.Remove(usuarioTemp);

                    //Salva todas as alterações
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
