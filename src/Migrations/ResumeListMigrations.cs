using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Modules.Resume.Models;
using System.Threading.Tasks;

namespace OrchardCore.Modules.Resume.Migrations;

public class ResumeListMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public ResumeListMigrations(IContentDefinitionManager contentDefinitionManager) =>
        _contentDefinitionManager = contentDefinitionManager;

    public async Task<int> CreateAsync()
    {
        await _contentDefinitionManager
            .AlterPartDefinitionAsync(nameof(ResumeListPart), builder => builder
                .Attachable()
                .WithDescription("Displays a list of resumes controlled by widgets."));

		return 1;
    }
}