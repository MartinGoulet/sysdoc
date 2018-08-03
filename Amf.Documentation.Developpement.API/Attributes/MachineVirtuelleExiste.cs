using System.Threading.Tasks;
using Amf.Documentation.Developpement.API.Entities;
using Amf.Documentation.Developpement.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Amf.Documentation.Developpement.API
{
    public class MachineVirtuelleExiste : TypeFilterAttribute
    {
        public MachineVirtuelleExiste() : base(typeof(MachineVirtuelleExisteFilterImpl))
        {            
        }

        private class MachineVirtuelleExisteFilterImpl : IAsyncActionFilter
        {
            private readonly IMachineVirtuelleRepository _context;
            
            public MachineVirtuelleExisteFilterImpl(IMachineVirtuelleRepository context)
            {
                _context = context;
            }

            async Task IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if(context.ActionArguments.ContainsKey("id"))
                {
                    var id = context.ActionArguments["id"] as int?;
                    if(id.HasValue)
                    {
                        var vm = await _context.GetByIdAsync(id.Value);
                        if(vm == null)
                        {
                            context.Result = new NotFoundObjectResult(id.Value);
                            return;
                        }
                    }
                }
                
                await next();
            }
        }
    }

}