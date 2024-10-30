using Discord;
using Discord.Interactions;
using Republic.Embeds;

namespace Republic.Portals.InteractionHandlers;

[RequireUserPermission(GuildPermission.Administrator)]
public class PingHandler : InteractionModuleBase<SocketInteractionContext>
{
	// /ping - dummy command to handle ping and pong and gives us the client latency
	[SlashCommand("ping", "Pings the system latency")]
	public async Task HandlePingAsync()
	{
		await RespondAsync(embed: new PingEmbed(Context.Client.Latency).Build(), ephemeral: true);
	}

	[SlashCommand("help", "Displays help message")]
	public async Task HandleHelpAsync()
	{
		const string helpReference = """
									 `/teleport {channel}`
									 Opens a portal from current channel to provided rxChannel.
									 Alias: `!tp`, `!teleport`, `!portal`
									 `/exclude`
									 Exclude a channel for being read only.
									 `/logchannel {channel}`
									 Sets the channel where the bot logs information.
									 """;
		await RespondAsync(embed: new HelpEmbed("Portals bot", "v1.0", helpReference, 793688107077468171).Build(), ephemeral: true);
	}
}