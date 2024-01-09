using Blazor_LocaleTest.Components;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//�ǉ� ----------------
builder.Services.AddLocalization();
//�ǉ� ----------------
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


//�ǉ� ----------------
var supportedCultures = new[] { "en-US", "ja-JP", "zh-CN", "fr-FR" };

//�ǉ� ----------------
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);


//�ǉ� ----------------
app.UseRequestLocalization(localizationOptions);

//�ǉ� ----------------
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();

