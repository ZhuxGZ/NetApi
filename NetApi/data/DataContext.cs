using System;
using Microsoft.EntityFrameworkCore;
using NetApi.Models;

namespace NetApi.data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=pokemonsApi;User=sa;Password=P@ssword1234;Trusted_Connection=False;Encrypt=false");
        }

        public DbSet<Pokemon> Pokemons { get; set; }
    }
}

