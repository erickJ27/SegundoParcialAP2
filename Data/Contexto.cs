using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SegundoParcialApli2.Models;

namespace SegundoParcialApli2.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Llamada> llamadas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlite(@"Data Source=Database/Parcial2.db"));

        }
    }
}
