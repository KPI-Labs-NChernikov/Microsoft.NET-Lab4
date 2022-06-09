using Backend;
using Backend.Handlers;
using Backend.Interfaces;
using Backend.Students;
using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Other;
using Backend.Containers;

namespace ConsoleApp.Data
{
    public class DataSeeder : IDataSeeder
    {
        public ICollection<EducationalInstitution> Institutions { get; }

        public DataSeeder(ICollection<EducationalInstitution> institutions)
        {
            Institutions = institutions ?? throw new ArgumentNullException(nameof(institutions));
        }

        public void SeedData()
        {
            var institution = new EducationalInstitution
            {
                Name = "National Technical University of Ukraine \"Igor Sikorsky Kyiv Polytechnic Institute\""
            };
            var universityStudents = new UniversityStudent[]
            {
                new UniversityStudent
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Patronymic = "Ivanovych",
                    TypeOfStudy = TypeOfStudy.Remote,
                    Marks = new MarksContainer(new Dictionary<string, double>
                    {
                        { "Programming", 59 },
                        { "Algorythms", 78 },
                        { "Further mathematics", 90 },
                        { "English", 97.7 },
                        { "Databases", 95 },
                        { "Psychology", 80 },
                    }),
                    FullSemester = 3
                },
                new UniversityStudent
                {
                    FirstName = "Petro",
                    LastName = "Sydorenko",
                    Patronymic = "Mykolayovych",
                    TypeOfStudy = TypeOfStudy.Daily,
                    Marks = new MarksContainer(new Dictionary<string, double>
                    {
                        { "Programming", 90 },
                        { "Android development", 99 },
                        { "Web development", 90 },
                        { "English", 95 },
                        { "Computer graphics", 100 },
                        { "Physical education", 86 },
                    }),
                    FullSemester = 5
                },
                new UniversityStudent
                {
                    FirstName = "Joe",
                    LastName = "Barbaro",
                    TypeOfStudy = TypeOfStudy.Daily,
                    Marks = new MarksContainer(new Dictionary<string, double>
                    {
                        { "Computer systems architecture", 77 },
                        { "Management basics", 89 },
                        { "Asynchronous programming", 78 },
                        { "English", 98 },
                        { "Computer graphics", 65 },
                        { "Practise", 80 },
                    }),
                    FullSemester = 12
                },           
                new UniversityStudent
                {
                    FirstName = "Petro",
                    LastName = "Petrenko",
                    Patronymic = "Pertovych",
                    TypeOfStudy = TypeOfStudy.Daily,
                    Marks = new MarksContainer(new Dictionary<string, double>
                    {
                        { "Computer systems architecture", 91 },
                        { "Game development", 99 },
                        { "Asynchronous programming", 90 },
                        { "English", 99 },
                        { "Computer graphics", 100 },
                        { "Practise", 86 },
                    }),
                    FullSemester = 8
                },             
                new UniversityStudent
                {
                    FirstName = "Pavlo",
                    LastName = "Pavlenko",
                    Patronymic = "Pertovych",
                    TypeOfStudy = TypeOfStudy.Externship,
                    Marks = new MarksContainer(new Dictionary<string, double>
                    {
                        { "Programming", 92 },
                        { "Data structures", 99 },
                        { "Discrete mathematics", 90 },
                        { "English", 99 },
                        { "Further mathematics", 100 },
                        { "Physical education", 100 },
                    }),
                    FullSemester = 1
                },
            };
            foreach (var student in universityStudents)
                institution.Students.Add(student);
            Institutions.Add(institution);

            institution = new EducationalInstitution
            {
                Name = "Specialized school №71 with English specialization"
            };
            var schoolStudents = new SchoolStudent[]
            {
                new SchoolStudent
                {
                    FirstName = "Ivan",
                    LastName = "Ivanenko",
                    Patronymic = "Pavlovych",
                    TypeOfStudy = TypeOfStudy.Home,
                    Marks = new MarksContainer(new Dictionary<string, double>
                    {
                        { "Maths", 10 },
                        { "Physical education", 3 },
                        { "Computer Science", 6 },
                        { "English", 4 },
                        { "Ukrainian", 6 },
                        { "German", 8 },
                        { "Literature", 7}
                    }),
                    FullSemester = 9
                },
                new SchoolStudent
                {
                    FirstName = "Mykola",
                    LastName = "Petrov",
                    Patronymic = "Pavlovych",
                    TypeOfStudy = TypeOfStudy.Individual,
                    Marks = new MarksContainer(new Dictionary<string, double>
                    {
                        { "Algebra", 10 },
                        { "Geometry", 10 },
                        { "Physics", 10 },
                        { "Chemistry", 10 },
                        { "Physical education", 9 },
                        { "Computer Science", 10 },
                        { "English", 11 },
                        { "Ukrainian", 8 },
                        { "German", 8 },
                        { "Literature", 9}
                    }),
                    FullSemester = 18
                },
                new SchoolStudent
                {
                    FirstName = "Liia",
                    LastName = "Petrenko",
                    Patronymic = "Serhiivna",
                    TypeOfStudy = TypeOfStudy.Evening,
                    Marks = new MarksContainer(new Dictionary<string, double>
                    {
                        { "Algebra", 5 },
                        { "Geometry", 4 },
                        { "Physics", 8 },
                        { "Chemistry", 10 },
                        { "Physical education", 6 },
                        { "Computer Science", 3 },
                        { "English", 2 },
                        { "Ukrainian", 1 },
                        { "German", 5 },
                        { "Literature", 7}
                    }),
                    FullSemester = 22
                },
                new SchoolStudent
                {
                    FirstName = "Mariia",
                    LastName = "Petrova",
                    Patronymic = "Oleksandrivna",
                    TypeOfStudy = TypeOfStudy.Daily,
                    Marks = new MarksContainer(new Dictionary<string, double>
                    {
                        { "Algebra", 10 },
                        { "Geometry", 11 },
                        { "Physics", 11 },
                        { "Chemistry", 10 },
                        { "Physical education", 12 },
                        { "Computer Science", 10 },
                        { "English", 11 },
                        { "Ukrainian", 10 },
                        { "German", 10 },
                        { "Literature", 11}
                    }),
                    FullSemester = 22
                },
                new SchoolStudent
                {
                    FirstName = "Kateryna",
                    LastName = "Panasenko",
                    Patronymic = "Viktorivna",
                    TypeOfStudy = TypeOfStudy.Daily,
                    Marks = new MarksContainer(new Dictionary<string, double>
                    {
                        { "Algebra", 10 },
                        { "Geometry", 11 },
                        { "Physics", 11 },
                        { "Chemistry", 8 },
                        { "Physical education", 12 },
                        { "Computer Science", 10 },
                        { "English", 10 },
                        { "Ukrainian", 10 },
                        { "German", 10 },
                        { "Literature", 12}
                    }),
                    FullSemester = 21
                }
            };
            foreach (var student in schoolStudents)
                institution.Students.Add(student);
            Institutions.Add(institution);
        }
    }
}
