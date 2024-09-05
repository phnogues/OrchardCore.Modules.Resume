using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.Modules.Resume.Models;
using System.ComponentModel.DataAnnotations;

namespace OrchardCore.Modules.Resume.ViewModels;

public class ResumeEducationPartViewModel : ResumeBaseViewModel
{
    [Required]
    public string SchoolName { get; set; }

	public string Degree { get; set; }

	[BindNever]
    public ResumeEducationPart ResumeEducationPart { get; set; }
}
