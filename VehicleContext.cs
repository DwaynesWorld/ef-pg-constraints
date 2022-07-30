public class VehicleContext : DbContext
{
    public VehicleContext()
    {
        Cars = Set<Car>();
    }

    public DbSet<Car> Cars { get; set; }

    public async Task SeedAsync(int count)
    {
        var fixture = new Fixture();
        var random = new Random();

        var cars = fixture
            .Build<Car>()
            .With(x => x.Id, 0)
            .With(x => x.Year, random.Next(1904, 2024))
            .CreateMany(count);

        await AddRangeAsync(cars);
        await SaveChangesAsync();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(@$"
                Host=localhost;
                Database={Environment.GetEnvironmentVariable("POSTGRES_DB")!};
                Username={Environment.GetEnvironmentVariable("POSTGRES_USER")!};
                Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")!}")
            .UseSnakeCaseNamingConvention();
    }
}