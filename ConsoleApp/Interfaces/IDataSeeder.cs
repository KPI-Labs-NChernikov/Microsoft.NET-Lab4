using Backend.Interfaces;

namespace ConsoleApp.Interfaces
{
    public interface IDataSeeder
    {
        ICollection<IEducationalInstitution> Institutions { get; }

        void SeedData();
    }
}
