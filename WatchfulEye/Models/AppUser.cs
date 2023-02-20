using Microsoft.AspNetCore.Identity;
using WatchfulEye.Models.Simulator;
namespace WatchfulEye.Models
{
    public class AppUser : IdentityUser
    {
        private int _level = 1;

        private int _experience = 0;

        private int _toNextLevel = 10;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int CurrentCompletedLevel { get; set; }

        public SimulatorLevel? AssignedLevel { get; set; }

        public int? AssignedLevelId { get; set; }

        public int Level { get { return _level; } set { _level = value; } }

        public int Experience { get { return _experience; } set { _experience = value; } }

        public int ToNextLevel { get { return _toNextLevel; } set { _toNextLevel = value; } }

        public bool AbleToLevel()
        {
            return Experience >= ToNextLevel;
        }

        public int LevelUp()
        {
            if (Experience < ToNextLevel)
            {
                return -1;
            }
            else
            {
                Level++;
                ToNextLevel = (int)(10 * Math.Pow(Level, 2));
                Experience = 0;
            }

            return Level;
        }

        public void AwardXP(int amt)
        {
            Experience += amt;

            if (AbleToLevel())
            {
                LevelUp();
            }
        }

        //public string Username { get; set; }
    }
}
