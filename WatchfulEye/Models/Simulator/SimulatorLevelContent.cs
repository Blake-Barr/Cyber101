namespace WatchfulEye.Models.Simulator
{
    public class SimulatorLevelContent
    {

        private string? _quizAnswerKey;

        private string? _cipherList;
        public int Id { get; set; }

        public int GameType { get; set; }

        public string LevelTitle  { get; set; }

        public string LevelDescription  { get; set; }

        public string HTMLContent { get; set; }

        public int TutorialLevel { get; set; }

        // Quiz Fields
        public string? QuizAnswerKey
        {
            get { if (_quizAnswerKey != null) return String.Join("", _quizAnswerKey.Split(",")); else return ""; }
            set { _quizAnswerKey = String.Join(",",value); }
        }

        // Spot Game Fields
        public int? TotalSpots { get; set; }

        // Cipher Game Fields
        public string? CipherList
        {
            get { if (_cipherList != null) return _cipherList; else return ""; }
            set { _cipherList = String.Join(",", value); }
        }

        public string? EncryptedWord { get; set; }

        public int? CipherType { get; set; }

        public string? ScamUserHTML { get; set; }
        public string RenderLevel()
        {
            return HTMLContent;
        }

        public QuizResults CheckAnswers(string answers)
        {
            //string anstring = String.Join("", answers);
            char[] anstring = answers.ToCharArray();
            char[] anskey = QuizAnswerKey.ToCharArray();
            string[] matches = new string[anskey.Length];

            var complete = true;
            for(int i = 0; i < anskey.Length; i++)
            {
                if (!anstring[i].Equals(anskey[i]))   {
                    complete = false;
                    matches[i] = "0";
                }   else matches[i] = "1";
            }
            return new QuizResults(matches, complete);
        }
    }

    public class QuizResults
    {
        public string[] Matches;
        public bool Completed;

        public QuizResults(string[] matches, bool completed)
        {
            this.Matches = matches;
            this.Completed = completed;
        }
    }
}
