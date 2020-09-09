using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspNetCoreMvcSqlSvr.Data;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcSqlSvr
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // ���̃��\�b�h�̓����^�C���ɂ���ČĂяo����܂��B���̃��\�b�h���g�p���ăR���e�i�ɃT�[�r�X��ǉ����܂��B
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddRazorPages();
            services.AddDbContext<MvcShohinContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MvcShohinContext")));

        }

        // ���̃��\�b�h�̓����^�C���ɂ���ČĂяo����܂��B���̃��\�b�h���g�p����HTTP���N�G�X�g�p�C�v���C����ݒ肵�܂��B
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // �f�t�H���g��HSTS�l��30���ł��B�^�p�V�i���I�ł����ύX���邱�Ƃ��ł��܂��B https://aka.ms/aspnetcore-hsts ���Q�Ƃ��Ă��������B
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}