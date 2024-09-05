using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Modules.Resume.Models;
using OrchardCore.Modules.Resume.ViewModels;
using System.Threading.Tasks;

namespace OrchardCore.Modules.Resume.Drivers;

public class ResumeAwardPartDisplayDriver : ContentPartDisplayDriver<ResumeAwardPart>
{
	public override IDisplayResult Display(ResumeAwardPart part, BuildPartDisplayContext context) =>

		Initialize<ResumeAwardPartViewModel>(GetDisplayShapeType(context), viewModel => PopulateViewModel(part, viewModel))
			.Location("Detail", "Content:1")
			.Location("Summary", "Content:1");

	public override IDisplayResult Edit(ResumeAwardPart part, BuildPartEditorContext context) =>
		Initialize<ResumeAwardPartViewModel>(GetEditorShapeType(context), viewModel => PopulateViewModel(part, viewModel));


	public override async Task<IDisplayResult> UpdateAsync(ResumeAwardPart part, IUpdateModel updater, UpdatePartEditorContext context)
	{
		var viewModel = new ResumeAwardPartViewModel();

		await updater.TryUpdateModelAsync(viewModel, Prefix);

		part.AwardTitle = viewModel.AwardTitle;
		part.AwardIdOrName = viewModel.AwardIdOrName;
		part.IssuingOrganization = viewModel.IssuingOrganization;
		part.StartDate = viewModel.StartDate;
		part.EndDate = viewModel.EndDate;
		part.Description = viewModel.Description;
		part.Location = viewModel.Location;

		return await EditAsync(part, context);
	}

	private static void PopulateViewModel(ResumeAwardPart part, ResumeAwardPartViewModel viewModel)
	{
		viewModel.AwardTitle = part.AwardTitle;
		viewModel.AwardIdOrName = part.AwardIdOrName;
		viewModel.IssuingOrganization = part.IssuingOrganization;
		viewModel.StartDate = part.StartDate;
		viewModel.EndDate = part.EndDate;
		viewModel.Description = part.Description;
		viewModel.Location = part.Location;

		viewModel.AwardPart = part;
	}
}
