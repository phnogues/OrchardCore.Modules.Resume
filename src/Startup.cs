using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Environment.Shell.Configuration;
using OrchardCore.Modules.Resume.Drivers;
using OrchardCore.Modules.Resume.Handlers;
using OrchardCore.Modules.Resume.Migrations;
using OrchardCore.Modules.Resume.Models;
using OrchardCore.Modules.Resume.Services;
using OrchardCore.Modules.Resume.Services.Interfaces;
using OrchardCore.ResourceManagement;

namespace OrchardCore.Modules.Resume;

public class Startup : StartupBase
{
	private readonly IShellConfiguration _shellConfiguration;

	public Startup(IShellConfiguration shellConfiguration) => _shellConfiguration = shellConfiguration;

	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();

		// Resume Part
		services.AddContentPart<ResumePart>()
					.UseDisplayDriver<ResumePartDisplayDriver>()
					.AddHandler<ResumePartHandler>();
		services.AddDataMigration<ResumeMigrations>();

		// Resume List
		services.AddScoped<IResumeListService, ResumeListService>();
		services.AddScoped<IDataMigration, ResumeListMigrations>();
		services.AddContentPart<ResumeListPart>()
					.UseDisplayDriver<ResumeListPartDisplayDriver>();

		// Resume Education
		services.AddContentPart<ResumeEducationPart>()
					.UseDisplayDriver<ResumeEducationPartDisplayDriver>();
		services.AddDataMigration<ResumeEducationMigrations>();

		// Resume Experience
		services.AddContentPart<ResumeExperiencePart>()
					.UseDisplayDriver<ResumeExperiencePartDisplayDriver>();
		services.AddDataMigration<ResumeExperienceMigrations>();

		// Resume Award
		services.AddContentPart<ResumeAwardPart>()
					.UseDisplayDriver<ResumeAwardPartDisplayDriver>();
		services.AddDataMigration<ResumeAwardMigrations>();
	}
}