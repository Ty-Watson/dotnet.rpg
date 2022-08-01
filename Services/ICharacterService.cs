using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.rpg.Services
{
    public interface ICharacterService
    {
        public Task<ServiceResponse<List<Character>>> GetAllCharacters();
        public Task<ServiceResponse<List<Character>>> CreateCharacters(Character character);
        public Task<ServiceResponse<Character>> GetSingleCharacter(int id);
        public Task<ServiceResponse<Character>> UpdateCharacter(Character updatedCharacter);
        public Task<ServiceResponse<List<Character>>> DeleteCharacter(int id);
        
    }
}