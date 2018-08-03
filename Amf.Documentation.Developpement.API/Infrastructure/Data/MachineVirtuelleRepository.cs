
using Amf.Documentation.Developpement.API.Entities;
using Amf.Documentation.Developpement.API.Interfaces;

namespace Amf.Documentation.Developpement.API.Infrastructure.Data
{
    public class MachineVirtuelleRepository : GenericRepository<MachineVirtuelle>, IMachineVirtuelleRepository
    {
        public MachineVirtuelleRepository(DeveloppementContext dbContext) : base(dbContext)
        {
        }
    }
}