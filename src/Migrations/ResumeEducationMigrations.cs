using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Modules.Resume.Models;
using System.Threading.Tasks;

namespace OrchardCore.Modules.Resume.Migrations;

public class ResumeEducationMigrations : DataMigration
{
	private readonly IContentDefinitionManager _contentDefinitionManager;

	public ResumeEducationMigrations(IContentDefinitionManager contentDefinitionManager) => _contentDefinitionManager = contentDefinitionManager;

	public async Task<int> CreateAsync()
	{
		await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(ResumeEducationPart), part => part.Attachable());

		await _contentDefinitionManager.AlterTypeDefinitionAsync(ContentTypes.ResumeEducation, type => type
			.Creatable()
			.Listable()
			.WithPart(nameof(ResumeEducationPart))
		);

		return 1;
	}
}