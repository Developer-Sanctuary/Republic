using Discord;

namespace Republic.Portals.Common;

public interface IEmbedProvider
{
    Embed Build();
}