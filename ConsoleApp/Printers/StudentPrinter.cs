using Backend.Handlers;
using Backend.Interfaces;
using Backend.Other;
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
                Console.WriteLine($"\t{mark.Key}: {mark.Value:F2}");
            Console.WriteLine($"Min: {_handler.MinMark:F2} Average: {_handler.AvgMark:F2} Max: {_handler.MaxMark:F2}");
            Console.WriteLine();
            var continueStudy = _handler.CanContinueLearning(out string? description);
            Console.WriteLine($"Can continue studying? {(continueStudy ? "yes" : "no")}");
            Console.WriteLine(description);
            Console.WriteLine();
        }

        public void UpdateStudent()
        {
            static void PrintAfter(string propertyName)
            {
                Console.WriteLine($"The {propertyName} has been successfully updated");
                HelperMethods.Continue();
            }

            Console.Clear();
            HelperMethods.PrintHeader(HelperMethods.GetHeader($"Student"));
            Print();
            var menu = new LiteMenu
            {
                IsQuitable = true,
                Name = "property to update",
                Items = new List<(string, Action?)>
                {
                    ("Name", () =>
                    {
                        UpdateName();
                        PrintAfter("name");
                        
                    }),
                    ("Course", () =>
                    {
                        UpdateCourse();
                        PrintAfter("course");
                    }),
                    ("Semester", () =>
                    {
                        UpdateSemester();
                        PrintAfter("semester");
                    }),
                    ("Type of study", () =>
                    {
                        Console.WriteLine();
                        UpdateTypeOfStudy();
                        PrintAfter("type of study");
                    }),
                    ("Marks", () =>
                    {
                        Console.WriteLine();
                        UpdateMarks();
                        HelperMethods.Continue();
                    })
                }
            };
            menu.Print();
        }

        private static bool WhitespaceValidation(string? s) => !string.IsNullOrWhiteSpace(s);

        private static string WhitespaceValidationErrorMessage => "this field shouldn't be empty";

        public void UpdateName()
        {
            var form = new StringForm
            {
                IsValid = WhitespaceValidation,
                Name = "first name",
                ErrorMessage = WhitespaceValidationErrorMessage
            };
            _student.FirstName = form.GetString();
            form.Name = "last name";
            _student.LastName = form.GetString();
            form.Name = "patronymic (or leave empty if none)";
            form.IsValid = null;
            _student.Patronymic = form.GetString();
            if (_student.Patronymic == string.Empty)
                _student.Patronymic = null;
        }

        public void UpdateCourse()
        {
            var form = new NumberForm<ushort>
            {
                Parser = ushort.TryParse,
                Name = "course"
            };
            try
            {
                _handler.Course = form.GetNumber();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occured: most likely, too big or too low value");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Please, enter the course once more");
                UpdateCourse();
            }
        }

        public void UpdateSemester()
        {
            var form = new NumberForm<ushort>
            {
                Parser = ushort.TryParse,
                Name = "semester",
                Min = 1,
                Max = 2
            };
            _handler.Semester = form.GetNumber();
        }

        public void UpdateTypeOfStudy()
        {
            var enumValues = Enum.GetNames(typeof(TypeOfStudy));
            var menu = new LiteMenu
            {
                Name = "type of study"
            };
            foreach (var value in enumValues)
                menu.Items.Add((value, () => _student.TypeOfStudy = (TypeOfStudy)Enum.Parse(typeof(TypeOfStudy), value)));
            menu.Print();
        }

        public void UpdateMarks()
        {
            var menu = new LiteMenu
            {
                IsQuitable = true,
                Name = "action",
                Items = new List<(string, Action?)>
                {
                    ("Add or update a mark", () =>
                    {
                        Console.WriteLine();
                        UpdateMark();
                        Console.WriteLine();
                        UpdateMarks();
                    }),
                    ("Delete a mark", () =>
                    {
                        Console.WriteLine();
                        DeleteMark();
                        Console.WriteLine();
                        UpdateMarks();
                    })
                }
            };
            menu.Print();
        }

        private void UpdateMark()
        {
            var nameForm = new StringForm
            {
                IsValid = WhitespaceValidation,
                Name = "mark's name",
                ErrorMessage = WhitespaceValidationErrorMessage
            };
            var markForm = new NumberForm<double>
            {
                Parser = double.TryParse,
                Name = "mark",
                Min = _student.Marks.Min,
                Max = _student.Marks.Max,
                StringHandler = s => s.Replace('.', ',')
            };
            _student.Marks.Update(nameForm.GetString(), markForm.GetNumber());
            Console.WriteLine($"The marks have been successfully updated");
        }

        private void DeleteMark()
        {
            var nameForm = new StringForm
            {
                IsValid = WhitespaceValidation,
                Name = "mark's name",
                ErrorMessage = WhitespaceValidationErrorMessage
            };
            try
            {
                var chosenCourse = nameForm.GetString();
                _student.Marks.Delete(chosenCourse);
                Console.WriteLine($"The {chosenCourse} has been successfully deleted");
            }
            catch (KeyNotFoundException exc)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                HelperMethods.PrintErrorMessage(exc.Message);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
        }
    }
}
