using BakeryApplication.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApplicationTests.TagHelpers
{
    public class EmailTagHelperTests
    {
        [Fact]
        public void Generates_Email_Link()
        {
            // arrange
            EmailTagHelper emailTagHelper = new EmailTagHelper()
            {
                Address = "test@bakeryshop.com",
                Content = "Email"
            };

            var tagHelperContext = new TagHelperContext(
                                   new TagHelperAttributeList(),
                                   new Dictionary<object, object>(), string.Empty);

            var content = new Mock<TagHelperContent>();

            var TagHelperOutput = new TagHelperOutput("a",
                                  new TagHelperAttributeList(),
                                  (cache, encoder) => Task.FromResult(content.Object));

            // act
            emailTagHelper.Process(tagHelperContext, TagHelperOutput);

            // Assert
            Assert.Equal("Email", TagHelperOutput.Content.GetContent());
            Assert.Equal("a", TagHelperOutput.TagName);
            Assert.Equal("mailto:test@bakeryshop.com", TagHelperOutput.Attributes[0].Value);
        }
    }
}
