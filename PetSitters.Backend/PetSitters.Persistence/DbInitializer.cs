namespace PetSitters.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ServicesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
