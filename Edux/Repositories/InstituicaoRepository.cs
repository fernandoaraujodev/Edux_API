using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Edux.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EduxContext _ctx;

        public InstituicaoRepository()
        {
            _ctx = new EduxContext();
        }

        #region Leitura

        /// <summary>
        /// Método que busca uma instituição pelo id
        /// </summary>
        /// <param name="id">Id da instituicao</param>
        /// <returns></returns>
        public Instituicao BuscarPorId(int id)
        {
            try
            {
                //Contexto é chamado com a instrução de encontrar na tabela Instituição com o id passado
                return _ctx.Instituicao.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Método que busca uma instituição pelo nome informado
        /// </summary>
        /// <param name="nome">String com o nome a ser buscado</param>
        /// <returns></returns>
        public List<Instituicao> BuscarPorNome(string nome)
        {
            try
            {
                // Busca uma intituição que contenha o nome informado
                return _ctx
                        .Instituicao
                        .Where(c => c.Nome.Contains(nome))
                        .ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista todas as instituições cadastradas no contexto
        /// </summary>
        /// <returns>Lista de instituições cadastradas</returns>
        public List<Instituicao> Listar()
        {
            try
            {
                return _ctx.Instituicao.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Gravacao

        /// <summary>
        /// Método para adicionar uma nova instituição 
        /// </summary>
        /// <param name="inst">Objeto do tipo instituição</param>
        public void Adicionar(Instituicao inst)
        {
            try
            {
                // O contexto recebe o objeto inst do método
                _ctx.Add(inst);


                //Salva as alterações no banco de dados Edux
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Método para editar uma instituição
        /// </summary>
        /// <param name="inst">Objeto do tipo instituição</param>
        public void Editar(Instituicao inst)
        {
            try
            {
                Instituicao instTemp = new Instituicao();

                //Usa o método BuscarPorId para verificar a existência da instituição informada
                instTemp = BuscarPorId(inst.IdInstituicao);

                //Se ela não existir é informado que a instituição não foi encontrada
                if (instTemp == null)
                {
                    throw new Exception("Instituição não encontrada");
                }
                else
                {
                    //Caso contrário salva todas as alterações no objeto insTemp
                    //Para posteiormente salvá-las no contexto
                    instTemp.Nome = inst.Nome;
                    instTemp.Cidade = inst.Cidade;
                    instTemp.Bairro = inst.Bairro;
                    instTemp.Complemento = inst.Complemento;
                    instTemp.Numero = inst.Numero;
                    instTemp.Uf = inst.Uf;
                    instTemp.Curso = inst.Curso;
                    instTemp.Logradouro = inst.Logradouro;
                    instTemp.Cep = inst.Cep;

                    //Atualiza a instituição com o id informado
                    _ctx.Instituicao.Update(instTemp);

                    //Salva as alterações no contexto
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Método que remove uma instituição do contexto
        /// </summary>
        /// <param name="id">Recebe o id da instituição</param>
        public void Remover(int id)
        {
            try
            {

                //Usa o método BuscarPorId para verificar a existência da instituição informada
                Instituicao instTemp = BuscarPorId(id);

                //Se ela não existir é informado que a instituição não foi encontrada
                if (instTemp == null)
                {
                    throw new Exception("Instituição não encontrada");
                }
                else
                {
                    //Remove a instituição informada do contexto
                    _ctx.Instituicao.Remove(instTemp);

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
