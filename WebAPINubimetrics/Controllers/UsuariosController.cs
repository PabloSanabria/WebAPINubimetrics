using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPINubimetrics.Entity.DTO;
using WebAPINubimetrics.Interface;
using WebAPINubimetrics.Models.DB;

namespace WebAPINubimetrics.Controllers
{
    /// <summary>
    /// Controller utilizado para representar el servicio Usuarios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        #region private members
        
        private readonly DB_Nubimetrics_APIContext _context;
        private readonly IBSUsuarioValidaciones _usuarioValidaciones;

        #endregion


        #region Constructor
        /// <summary>
        /// Constructor del controller MercadoLibre
        /// </summary>
        /// <param name="context"></param>
        public UsuariosController(DB_Nubimetrics_APIContext context, IBSUsuarioValidaciones usuarioValidaciones)
        {
            _context = context;
            _usuarioValidaciones = usuarioValidaciones;
        }

        #endregion

        #region endpoints     

        #region punto1Usuarios

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuario()
        {
            //se obtienen los usuarios desde la BD 
            return await _context.User.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            //se obtiene un usuario a partir de su ID            
            var usuario = await _context.User.FindAsync(id);

            return (_usuarioValidaciones.UsuarioNulo(usuario)) ? NotFound() :usuario;
           
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioDTO>> PutUsuario(int id, UsuarioDTO usuario)
        {
            //verificamos que los id ingresados no sean distintos
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            if (!_usuarioValidaciones.UsuarioValoresCorrectos(usuario))
                return NotFound("Error en alguno de los valores ingresados");

            //Se modifica un usuario
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //si no se encuentra el id a modificar retorno NotFound
                if (!_usuarioValidaciones.UsuarioExiste(_context.User.ToList(),id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }            

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> PostUsuario(UsuarioDTO usuario)
        {
            if(!_usuarioValidaciones.UsuarioValoresCorrectos(usuario))
                return NotFound("Error en alguno de los valores ingresados");
            //Se graba un usuario en BD
            _context.User.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.User.FindAsync(id);
            if (_usuarioValidaciones.UsuarioNulo(usuario))
            {
                return NotFound();
            }
            
            //Se elimina un usuario de la BD
            _context.User.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #endregion
    }
}
