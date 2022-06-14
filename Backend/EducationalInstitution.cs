using Backend.Handlers;
using Backend.Interfaces;
using Backend.Other;

namespace Backend
{
    public class EducationalInstitution<T> : IEducationalInstitution where T : IStudent
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<T> Students { get; set; } = new List<T>();

        IEnumerable<IStudent> IEducationalInstitution.Students => (IEnumerable<IStudent>)Students;

        public IEnumerable<IStudent> GetOrderedStudents(StudentOrderingType orderBy, StudentOrderingType? thenBy)
        {
            static Func<IStudent, object> GetSelectorFromType(StudentOrderingType type)
            {
                var typeNumber = Math.Abs((short)type);
                return typeNumber switch
                {
                    2 => s => new StudentStatsHandler(s).AvgMark,
                    _ => s => s.FullSemester,
                };
            }

            var students = (this as IEducationalInstitution).Students;
            Func<Func<IStudent, object>, IOrderedEnumerable<IStudent>> orderByFunc 
                = orderBy < 0 ? students.OrderByDescending : students.OrderBy;
            var result = orderByFunc.Invoke(GetSelectorFromType(orderBy));
            if (thenBy != null)
            {
                orderByFunc = thenBy < 0 ? result.ThenByDescending : result.ThenBy;
                result = orderByFunc.Invoke(GetSelectorFromType(thenBy.Value));
            }
            return result;
        }

        private const string _deleteErrorMessage = "There is no such an element in the collection";
        public void RemoveStudent(IStudent student)
        {
            try
            {
                var result = Students.Remove((T)student);
                if (!result)
                    throw new ArgumentException(_deleteErrorMessage, nameof(student));
            }
            catch(InvalidCastException)
            {
                throw new ArgumentException(_deleteErrorMessage, nameof(student));
            }
        }
    }
}
