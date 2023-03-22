using BigProject.Data.Entities;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Drawing.Drawing2D;
using static System.String;

namespace CatsProject.TagHelpers
{
	public class BreedsTagHelper : TagHelper
	{
		private readonly LinkGenerator _linkGenerator;

		public BreedsTagHelper(LinkGenerator linkGenerator)
		{
			_linkGenerator = linkGenerator;
		}

		public IEnumerable<string> Breeds { get; set; } = default!;

		public string BreedsClass { get; set; } = Empty;

		public string AClass { get; set; } = Empty;

		public string AspController { get; set; } = Empty;

		public string AspAction { get; set; } = Empty;

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "div";
			output.Attributes.SetAttribute("class", BreedsClass);
			string? href = Empty;
			foreach (var breed in Breeds)
			{
				href = _linkGenerator.GetPathByAction(AspAction, AspController, new { Breed = breed });
				output.Content.AppendHtml($"<a class='{AClass}' href='{href}'>{breed}</a>");
			}
		}
	}
}
