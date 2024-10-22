// createbuilder applicerar defaults. ser till att app tittar p� appsettings.json o laddar settings d�rifr�n.
// T.ex logsettings. Ser ocks� till att kestrel anv�nds och iis integration.
using BethanysPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

// egna services:
// med repos, anv�nds oftast AddScoped. Skapar en singleton instance per request.
// l�gger till dem i DI container.
builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IPieRepository, MockPieRepository>();


// inkludera nedanst�ende. tar in framework services som m�jligg�r mvc-services.
builder.Services.AddControllersWithViews();

// v�ran app �r redo, kan ta in middleware efter nedanst�ende line.
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
// ser till att vi kan se v�ra sidor.
app.MapDefaultControllerRoute();

app.Run();
