using CJW._00.Scripts.ForgeScripts.Models;

namespace CJW._00.Scripts.ForgeScripts
{
    public class GameModel
    {
        public ForgeModel Forge { get; private set; }

        public GameModel()
        {
            Forge = new ForgeModel();
        }
    }
}