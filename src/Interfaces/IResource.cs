namespace Trestlebridge.Interfaces
{
    public interface IResource<T>
    {
        string Type { get; }
        double Process (T equipment);
    }
}