using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace OrchardCore.Modules.Resume.Models;

public class ResumePart : ContentPart
{
    public string Name { get; set; }

    public TextField Biography { get; set; } = new();
}
