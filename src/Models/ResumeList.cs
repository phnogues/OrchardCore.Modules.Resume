using OrchardCore.ContentManagement;
using System.Collections.Generic;

namespace OrchardCore.Modules.Resume.Models;

public class ResumeList
{
	public IEnumerable<ContentItem> Experiences { get; set; }

	public IEnumerable<ContentItem> Educations { get; internal set; }

	public IEnumerable<ContentItem> Awards { get; internal set; }
}
