using Backend.Interfaces;
using Backend.Other;

namespace Backend.Students
{
    public class SchoolStudent : IStudent
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Patronymic { get; set; }
        public ushort Course { get; set; }

        private const ushort _lastCourse = 11;

        public bool IsLastCourse => Course == _lastCourse;

        public bool NeedsToPassAnExternalExam => Course == 9 || Course == _lastCourse;

        public IDictionary<string, double> Marks { get; set; } = new Dictionary<string, double>();
        public TypeOfStudy TypeOfStudy { get; set; }

        public double MinPassScore => 4;
    }
}
