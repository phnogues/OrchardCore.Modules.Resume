using OrchardCore.Modules.Resume.Models;
using System.Threading.Tasks;

namespace OrchardCore.Modules.Resume.Services.Interfaces;

public interface IResumeListService
{
    Task<ResumeList> GetProductsAsync(ResumeListPart resumeList);
}
