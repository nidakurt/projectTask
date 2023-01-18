using Microsoft.EntityFrameworkCore;
using ProjectTask.Data.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b=>b.MigrationsAssembly("ProjectTask.WebAPI"));
});
//builder.Services.AddCors(options => options.AddPolicy(name: "ProjectTaskOrigins",
//    policy=>
//    {
//        policy.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader();
//    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


app.UseAuthorization();

app.MapControllers();

app.Run();
