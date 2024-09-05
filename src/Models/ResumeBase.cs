using OrchardCore.ContentManagement;
using System;

namespace OrchardCore.Modules.Resume.Models;

public class ResumeBase : ContentPart
{
    public string Description { get; set; }

    public string Location { get; set; }

    public DateOnly? StartDate { get; set; }

	public DateOnly? EndDate { get; set; }
}
