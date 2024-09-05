using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.Modules.Resume.Models;
using System.ComponentModel.DataAnnotations;

namespace OrchardCore.Modules.Resume.ViewModels;

public class ResumeExperiencePartViewModel : ResumeBaseViewModel
{
	[Required]
	public string CompanyName { get; set; }

	[Required]
	public string JobTitle { get; set; }

	public string Skills { get; set; }

	[BindNever]
    public ResumeExperiencePart ResumePart { get; set; }
}
