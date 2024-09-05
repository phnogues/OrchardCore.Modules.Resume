using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Modules.Resume.Models;
using OrchardCore.Modules.Resume.ViewModels;
using System.Threading.Tasks;

namespace OrchardCore.Modules.Resume.Drivers;

public class ResumeExperiencePartDisplayDriver : ContentPartDisplayDriver<ResumeExperiencePart>
{
    public override IDisplayResult Display(ResumeExperiencePart part, BuildPartDisplayContext context) =>
       
        Initialize<ResumeExperiencePartViewModel>(GetDisplayShapeType(context), viewModel => PopulateViewModel(part, viewModel))
            .Location("Detail", "Content:1")
            .Location("Summary", "Content:1");

    public override IDisplayResult Edit(ResumeExperiencePart part, BuildPartEditorContext context) =>
        Initialize<ResumeExperiencePartViewModel>(GetEditorShapeType(context), viewModel => PopulateViewModel(part, viewModel));

    public override async Task<IDisplayResult> UpdateAsync(ResumeExperiencePart part, IUpdateModel updater, UpdatePartEditorContext context)
    {
        var viewModel = new ResumeExperiencePartViewModel();

        await updater.TryUpdateModelAsync(viewModel, Prefix);

        part.CompanyName = viewModel.CompanyName;
        part.Location = viewModel.Location;
        part.EndDate = viewModel.EndDate;
        part.StartDate = viewModel.StartDate;
        part.Description = viewModel.Description;
        part.JobTitle = viewModel.JobTitle;
        part.Skills = viewModel.Skills;

        return await EditAsync(part, context);
    }

    private static void PopulateViewModel(ResumeExperiencePart part, ResumeExperiencePartViewModel viewModel)
    {
        viewModel.CompanyName = part.CompanyName;
		viewModel.Location = part.Location;
		viewModel.EndDate = part.EndDate;
		viewModel.StartDate = part.StartDate;
		viewModel.Description = part.Description;
		viewModel.JobTitle = part.JobTitle;
		viewModel.Skills = part.Skills;

		viewModel.ResumePart = part;
    }
}
