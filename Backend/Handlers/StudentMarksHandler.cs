using Backend.Interfaces;

namespace Backend.Handlers
{
    public class StudentMarksHandler : StudentHandler
    {
        public StudentMarksHandler(IStudent student) : base(student)
        {   }

        public void Add(string course, double mark) => _student.Marks.Add(course, mark);

        public void Update(string course, double mark) => _student.Marks.Update(course, mark);

        public void Delete(string course) => _student.Marks.Delete(course);

        public double Min => _student.Marks.Min;

        public double Max => _student.Marks.Max;
    }
}
