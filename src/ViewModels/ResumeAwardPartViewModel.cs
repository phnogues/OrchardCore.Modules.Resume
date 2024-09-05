using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.Modules.Resume.Models;
using System.ComponentModel.DataAnnotations;

namespace OrchardCore.Modules.Resume.ViewModels;

public class ResumeAwardPartViewModel : ResumeBaseViewModel
{
	[Required]
	public string AwardTitle { get; set; }

	public string AwardIdOrName { get; set; }

	public string IssuingOrganization { get; set; }

	[BindNever]
	public ResumeAwardPart AwardPart { get; set; }
}
