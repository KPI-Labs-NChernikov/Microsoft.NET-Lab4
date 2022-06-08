using Backend.Interfaces;
using Backend.Other;

namespace Backend.Students
{
    public class UniversityStudent : IStudent
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Patronymic { get; set; }
        public ushort Course { get; set; }

        private const ushort _lastBachelorCourse = 4;

        public bool IsLastCourse => Course == _lastBachelorCourse || Course == 6;

        public bool NeedsToPassAnExternalExam => Course == _lastBachelorCourse;

        public IDictionary<string, double> Marks { get; set; } = new Dictionary<string, double>();
        public TypeOfStudy TypeOfStudy { get; set; }

        public double MinPassScore => 60;
    }
}
