using Backend.Interfaces;

namespace Backend.Containers
{
    public class MarksContainer : IMarksContainer
    {
        private readonly Dictionary<string, double> _marks;

        public double Min { get; set; } = 0;

        public double Max { get; set; } = 100;

        public MarksContainer() => _marks = new Dictionary<string, double>();

        public MarksContainer(Dictionary<string, double> marks)
        {
            _marks = marks ?? throw new ArgumentNullException(nameof(marks));
        }

        public IReadOnlyDictionary<string, double> Marks => _marks;

        private bool IsValid(double mark) => mark >= Min && mark <= Max;

        public void Add(string course, double mark)
        {
            if (!IsValid(mark))
                throw new ArgumentOutOfRangeException(nameof(mark), $"The mark should be in range from {Min} to {Max}");
            _marks.Add(course, mark);
        }

        public void Update(string course, double mark)
        {
            if (!IsValid(mark))
                throw new ArgumentOutOfRangeException(nameof(mark), $"The mark should be in range from {Min} to {Max}");
            _marks[course] = mark;
        }

        public void Delete(string course)
        {
            _marks.Remove(course);
        }
    }
}
