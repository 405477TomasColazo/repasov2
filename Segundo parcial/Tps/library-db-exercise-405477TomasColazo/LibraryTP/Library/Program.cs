using Library.Context;
using Library.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependencia repositories
builder.Services.AddScoped<IGeneroRepository,GeneroRepository>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

//PostgreSQL
builder.Services.AddDbContext<LibraryDBContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase")));

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<LibraryDBContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase")));
//SQL server

//builder.Services.AddDbContext<LibraryDBContext>((context) =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("ConexionSql");
//    context.UseSqlServer(connectionString);
//});

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirTodo");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
