using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amf.Documentation.Developpement.API.Entities;
using Amf.Documentation.Developpement.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amf.Documentation.Developpement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    [Temps]
    public class MachineVirtuelleController : ControllerBase
    {
        private readonly DeveloppementContext _context;

        public MachineVirtuelleController(DeveloppementContext context) =>
            _context = context;

        /// <summary>
        /// Obtenir la liste des machines virtuelles
        /// </summary>
        [HttpGet()]
        public async Task<ActionResult<List<MachineVirtuelle>>> GetAllAsync() =>
            await _context.MachineVirtuelles.ToListAsync();

        /// <summary>
        /// Obtenir une machine virtuelle par son identifiant
        /// </summary>
        /// <param name="id">Identifiant de la VM</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<MachineVirtuelle>> GetByIdAsync(long id)
        {
            var vm = await _context.MachineVirtuelles.FindAsync(id);

            if (vm == null)
            {
                return NotFound();
            }

            return Ok(vm);
        }

        /// <summary>
        /// Créer une machine virtuelle 
        /// </summary>
        /// <param name="vm">Informations de la machine virtuelle</param>
        /// <returns>Machine virtuelle créée</returns>
        [HttpPost]
        public async Task<ActionResult<MachineVirtuelleDto>> CreateAsync([FromBody] MachineVirtuelle vm)
        {

            await _context.MachineVirtuelles.AddAsync(vm);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByIdAsync), new { id = vm.Id }, vm);
        }

    }
}