using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Modules.Resume.Models;

using System.Threading.Tasks;

namespace OrchardCore.Modules.Resume.Migrations;

public class ResumeAwardMigrations : DataMigration
{
	private readonly IContentDefinitionManager _contentDefinitionManager;

	public ResumeAwardMigrations(IContentDefinitionManager contentDefinitionManager) => _contentDefinitionManager = contentDefinitionManager;

	public async Task<int> CreateAsync()
	{
		await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(ResumeAwardPart), part => part.Attachable());

		await _contentDefinitionManager.AlterTypeDefinitionAsync(ContentTypes.ResumeAward, type => type
			.Creatable()
			.Listable()
			.WithPart(nameof(ResumeAwardPart))
		);

		return 1;
	}
}