using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Modules.Resume.Models;
using OrchardCore.Modules.Resume.Services.Interfaces;
using OrchardCore.Modules.Resume.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace OrchardCore.Modules.Resume.Drivers;

public class ResumeListPartDisplayDriver : ContentPartDisplayDriver<ResumeListPart>
{
    private readonly IResumeListService _resumeListService;

    public ResumeListPartDisplayDriver(IResumeListService resumeListService)
    {
        _resumeListService = resumeListService;
    }

    public override IDisplayResult Display(ResumeListPart part, BuildPartDisplayContext context) =>
        Combine(
            Initialize<ResumeListPartViewModel>(
                    GetDisplayShapeType(context),
                    async viewModel => await BuildViewModelAsync(viewModel, part, context))
                .Location("Detail", "Content:25")
                .Location("Summary", "Meta:10"));

    private async Task BuildViewModelAsync(ResumeListPartViewModel viewModel, ResumeListPart part, BuildPartDisplayContext context)
    {
        viewModel.ResumeListPart = part;


        var productList = await _resumeListService.GetProductsAsync(part);

        viewModel.Experiences = productList.Experiences.OrderByDescending(r=> r.Content.ResumeExperiencePart.StartDate);
        viewModel.Educations = productList.Educations.OrderByDescending(r => r.Content.ResumeEducationPart.StartDate);
        viewModel.Awards = productList.Awards.OrderByDescending(r => r.Content.ResumeAwardPart.StartDate);

        viewModel.Context = context;
    }
}
