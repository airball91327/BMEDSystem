#pragma checksum "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12b8a961c8d72f8a0a515763150b11f1c8861f16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Asset_Delete2), @"mvc.1.0.view", @"/Areas/BMED/Views/Asset/Delete2.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Asset/Delete2.cshtml", typeof(AspNetCore.Areas_BMED_Views_Asset_Delete2))]
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
#line 1 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS;

#line default
#line hidden
#line 3 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models;

#line default
#line hidden
#line 4 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12b8a961c8d72f8a0a515763150b11f1c8861f16", @"/Areas/BMED/Views/Asset/Delete2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Asset_Delete2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.AssetModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "id", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteById", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Asset", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "BMED", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(31, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
  
    Layout = "~/Views/Shared/_LayoutNoTitle.cshtml";

#line default
#line hidden
            BeginContext(94, 140, true);
            WriteLiteral("\r\n<h2>刪除</h2>\r\n\r\n<h3>確定要刪除此資料?</h3>\r\n<fieldset>\r\n    <legend style=\"color: white\">儀器設備</legend>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(235, 41, false);
#line 14 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.Cname));

#line default
#line hidden
            EndContext();
            BeginContext(276, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(332, 37, false);
#line 17 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.Cname));

#line default
#line hidden
            EndContext();
            BeginContext(369, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(427, 41, false);
#line 21 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.Ename));

#line default
#line hidden
            EndContext();
            BeginContext(468, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(524, 37, false);
#line 24 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.Ename));

#line default
#line hidden
            EndContext();
            BeginContext(561, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(619, 43, false);
#line 28 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.AccDate));

#line default
#line hidden
            EndContext();
            BeginContext(662, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(718, 39, false);
#line 31 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.AccDate));

#line default
#line hidden
            EndContext();
            BeginContext(757, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(815, 43, false);
#line 35 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.BuyDate));

#line default
#line hidden
            EndContext();
            BeginContext(858, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(914, 39, false);
#line 38 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.BuyDate));

#line default
#line hidden
            EndContext();
            BeginContext(953, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(1011, 41, false);
#line 42 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.Brand));

#line default
#line hidden
            EndContext();
            BeginContext(1052, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1108, 37, false);
#line 45 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.Brand));

#line default
#line hidden
            EndContext();
            BeginContext(1145, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(1203, 44, false);
#line 49 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.Standard));

#line default
#line hidden
            EndContext();
            BeginContext(1247, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1303, 40, false);
#line 52 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.Standard));

#line default
#line hidden
            EndContext();
            BeginContext(1343, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(1401, 40, false);
#line 56 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
            EndContext();
            BeginContext(1441, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1497, 36, false);
#line 59 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.Type));

#line default
#line hidden
            EndContext();
            BeginContext(1533, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(1591, 44, false);
#line 63 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.VendorId));

#line default
#line hidden
            EndContext();
            BeginContext(1635, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1691, 40, false);
#line 66 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.VendorId));

#line default
#line hidden
            EndContext();
            BeginContext(1731, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(1789, 47, false);
#line 70 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.DisposeKind));

#line default
#line hidden
            EndContext();
            BeginContext(1836, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1892, 43, false);
#line 73 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.DisposeKind));

#line default
#line hidden
            EndContext();
            BeginContext(1935, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(1993, 44, false);
#line 77 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.DelivDpt));

#line default
#line hidden
            EndContext();
            BeginContext(2037, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(2093, 40, false);
#line 80 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.DelivDpt));

#line default
#line hidden
            EndContext();
            BeginContext(2133, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(2191, 45, false);
#line 84 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.LeaveSite));

#line default
#line hidden
            EndContext();
            BeginContext(2236, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(2292, 41, false);
#line 87 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.LeaveSite));

#line default
#line hidden
            EndContext();
            BeginContext(2333, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(2391, 42, false);
#line 91 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.AccDpt));

#line default
#line hidden
            EndContext();
            BeginContext(2433, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(2489, 38, false);
#line 94 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.AccDpt));

#line default
#line hidden
            EndContext();
            BeginContext(2527, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(2585, 40, false);
#line 98 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(2625, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(2681, 36, false);
#line 101 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(2717, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(2775, 42, false);
#line 105 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.Shares));

#line default
#line hidden
            EndContext();
            BeginContext(2817, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(2873, 38, false);
#line 108 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.Shares));

#line default
#line hidden
            EndContext();
            BeginContext(2911, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(2969, 42, false);
#line 112 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.MakeNo));

#line default
#line hidden
            EndContext();
            BeginContext(3011, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(3067, 38, false);
#line 115 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.MakeNo));

#line default
#line hidden
            EndContext();
            BeginContext(3105, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(3163, 40, false);
#line 119 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayNameFor(model => model.Note));

#line default
#line hidden
            EndContext();
            BeginContext(3203, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(3259, 36, false);
#line 122 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
   Write(Html.DisplayFor(model => model.Note));

#line default
#line hidden
            EndContext();
            BeginContext(3295, 31, true);
            WriteLiteral("\r\n    </div>\r\n\r\n</fieldset>\r\n\r\n");
            EndContext();
            BeginContext(3326, 245, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "344c91101f3e44d8993fe950c57cdd59", async() => {
                BeginContext(3412, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3418, 51, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "199b0ce85ce74111be470935259d1856", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 128 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Asset\Delete2.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.AssetNo);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3469, 95, true);
                WriteLiteral("\r\n    <div>\r\n        <input class=\"btn btn-primary\" type=\"submit\" value=\"確定刪除\" />\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3571, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.AssetModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
