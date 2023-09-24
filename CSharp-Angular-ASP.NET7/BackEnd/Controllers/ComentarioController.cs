using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        public readonly AplicactionDbContext _context;
        public IWebHostEnvironment HostingEnvironment { get; set; }
        public ComentarioController(AplicactionDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            HostingEnvironment = hostingEnvironment;

        }
        // GET: api//api/Comentario/Get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _context.Comentario.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/Comentario/Get/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var listid = await _context.Comentario.FindAsync(id);
               
                if (listid == null)
                {
                    return NotFound();
                }
                return Ok(listid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/Comentario
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comentario comentario)
        {
            try
            {
                if (comentario != null)
                {
                    // Obtén los IDs existentes en la tabla
                    var existingIds = _context.Comentario.Select(c => c.Id).ToList();

                    // Busca el próximo ID disponible
                    int nextId = 1;
                    while (existingIds.Contains(nextId))
                    {
                        nextId++;
                    }

                    // Asigna el próximo ID al objeto comentario
                    comentario.Id = nextId;

                    _context.Add(comentario);
                    await _context.SaveChangesAsync();

                    return Ok(comentario);
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/Comentario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Comentario comentario, int id)
        {
            try
            {
                if (comentario.Id == id)
                {
                    _context.Update(comentario);
                    await _context.SaveChangesAsync();

                    return Ok(new { message = "Actualizado Con exito", comentario });
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/Comentario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var comentario = await _context.Comentario.FindAsync(id);
                if (comentario == null )
                {
                    return NotFound();
                }

                _context.Comentario.Remove(comentario!);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Comentario Eliminado", comentario });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

    }
}
