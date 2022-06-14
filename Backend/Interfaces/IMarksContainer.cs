namespace Backend.Interfaces
{
    public interface IMarksContainer
    {
        double Min { get; set; }

        double Max { get; set; }

        IReadOnlyDictionary<string, double> Marks { get; }

        void Add(string course, double mark);

        void Update(string course, double mark);

        void Delete(string course);
    }
}
