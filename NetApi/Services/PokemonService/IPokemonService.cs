using System;
using NetApi.Models;

namespace NetApi.Services.PokemonService
{
	public interface IPokemonService
	{
		List<Pokemon> GetAllPokemons();
		Pokemon GetPokemon(int id);
		List<Pokemon> AddPokemon(Pokemon pokemon);
		List<Pokemon> UpdatePokemon(int id, Pokemon request);
		List<Pokemon> DeletePokemon(int id);
	}
}

