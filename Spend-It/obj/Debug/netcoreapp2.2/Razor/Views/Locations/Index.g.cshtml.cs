#pragma checksum "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "262effe1421abf4d8c329022a6c08a0839d1ce9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Locations_Index), @"mvc.1.0.view", @"/Views/Locations/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Locations/Index.cshtml", typeof(AspNetCore.Views_Locations_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\_ViewImports.cshtml"
using Spend_It;

#line default
#line hidden
#line 2 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\_ViewImports.cshtml"
using Spend_It.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"262effe1421abf4d8c329022a6c08a0839d1ce9d", @"/Views/Locations/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f146b68e216a5f4e7a1dbf324704b80ecbff2da", @"/Views/_ViewImports.cshtml")]
    public class Views_Locations_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Spend_It.Models.Location>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(89, 20, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n");
            EndContext();
            BeginContext(167, 50, true);
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n");
            EndContext();
            BeginContext(431, 34, true);
            WriteLiteral("            <th>\r\n                ");
            EndContext();
            BeginContext(466, 48, false);
#line 22 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.LocationName));

#line default
#line hidden
            EndContext();
            BeginContext(514, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(570, 49, false);
#line 25 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.StreetAddress));

#line default
#line hidden
            EndContext();
            BeginContext(619, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(675, 40, false);
#line 28 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(715, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(771, 48, false);
#line 31 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.LocationType));

#line default
#line hidden
            EndContext();
            BeginContext(819, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 37 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(937, 14, true);
            WriteLiteral("        <tr>\r\n");
            EndContext();
            BeginContext(1163, 34, true);
            WriteLiteral("            <td>\r\n                ");
            EndContext();
            BeginContext(1198, 47, false);
#line 46 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.LocationName));

#line default
#line hidden
            EndContext();
            BeginContext(1245, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1301, 48, false);
#line 49 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.StreetAddress));

#line default
#line hidden
            EndContext();
            BeginContext(1349, 21, true);
            WriteLiteral("\r\n            </td>\r\n");
            EndContext();
            BeginContext(1472, 34, true);
            WriteLiteral("            <td>\r\n                ");
            EndContext();
            BeginContext(1507, 48, false);
#line 55 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.City.CityName));

#line default
#line hidden
            EndContext();
            BeginContext(1555, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1611, 64, false);
#line 58 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.LocationType.LocationTypeName));

#line default
#line hidden
            EndContext();
            BeginContext(1675, 70, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n             \r\n                ");
            EndContext();
            BeginContext(1745, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "262effe1421abf4d8c329022a6c08a0839d1ce9d8181", async() => {
                BeginContext(1801, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 62 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml"
                                          WriteLiteral(item.LocationId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1812, 55, true);
            WriteLiteral(" |\r\n               \r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 66 "C:\Users\newforce\workspace\backEnd\book5\Spend-It\Spend-It\Views\Locations\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1870, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Spend_It.Models.Location>> Html { get; private set; }
    }
}
#pragma warning restore 1591
