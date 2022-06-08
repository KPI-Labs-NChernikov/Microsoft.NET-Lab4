using Backend.Other;

namespace Backend.Interfaces
{
    public interface IStudent
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string? Patronymic {get; set;}

        /// <summary>
        /// The total number of semesters. For example:
        /// Course = 3; Semester = 1; => FullSemester = 5
        /// Course = 3; Semester = 2; => FullSemester = 6
        /// </summary>
        ushort FullSemester { get; set; }

        bool IsLastSemester { get; }

        bool NeedsToPassAnExternalExam { get; }

        double MinPassScore { get; }

        IMarksContainer Marks { get; set; }

        TypeOfStudy TypeOfStudy { get; set; }
    }
}
