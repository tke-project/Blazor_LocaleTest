using Blazor_LocaleTest.Components;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//追加 ----------------
builder.Services.AddLocalization();
//追加 ----------------
builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


//追加 ----------------
var supportedCultures = new[] { "en-US", "ja-JP", "zh-CN", "fr-FR" };

//追加 ----------------
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);


//追加 ----------------
app.UseRequestLocalization(localizationOptions);

//追加 ----------------
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();

