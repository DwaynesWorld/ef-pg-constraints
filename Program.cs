DotNetEnv.Env.TraversePath().Load();
await using var context = new VehicleContext();
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();
await context.SeedAsync(100);

var nextId = new Random().Next(1, 101);
var car = (await context.Cars.FindAsync(nextId))!;
Console.WriteLine(car.ToString());

