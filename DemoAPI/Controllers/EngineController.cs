using DemoAPI.Interfaces;
using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemoAPI.Controllers
{
    public class EngineController : Controller
    {
        private readonly ICharacterAPI _characterAPI;
        private readonly ICharacterRepository _characterRepository;
        private readonly IConfigRepository _config;

        //Dependency Injections
        public EngineController(ICharacterAPI characterAPI, ICharacterRepository characterRepository, IConfigRepository config)
        {
            _characterAPI = characterAPI;
            _characterRepository = characterRepository;
            _config = config;
        }

        #region Populate
        [HttpPost("api/PopulateCharacter/{characterID}")]
        public IActionResult PopulateCharacter(int characterID)
        {
            try
            {
                //call API to get data
                var jsonResponse = _characterAPI.GetCharacterFromAPI(characterID);
                int characterPopulated = 0;
                if (jsonResponse != null)
                {
                    //Map characters to Model
                    CharacterModel character = JsonConvert.DeserializeObject<CharacterModel>(jsonResponse);
                    character.Id = characterID;

                    ConfigModel configuration = _config.GetConfig(); 
                    if (string.Equals(configuration.Mass_Unit,"English",StringComparison.OrdinalIgnoreCase))
                    {
                        //kg to lb conversion
                        character.Mass = character.Mass * 2.2;
                    }
                    //Sync model to DB
                    characterPopulated = _characterRepository.PostCharacterToDB(character);
                }
                else
                {
                    return NotFound("Character was not found in API.");
                }

                if (characterPopulated > 0)
                {
                    return Ok("Character successfully populated.");
                }
                else
                {
                    return StatusCode(500, "Failed to populate the character into the database.");
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        #endregion


        #region Export
        #endregion 
    }
}
