using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Posterr.Repository.Postgresql
{
	/*
	 * Migrations summary commands
	 * 
	 * Gen. new migration:  dotnet ef migrations add <name_of_migration>
	 *    Gen. SQL script:  dotnet ef migrations script
	 *               List:  dotnet ef migrations list
	 *             Update:  dotnet ef database update
	 *             Remove:  dotnet ef migrations remove –-force
	 *      Drop Database:  dotnet ef database drop 
	 *      
	 *  TIP: use the command bellow to copy the script to the clipboard
	 *  dotnet ef migrations script | Set-Clipboard
	 *  
	 */
	public class PosterrContextFactory : IDesignTimeDbContextFactory<PosterrDbContext>
	{
		public PosterrDbContext CreateDbContext(string[] args)
		{
			var options = GetPosterrContextOptions();
			return new PosterrDbContext(options);
		}

		public static DbContextOptions GetPosterrContextOptions()
		{
			var envFilePath = Path.Combine(Directory.GetCurrentDirectory(), ".env");

			if (File.Exists(envFilePath))
            {
				DotNetEnv.Env.Load(envFilePath);
			}

			var configuration = new ConfigurationBuilder()
				.AddEnvironmentVariables()
				.Build();
			
			var builder = new DbContextOptionsBuilder<PosterrDbContext>();
			builder.EnableSensitiveDataLogging();
			builder.EnableDetailedErrors();
			var connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;	
			builder.UseNpgsql(connectionString);
			return builder.Options;
		}
	}
}
