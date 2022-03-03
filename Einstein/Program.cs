using Microsoft.EntityFrameworkCore;
using Einstein.Interfaces;
using Einstein.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IAppointmentsServices, AppointmentsServices>();
builder.Services.AddTransient<IMedicalsServices, MedicalsServices>();
builder.Services.AddTransient<IPatientsServices, PatientsServices>();

builder.Services.AddDbContext<Einstein.Data.EinsteinContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("dbDefault"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();