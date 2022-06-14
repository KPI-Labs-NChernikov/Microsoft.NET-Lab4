using Backend.Other;

namespace Backend.Interfaces
{
    public interface IEducationalInstitution
    {
        string Name { get; set; }

        IEnumerable<IStudent> Students { get; }

        IEnumerable<IStudent> GetOrderedStudents(StudentOrderingType orderBy, StudentOrderingType? thenBy);

        void RemoveStudent(IStudent student);
    }
}
