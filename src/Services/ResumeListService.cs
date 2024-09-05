using OrchardCore.ContentManagement.Records;
using OrchardCore.ContentManagement;
using OrchardCore.Modules.Resume.Models;
using OrchardCore.Modules.Resume.Services.Interfaces;
using System;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata;
using System.Collections.Generic;
using System.Linq;
using YesSql;
using YesSql.Services;
using System.Threading;

namespace OrchardCore.Modules.Resume.Services;

public class ResumeListService : IResumeListService
{
	private readonly ISession _session;
	private readonly IContentDefinitionManager _contentDefinitionManager;

	public ResumeListService(ISession session,
		IContentDefinitionManager contentDefinitionManager)
	{
		_session = session;
		_contentDefinitionManager = contentDefinitionManager;
	}

	public async Task<ResumeList> GetProductsAsync(ResumeListPart productList)
	{
		ArgumentNullException.ThrowIfNull(productList);

		return new ResumeList
		{
			Experiences = await GetContentItems(nameof(ResumeExperiencePart)),
			Educations = await GetContentItems(nameof(ResumeEducationPart)),
			Awards = await GetContentItems(nameof(ResumeAwardPart)),
		};
	}

	private async Task<List<ContentItem>> GetContentItems(string partDefinition)
	{
		var types = (await _contentDefinitionManager.ListTypeDefinitionsAsync())
		  .Where(type => type.Parts.Any(part => part.PartDefinition.Name == partDefinition))
		  .Select(type => type.Name)
		  .ToArray();

		var query = _session.Query<ContentItem>();
		query = query.With<ContentItemIndex>(index => index.ContentType.IsIn(types) && index.Published);

		return await query
					.ToAsyncEnumerable()
					.Where(e => e.Content.LocalizationPart is null || (e.Content.LocalizationPart != null && e.Content.LocalizationPart.Culture == Thread.CurrentThread.CurrentCulture))
					.ToListAsync();
	}
}
