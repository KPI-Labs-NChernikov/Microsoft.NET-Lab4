using Backend.Other;

namespace Backend.Interfaces
{
    public interface IEducationalInstitution
    {
        public string Name { get; set; }

        public IEnumerable<IStudent> Students { get; }

        public IEnumerable<IStudent> GetOrderedStudents(StudentOrderingType orderBy, StudentOrderingType? thenBy);

        public void RemoveStudent(IStudent student);
    }
}
