namespace Backend.Interfaces
{
    public interface IMarksContainer
    {
        public double Min { get; set; }

        public double Max { get; set; }

        public IReadOnlyDictionary<string, double> Marks { get; }

        void AddMark(string course, double mark);

        void UpdateMark(string course, double mark);

        void DeleteMark(string course);
    }
}
