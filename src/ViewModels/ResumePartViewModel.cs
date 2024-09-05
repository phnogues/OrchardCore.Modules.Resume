using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.Modules.Resume.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrchardCore.Modules.Resume.ViewModels;

public class ResumePartViewModel
{
    [Required]
    public string Name { get; set; }

    [BindNever]
    public ResumePart ResumePart { get; set; }
}
