public class Car
{
    public int Id { get; set; }
    public string Make { get; set; } = default!;
    public string Model { get; set; } = default!;
    public int Year { get; set; }
    public Body Body { get; set; }
    public Size Size { get; set; }

    public override string ToString()
    {
        var options = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };
        return JsonSerializer.Serialize(this, options);
    }
}

public enum Body
{
    Unknown,
    Coupe,
    Sedan,
    Wagon,
    SUV,
    Truck,
    Van,
    Semi // Added after initial migration
}

public enum Size
{
    Unknown,
    Compact,
    MidSize,
    // FullSize, Removed after second migration
}


public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Make).IsRequired();
        builder.Property(x => x.Model).IsRequired();
        builder.Property(x => x.Body).HasConversion<string>();
        builder.Property(x => x.Size).HasConversion<string>();

        builder.HasCheckConstraint("ck_cars_body", $"body in({GetEnumValues<Body>()})");
        builder.HasCheckConstraint("ck_cars_size", $"\"size\" in({GetEnumValues<Size>()})");
    }

    public static string GetEnumValues<T>() where T : struct, Enum
    {
        return string.Join(", ", Enum.GetNames<T>().Select(x => $"'{x}'"));
    }
}