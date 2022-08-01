using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.rpg.Services;
using Microsoft.AspNetCore.Mvc;


namespace dotnet.rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetSingle(int id)
        {
            
            return Ok(await _characterService.GetSingleCharacter(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Create(Character character)
        {
            return Ok(await _characterService.CreateCharacters(character));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Character>>> Update(Character updatedCharacter)
        {
            return Ok (await _characterService.UpdateCharacter(updatedCharacter));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Delete(int id)
        {
            return Ok (await _characterService.DeleteCharacter(id));
        }

        
     
    }
}