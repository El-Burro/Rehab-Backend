using RehabBackend.Services.Interfaces;

public static class RepositoryExtensions
{
    public static async Task<IEnumerable<T>> GetAllByIds<T>(this IRepository<T> repository, List<int>? ids) where T : class
    {
        if (ids == null || !ids.Any())
        {
            return new List<T>();
        }

        throw new NotImplementedException("GetAllByIds is not implemented for this repository.");
    }
}
