using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GonzalezF_RicaldeN_Boadad_EspinozaA.Models;

namespace GonzalezF_RicaldeN_Boadad_EspinozaA.Data
{
    public class BDDChatContext : DbContext
    {
        public BDDChatContext (DbContextOptions<BDDChatContext> options)
            : base(options)
        {
        }

        public DbSet<GonzalezF_RicaldeN_Boadad_EspinozaA.Models.GuardarInformacionChat> GuardarInformacionChat { get; set; } = default!;
        public DbSet<GonzalezF_RicaldeN_Boadad_EspinozaA.Models.Usuario> Usuario { get; set; } = default!;
    }
}
