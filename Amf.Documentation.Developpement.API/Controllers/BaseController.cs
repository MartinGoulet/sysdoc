using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amf.Documentation.Developpement.API.Entities;
using Amf.Documentation.Developpement.API.Infrastructure.Data;
using Amf.Documentation.Developpement.API.Interfaces;
using Amf.Documentation.Developpement.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amf.Documentation.Developpement.API.Controllers
{
    /// <summary>
    /// Contrôleur pour l'accès au machine virtuelle
    /// </summary>
    [ValidateModel]
    public class BaseController<TEntite, TRepository> : ControllerBase
        where TEntite : class
        where TRepository : IGenericRepository<TEntite>
    {

        private readonly TRepository _context;

        public BaseController(TRepository context) =>
            _context = context;

        /// <summary>
        /// Obtenir la liste des entités
        /// </summary>
        [HttpGet()]
        public async Task<List<TEntite>> GetAllAsync() =>
            await _context.ListAsync();

        /// <summary>
        /// Obtenir un entité selon son identifiant
        /// </summary>
        /// <param name="id">Identifiant de l'entité</param>
        [HttpGet("{id}")]
        [MachineVirtuelleExiste()]
        public async Task<ActionResult> GetByIdAsync(int id) =>
            Ok(await _context.GetByIdAsync(id));

        /// <summary>
        /// Créer un entité
        /// </summary>
        /// <param name="entite">Informations de l'entité</param>
        /// <returns>L'entité créée</returns>
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] TEntite entite)
        {
            await _context.AddAsync(entite);
            return Ok(entite);
        }

        /// <summary>
        /// Modifier l'entité
        /// </summary>
        /// <param name="id">Identifiant de l'entité</param>
        /// <param name="entite">Informations de l'entité</param>
        /// <returns>L'entité modifiée</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] TEntite entite)
        {
            await _context.UpdateAsync(entite);
            return Ok(entite);
        }

        /// <summary>
        /// Détruire une entité
        /// </summary>
        /// <param name="id">Identifiant de l'entité</param>
        /// <returns>Entité détruite</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _context.DeleteAsync(id);
            return Ok(id);
        }

    }
}