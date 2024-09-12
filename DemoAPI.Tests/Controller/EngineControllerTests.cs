using DemoAPI.API;
using DemoAPI.Interfaces;
using DemoAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using DemoAPI.Controllers;
using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Newtonsoft.Json;

namespace DemoAPI.Tests.Controller
{
    public class EngineControllerUnitTests
    {
        private readonly EngineController _engineController;

        private readonly ICharacterAPI _characterAPI;
        private readonly ICharacterRepository _characterRepository;
        private readonly IConfigRepository _config;

        //Dependency Injections
        public EngineControllerUnitTests()
        {
            //Fakes/Mocks
            _characterAPI = A.Fake<ICharacterAPI>();
            _characterRepository = A.Fake<ICharacterRepository>();
            _config = A.Fake<IConfigRepository>();

            //SUT - System Under Test
            _engineController = new EngineController(_characterAPI, _characterRepository, _config);
        }

        #region UNIT TESTS
        [Fact]
        public void Character_is_populated_without_mass_unit_config()
        {
            //Arrange
            int characterID = 1; //ito yung ipapasa sa method
            string strCharacter = "{\"name\":\"Darth Vader\",\"height\":\"172\",\"mass\":\"77\",\"hair_color\":\"blond\",\"skin_color\":\"fair\",\"eye_color\":\"blue\",\"birth_year\":\"19BBY\",\"gender\":\"male\",\"homeworld\":\"https://swapi.dev/api/planets/1/\",\"films\":[\"https://swapi.dev/api/films/1/\",\"https://swapi.dev/api/films/2/\",\"https://swapi.dev/api/films/3/\",\"https://swapi.dev/api/films/6/\"],\"species\":[],\"vehicles\":[\"https://swapi.dev/api/vehicles/14/\",\"https://swapi.dev/api/vehicles/30/\"],\"starships\":[\"https://swapi.dev/api/starships/12/\",\"https://swapi.dev/api/starships/22/\"],\"created\":\"2014-12-09T13:50:51.644000Z\",\"edited\":\"2014-12-20T21:17:56.891000Z\",\"url\":\"https://swapi.dev/api/people/1/\"}";
            ConfigModel config = new();
            CharacterModel character = JsonConvert.DeserializeObject<CharacterModel>(strCharacter);

            A.CallTo(() => _characterAPI.GetCharacterFromAPI(characterID)).Returns(strCharacter);
            A.CallTo(() => _config.GetConfig()).Returns(config);

            // Mock PostCharacterToDB by matching the properties
            A.CallTo(() => _characterRepository.PostCharacterToDB(
                A<CharacterModel>.That.Matches(c => c.Name == "Darth Vader" && c.Mass == character.Mass)
            )).Returns(1);

            //Action
            var result = _engineController.PopulateCharacter(characterID);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void Character_is_populated_with_english_mass_unit_config()
        {
            //Arrange
            int characterID = 1; //ito yung ipapasa sa method
            string strCharacter = "{\"name\":\"Darth Vader\",\"height\":\"172\",\"mass\":\"77\",\"hair_color\":\"blond\",\"skin_color\":\"fair\",\"eye_color\":\"blue\",\"birth_year\":\"19BBY\",\"gender\":\"male\",\"homeworld\":\"https://swapi.dev/api/planets/1/\",\"films\":[\"https://swapi.dev/api/films/1/\",\"https://swapi.dev/api/films/2/\",\"https://swapi.dev/api/films/3/\",\"https://swapi.dev/api/films/6/\"],\"species\":[],\"vehicles\":[\"https://swapi.dev/api/vehicles/14/\",\"https://swapi.dev/api/vehicles/30/\"],\"starships\":[\"https://swapi.dev/api/starships/12/\",\"https://swapi.dev/api/starships/22/\"],\"created\":\"2014-12-09T13:50:51.644000Z\",\"edited\":\"2014-12-20T21:17:56.891000Z\",\"url\":\"https://swapi.dev/api/people/1/\"}";
            ConfigModel config = new() { Mass_Unit = "EnGliSh" };
            CharacterModel character = JsonConvert.DeserializeObject<CharacterModel>(strCharacter);

            A.CallTo(() => _characterAPI.GetCharacterFromAPI(characterID)).Returns(strCharacter);
            A.CallTo(() => _config.GetConfig()).Returns(config);

            // Mock PostCharacterToDB by matching the properties
            A.CallTo(() => _characterRepository.PostCharacterToDB(
                A<CharacterModel>.That.Matches(c => c.Name == "Darth Vader" && c.Mass == (character.Mass * 2.2))
                    )).Returns(1);

            //Action
            var result = _engineController.PopulateCharacter(characterID);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        #endregion
    }
}
