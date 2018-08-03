using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amf.Documentation.Developpement.API.Entities    
{
    public class MachineVirtuelle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }
    }
}