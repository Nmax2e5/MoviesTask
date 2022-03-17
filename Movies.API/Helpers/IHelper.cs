namespace Movies.API.Helpers
{
    public interface IHelper
    {
        T? ReadFile<T>(string filePath);
    }
}
