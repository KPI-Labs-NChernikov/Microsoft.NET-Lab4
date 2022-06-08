using Backend.Handlers;
using Backend.Interfaces;
using ConsoleApp.Helpers;
using ConsoleApp.Interfaces;

namespace ConsoleApp.Printers
{
    public class StudentPrinter : IPrinter
    {
        private readonly IStudent _student;

        private readonly StudentStatsHandler _handler;

        public StudentPrinter(IStudent student)
        {
            _student = student ?? throw new ArgumentNullException(nameof(student));
            _handler = new StudentStatsHandler(student);
        }

        public void Print()
        {
            Console.WriteLine($"{_handler.FullName}:");
            Console.WriteLine($"Course: {_handler.Course}; Semester: {_handler.Semester}");
            Console.WriteLine($"Type of study: {_student.TypeOfStudy}");
            Console.WriteLine("Marks:");
            foreach (var mark in _handler.Marks)
                Console.WriteLine($"\t{mark.Key} : {mark.Value:F2}");
            Console.WriteLine($"Min: {_handler.MinMark:F2} Average: {_handler.AvgMark:F2} Max: {_handler.MaxMark:F2}");
            Console.WriteLine();
            var continueStudy = _handler.CanContinueLearning(out string? description);
            Console.WriteLine($"Can continue studying? {(continueStudy ? "yes" : "no")}");
            Console.WriteLine(description);
            Console.WriteLine();
        }
    }
}
