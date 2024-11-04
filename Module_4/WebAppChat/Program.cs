using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using WebAppChat.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(o => o.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>((opt) =>
{
    opt.SetDefaultCulture("vi-VN");
    opt.AddSupportedCultures("en-US", "vi-VN");
    opt.FallBackToParentCultures = true;
    opt.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider(),
    };
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(p =>
{
    p.LoginPath = "/auth/login";
    p.LogoutPath = "/auth/logout";
    p.AccessDeniedPath = "/auth/denined";
    p.Cookie.Name = "cebnetvn";
    p.ExpireTimeSpan = TimeSpan.FromDays(30);
});

builder.Services.AddSingleton<ChatHub>();
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder)
    .AddDataAnnotationsLocalization();

var app = builder.Build();
app.MapHub<ChatHub>("/chathub");

app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();