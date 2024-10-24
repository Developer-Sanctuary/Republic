using Discord;
using Discord.WebSocket;
using Republic.Private;

namespace Republic.Judiciary;

class Bot
{
	private DiscordSocketClient? _client;

	public async Task RunAsync()
	{
		_client = new DiscordSocketClient();
		_client.Log += LogAsync;
		_client.MessageReceived += MessageReceivedAsync;

		var _token = Constants.Token;

		await _client.LoginAsync(TokenType.Bot, _token);
		await _client.StartAsync();

		await Task.Delay(-1);
	}

	private Task LogAsync(LogMessage log)
	{
		Console.WriteLine(log.ToString());
		return Task.CompletedTask;
	}

	private async Task MessageReceivedAsync(SocketMessage message)
	{
		if (message.Author.IsBot) return;

		// Log the channel information
		Console.WriteLine($"Received message in channel: {message.Channel.Id} - {message.Channel.Name}");

		if (message.Content.StartsWith("!lawsuit"))
		{
			await message.Channel.SendMessageAsync("Not implemented.");
			// TODO: Discuss with cube how exactly the lawsuit should be handled.
		}
	}
}