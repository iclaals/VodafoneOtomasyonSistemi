using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorselProgramlamaVize.CodeFirst
{
    public class VodafoneContext:DbContext
    {
        public DbSet<hatBasvurularr> hatBasvurulars { get; set; }
        public DbSet<hatFaturaliFaturasizz> hatFaturaliFaturasizzs { get; set; }

        public DbSet<evMusteri> evMusteris { get; set;}

        public DbSet<AramaKaydi> AramaKaydis { get; set; }
    }
}
