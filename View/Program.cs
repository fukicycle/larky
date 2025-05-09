using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.DTO;
using Infrastructure.Firebase;
using Infrastructure.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using View;
using Blazored.LocalStorage;
using View.Services;
using Infrastructure.LocalServer;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSpeechSynthesis();
builder.Services.AddKeyedSingleton(typeof(IRepository<UserDTO, string>), nameof(FirebaseScheme.Users), new FirebaseRepository<UserDTO, string>(FirebaseScheme.Users));
builder.Services.AddKeyedSingleton(typeof(IRepository<WordDTO, string>), nameof(FirebaseScheme.Words), new FirebaseRepository<WordDTO, string>(FirebaseScheme.Words));
builder.Services.AddKeyedSingleton(typeof(IRepository<RankingDTO, int>), nameof(FirebaseScheme.Rankings), new FirebaseRepository<RankingDTO, int>(FirebaseScheme.Rankings));
builder.Services.AddKeyedSingleton(typeof(IRepository<BadgeDTO, string>), nameof(FirebaseScheme.Badges), new FirebaseRepository<BadgeDTO, string>(FirebaseScheme.Badges));
builder.Services.AddScoped<WordService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddSingleton<ILocalFileManager, LocalFileManager>();
builder.Services.AddSingleton<IPersistencer<PersistentStateContainer>, LocalStorageService<PersistentStateContainer>>();
builder.Services.AddSingleton<IPersistencer<PersistentSettingContainer>, LocalStorageService<PersistentSettingContainer>>();
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<AppStateContainer>();

await builder.Build().RunAsync();

