namespace Backend.Interfaces
{
    public interface IMarksContainer
    {
        public double Min { get; set; }

        public double Max { get; set; }

        public IReadOnlyDictionary<string, double> Marks { get; }

        void Add(string course, double mark);

        void Update(string course, double mark);

        void Delete(string course);
    }
}
