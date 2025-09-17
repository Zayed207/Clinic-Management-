var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(BusinessLayer.Profiles.EmployeeProfile));
builder.Services.AddAutoMapper(typeof(BusinessLayer.Profiles.PersonProfile));
builder.Services.AddAutoMapper(typeof(BusinessLayer.Profiles.MedicalRecordProfile));
builder.Services.AddAutoMapper(typeof(BusinessLayer.Profiles.ClincProfile));
builder.Services.AddAutoMapper(typeof(BusinessLayer.Profiles.DoctorProfile));
builder.Services.AddAutoMapper(typeof(BusinessLayer.Profiles.PatientProfile));
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
