using System.ComponentModel.DataAnnotations;

namespace WatchfulEye.Models.Simulator
{
    public class SimulatorLevel
    {
        public int Id { get; set; }
        public int? LevelNum { get; set; }
        public int? GameType { get; set; }
        public string HTMLContent { get; set; }
        public string LevelName { get; set; }
        public string LevelDesc { get; set; }

        public int GameAmt = 1;

        public SimulatorLevel() { }

        public SimulatorLevel(int levelNum, int gameType)
        {
            this.LevelNum = levelNum;
            this.GameType = gameType;
        }

        public string RenderLevel()
        {
            return HTMLContent;
        }
    }
}
