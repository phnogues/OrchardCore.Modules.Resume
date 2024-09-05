using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Modules.Resume.Models;
using OrchardCore.Modules.Resume.ViewModels;
using System.Threading.Tasks;

namespace OrchardCore.Modules.Resume.Drivers;

public class ResumePartDisplayDriver : ContentPartDisplayDriver<ResumePart>
{
    public override IDisplayResult Display(ResumePart part, BuildPartDisplayContext context) =>
       
        Initialize<ResumePartViewModel>(GetDisplayShapeType(context), viewModel => PopulateViewModel(part, viewModel))
            .Location("Detail", "Content:1")
            .Location("Summary", "Content:1");

    public override IDisplayResult Edit(ResumePart part, BuildPartEditorContext context) =>
        Initialize<ResumePartViewModel>(GetEditorShapeType(context), viewModel => PopulateViewModel(part, viewModel));

    public override async Task<IDisplayResult> UpdateAsync(ResumePart part, IUpdateModel updater, UpdatePartEditorContext context)
    {
        var viewModel = new ResumePartViewModel();

        await updater.TryUpdateModelAsync(viewModel, Prefix);

        part.Name = viewModel.Name;

        return await EditAsync(part, context);
    }

    private static void PopulateViewModel(ResumePart part, ResumePartViewModel viewModel)
    {
        viewModel.ResumePart = part;
    }
}
