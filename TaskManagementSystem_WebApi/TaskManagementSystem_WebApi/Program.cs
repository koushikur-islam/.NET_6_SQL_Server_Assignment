using Business_Logic_Layer.Services;
using Business_Logic_Layer.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Registering Auto Mapper services.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Dependecy injection registrations.
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddTransient<IRequestLogService, RequestLogService>();
builder.Services.AddTransient<IExceptionLogService, ExceptionLogService>();
builder.Services.AddScoped<ITaskAssignmentService, TaskAssignmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

//Registering all the middlewares.
app.RegisterMiddlewares();

//Global exception handling to a specific route that logs the exception details for the route to database.
app.UseExceptionHandler("/error");

app.UseAuthorization();

app.MapControllers();

app.Run();