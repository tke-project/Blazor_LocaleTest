using Blazor_LocaleTest.Components;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//’Ç‰Á ----------------
builder.Services.AddLocalization();
//’Ç‰Á ----------------
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


//’Ç‰Á ----------------
var supportedCultures = new[] { "en-US", "ja-JP", "zh-CN", "fr-FR" };

//’Ç‰Á ----------------
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);


//’Ç‰Á ----------------
app.UseRequestLocalization(localizationOptions);

//’Ç‰Á ----------------
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();

