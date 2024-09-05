using OrchardCore.ContentManagement.Handlers;
using OrchardCore.Modules.Resume.Models;
using System.Threading.Tasks;

namespace OrchardCore.Modules.Resume.Handlers;

public class ResumePartHandler : ContentPartHandler<ResumePart>
{
    public override Task UpdatedAsync(UpdateContentContext context, ResumePart part)
    {
        context.ContentItem.DisplayText = part.Name;

        return Task.CompletedTask;
    }
}

