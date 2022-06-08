using Backend;
using ConsoleApp.Data;
using ConsoleApp.Interfaces;

var institutions = new List<EducationalInstitution>();
IDataSeeder seeder = new DataSeeder(institutions);
seeder.SeedData();
Console.WriteLine();