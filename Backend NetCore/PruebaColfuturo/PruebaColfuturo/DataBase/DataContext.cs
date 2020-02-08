using Microsoft.EntityFrameworkCore;
using PruebaColfuturo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaColfuturo.DataBase
{
    public class DataContext: DbContext
    {
        private readonly string connectionString;

        public DataContext(DbContextOptions<DataContext> options): base (options) {
        }
        public DbSet <Usuario> Usuario { set; get; }
        public DbSet<PruebaColfuturo.Model.Idioma> Idioma { get; set; }
        public DbSet<PruebaColfuturo.Model.TipoCarta> TipoCarta { get; set; }
        public DbSet<PruebaColfuturo.Model.CartaGenerada> CartaGenerada { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
