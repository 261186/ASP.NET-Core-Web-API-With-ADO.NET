using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//Bu kod, ASP.NET Core projesinde JSON serile�tirmesinin yap�land�r�lmas� i�in kullan�l�r. 
//    AddControllersWithViews metodu, uygulaman�n kontrol�rlerini ve g�r�n�mlerini eklerken,
//    AddNewtonsoftJson metodu ise JSON serile�tirmesi i�in Newtonsoft.Json k�t�phanesini yap�land�r�r.
//     sat�r�yla, Newtonsoft.Json serile�tirme ayarlar�na eri�ilir ve bu ayarlarla birlikte 
//     JSON nesnelerinin serile�tirilmesi i�in varsay�lan davran��� de�i�tirebiliriz.
//     Burada DefaultContractResolver, serile�tirme i�lemi s�ras�nda JSON nesnelerinin t�m 
//     �zelliklerini dikkate alarak do�rudan serile�tirme yap�lmas�n� sa�lar. Bu ayar, �zellik 
//     isimlerinin PascalCase olmas�n� ve ba�ka �zel ayarlar�n�z� belirtmek i�in kullan�labilir.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
