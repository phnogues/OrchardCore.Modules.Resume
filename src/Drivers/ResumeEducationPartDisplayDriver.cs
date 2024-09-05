using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Modules.Resume.Models;
using OrchardCore.Modules.Resume.ViewModels;
using System.Threading.Tasks;

namespace OrchardCore.Modules.Resume.Drivers;

public class ResumeEducationPartDisplayDriver : ContentPartDisplayDriver<ResumeEducationPart>
{
    public override IDisplayResult Display(ResumeEducationPart part, BuildPartDisplayContext context) =>
       
        Initialize<ResumeEducationPartViewModel>(GetDisplayShapeType(context), viewModel => PopulateViewModel(part, viewModel))
            .Location("Detail", "Content:1")
            .Location("Summary", "Content:1");

    public override IDisplayResult Edit(ResumeEducationPart part, BuildPartEditorContext context) =>
        Initialize<ResumeEducationPartViewModel>(GetEditorShapeType(context), viewModel => PopulateViewModel(part, viewModel));

    public override async Task<IDisplayResult> UpdateAsync(ResumeEducationPart part, IUpdateModel updater, UpdatePartEditorContext context)
    {
        var viewModel = new ResumeEducationPartViewModel();

        await updater.TryUpdateModelAsync(viewModel, Prefix);

        part.SchoolName = viewModel.SchoolName;
        part.Location = viewModel.Location;
        part.StartDate = viewModel.StartDate;
        part.EndDate = viewModel.EndDate;
        part.Description = viewModel.Description;
        part.Degree = viewModel.Degree;

        return await EditAsync(part, context);
    }

    private static void PopulateViewModel(ResumeEducationPart part, ResumeEducationPartViewModel viewModel)
    {
        viewModel.SchoolName = part.SchoolName;
		viewModel.Location = part.Location;
		viewModel.StartDate = part.StartDate;
		viewModel.EndDate = part.EndDate;
		viewModel.Description = part.Description;
		viewModel.Degree = part.Degree;

		viewModel.ResumeEducationPart = part;
    }
}
