namespace Republic.Judiciary;

class Program
{
	static async Task Main(string[] args)
	{
		var bot = new Bot();
		await bot.RunAsync();
	}
}
