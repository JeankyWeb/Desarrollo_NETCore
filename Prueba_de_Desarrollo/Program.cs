using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Text;
using test.application;
using test.domain;
using test.infraestructure;
using YourNamespace;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de JWT
var key = Encoding.ASCII.GetBytes("Una_clave_secreta_muy_segura_y_larga_de_al_menos_32_caracteres");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Configurar DbContext
builder.Services.AddDbContext<YourDbContext>(options => // Cambia aqu�
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios y repositorios
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, SqlTransactionRepository>(); // O MongoTransactionRepository seg�n lo que necesites

// Configuraci�n de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Aseg�rate de incluir esto
app.UseAuthorization();

app.MapControllers();

app.Run();
