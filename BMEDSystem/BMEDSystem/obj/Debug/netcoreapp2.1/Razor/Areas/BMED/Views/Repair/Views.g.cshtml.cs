#pragma checksum "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "593159631ae4e3c53ff24362054cfd861a1a9fb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Repair_Views), @"mvc.1.0.view", @"/Areas/BMED/Views/Repair/Views.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Repair/Views.cshtml", typeof(AspNetCore.Areas_BMED_Views_Repair_Views))]
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
#line 3 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml"
using EDIS.Models.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"593159631ae4e3c53ff24362054cfd861a1a9fb3", @"/Areas/BMED/Views/Repair/Views.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Repair_Views : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.RepairModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery-validation/dist/jquery.validate.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(141, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml"
  
    Layout = "~/Views/Shared/_PassedLayout.cshtml";
    ViewBag.Title = "預覽/請修";

    if (TempData["SendMsg"] != null)
    {

#line default
#line hidden
            BeginContext(277, 44, true);
            WriteLiteral("        <script>\r\n            var message = ");
            EndContext();
            BeginContext(322, 35, false);
#line 14 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml"
                     Write(Json.Serialize(TempData["SendMsg"]));

#line default
#line hidden
            EndContext();
            BeginContext(357, 51, true);
            WriteLiteral(";\r\n            alert(message);\r\n        </script>\r\n");
            EndContext();
#line 17 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml"
    }

#line default
#line hidden
            BeginContext(418, 82, true);
            WriteLiteral("\r\n<h2>預覽</h2>\r\n<h4>請修</h4>\r\n<hr />\r\n<div id=\"pnlFILES\" style=\"margin: 10pt\">\r\n    ");
            EndContext();
            BeginContext(501, 106, false);
#line 24 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml"
Write(await Component.InvokeAsync("BMEDAttainFileList", new { id = Model.DocId, typ = "1", viewType = "Views" }));

#line default
#line hidden
            EndContext();
            BeginContext(607, 23, true);
            WriteLiteral("\r\n</div>\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(631, 71, false);
#line 28 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml"
Write(await Component.InvokeAsync("BMEDRepDetail2", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(702, 533, true);
            WriteLiteral(@"
</div>

<ul class=""nav nav-pills"" style=""font-size:120%"">
    <li role=""presentation"" class=""active""><a href=""#repairdtl"" data-toggle=""tab"" style=""padding-left:20px"">請修紀錄與工時</a></li>
    <li role=""presentation""><a href=""#repaircost"" data-toggle=""tab"" style=""padding-left:20px"">費用明細</a></li>
    <li role=""presentation""><a href=""#repflowlist"" data-toggle=""tab"" style=""padding-left:20px"">流程紀錄</a></li>
</ul>
<hr />
<div class=""tab-content"">
    <div id=""repairdtl"" class=""tab-pane fade in active"">
        <p>
            ");
            EndContext();
            BeginContext(1236, 70, false);
#line 40 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml"
       Write(await Component.InvokeAsync("BMEDRepDetail", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(1306, 41, true);
            WriteLiteral("\r\n        </p>\r\n        <p>\r\n            ");
            EndContext();
            BeginContext(1348, 91, false);
#line 43 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml"
       Write(await Component.InvokeAsync("BMEDRepEmpList", new { id = Model.DocId, viewType = "Views" }));

#line default
#line hidden
            EndContext();
            BeginContext(1439, 104, true);
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div id=\"repaircost\" class=\"tab-pane fade\">\r\n        <div>\r\n            ");
            EndContext();
            BeginContext(1544, 92, false);
#line 48 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml"
       Write(await Component.InvokeAsync("BMEDRepCostList", new { id = Model.DocId, viewType = "Views" }));

#line default
#line hidden
            EndContext();
            BeginContext(1636, 107, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div id=\"repflowlist\" class=\"tab-pane fade\">\r\n        <div>\r\n            ");
            EndContext();
            BeginContext(1744, 72, false);
#line 53 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml"
       Write(await Component.InvokeAsync("BMEDRepFlowList", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(1816, 77, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <a class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1893, "\"", 1948, 1);
#line 59 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml"
WriteAttributeValue("", 1900, Url.Action("Index", "Home", new { Area = "" } ), 1900, 48, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1949, 43, true);
            WriteLiteral(">回到簽核列表</a>\r\n    <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1992, "\"", 2083, 1);
#line 60 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Views.cshtml"
WriteAttributeValue("", 1999, Url.Action("PrintRepairDoc", "Repair", new { Area = "BMED", DocId = Model.DocId } ), 1999, 84, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2084, 35, true);
            WriteLiteral(" target=\"_blank\">列印</a>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2137, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2143, 75, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "737d1ed3f6fb4a8890155a3546026dbf", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2218, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2224, 94, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af1996a25424496881fa360c24e86898", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2318, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CustomRoleManager RoleManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CustomUserManager UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.RepairModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
