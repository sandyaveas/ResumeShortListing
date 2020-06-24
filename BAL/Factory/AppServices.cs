using System;
using System.Collections.Generic;
using System.Text;
using BAL.Factory;
using BAL.Services;

namespace BAL.Factory
{
    public class AppServices : IAppServices
    {
        public CandidateServices Candidate { get => new CandidateServices(); }

        public SkillServices Skill { get => new SkillServices(); }

        public PersonalDetailServices PersonalDetail { get => new PersonalDetailServices(); }

        public JobExperienceServices JobExperience { get => new JobExperienceServices(); }

        public CanActivityServices CanActivity { get => new CanActivityServices(); }
    }
}
