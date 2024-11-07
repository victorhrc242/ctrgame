using apictrgamer;
using ctrgamer._01_service;
using ctrgamer._01_service.Interfaces;
using ctrgamer._02_Repositorio;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades.DTO.Compra;
using ctrgamer._04_Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(mappingprofile));
//usuario
builder.Services.AddScoped<IUsuariorepositor, UsuarioRepositor>();
builder.Services.AddScoped<IUsuarioservice, UsuarioService>();
//revendedor
builder.Services.AddScoped<IRevendedorRepositor, revendedorrepositor>();
builder.Services.AddScoped<IReevendedoservice, reevedendorservice_>();
//avaliacao
builder.Services.AddScoped<IAvaliacaoReposytor, AvaliacaRepositor>();
builder.Services.AddScoped<IAvaliacaoservice, avaliacaosservice>();
//carrinho
builder.Services.AddScoped<ICarrinhorepositor, carrinhoRepositorioi>();
builder.Services.AddScoped<ICarrinhoservice, carrinhoService>();
//categoria
builder.Services.AddScoped<ICategoriaReposytor, categoriarepositor>();
builder.Services.AddScoped<Icategoriasservice, categoriaservice>();

//jogo
builder.Services.AddScoped<IJogosReposytor, Jogorepositorio>();
builder.Services.AddScoped<IJogoservice, jogosservice>();
//jogocategoria
builder.Services.AddScoped<IJogocategoriaRepositor, jogocategoriarepositor>();
builder.Services.AddScoped<IJogocategoriaservice, jogocategoriaservice>();
//venda
builder.Services.AddScoped<IVendarepositor, VendaReposytor>();
builder.Services.AddScoped<IVendaservice, Vendasrevice>();
var app = builder.Build();
InicializadorBd.Inicializador();
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
