using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//Bu kod, ASP.NET Core projesinde JSON serileştirmesinin yapılandırılması için kullanılır. 
//    AddControllersWithViews metodu, uygulamanın kontrolörlerini ve görünümlerini eklerken,
//    AddNewtonsoftJson metodu ise JSON serileştirmesi için Newtonsoft.Json kütüphanesini yapılandırır.
//     satırıyla, Newtonsoft.Json serileştirme ayarlarına erişilir ve bu ayarlarla birlikte 
//     JSON nesnelerinin serileştirilmesi için varsayılan davranışı değiştirebiliriz.
//     Burada DefaultContractResolver, serileştirme işlemi sırasında JSON nesnelerinin tüm 
//     özelliklerini dikkate alarak doğrudan serileştirme yapılmasını sağlar. Bu ayar, özellik 
//     isimlerinin PascalCase olmasını ve başka özel ayarlarınızı belirtmek için kullanılabilir.
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
