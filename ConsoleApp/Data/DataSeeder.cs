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
            var university = new EducationalInstitution
            {
                Name = "National Technical University of Ukraine \"Igor Sikorsky Kyiv Polytechnic Institute\""
            };
            var universityStudentHandlers = new StudentHandler[]
            {
                new StudentHandler(new UniversityStudent
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Patronymic = "Ivanovych",
                    TypeOfStudy = TypeOfStudy.Remote,
                    Marks = new MarksContainer(new Dictionary<string, double>
                    {
                        { "Programming", 77 },

                    })
                })
                {
                    
                }
            };
        }
    }
}
