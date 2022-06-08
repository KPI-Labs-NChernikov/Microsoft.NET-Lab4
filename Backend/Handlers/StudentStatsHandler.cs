using Backend.Interfaces;

namespace Backend.Handlers
{
    public class StudentStatsHandler : StudentHandler
    {
        public StudentStatsHandler(IStudent student) : base(student)
        { }

        public double MinMark
        {
            get
            {
                double result;
                try
                {
                    result = _student.Marks.Marks.Values.Min();
                }
                catch (InvalidOperationException)
                {
                    result = 0;
                }
                return result;
            }
        }

        public double MaxMark
        {
            get
            {
                double result;
                try
                {
                    result = _student.Marks.Marks.Values.Max();
                }
                catch (InvalidOperationException)
                {
                    result = 0;
                }
                return result;
            }
        }

        public double AvgMark
        {
            get
            {
                double result;
                try
                {
                    result = _student.Marks.Marks.Values.Average();
                }
                catch (InvalidOperationException)
                {
                    result = 0;
                }
                return result;
            }
        } 
    }
}
