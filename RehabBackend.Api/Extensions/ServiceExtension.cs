using RehabBackend.Core.Entities;
using RehabBackend.Services.Interfaces;
using RehabBackend.Services.Repositories;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<Client>), typeof(ClientRepository));
        services.AddScoped(typeof(IRepository<Patient>), typeof(PatientRepository));
        services.AddScoped(typeof(IRepository<Exercise>), typeof(ExerciseRepository));
        services.AddScoped(typeof(IRepository<Plan>), typeof(PlanRepository));

        // Add other services, like DbContext or other dependencies
        // services.AddDbContext<YourDbContext>(options => ...);
    }
}