#pragma checksum "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef4a742245660a2f5aecc64d4e608931f0a528c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDAttainFileUpload_AjaxView), @"mvc.1.0.view", @"/Areas/BMED/Views/Shared/Components/BMEDAttainFileUpload/AjaxView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Shared/Components/BMEDAttainFileUpload/AjaxView.cshtml", typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDAttainFileUpload_AjaxView))]
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
#line 1 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS;

#line default
#line hidden
#line 3 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models;

#line default
#line hidden
#line 4 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef4a742245660a2f5aecc64d4e608931f0a528c4", @"/Areas/BMED/Views/Shared/Components/BMEDAttainFileUpload/AjaxView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Shared_Components_BMEDAttainFileUpload_AjaxView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.AttainFileModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/BMED/FileUpload3.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("imgLOADING"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/opc-ajax-loader.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Upload3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AttainFile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "BMED", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(36, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(38, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "541c2de7ea064841a822c804f55b97e1", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 3 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(112, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(116, 3512, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5dba779b89fd4f2bbbc7a142390cc9a6", async() => {
                BeginContext(217, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(226, 36, false);
#line 7 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
Write(Html.HiddenFor(model => model.SeqNo));

#line default
#line hidden
                EndContext();
                BeginContext(262, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(269, 39, false);
#line 8 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
Write(Html.HiddenFor(model => model.IsPublic));

#line default
#line hidden
                EndContext();
                BeginContext(308, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(315, 38, false);
#line 9 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
Write(Html.HiddenFor(model => model.DocType));

#line default
#line hidden
                EndContext();
                BeginContext(353, 47, true);
                WriteLiteral("\r\n    <div class=\"form-horizontal\">\r\n\r\n        ");
                EndContext();
                BeginContext(401, 64, false);
#line 12 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
                EndContext();
                BeginContext(465, 50, true);
                WriteLiteral("\r\n\r\n        <div class=\"form-group\">\r\n            ");
                EndContext();
                BeginContext(516, 94, false);
#line 15 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
       Write(Html.LabelFor(model => model.DocId, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
                EndContext();
                BeginContext(610, 55, true);
                WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
                EndContext();
                BeginContext(666, 118, false);
#line 17 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
           Write(Html.EditorFor(model => model.DocId, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
                EndContext();
                BeginContext(784, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(803, 83, false);
#line 18 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
           Write(Html.ValidationMessageFor(model => model.DocId, "", new { @class = "text-danger" }));

#line default
#line hidden
                EndContext();
                BeginContext(886, 40, true);
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n");
                EndContext();
                BeginContext(1385, 48, true);
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            ");
                EndContext();
                BeginContext(1434, 94, false);
#line 31 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
       Write(Html.LabelFor(model => model.Title, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
                EndContext();
                BeginContext(1528, 55, true);
                WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
                EndContext();
                BeginContext(1584, 94, false);
#line 33 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
           Write(Html.EditorFor(model => model.Title, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
                EndContext();
                BeginContext(1678, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1697, 83, false);
#line 34 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
           Write(Html.ValidationMessageFor(model => model.Title, "", new { @class = "text-danger" }));

#line default
#line hidden
                EndContext();
                BeginContext(1780, 86, true);
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
                EndContext();
                BeginContext(1867, 97, false);
#line 39 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
       Write(Html.LabelFor(model => model.FileLink, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
                EndContext();
                BeginContext(1964, 55, true);
                WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
                EndContext();
                BeginContext(2020, 39, false);
#line 41 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
           Write(Html.HiddenFor(model => model.FileLink));

#line default
#line hidden
                EndContext();
                BeginContext(2059, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(2078, 109, false);
#line 42 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
           Write(Html.EditorFor(model => model.Files, new { htmlAttributes = new { @class = "form-control", type = "file" } }));

#line default
#line hidden
                EndContext();
                BeginContext(2187, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(2206, 86, false);
#line 43 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileUpload\AjaxView.cshtml"
           Write(Html.ValidationMessageFor(model => model.FileLink, "", new { @class = "text-danger" }));

#line default
#line hidden
                EndContext();
                BeginContext(2292, 40, true);
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n");
                EndContext();
                BeginContext(2826, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(3293, 198, true);
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-offset-2 col-md-10\">\r\n                <input id=\"btnUPLOAD\" type=\"button\" value=\"確定上傳\" class=\"btn btn-default\" />\r\n                ");
                EndContext();
                BeginContext(3491, 80, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bb51b12f89804588a30d2250800ff41e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3571, 50, true);
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3628, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.AttainFileModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
