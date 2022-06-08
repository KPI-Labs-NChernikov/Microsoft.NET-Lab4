using Backend.Containers;
using Backend.Interfaces;
using Backend.Other;

namespace Backend.Students
{
    public class UniversityStudent : IStudent
    {
        public UniversityStudent()
        {
            Marks.Min = 0;
            Marks.Max = 100;
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Patronymic { get; set; }

        private const ushort _lastBachelorSemester = 4 * 2;

        public bool IsLastSemester => FullSemester == _lastBachelorSemester || FullSemester == 6 * 2;

        public bool NeedsToPassAnExternalExam => FullSemester == _lastBachelorSemester;

        public IMarksContainer Marks { get; set; } = new MarksContainer();
        public TypeOfStudy TypeOfStudy { get; set; }

        public double MinPassScore => 60;

        private ushort _fullSemester = 1;

        public ushort FullSemester
        {
            get => _fullSemester;
            set
            {
                var min = 1;
                var max = 12;
                if (value < min || value > max)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        $"The value should be from {min} to {max}");
                _fullSemester = value;
            }
        }
    }
}
