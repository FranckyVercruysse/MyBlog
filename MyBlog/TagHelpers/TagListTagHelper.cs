using Microsoft.AspNetCore.Razor.TagHelpers;
using MyBlog.Models;
using System.Collections.Generic;

namespace MyBlog.TagHelpers
{
    public class TagListTagHelper : TagHelper
    {
        public ICollection<PostTag> PostTags { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            string anchortags = string.Empty;
            foreach(var postTag in PostTags)
            {
                anchortags += $@"<a href=\Tag\{postTag.Tag.UrlSlug}>{postTag.Tag.Name}</a>   ";
            }
            
            output.Content.SetHtmlContent(anchortags);
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
