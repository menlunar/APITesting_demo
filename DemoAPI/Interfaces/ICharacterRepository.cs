using DemoAPI.Models;

namespace DemoAPI.Interfaces
{
    public interface ICharacterRepository
    {
        public int PostCharacterToDB(CharacterModel model);
    }
}
    