using Backend;
using Backend.Handlers;
using Backend.Interfaces;
using Backend.Other;
using Backend.Students;
using ConsoleApp.Helpers;
using ConsoleApp.Interfaces;

namespace ConsoleApp.Printers
{
    public class EducationalInstitutionPrinter : IPrinter
    {
        private readonly EducationalInstitution _institution;

        private IEnumerable<IStudent> Students 
            => _institution.GetOrderedStudents(StudentOrderingType.CourseAsc, StudentOrderingType.AvgMarkDesc);

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
                    ("Add a student", () => {
                        AddStudent();
                        Print();
                        }),
                    ("Update a student", () => {
                        UpdateStudents();
                        Print();
                        }),
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
            foreach (var student in Students)
                menu.Items.Add((HelperMethods.GetStudentString(student), () =>
                {
                    Console.Clear();
                    HelperMethods.PrintHeader(HelperMethods.GetHeader($"Student"));
                    new StudentPrinter(student).Print();
                    HelperMethods.Continue();
                }
                ));
            menu.Print();
        }

        public void AddStudent()
        {
            Console.Clear();
            HelperMethods.PrintHeader(HelperMethods.GetHeader($"{_institution.Name}: Students - Add"));
            var student = SelectStudentType();
            Console.WriteLine();
            var printer = new StudentPrinter(student);
            printer.UpdateName();
            Console.WriteLine();
            printer.UpdateCourse();
            Console.WriteLine();
            printer.UpdateSemester();
            Console.WriteLine();
            printer.UpdateTypeOfStudy();
            Console.WriteLine();
            _institution.Students.Add(student);
            Console.WriteLine("The student has been successfully added:");
            printer.Print();
            Console.WriteLine();
            HelperMethods.Continue();
        }

        private static IStudent SelectStudentType()
        {
            IStudent result = null!;
            var menu = new LiteMenu
            {
                Name = "type of the student",
                Items = new List<(string, Action?)>
                {
                    ("University student", () => result = new UniversityStudent()),
                    ("School student", () => result = new SchoolStudent())
                }
            };
            menu.Print();
            return result;
        }

        public void UpdateStudents()
        {
            var menu = new Menu
            {
                Header = HelperMethods.GetHeader($"{_institution.Name}: Students - Update"),
                Name = "student to update"
            };
            foreach (var student in Students)
                menu.Items.Add((HelperMethods.GetStudentString(student), () => new StudentPrinter(student).UpdateStudent()));
            menu.Print(true);
        }

        public void DeleteStudent()
        {
            Console.Clear();
            HelperMethods.PrintHeader(HelperMethods.GetHeader($"{_institution.Name}: Students - Delete"));
            for (int i = 0; i < Students.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {HelperMethods.GetStudentString(Students.ElementAt(i))}");
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
                var student = Students.ElementAt(number);
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
