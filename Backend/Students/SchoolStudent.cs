using Backend.Containers;
using Backend.Interfaces;
using Backend.Other;

namespace Backend.Students
{
    public class SchoolStudent : IStudent
    {
        public SchoolStudent()
        {
            Marks.Min = 0;
            Marks.Max = 12;
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Patronymic { get; set; }

        private const ushort _lastSemester = 22;

        public bool IsLastSemester => FullSemester == _lastSemester;

        public bool NeedsToPassAnExternalExam => FullSemester == 9 * 2 || FullSemester == _lastSemester;

        public IMarksContainer Marks { get; set; } = new MarksContainer();

        public TypeOfStudy TypeOfStudy { get; set; }

        public double MinPassScore => 4;

        private ushort _fullSemester = 1;

        public ushort FullSemester
        {
            get => _fullSemester;
            set
            {
                var min = 1;
                if (value < min || value > _lastSemester)
                    throw new ArgumentOutOfRangeException(nameof(value), 
                        $"The value should be from {min} to {_lastSemester}");
                _fullSemester = value;
            }
        }
    }
}
