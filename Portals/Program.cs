﻿using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Republic.Portals.DB;
using Republic.Portals.Helpers;
using Serilog;

namespace Republic.Portals;

public class Program
{
	public static async Task Main()
	{
		// Create config builder
		var configuration = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			.AddEnvironmentVariables()
			.Build();
		Log.Debug("Configuration loaded");

		Log.Debug("Configuring logger");
		ConfigureLogger(configuration["Logger:Template"]!);

		DiscordSocketConfig discordSocketConfig = new()
		{
			GatewayIntents = GatewayIntents.Guilds | GatewayIntents.GuildMessages | GatewayIntents.MessageContent,
			LogGatewayIntentWarnings = false,
			LogLevel = LogSeverity.Debug
		};

		// Creating a .NET generic Host instance
		IHost host = Host.CreateDefaultBuilder()
			.ConfigureServices(serviceCollection =>
			{
				serviceCollection.AddSingleton(discordSocketConfig)
					.AddSingleton<IConfiguration>(configuration)
					.AddDbContext<BotDbContext>(
						options => options.UseSqlite(configuration["Database:ConnectionString"]))
					.AddSingleton<DiscordSocketClient>()
					.AddSingleton(provider =>
						new InteractionService(provider.GetRequiredService<DiscordSocketClient>()))
					.AddSingleton<CommandService>()
					.AddSingleton<InteractionHandler>()
					.AddSingleton<CommandHandler>()
					.AddTransient<Helper>();
				serviceCollection.AddHostedService<BotService>();
				Log.Debug("Added dependencies to ServiceCollection");
			})
			.UseSerilog()
			.Build();
		Log.Debug("Built host successfully");
		Log.Debug("Attempting to start application");

		// Start the host
		await host.RunAsync();
	}

	private static void ConfigureLogger(string loggerTemplate)
	{
		// Additional configs for logger like formatters
		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.Enrich.WithAssemblyName()
			.WriteTo.Console(outputTemplate: loggerTemplate)
			.CreateLogger();
	}
}