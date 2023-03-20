using Microsoft.AspNetCore.Razor.TagHelpers;
using static System.String;

namespace CatsProject.TagHelpers
{
	public class BreedsTagHelper : TagHelper
	{
		public IEnumerable<string> Breeds { get; set; } = default!;

		public string BreedsClass { get; set; } = Empty;

		public string AClass { get; set; } = Empty;

		public string Ahref { get; set; } = Empty;

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "div";
			output.Attributes.SetAttribute("class", BreedsClass);
			foreach (var breed in Breeds)
			{
				output.Content.AppendHtml($"<a class='{AClass}' href='{Ahref}/{breed}'>{breed}</a>");
			}
		}
	}
}
