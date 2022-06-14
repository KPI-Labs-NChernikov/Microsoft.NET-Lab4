using Backend.Interfaces;
using ConsoleApp.Data;
using ConsoleApp.Helpers;
using ConsoleApp.Interfaces;
using ConsoleApp.Printers;

Console.ForegroundColor = ConsoleColor.DarkGreen;
var institutions = new List<IEducationalInstitution>();
IDataSeeder seeder = new DataSeeder(institutions);
seeder.SeedData();
var mainMenu = new Menu
{
    Header = HelperMethods.GetHeader("Main"),
    Name = "educational institution",
};
foreach (var institution in institutions)
    mainMenu.Items.Add((institution.Name, () => new EducationalInstitutionPrinter(institution).Print()));
mainMenu.Print();
Console.ResetColor();
