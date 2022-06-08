using Backend.Interfaces;

namespace Backend.Handlers
{
    public class StudentStatsHandler : StudentHandler
    {
        public StudentStatsHandler(IStudent student) : base(student)
        { }

        public double MinMark => _student.Marks.Values.Min();

        public double MaxMark => _student.Marks.Values.Max();

        public double AvgMark => _student.Marks.Values.Average();
    }
}
