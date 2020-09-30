using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Edux.Repositories
{
    public class PerfilRepository : IPerfiIRepository
    {
        private readonly EduxContext _ctx;
        public PerfilRepository()
        {
            _ctx = new EduxContext();
        }

        public void Adicionar(Perfil perfil)
        {
            try
            {
                // Adicionar perfil
                _ctx.Add(perfil);

                //Salvar alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, Perfil perfil)
        {
            try
            {
                //Buscar perfil pelo id
                Perfil perfilTemp = BuscarPorId(id);

                //Edita Permissao
                perfilTemp.Permissao = perfil.Permissao;

                //Altera perfil no contexto
                _ctx.Perfil.Update(perfilTemp);
                //Salva o contexo
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Perfil BuscarPorId(int id)
        {
            try
            {
                //procura o id
                return _ctx.Perfil.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<Perfil> Listar()
        {
            try
            {
                //Coloca o perfil em uma lista
                List<Perfil> perfil = _ctx.Perfil.ToList();
                return perfil;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            };
        }

        public void Remover(int id)
        {
            try
            {
                //Buscar perfil pelo id
                Perfil perfilTemp = BuscarPorId(id);

                //Verifica se Perfil existe
                //Caso não existe gera um exception
                if (perfilTemp == null)
                    throw new Exception("perfil não encontrado");

                //Remove o perfil do dbSet
                _ctx.Perfil.Remove(perfilTemp);
                //Salva as alterações do contexto
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
