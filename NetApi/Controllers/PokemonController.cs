using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetApi.Models;

namespace NetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private static List<Pokemon> pokemons = new List<Pokemon>
        {
           new Pokemon
           {
              Id = 1,
              Name = "Charmander",
              Type = "Fire"
           },
           new Pokemon
           {
              Id = 2,
              Name = "Bulbasaur",
              Type = "Grass"
           }
        };

        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> GetAllPokemons()
        {
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(int id)
        {
            var pokemon = pokemons.Find(X => X.Id == id);

            if (pokemon == null)
            {
                return NotFound("Sorry, but this pokemon doesn't exist");
            }

            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pokemon>>> AddHero(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
            return Ok(pokemons);
        }
    }
}
