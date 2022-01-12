using Business_Logic_Layer.Services;
using Business_Logic_Layer.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddTransient<IRequestLogService, RequestLogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.RegisterMiddlewares();

app.UseAuthorization();

app.MapControllers();

app.Run();