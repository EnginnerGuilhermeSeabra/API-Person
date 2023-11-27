using Person.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services
  .AddCustomMvc()
  .AddValidators()
  .AddRepositories()
  .AddApplicationServices()  ;
  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app
  .UseCors("CorsPolicy")
  .UseRouting()
  .UseAuthorization()
  .UseEndpoints(endpoints => endpoints.MapControllers())
  .UseHttpsRedirection()
  .UseAuthentication();


app.Run();
