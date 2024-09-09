using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorselProgramlamaVize.CodeFirst
{
    public class basvuruContext:DbContext
    {
        public DbSet<hatBasvurularr> hatBasvurularsss { get; set; }
    }
}
