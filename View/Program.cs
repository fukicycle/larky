using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.DTO;
using Infrastructure.Firebase;
using Infrastructure.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using View;
using View.Services;
using Blazored.LocalStorage;
using Domain.Logics;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSpeechSynthesis();
builder.Services.AddKeyedSingleton(typeof(IRepository<UserDTO>), nameof(FirebaseScheme.Users), new FirebaseRepository<UserDTO>(FirebaseScheme.Users));
builder.Services.AddKeyedSingleton(typeof(IRepository<WordDTO>), nameof(FirebaseScheme.Words), new FirebaseRepository<WordDTO>(FirebaseScheme.Words));
builder.Services.AddKeyedSingleton(typeof(IRepository<RankingDTO>), nameof(FirebaseScheme.Rankings), new FirebaseRepository<RankingDTO>(FirebaseScheme.Rankings));
builder.Services.AddKeyedSingleton(typeof(IRepository<BadgeDTO>), nameof(FirebaseScheme.Badges), new FirebaseRepository<BadgeDTO>(FirebaseScheme.Badges));
builder.Services.AddScoped<StudyService>();
builder.Services.AddScoped<IPersistencer<PersistentStateContainer>, LocalStorageService<PersistentStateContainer>>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
