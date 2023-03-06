using WatchfulEye.Models.Simulator;

namespace WatchfulEye.ViewModels
{
    public class SimulatorLevelViewModel
    {
        public SimulatorLevel simulatorLevel { get; set; }
        public SimulatorLevelContent simulatorLevelContent { get; set; }
        public SimulatorLevelViewModel(SimulatorLevel simulatorLevel, SimulatorLevelContent simulatorLevelContent)
        {
            this.simulatorLevel = simulatorLevel;
            this.simulatorLevelContent = simulatorLevelContent;
        }

        public SimulatorLevelViewModel() { }
    }
}
