using Backend.Handlers;
using Backend.Interfaces;
using Backend.Other;

namespace Backend
{
    public class EducationalInstitution
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<IStudent> Students { get; set; } = new List<IStudent>();

        public IEnumerable<IStudent> GetOrderedStudents(StudentOrderingType orderBy, StudentOrderingType? thenBy)
        {
            static Func<IStudent, object> GetSelectorFromType(StudentOrderingType type)
            {
                var typeNumber = Math.Abs((short)type);
                return typeNumber switch
                {
                    2 => s => new StudentStatsHandler(s).AvgMark,
                    _ => s => s.Course,
                };
            }

            Func<Func<IStudent, object>, IOrderedEnumerable<IStudent>> orderByFunc 
                = orderBy < 0 ? Students.OrderByDescending : Students.OrderBy;
            var result = orderByFunc.Invoke(GetSelectorFromType(orderBy));
            if (thenBy != null)
            {
                orderByFunc = thenBy < 0 ? result.ThenByDescending : result.ThenBy;
                result = orderByFunc.Invoke(GetSelectorFromType(orderBy));
            }
            return result;
        }
    }
}
