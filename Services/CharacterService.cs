using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.rpg.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnet.rpg.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly DataContext _context;

        public CharacterService(DataContext context)
        {
            _context = context;
        }

 

        public async Task<ServiceResponse<List<Character>>> CreateCharacters(Character character)
        {
            var response = new ServiceResponse<List<Character>>();
            var addedCharacter = _context.Add(character);
            await _context.SaveChangesAsync();
            response.Data = await _context.Characters.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<List<Character>>> DeleteCharacter(int id)
        {
            var response = new ServiceResponse<List<Character>>();
            var character = await _context.Characters.FirstAsync( c => c.Id == id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            response.Data = await _context.Characters.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var response = new ServiceResponse<List<Character>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            response.Data = dbCharacters; 
            return response;
        }

        public async Task<ServiceResponse<Character>> GetSingleCharacter(int id)
        {
            var response = new ServiceResponse<Character>();
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            response.Data = character;
            return response;
        }

        public async Task<ServiceResponse<Character>> UpdateCharacter(Character updatedCharacter)
        {
            var response = new ServiceResponse<Character>();
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);

            character.HitPoints = updatedCharacter.HitPoints;
            character.Defense = updatedCharacter.Defense;
            character.Name = updatedCharacter.Name;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Class = updatedCharacter.Class;


            await _context.SaveChangesAsync();


            response.Data = character;
            return response;
        }
    }
}