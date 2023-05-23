using aspnet02_boardapp.Data;
using Microsoft.EntityFrameworkCore;

namespace aspnet02_boardapp
{
    public class Program
    {
        // ASP.Net ������ ���� ���� �ʱ�ȭ
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Data���� ���� ApplicationDBContext�� ����ϰڴٴ� ���� �߰�
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
                // appsettings.json ConnectionStrings���� ���� ���ڿ� �Ҵ�
                builder.Configuration.GetConnectionString("DefaultConnection"),
                // ���� ���ڿ��� DB�� ���� ������ �ڵ����� �������� ���� �ǹ���
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
                ));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}