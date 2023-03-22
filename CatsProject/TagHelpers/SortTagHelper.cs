using CatsProject.Models.Enum;
using Microsoft.AspNetCore.Razor.TagHelpers;
using static System.String;

namespace CatsProject.TagHelpers
{
	public class SortTagHelper : TagHelper
	{
		private readonly LinkGenerator _linkGenerator;

		public SortTagHelper(LinkGenerator linkGenerator)
		{
			_linkGenerator = linkGenerator;
		}

		public string SortClass { get; set; } = Empty;

		public string AClass { get; set; } = Empty;

		public string AspController { get; set; } = Empty;

		public string AspAction { get; set; } = Empty;

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "div";
			output.Attributes.SetAttribute("class", SortClass);
			string? href = Empty;
			foreach (CatsSort sort in Enum.GetValues(typeof(CatsSort)))
			{
				href = _linkGenerator.GetPathByAction(AspAction, AspController, new { sort = sort.ToString() });
				output.Content.AppendHtml($"<a class='{AClass}' href='{href}'>{sort}</a>");	
			}
		}
	}
}
