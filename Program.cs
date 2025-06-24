using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using Store.API.MiddleWares;
using Store.Data.Context;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using Store.Services.Mapping;
using Store.Services.Services.AddressService;
using Store.Services.Services.BasketService;
using Store.Services.Services.CachService;
using Store.Services.Services.CategoryService;
using Store.Services.Services.CouponeService;
using Store.Services.Services.CouponUserService;
using Store.Services.Services.CouponUserUserService;
using Store.Services.Services.DashBoradService;
using Store.Services.Services.DeliveryService;
using Store.Services.Services.HelpQustionsService;
using Store.Services.Services.IChatService;
using Store.Services.Services.IContactUsService;
using Store.Services.Services.InstaShopDashboard;
using Store.Services.Services.NotificationService;
using Store.Services.Services.NotificationUserService;
using Store.Services.Services.OfferService;
using Store.Services.Services.OrderItemService;
using Store.Services.Services.OrderService;
using Store.Services.Services.OrderStatusService;
using Store.Services.Services.PaymentCardervice;
using Store.Services.Services.PaymentCardService;
using Store.Services.Services.ProductService;
using Store.Services.Services.RateService;
using Store.Services.Services.SearchHistoryService;
using Store.Services.Services.StoreService;
using Store.Services.Services.StoreTypeService;
using Store.Services.Services.TransactionService;
using Store.Services.Services.WalletService;
using Store.Services.TokenService;
using Store.Services.UserService;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<storeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<storeDbContext>().AddDefaultTokenProviders();
builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
{
    var configurations = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));
    return ConnectionMultiplexer.Connect(configurations);  
});

#region RegisterServices
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IStoreTypeRepository, StoreTypeRepository>();
builder.Services.AddScoped<IRateRepository, RateRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddScoped<ICouponUserRepository, CouponUserRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationUserRepository, NotificationUserRepository>();
builder.Services.AddScoped<IhelpQuestionsRepository, helpQuestionsRepository>();
builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<ISearchHistoryRepository, SearchHistoryRepository>();
builder.Services.AddScoped<IPaymentCardRepository, PaymentCardRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStoreTypeService, StoreTypeService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDliveryService, DliveryService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<ICouponUserService, CouponUserService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<INotificationUserService, NotificationUserService>();
builder.Services.AddScoped<IHelpService, HelpService>();
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IRateService, RateService>();
builder.Services.AddScoped<IContactUsService, ContactUsService>();
builder.Services.AddScoped<IDashBoardService, DashBoardService>();
builder.Services.AddScoped<IOrdeStatusService, OrdeStatusService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<ISearchHistoryService, SearchHistoryService>();
builder.Services.AddScoped<IInstaDashboardService, InstaDashboardService>();
builder.Services.AddScoped<IPaymentCardService, PaymentCardService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<SignInManager<AppUser>>();
builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddSignalR();
#endregion


//Add Token Scheme
#region Token Service
builder.Services.AddAuthentication(options =>
{
options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
options.TokenValidationParameters = new TokenValidationParameters
{
ValidateIssuer = true,
ValidateAudience = true,
ValidateLifetime = true,
ValidateIssuerSigningKey = true,
ValidIssuer = jwtSettings["Issuer"],
ValidAudience = jwtSettings["Audience"],
IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
};
}); 
#endregion


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("StoreOwnerOnly", policy => policy.RequireRole("StoreOwner"));
    options.AddPolicy("CustomerOnly", policy => policy.RequireRole("Customer"));
    options.AddPolicy("DeliveryDriverOnly", policy => policy.RequireRole("DeliveryDriver"));
    options.AddPolicy("SupporterOnly", policy => policy.RequireRole("Supporter"));
    options.AddPolicy("GuestOnly", policy => policy.RequireRole("Guest"));
});


//builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Swagger Customizations
#region Swagger doc
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Store_API", Version = "v1" });
    var securetyScheme = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \nEnter 'Bearer' [space] and then your token in the text input below.\nExample: \"Bearer abc123\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securetyScheme);
    var securityRequairments = new OpenApiSecurityRequirement
{
        {securetyScheme, new[] { "Bearer" } }
};
    c.AddSecurityRequirement(securityRequairments);

});
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExcptionMiddlewares>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await SeedRolesAsync(serviceProvider);
}



app.Run();

async Task SeedRolesAsync(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "StoreOwner", "Customer", "DeliveryDriver", "Supporter", "Guest" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}