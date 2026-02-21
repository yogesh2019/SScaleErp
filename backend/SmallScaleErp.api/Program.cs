using Microsoft.EntityFrameworkCore;
using SmallScaleErp.api.Data;
using SmallScaleErp.api.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(
                "https://sscaleerp.onrender.com",   // production frontend
                "https://scaling-bassoon-pp6jjgrg9j736vvq.github.dev" // codespaces dev
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
#region  SeedData
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!context.InventoryItems.Any())
    {
        context.InventoryItems.AddRange(
    new InventoryItem { ProductCode = "P-1001", ProductName = "Steel Rod 10mm", Category = "Raw Material", StockQty = 500, Warehouse = "WH-A" },
    new InventoryItem { ProductCode = "P-1002", ProductName = "Aluminium Sheet", Category = "Raw Material", StockQty = 150, Warehouse = "WH-B" },
    new InventoryItem { ProductCode = "P-1003", ProductName = "Copper Wire Roll", Category = "Raw Material", StockQty = 300, Warehouse = "WH-A" },
    new InventoryItem { ProductCode = "P-1004", ProductName = "Finished Frame", Category = "Finished Goods", StockQty = 75, Warehouse = "WH-C" },
    new InventoryItem { ProductCode = "P-1005", ProductName = "Industrial Bolt Set", Category = "Components", StockQty = 1200, Warehouse = "WH-D" },
    new InventoryItem { ProductCode = "P-1006", ProductName = "Gear Assembly", Category = "Components", StockQty = 60, Warehouse = "WH-C" },
    new InventoryItem { ProductCode = "P-1007", ProductName = "Packaging Box Large", Category = "Packaging", StockQty = 900, Warehouse = "WH-B" },
    new InventoryItem { ProductCode = "P-1008", ProductName = "Hydraulic Pump", Category = "Machinery", StockQty = 15, Warehouse = "WH-E" },
    new InventoryItem { ProductCode = "P-1009", ProductName = "Control Panel Board", Category = "Electronics", StockQty = 40, Warehouse = "WH-E" },
    new InventoryItem { ProductCode = "P-1010", ProductName = "Lubricant Oil Drum", Category = "Consumables", StockQty = 110, Warehouse = "WH-D" }
);
        context.SaveChanges();
    }
}
#endregion
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
