using Microsoft.EntityFrameworkCore;
using WEB_API_2.Models;
using WEB_API_2.Services;



var builder = WebApplication.CreateBuilder(args);

// Configura la cadena de conexi�n para MySQL
string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");

// Agrega servicios a la colecci�n de servicios.
builder.Services.AddControllers();

// Configura el DbContext para MySQL
builder.Services.AddDbContext<ev2Context>(options =>
{
    options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));
});

// Agregar servicios de documentaci�n Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Mi API", Version = "v1" });
});

// Registra tus servicios personalizados
builder.Services.AddDbContext<ev2Context>();
builder.Services.AddScoped<CategoriaService>();



var app = builder.Build();

// Configure el HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Habilita Swagger en modo de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
    });
}
else
{
    // Configura el manejo de errores personalizado u otros middlewares de producci�n
    // app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();

// Agregar la llamada app.UseRouting() antes de app.UseAuthorization() y app.MapControllers()
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
