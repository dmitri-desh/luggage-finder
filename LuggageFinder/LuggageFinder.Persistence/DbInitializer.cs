namespace LuggageFinder.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(LuggageFinderDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
