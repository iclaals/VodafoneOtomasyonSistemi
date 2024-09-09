using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorselProgramlamaVize.CodeFirst
{
    public class FaturaliFaturasizContext:DbContext
    {
        public DbSet<hatFaturaliFaturasizz> HatFaturasizz { get; set; }
    }
}
