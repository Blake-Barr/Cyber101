using System.ComponentModel.DataAnnotations;

namespace WatchfulEye.Models.Simulator
{
    public class SimulatorLevel
    {
        public int Id { get; set; }
        public int? LevelNum { get; set; }

        public SimulatorLevelContent? SLC { get; set; }

        public int GameAmt = 1;

        public int? SLCId { get; set; }

        public SimulatorLevel() { }

        public SimulatorLevel(int levelNum)
        {
            this.LevelNum = levelNum;
        }


    }
}
