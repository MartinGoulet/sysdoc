using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amf.Documentation.Developpement.API.Entities;
using Amf.Documentation.Developpement.API.Infrastructure.Data;
using Amf.Documentation.Developpement.API.Interfaces;
using Amf.Documentation.Developpement.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amf.Documentation.Developpement.API.Controllers.V2
{
    /// <summary>
    /// Contrôleur pour l'accès au machine virtuelle
    /// </summary>
    [Route("api/[controller]")]
    [ValidateModel]
    [MachineVirtuelleExiste()]
    public class MachineVirtuelleController : BaseController<MachineVirtuelle, IMachineVirtuelleRepository>
    {
        public MachineVirtuelleController(IMachineVirtuelleRepository context) : base(context)
        {

        }

    }
}