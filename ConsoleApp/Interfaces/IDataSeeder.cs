using Backend;

namespace ConsoleApp.Interfaces
{
    public interface IDataSeeder
    {
        ICollection<EducationalInstitution> Institutions { get; }

        void SeedData();
    }
}
