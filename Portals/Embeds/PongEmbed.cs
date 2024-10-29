using Discord;
using Republic.Common;

namespace Republic.Portals.Embeds;

public class PongEmbed(int ping) : IEmbedProvider
{
	public Embed Build() => new EmbedBuilder()
		.WithTitle("Pong!")
		.WithDescription($"Latency: `{ping} ms`")
		.WithColor(Color.Blue)
		.Build();
}