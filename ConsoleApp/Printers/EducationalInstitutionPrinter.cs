using Backend;
using Backend.Handlers;
using Backend.Interfaces;
using ConsoleApp.Helpers;
using ConsoleApp.Interfaces;

namespace ConsoleApp.Printers
{
    public class EducationalInstitutionPrinter : IPrinter
    {
        private readonly EducationalInstitution _institution;

        public EducationalInstitutionPrinter(EducationalInstitution institution)
        {
            _institution = institution ?? throw new ArgumentNullException(nameof(institution));
        }

        public void Print()
        {
            Console.Clear();
            HelperMethods.PrintHeader(HelperMethods.GetHeader("Institution"));
            Console.WriteLine($"Name: {_institution.Name}");
            Console.WriteLine($"Students count: {_institution.Students.Count}");
            var menu = new LiteMenu
            {
                IsQuitable = true,
                Name = "function",
                Items = new List<(string, Action?)>
                {
                    ("Show all", () => {
                        PrintStudents();
                        Print();
                        }),
                    ("Add a student", null),
                    ("Update a student", null),
                    ("Delete a student", () => {
                        DeleteStudent();
                        Print();
                        })
                }
            };
            menu.Print();
        }

        public void PrintStudents()
        {
            var menu = new Menu
            {
                Header = HelperMethods.GetHeader($"{_institution.Name}: Students"),
                Name = "student"
            };
            foreach (var student in _institution.Students)
            {
                menu.Items.Add((HelperMethods.GetStudentString(student), () => new StudentPrinter(student).Print()));
            }
            menu.Print();
        }

        public void DeleteStudent()
        {
            Console.Clear();
            HelperMethods.PrintHeader(HelperMethods.GetHeader($"{_institution.Name}: Students - Delete"));
            for (int i = 0; i < _institution.Students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {HelperMethods.GetStudentString(_institution.Students.ElementAt(i))}");
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"0. Quit{Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            var form = new NumberForm<int>()
            {
                Min = 0,
                Max = _institution.Students.Count,
                Parser = int.TryParse,
                Name = "students's number or 0 to quit"
            };
            var number = form.GetNumber();
            if (number != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("DELETE:");
                Console.ForegroundColor = ConsoleColor.Red;
                number--;
                var student = _institution.Students.ElementAt(number);
                var name = new StudentHandler(student).FullName;
                var dialog = new Dialog
                {
                    Question = $"Are you sure you want to delete a student {name}",
                    YAction = () =>
                    {
                        _institution.Students.Remove(student);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Student {name} has been successfully deleted");
                        HelperMethods.Continue();
                    },
                    NAction = () => DeleteStudent()
                };
                dialog.Print();
            }
        }
    }
}
