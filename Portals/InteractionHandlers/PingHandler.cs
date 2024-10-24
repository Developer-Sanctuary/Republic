using Discord;
using Discord.Interactions;
using Portal.Embeds;
using Republic.Portals.Embeds;

namespace Republic.Portals.InteractionHandlers;

[RequireUserPermission(GuildPermission.Administrator)]
public class PingHandler : InteractionModuleBase<SocketInteractionContext>
{
	// /ping - dummy command to handle ping and pong and gives us the client latency
	[SlashCommand("ping", "Pings the system latency")]
	public async Task HandlePingAsync()
	{
		await RespondAsync(embed: new PongEmbed(Context.Client.Latency).Build(), ephemeral: true);
	}

	[SlashCommand("help", "Displays help message")]
	public async Task HandleHelpAsync()
	{
		await RespondAsync(embed: new HelpEmbed().Build(), ephemeral: true);
	}
}