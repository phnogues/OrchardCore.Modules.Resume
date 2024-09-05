using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Modules.Resume.Models;
using System.Threading.Tasks;

namespace OrchardCore.Modules.Resume.Migrations;

public class ResumeExperienceMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public ResumeExperienceMigrations(IContentDefinitionManager contentDefinitionManager) => _contentDefinitionManager = contentDefinitionManager;

    public async Task<int> CreateAsync()
    { 
        await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(ResumeExperiencePart), part => part.Attachable());

		await _contentDefinitionManager.AlterTypeDefinitionAsync(ContentTypes.ResumeExperience, type => type
			.Creatable()
			.Listable()
			.WithPart(nameof(ResumeExperiencePart))
		);

		return 1;
    }
}