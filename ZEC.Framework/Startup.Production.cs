using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.WebEncoders;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Compression;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using WebMarkupMin.AspNet.Brotli;
using WebMarkupMin.AspNet.Common.Compressors;
using WebMarkupMin.AspNetCore5;
using WebMarkupMin.Core;
using WebMarkupMin.NUglify;
using ZEC.Core.Data;
using ZEC.Framework.Authentication;
using ZEC.Framework.Localization;

namespace ZEC.Framework
{
    public class StartupProduction
    {
        public StartupProduction(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Database

            services.AddDbContext<ApplicationDbContext>(options =>
                      options.UseSqlServer(
                          Configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region Identity

            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.SignIn.RequireConfirmedEmail = true;
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

            #endregion

            #region Cookies and Validators

            services.Configure<SecurityStampValidatorOptions>(options =>
                   options.ValidationInterval = TimeSpan.FromMinutes(15)
            );

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.MaxAge = TimeSpan.FromDays(3);
                options.ExpireTimeSpan = TimeSpan.FromDays(3);
                options.LoginPath = new PathString("/Account");
                options.AccessDeniedPath = new PathString("/AccessDenied");
                options.LogoutPath = new PathString("/Account/Logout");
                options.SlidingExpiration = true;
                options.Cookie.SameSite = SameSiteMode.Lax;
            });

            services.Configure<DataProtectionTokenProviderOptions>(o =>
                   o.TokenLifespan = TimeSpan.FromMinutes(15));

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            #endregion

            #region Caching and Antiforgery

            services.AddResponseCaching(options =>
            {
                options.UseCaseSensitivePaths = false;
            });

            services.AddMemoryCache();

            services.AddAntiforgery(o =>
            {
                o.HeaderName = "XSRF-ZEC-TOKEN-HEADER";
                o.Cookie.Name = "XSRF-ZEC-TOKEN";
                o.FormFieldName = "XSRF-ZEC-TOKEN-FORM";
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
                o.Cookie.SameSite = SameSiteMode.Strict;
            });

            #endregion

            #region AutoMapper

            services.AddAutoMapper(typeof(Startup));

            #endregion

            #region Markup Minification

            services.AddWebMarkupMin(options =>
            {
                options.AllowCompressionInDevelopmentEnvironment = false;
                options.AllowMinificationInDevelopmentEnvironment = false;
                options.DefaultEncoding = Encoding.UTF8;
                options.DisablePoweredByHttpHeaders = true;
            }).AddHtmlMinification(options =>
            {

                HtmlMinificationSettings settings = options.MinificationSettings;
                settings.RemoveRedundantAttributes = true;
                settings.RemoveHttpProtocolFromAttributes = true;
                settings.RemoveHttpsProtocolFromAttributes = true;

                options.CssMinifierFactory = new NUglifyCssMinifierFactory();
                options.JsMinifierFactory = new NUglifyJsMinifierFactory();
            })
              .AddHttpCompression(options =>
              {
                  options.CompressorFactories = new List<ICompressorFactory>
                  {
                    new BrotliCompressorFactory(new BrotliCompressionSettings
                    {
                        Level = 4
                    }),
                    new DeflateCompressorFactory(new DeflateCompressionSettings
                    {
                        Level = CompressionLevel.Fastest
                    }),
                    new GZipCompressorFactory(new GZipCompressionSettings
                    {
                        Level = CompressionLevel.Fastest
                    })
                  };
              });

            #endregion

            #region Razor & Blazor config

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddControllersWithViews(options =>
            {
                options.CacheProfiles.Add("Caching", new CacheProfile()
                {
                    Duration = 120,
                    Location = ResponseCacheLocation.Any,
                    VaryByHeader = "cookie"
                });
                options.CacheProfiles.Add("NoCaching", new CacheProfile()
                {
                    NoStore = true,
                    Location = ResponseCacheLocation.None
                });

            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })
            .AddRazorRuntimeCompilation()
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                  factory.Create(typeof(SharedResources));
            });

            #endregion

            #region Localization

            services.AddLocalization(L => L.ResourcesPath = "Localization/Resources");

            #endregion

            #region HSTS

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });

            #endregion

            #region Logging

            services.AddLogging();

            #endregion

            #region Other services

            services.Configure<WebEncoderOptions>(options =>
            {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
            });

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Error");
            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            app.UseHsts();

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions()
            {
                HttpsCompression = Microsoft.AspNetCore.Http.Features.HttpsCompressionMode.Compress,
                OnPrepareResponse = (context) =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromDays(365)
                    };

                }
            });

            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("ar-SY"),
            };
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US", "en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            };
            app.UseRequestLocalization(localizationOptions);
            app.UseWebMarkupMin();
            app.UseResponseCaching();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
            });
        }
    }
}
