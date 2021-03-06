﻿using System.Collections.Generic;
using System.Linq;
using Amf.Documentation.Developpement.API.Entities;
using Amf.Documentation.Developpement.API.Infrastructure.Data;

namespace Amf.Documentation.Developpement.API
{
    public static class DbContextExtension
    {
        public static void EnsureSeeded(this DeveloppementContext context)
        {
            if(!context.MachineVirtuelles.Any())
            {
                context.AddRange(new List<MachineVirtuelle>() {
                    new MachineVirtuelle() { Nom = "OVM-LD2K12-001" },
                    new MachineVirtuelle() { Nom = "OVM-LD2K12-002" },
                    new MachineVirtuelle() { Nom = "OVM-LD2K12-003" },
                    new MachineVirtuelle() { Nom = "OVM-LD2K12-004" },
                    new MachineVirtuelle() { Nom = "OVM-LD2K12-005" }
                });
                context.SaveChanges();
            }
        }
    }
}