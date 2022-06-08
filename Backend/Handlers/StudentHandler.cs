using Backend.Interfaces;
using Backend.Other;

namespace Backend.Handlers
{
    public class StudentHandler
    {
        protected readonly IStudent _student;

        public IStudent Student => _student;

        public StudentHandler(IStudent student)
        {
            _student = student;
        }

        public string FullName => $"{_student.LastName} {_student.FirstName} {_student.Patronymic}".TrimEnd();

        public TypeOfStudy TypeOfStudy => _student.TypeOfStudy;

        public ushort Course
        {
            get => (ushort)((_student.FullSemester + 1) / 2);
            set => _student.FullSemester = (ushort)(value * 2 - (2 - Semester));
        }

        public ushort Semester
        {
            get => (ushort)(_student.FullSemester % 2 == 0 ? 2 : 1);
            set
            {
                var min = 1;
                var max = 2;
                if (value < min || value > max)
                    throw new ArgumentOutOfRangeException(nameof(value), $"The value should be from {min} to {max}");
                _student.FullSemester = (ushort)(Course * 2 - (2 - value));
            }
        }

        public IDictionary<string, double> Marks => _student.Marks;

        public virtual bool CanContinueLearning(out string? description)
        {
            bool result = true;
            if (!_student.Marks.Values.All(m => m >= _student.MinPassScore))
            {
                result = false;
                description = $"The student has not completed the last course successfully - " +
                    $"they have some grades that are lower than {_student.MinPassScore}";
            }
            else if (_student.NeedsToPassAnExternalExam)
            {
                string descriptionMiddle;
                if (_student.IsLastSemester)
                    descriptionMiddle = "enter the another level of study";
                else
                    descriptionMiddle = "continue learning";
                description = $"The student is able to {descriptionMiddle} after passing an external exam";
            }
            else if (_student.IsLastSemester)
            {
                result = false;
                description = $"The student is graduaded and, most likely, has a degree of master." +
                    $"{Environment.NewLine}But, the life is learning, so, you may consider obtaining a PhD degree";
            }
            else
                description = "Student has been successfully transferred to the next course";
            return result;
        }
    }
}
