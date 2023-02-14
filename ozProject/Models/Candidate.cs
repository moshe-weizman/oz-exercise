using System.Reflection.Metadata.Ecma335;

namespace ozProject.Models
{
   
    public enum ExperienceLevel { Junior=1, Senior}
    public class Candidate : Person
    {
        public Nullable<int> BeginYear { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public string[] Languages { get; set; }

        public ExperienceLevel LevelExperience
        {
            get {
                const int yearsExperience = 3;
                
                ExperienceLevel level;
                if (!BeginYear.HasValue )
                {
                    return ExperienceLevel.Junior;
                }
                if (DateTime.Now.Year - BeginYear > yearsExperience) 
                    level = ExperienceLevel.Senior;
                else 
                    level = ExperienceLevel.Junior;
                return level;
            }
            private set { } }

          

    }
}
