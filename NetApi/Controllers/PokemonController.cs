using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetApi.Models;
using NetApi.Services.PokemonService;

namespace NetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
       private readonly string errorMessage = "That pokemon does not exist";
       private readonly IPokemonService _pokemonService;
       public PokemonController(IPokemonService pokemonService)
       {
            _pokemonService = pokemonService;
       }

        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> GetAllPokemons()
        {
            var result = _pokemonService.GetAllPokemons();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(int id)
        {
            var result = _pokemonService.GetPokemon(id);

            if (result == null)
            {
                return NotFound(errorMessage);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pokemon>>> AddPokemon(Pokemon pokemon)
        {
            var result = _pokemonService.AddPokemon(pokemon);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Pokemon>>> UpdatePokemon(int id, Pokemon request)
        {
            var result = _pokemonService.UpdatePokemon(id, request);

            if (result == null)
            {
                return NotFound(errorMessage);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Pokemon>>> DeletePokemon(int id)
        {
            var result = _pokemonService.DeletePokemon(id);

            if (result == null)
            {
                return NotFound(errorMessage);
            }

            return result;
        }
    }
}
