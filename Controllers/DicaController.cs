using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Edux.Contexts;
using Edux.Domains;
using Microsoft.AspNetCore.Authorization;

namespace Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController : ControllerBase
    {
        private readonly EduxContext _context = new EduxContext();


        // GET: api/Dica
        /// <summary>
        /// Mostra todas as dicas criadas
        /// </summary>
        /// <returns>uma lista dos cursos já cadastrados</returns>
        [Authorize(Roles = "Professor, Administrador, Aluno")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dica>>> GetDica()
        {
            return await _context.Dica.ToListAsync();
        }

        // GET: api/Dica/5
        /// <summary>
        /// Busca a dica de acordo com o id passado
        /// </summary>
        /// <param name="id">id dica</param>
        /// <returns>retorna o dica pertencente ao id</returns>
        [Authorize(Roles = "Professor, Administrador, Aluno")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Dica>> GetDica(int id)
        {
            var dica = await _context.Dica.FindAsync(id);

            if (dica == null)
            {
                return NotFound();
            }

            return dica;
        }

        // PUT: api/Dica/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Altera uma dica com o id informado
        /// </summary>
        /// <param name="id">id do dica</param>
        /// <param name="dica">objeto dica</param>
        /// <returns>objeto alterado</returns>
        [Authorize(Roles = "Professor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDica(int id, Dica dica)
        {
            if (id != dica.IdDica)
            {
                return BadRequest();
            }

            _context.Entry(dica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DicaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dica
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra uma nova dica
        /// </summary>
        /// <param name="dica">objeto dica</param>
        /// <returns></returns>
        [Authorize(Roles = "Professor")]
        [HttpPost]
        public async Task<ActionResult<Dica>> PostDica(Dica dica)
        {
            _context.Dica.Add(dica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDica", new { id = dica.IdDica }, dica);
        }

        // DELETE: api/Dica/5
        /// <summary>
        /// Deleta uma dica com o id informado
        /// </summary>
        /// <param name="id">id dica</param>
        /// <returns></returns>
        [Authorize(Roles = "Professor")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dica>> DeleteDica(int id)
        {
            var dica = await _context.Dica.FindAsync(id);
            if (dica == null)
            {
                return NotFound();
            }

            _context.Dica.Remove(dica);
            await _context.SaveChangesAsync();

            return dica;
        }

        private bool DicaExists(int id)
        {
            return _context.Dica.Any(e => e.IdDica == id);
        }
    }
}