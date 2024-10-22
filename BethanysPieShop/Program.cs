// createbuilder applicerar defaults. ser till att app tittar på appsettings.json o laddar settings därifrån.
// T.ex logsettings. Ser också till att kestrel används och iis integration.
using BethanysPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

// egna services:
// med repos, används oftast AddScoped. Skapar en singleton instance per request.
// lägger till dem i DI container.
builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IPieRepository, MockPieRepository>();


// inkludera nedanstående. tar in framework services som möjliggör mvc-services.
builder.Services.AddControllersWithViews();

// våran app är redo, kan ta in middleware efter nedanstående line.
var app = builder.Build();

// MIDDLEWARE PIPELINE: 
// kollar efter statiska filer i www.root. Shortcircuitar requesten.
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    // visar developer exceptionpage. 
    app.UseDeveloperExceptionPage();
}

// endpoint middleware
// ser till att vi kan se våra sidor.
app.MapDefaultControllerRoute();

app.Run();
