using System;
using NetApi.Models;
using NetApi.data;

namespace NetApi.Services.PokemonService
{
    public class PokemonService : IPokemonService
    {

        private readonly DataContext _context;
        public PokemonService(DataContext context)
        {
            _context = context;
        }

        public List<Pokemon> AddPokemon(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            _context.SaveChanges();

            var pokemons = _context.Pokemons.ToList();
            return pokemons;
        }

        public List<Pokemon> DeletePokemon(int id)
        {
            var pokemon = _context.Pokemons.Find(id);

            if (pokemon == null)
            {
                return null;
            }

            _context.Pokemons.Remove(pokemon);
            _context.SaveChanges();

            var pokemons = _context.Pokemons.ToList();
            return pokemons;
        }

        public List<Pokemon> GetAllPokemons()
        {
            var pokemons = _context.Pokemons.ToList();
            return pokemons;
        }

        public Pokemon GetPokemon(int id)
        {
            var pokemon = _context.Pokemons.Find(id);

            if (pokemon == null)
            {
                return null;
            }

            return pokemon;
        }

        public List<Pokemon> UpdatePokemon(int id, Pokemon request)
        { 
            var pokemon = _context.Pokemons.Find(id);

            if (pokemon == null)
            {
                return null;
            }

            if (request.Name != null && request.Name != "string")
            {
                pokemon.Name = request.Name;
            }
            if (request.Type != null && request.Type != "string")
            {
                pokemon.Type = request.Type;
            }

            _context.SaveChanges();

            var pokemons = _context.Pokemons.ToList();
            return pokemons;
        }
    }
}

