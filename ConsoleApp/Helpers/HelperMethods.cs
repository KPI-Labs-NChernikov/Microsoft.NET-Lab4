using Backend.Handlers;
using Backend.Interfaces;
using System.Text;

namespace ConsoleApp.Helpers
{
    public static class HelperMethods
    {
        public static void Continue()
        {
            Console.WriteLine("Press enter co continue");
            Console.ReadLine();
        }

        public static void PrintHeader(string header)
        {
            Console.WriteLine($"{header}{Environment.NewLine}");
        }

        public static void PrintErrorMessage(string? excMessage)
        {
            var initialColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            excMessage = string.IsNullOrEmpty(excMessage) ? "Ooops, unknown error occured..."
                : $"An error occured: {excMessage}";
            Console.WriteLine(excMessage);
            Console.ForegroundColor = initialColor;
        }

        public static string? Search(string toFind)
        {
            Console.WriteLine($"Please, enter the {toFind}: ");
            return Console.ReadLine();
        }

        internal static string GetHeader(string subtype)
        {
            return $"22. Students of an educational institution: {subtype}{Environment.NewLine}" +
                    "Nikita Chernikov, IS-02";
        }

        internal static string GetStudentString(IStudent student)
        {
            var handler = new StudentStatsHandler(student);
            var builder = new StringBuilder($"{handler.FullName}:{Environment.NewLine}");
            builder.AppendLine($"Course: {handler.Course}; Semester: {handler.Semester}");
            builder.AppendLine($"Type of study: {student.TypeOfStudy}");
            builder.AppendLine($"Average mark: {handler.AvgMark:F2}");
            var continueStudy = handler.CanContinueLearning(out string? description);
            builder.AppendLine($"Can continue studying? {(continueStudy ? "yes" : "no")}");
            builder.AppendLine(description);
            return builder.ToString();
        }
    }
}
