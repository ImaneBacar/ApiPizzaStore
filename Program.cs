using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PizzaStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Charger la chaîne de connexion à partir de appsettings.json
var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "DataSource=Pizzas.db";

// Ajouter le DbContext avec la chaîne de connexion
builder.Services.AddDbContext<PizzaDb>(options =>
    options.UseSqlite(connectionString)
);

// Ajouter l'exploration des points de terminaison API (Swagger)
builder.Services.AddEndpointsApiExplorer();

// Ajouter Swagger pour documenter l'API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PizzaStore API",
        Description = "Faire les pizzas que vous aimez",
        Version = "v1"
    });
});

var app = builder.Build();

// Créer la base de données si elle n'existe pas déjà
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaDb>();
    db.Database.EnsureCreated();  // Crée la base de données si elle n'existe pas
}

// Configurer Swagger pour visualiser l'API
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});

// Définir les routes de l'API
app.MapGet("/", () => "Bonjour Sénégal!");
app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());
app.MapPost("/pizza", async (PizzaDb db, Pizza pizza) =>
{
    await db.Pizzas.AddAsync(pizza);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{pizza.IdEhod}", pizza);
});
app.MapGet("/pizza/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));
app.MapPut("/pizza/{id}", async (PizzaDb db, Pizza updatepizza, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();
    pizza.NomEhod = updatepizza.NomEhod;
    pizza.DescriptionEhod = updatepizza.DescriptionEhod;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/pizza/{id}", async (PizzaDb db, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null)
    {
        return Results.NotFound();
    }
    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Results.Ok();
});

// Démarrer l'application
app.Run();
