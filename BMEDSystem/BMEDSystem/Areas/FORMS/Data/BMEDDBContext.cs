using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Areas.FORMS.Models;

namespace EDIS.Areas.FORMS.Data
{
    public partial class BMEDDBContext : DbContext
    {
        public BMEDDBContext()
        { 
        
        }
        public BMEDDBContext(DbContextOptions<BMEDDBContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        //
        public DbSet<AttainFile> AttainFiles { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<OutsideBmedFlow> OutsideBmedFlows { get; set; }
    }
}
