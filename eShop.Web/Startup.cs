using eShop.CoreBusiness.Services;
//using eShop.DataStore.HardCoded;
using eShop.DataStore.SQL.Dapper;
//using eShop.DataStore.SQL.EF;
using eShop.StateStore.LocalStorage;
using eShop.UseCases.AddProductUseCase;
using eShop.UseCases.AuthorScreen;
using eShop.UseCases.BrandsScreen;
using eShop.UseCases.CategoriesScreen;
using eShop.UseCases.EditProductScreen;
using eShop.UseCases.OrderConfirmationScreen;
using eShop.UseCases.OutstandingOrderScreen;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.UseCases.ProcessedOrderScreen;
using eShop.UseCases.ProcessOrderScreen;
using eShop.UseCases.SearchProductScreen;
using eShop.UseCases.ShoppingCartScreen;
using eShop.UseCases.TransactionsOrderScreen;
using eShop.UseCases.ViewOrdersByCustomerScreen;
using eShop.UseCases.ViewProductScreen;
using eShop.Web.Common.JsInterOp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eShop.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuration.GetConnectionString

            services.AddControllers();
            //services.AddAuthentication("eShop.CookieAuth").AddCookie("eShop.CookieAuth", config =>
            //{
            //    config.Cookie.Name = "eShop.CookieAuth";
            //    config.LoginPath = "/login";
            //});
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
                options.AddPolicy("UserOnly", p => p.RequireClaim("Position", "User"));
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddTransient<JsNavigator>();

            //EF
            //services.AddDbContext<eShopContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //});

            //Dapper
            services.AddTransient<IDataAccess>(sp => new DataAccess(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();

            services.AddScoped<IShoppingCartStateStore, ShoppingCartStateStore>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IShoppingCart, ShoppingCart.LocalStorage.ShoppingCart>();

            services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
            services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
            services.AddTransient<IAddProductUseCase, AddProductUseCase>();
            services.AddTransient<IEditProductUseCase, EditProductUseCase>();
            services.AddTransient<UseCases.DeleteProductUseCase.IDeleteProductUseCase, UseCases.DeleteProductUseCase.DeleteProductUseCase>();
            
            services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
            services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();
            services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
            services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();

            services.AddTransient<IViewOutstandingOrderUseCase, ViewOutstandingOrderUseCase>();
            services.AddTransient<IViewProcessedOrdersUseCase, ViewProcessedOrdersUseCase>();
            services.AddTransient<IViewOrderDetailUseCase, ViewOrderDetailUseCase>();
            services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();
            services.AddTransient<IGetOrdersUseCase, GetOrdersUseCase>();
            services.AddTransient<IViewOrdersUseCase, ViewOrdersUseCase>();
            services.AddTransient<IViewOrdersByCustomerUseCase, ViewOrdersByCustomerUseCase>();

            services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
            services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
            services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
            services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
            services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();

            services.AddTransient<IViewBrandsUseCase, ViewBrandsUseCase>();
            services.AddTransient<IAddBrandUseCase, AddBrandUseCase>();
            services.AddTransient<IDeleteBrandUseCase, DeleteBrandUseCase>();
            services.AddTransient<IGetBrandByIdUseCase, GetBrandByIdUseCase>();
            services.AddTransient<IEditBrandUseCase, EditBrandUseCase>();

            services.AddTransient<IViewAuthorsUseCase, ViewAuthorsUseCase>();
            services.AddTransient<IAddAuthorUseCase, AddAuthorUseCase>();
            services.AddTransient<IDeleteAuthorUseCase, DeleteAuthorUseCase>();
            services.AddTransient<IGetAuthorByIdUseCase, GetAuthorByIdUseCase>();
            services.AddTransient<IEditAuthorUseCase, EditAuthorUseCase>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
