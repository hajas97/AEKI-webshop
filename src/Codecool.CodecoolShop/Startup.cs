using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;

using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Codecool.CodecoolShop
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            }); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //DbContextConfiguration
                //services.AddDbContext<AppDbContext>();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Product/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            


            SetupInMemoryDatabases();
        }

        private void SetupInMemoryDatabases()
        {
            IProductDao productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();

            //Supplier amazon = new Supplier{Name = "Amazon", Description = "Digital content and services"};
            //supplierDataStore.Add(amazon);
            //Supplier lenovo = new Supplier{Name = "Lenovo", Description = "Computers"};
            //supplierDataStore.Add(lenovo);
            //ProductCategory tablet = new ProductCategory {Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            //productCategoryDataStore.Add(tablet);
            //productDataStore.Add(new Product { Name = "Amazon Fire", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategory = tablet, Supplier = amazon });
            //productDataStore.Add(new Product { Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategory = tablet, Supplier = lenovo });
            //productDataStore.Add(new Product { Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = tablet, Supplier = amazon });

            // átírni a nevüket
            Supplier malm = new Supplier { Name = "Malm", Description = "Beds, desks and drawers." };
            supplierDataStore.Add(malm);
            Supplier kallax = new Supplier { Name = "Kallax", Description = "Lamps and shelves" };
            supplierDataStore.Add(kallax);
            Supplier dekad = new Supplier { Name = "Dekad", Description = "Alarm clocks" };
            supplierDataStore.Add(dekad);
            Supplier lack = new Supplier { Name = "Lack", Description = "Desks and shelves" };
            supplierDataStore.Add(lack);

            Supplier strandomon = new Supplier { Name = "Strandomon", Description = "Comfort armchair" };
            supplierDataStore.Add(strandomon);
            Supplier nolmyra = new Supplier { Name = "Nolmyra", Description = "Armchairs, cabinets" };
            supplierDataStore.Add(nolmyra);
            Supplier hektar = new Supplier { Name = "Hektar", Description = "Lamp and office chairs" };
            supplierDataStore.Add(hektar);
            Supplier markus = new Supplier { Name = "Markus", Description = "Office chairs" };
            supplierDataStore.Add(markus);


            // Livingroom furnitures
            ProductCategory BLamp = new ProductCategory { Name = "Lamp", Department = "Bedroom", Description = "it is a lamp." };
            productCategoryDataStore.Add(BLamp);
            ProductCategory BBed = new ProductCategory { Name = "Bed", Department = "Bedroom", Description = "it is a bed." };
            productCategoryDataStore.Add(BBed);
            ProductCategory BDrawer = new ProductCategory { Name = "Drawer", Department = "Bedroom", Description = "it is a drawer." };
            productCategoryDataStore.Add(BDrawer); 
            ProductCategory BWardrobe = new ProductCategory { Name = "Wardrobe", Department = "Bedroom", Description = "it is a wardrobe." };
            productCategoryDataStore.Add(BWardrobe);         
            ProductCategory BAlarmClock = new ProductCategory { Name = "Alarm clock", Department = "Bedroom", Description = "it is an alarm clock." };
            productCategoryDataStore.Add(BAlarmClock);
            ProductCategory BBedsidetable = new ProductCategory { Name = "Bedsidetable", Department = "Bedroom", Description = "it is a bedsidetable." };
            productCategoryDataStore.Add(BBedsidetable);

            //Office furnitures
            ProductCategory ODesk = new ProductCategory { Name = "Desk", Department = "Office", Description = "it is a desk." };
            productCategoryDataStore.Add(ODesk);
            ProductCategory OLamp = new ProductCategory { Name = "Lamp", Department = "Office", Description = "it is a lamp." };
            productCategoryDataStore.Add(OLamp);
            ProductCategory OChair = new ProductCategory { Name = "Office chair", Department = "Office", Description = "it is a chair." };
            productCategoryDataStore.Add(OChair);

            //livingroom furnitures
            ProductCategory LDesk = new ProductCategory { Name = "Desk", Department = "Livingroom", Description = "it is a desk." };
            productCategoryDataStore.Add(LDesk);
            ProductCategory LShelf = new ProductCategory { Name = "Shelf", Department = "Livingroom", Description = "it is a shelf." };
            productCategoryDataStore.Add(LShelf);
            ProductCategory LArmChair = new ProductCategory { Name = "Armchair", Department = "Livingroom", Description = "it is an armchair." };
            productCategoryDataStore.Add(LArmChair);
            ProductCategory LCabinet = new ProductCategory { Name = "Cabinet", Department = "Livingroom", Description = "it is an cabinet." };
            productCategoryDataStore.Add(LCabinet);

            // felvenni az új termékeket
            productDataStore.Add(new Product { Name = "Dekad alarm clock", DefaultPrice = 2990, Currency = "Ft", Description = "This little white clock will wake you up every morning.", ProductCategory = BAlarmClock, Supplier = dekad });
            productDataStore.Add(new Product { Name = "Kallax lamp", DefaultPrice = 11990, Currency = "Ft", Description = "This nice Kallax lamp will be lighten up your room.", ProductCategory = BLamp, Supplier = kallax });
            productDataStore.Add(new Product { Name = "Kallax wardrobe", DefaultPrice = 16990, Currency = "Ft", Description = "You can store many clothes in this wardrobe.", ProductCategory = BWardrobe, Supplier = kallax });
            productDataStore.Add(new Product { Name = "Malm bed", DefaultPrice =109900, Currency = "Ft", Description = "This bed has a storage under the matress.", ProductCategory = BBed, Supplier = malm });
            productDataStore.Add(new Product { Name = "Malm bedsidetable", DefaultPrice =10900, Currency = "Ft", Description = "A perfect match for your Malm bed.", ProductCategory = BBedsidetable, Supplier = malm });
            productDataStore.Add(new Product { Name = "Malm drawer", DefaultPrice =24990, Currency = "Ft", Description = "You can store your favourite clothes in it.", ProductCategory = BDrawer, Supplier = malm });
            productDataStore.Add(new Product { Name = "Lack desk", DefaultPrice = 15990, Currency = "Ft", Description = "You can even store your favourite magazines on it.", ProductCategory = LDesk, Supplier = lack });
            productDataStore.Add(new Product { Name = "Lack shelf", DefaultPrice = 5990, Currency = "Ft", Description = "A floating shelf, perfect match for your Lack desk.", ProductCategory = LShelf, Supplier = lack });
            productDataStore.Add(new Product { Name = "Nolmyra armchair", DefaultPrice = 12990, Currency = "Ft", Description = "A lightweight armchair for your flat.", ProductCategory = LArmChair, Supplier = nolmyra });
            productDataStore.Add(new Product { Name = "Nolmyra cabinet", DefaultPrice = 24990, Currency = "Ft", Description = "Nice looking cabinet into your livingroom.", ProductCategory = LCabinet, Supplier = nolmyra });
            productDataStore.Add(new Product { Name = "Strandomon armchair", DefaultPrice = 59990, Currency = "Ft", Description = "A yellow, comfortable armchair to your livingroom.", ProductCategory = LArmChair, Supplier = strandomon });
            productDataStore.Add(new Product { Name = "Hektar lamp", DefaultPrice = 12990, Currency = "Ft", Description = "Low-energy lamp with bright light.", ProductCategory = OLamp, Supplier = hektar });
            productDataStore.Add(new Product { Name = "Kallax desk", DefaultPrice = 39990, Currency = "Ft", Description = "A nice looking desk with shelves.", ProductCategory = ODesk, Supplier = kallax });
            productDataStore.Add(new Product { Name = "Markus office chair", DefaultPrice = 29990, Currency = "Ft", Description = "Our most popular office chair.", ProductCategory = OChair, Supplier = markus });
            productDataStore.Add(new Product { Name = "Hektar office chair", DefaultPrice = 39990, Currency = "Ft", Description = "Comfortable officehair to your home.", ProductCategory = OChair, Supplier = hektar });
            productDataStore.Add(new Product { Name = "Malm desk", DefaultPrice = 22990, Currency = "Ft", Description = "A big office desk, which can boost your productivity.", ProductCategory = ODesk, Supplier = malm });



        }
    }
}
