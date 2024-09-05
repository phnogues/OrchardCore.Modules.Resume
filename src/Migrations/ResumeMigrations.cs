using OrchardCore.Autoroute.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Modules.Resume.Models;
using OrchardCore.Title.Models;
using System.Threading.Tasks;

namespace OrchardCore.Modules.Resume.Migrations;

public class ResumeMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public ResumeMigrations(IContentDefinitionManager contentDefinitionManager) => _contentDefinitionManager = contentDefinitionManager;

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager.AlterPartDefinitionAsync(nameof(ResumePart), part => part.Attachable());

		await _contentDefinitionManager.AlterTypeDefinitionAsync(ContentTypes.Resume, type => type
			.Creatable()
			.Listable()
			.WithPart(nameof(TitlePart))
			.WithPart(nameof(AutoroutePart))
			.WithPart(nameof(ResumeListPart))			
		);

		return 1;
    }
}