﻿using Microsoft.AspNetCore.Mvc;
using SustainableEnergyAPI.Models;
using SustainableEnergyAPI.Data; // Namespace do ApplicationDbContext
using Microsoft.EntityFrameworkCore;

namespace SustainableEnergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyResourceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Injeção de dependência para o contexto do banco de dados
        public EnergyResourceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EnergyResource
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyResource>>> GetAll()
        {
            // Busca todos os registros do banco de dados
            var resources = await _context.EnergyResources.ToListAsync();
            return Ok(resources);
        }

        // GET: api/EnergyResource/1
        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyResource>> GetById(int id)
        {
            // Busca o registro específico pelo ID
            var resource = await _context.EnergyResources.FindAsync(id);
            if (resource == null)
                return NotFound();

            return Ok(resource);
        }

        // POST: api/EnergyResource
        [HttpPost]
        public async Task<ActionResult<EnergyResource>> Create(EnergyResource resource)
        {
            // Adiciona o novo recurso ao banco de dados
            _context.EnergyResources.Add(resource);
            await _context.SaveChangesAsync();

            // Retorna o recurso criado com o ID gerado
            return CreatedAtAction(nameof(GetById), new { id = resource.Id }, resource);
        }

        // PUT: api/EnergyResource/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EnergyResource updatedResource)
        {
            if (id != updatedResource.Id)
                return BadRequest("O ID no corpo da solicitação não corresponde ao ID da URL.");

            // Marca a entidade como modificada para que o EF Core atualize no banco
            _context.Entry(updatedResource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verifica se o recurso ainda existe antes de lançar erro
                if (!EnergyResourceExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/EnergyResource/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Busca o recurso pelo ID
            var resource = await _context.EnergyResources.FindAsync(id);
            if (resource == null)
                return NotFound();

            // Remove o recurso do banco de dados
            _context.EnergyResources.Remove(resource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Verifica se um recurso existe no banco pelo ID
        private bool EnergyResourceExists(int id)
        {
            return _context.EnergyResources.Any(e => e.Id == id);
        }
    }
}