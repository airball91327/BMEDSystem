#pragma checksum "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8856fc3d3cfaeae695077d4995f6323eb1d3f62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Budget_Delete), @"mvc.1.0.view", @"/Areas/BMED/Views/Budget/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Budget/Delete.cshtml", typeof(AspNetCore.Areas_BMED_Views_Budget_Delete))]
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
#line 1 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS;

#line default
#line hidden
#line 3 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models;

#line default
#line hidden
#line 4 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8856fc3d3cfaeae695077d4995f6323eb1d3f62", @"/Areas/BMED/Views/Budget/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Budget_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.BudgetModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
  
    Layout = "~/Views/Shared/_PassedLayout.cshtml";
    ViewBag.Title = "刪除";

#line default
#line hidden
            BeginContext(121, 122, true);
            WriteLiteral("\r\n<h2>刪除</h2>\r\n\r\n<h3>確定要刪除此項目?</h3>\r\n<fieldset>\r\n    <h4>預算</h4>\r\n    <hr />\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(244, 45, false);
#line 16 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.PlantName));

#line default
#line hidden
            EndContext();
            BeginContext(289, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(345, 41, false);
#line 19 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
   Write(Html.DisplayFor(model => model.PlantName));

#line default
#line hidden
            EndContext();
            BeginContext(386, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(445, 42, false);
#line 23 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.AccDpt));

#line default
#line hidden
            EndContext();
            BeginContext(487, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(543, 38, false);
#line 26 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
   Write(Html.DisplayFor(model => model.AccDpt));

#line default
#line hidden
            EndContext();
            BeginContext(581, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(640, 39, false);
#line 30 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.Amt));

#line default
#line hidden
            EndContext();
            BeginContext(679, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(735, 35, false);
#line 33 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
   Write(Html.DisplayFor(model => model.Amt));

#line default
#line hidden
            EndContext();
            BeginContext(770, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(829, 41, false);
#line 37 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(870, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(926, 37, false);
#line 40 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
   Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(963, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(1022, 46, false);
#line 44 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.TotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(1068, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1124, 42, false);
#line 47 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
   Write(Html.DisplayFor(model => model.TotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(1166, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(1225, 43, false);
#line 51 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.EngName));

#line default
#line hidden
            EndContext();
            BeginContext(1268, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1324, 39, false);
#line 54 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
   Write(Html.DisplayFor(model => model.EngName));

#line default
#line hidden
            EndContext();
            BeginContext(1363, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(1422, 40, false);
#line 58 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.Year));

#line default
#line hidden
            EndContext();
            BeginContext(1462, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1518, 36, false);
#line 61 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
   Write(Html.DisplayFor(model => model.Year));

#line default
#line hidden
            EndContext();
            BeginContext(1554, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(1613, 41, false);
#line 65 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.BuyId));

#line default
#line hidden
            EndContext();
            BeginContext(1654, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1710, 37, false);
#line 68 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
   Write(Html.DisplayFor(model => model.BuyId));

#line default
#line hidden
            EndContext();
            BeginContext(1747, 29, true);
            WriteLiteral("\r\n    </div>\r\n</fieldset>\r\n\r\n");
            EndContext();
            BeginContext(1776, 269, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c54f20b3fe345b883ccac996a3fef4d", async() => {
                BeginContext(1816, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1823, 36, false);
#line 73 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
Write(Html.HiddenFor(model => model.DocId));

#line default
#line hidden
                EndContext();
                BeginContext(1859, 95, true);
                WriteLiteral("\r\n    <div>\r\n        <input class=\"btn btn-default\" type=\"submit\" value=\"確定刪除\" /> |\r\n        <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1954, "\'", 2014, 1);
#line 76 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Budget\Delete.cshtml"
WriteAttributeValue("", 1961, Url.Action("Index", "Budget", new { Area = "BMED" }), 1961, 53, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2015, 23, true);
                WriteLiteral(">回到列表</a>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2045, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.BudgetModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
