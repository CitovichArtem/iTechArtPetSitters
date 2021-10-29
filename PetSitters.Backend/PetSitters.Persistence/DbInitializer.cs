namespace PetSitters.Persistence
{
    public class DbInitializer
    {
        public static void Initializer(PetSittersDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
