# 🕸️ Developer Sanctuary Website

#### The API and bots for Developer Sanctuary, all in one repo!

---

> [!NOTE]
> Yes, this repo is not part of the official [@Developer-Sanctuary](https://github.com/Developer-Sanctuary) github org since I don't yet have the correct perms in the org 😅

## 🤔 What is this repo?

This repository contains the source code for Dev Sanx's stylish website. The site is written using [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) and [C#](https://dotnet.microsoft.com/languages/csharp) using ASP.NET, and deployed on both Oracle Server (by me, [@Lamparter](https://github.com/Lamparter)) and on Raspberry Pi (courtesy of [@FireCube](https://github.com/firecubestudios)).

This repo also contains various bots written in Python and C# (and perhaps also Node in the future) that are built using Developer Sanctuary's distributed bot model.

### 📋 Bots

> Then we need to upgrade copilot bot to replace dyno in general commands
> Then there is the two big government and projects bot which I’ll handle
> The small bots include
> - [ ] starboard
> - [ ] portal bot (taken)
> - [ ] tags bot
> - [ ] counting bot (will replace with kimbra c# cortana bot but you can upgrade it maybe)
> - [ ] cross union bridge bot (you can use the old bot source code)
> - [ ] media bot to automate ⁠press
> - [ ] court bot to automate lawsuits
> - [ ] statbot replacement

_as proposed by FireCube in a conversation with Lamparter_

## 🔐 Credentials

In order to run the bots, you will need to provide the appropriate credentials. These credentials appear inside a unified store in the `Republic.Private` project.

1. Create a file named `Constants.cs` in `Republic.Private`
2. In the file, paste the following contents:
```cs
namespace Republic.Private;

public class Judiciary
{
		public const string Token = "token_for_court_automation_bot";
}

public class Portals
{
	public const string Token = "token_for_portals_bot";

	public class Bot
	{
		public const ulong GuildId = 714581497222398064; // Copy and paste the server ID of your target server here.
	}
}
```
3. The credentials store should now be working!
> If there are any problems here, feel free to create an issue or send a message in the `#dev-infrastructure` channel in Developer Sanctuary!
