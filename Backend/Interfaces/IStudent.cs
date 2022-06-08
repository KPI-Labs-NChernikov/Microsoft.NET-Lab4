using Backend.Other;

namespace Backend.Interfaces
{
    public interface IStudent
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string? Patronymic {get; set;}

        ushort Course { get; set; }

        bool IsLastCourse { get; }

        bool NeedsToPassAnExternalExam { get; }

        double MinPassScore { get; }

        IDictionary<string, double> Marks { get; set; }

        TypeOfStudy TypeOfStudy { get; set; }
    }
}
