using DemoAPI.Models;

namespace DemoAPI.Interfaces
{
    public interface ICharacterRepository
    {
        public bool PostCharacterToDB(CharacterModel model);
    }
}
    