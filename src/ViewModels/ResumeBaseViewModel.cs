using System;
using System.ComponentModel.DataAnnotations;

namespace OrchardCore.Modules.Resume.ViewModels;

public class ResumeBaseViewModel
{
	public string Description { get; set; }

	public string Location { get; set; }

	[Required]
	public DateOnly? StartDate { get; set; }

	public DateOnly? EndDate { get; set; }
}
