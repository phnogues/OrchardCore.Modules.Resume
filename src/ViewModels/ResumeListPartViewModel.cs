using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement;
using OrchardCore.DisplayManagement;
using OrchardCore.Modules.Resume.Models;
using System.Collections.Generic;

namespace OrchardCore.Modules.Resume.ViewModels;

public class ResumeListPartViewModel
{
    public ResumeListPart ResumeListPart { get; set; }

    public IShape Pager { get; set; }

    public IEnumerable<ContentItem> Experiences { get; set; }

    public IEnumerable<ContentItem> Educations { get; set; }

    public IEnumerable<ContentItem> Awards { get; set; }

    public BuildPartDisplayContext Context { get; set; }
}
