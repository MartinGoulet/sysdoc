using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amf.Documentation.Developpement.API.ViewModel    
{
    public class MachineVirtuelleDto
    {
        [Required]
        public string Nom { get; set; }
    }
}