#pragma checksum "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cdf42890071203168a7f728d1146450d17cb4b49"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Repair_Edit), @"mvc.1.0.view", @"/Areas/BMED/Views/Repair/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Repair/Edit.cshtml", typeof(AspNetCore.Areas_BMED_Views_Repair_Edit))]
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
#line 3 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
using EDIS.Models.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cdf42890071203168a7f728d1146450d17cb4b49", @"/Areas/BMED/Views/Repair/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Repair_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.RepairModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery-validation/dist/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 7 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
  
    Layout = "~/Views/Shared/_PassedLayout.cshtml";
    ViewBag.Title = "編輯/請修";

    if (TempData["SendMsg"] != null)
    {

#line default
#line hidden
            BeginContext(277, 44, true);
            WriteLiteral("        <script>\r\n            var message = ");
            EndContext();
            BeginContext(322, 35, false);
#line 14 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
                     Write(Json.Serialize(TempData["SendMsg"]));

#line default
#line hidden
            EndContext();
            BeginContext(357, 51, true);
            WriteLiteral(";\r\n            alert(message);\r\n        </script>\r\n");
            EndContext();
#line 17 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
    }

#line default
#line hidden
            BeginContext(418, 58, true);
            WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        var activePage = ");
            EndContext();
            BeginContext(477, 16, false);
#line 22 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
                    Write(ViewData["Page"]);

#line default
#line hidden
            EndContext();
            BeginContext(493, 209, true);
            WriteLiteral(";\r\n        if (activePage != 0) {\r\n            $(\"#page\" + activePage).children(\"a\").click();\r\n        }\r\n    });\r\n</script>\r\n\r\n<h2>編輯</h2>\r\n<h4>請修單</h4>\r\n<hr />\r\n<div id=\"pnlFILES\" style=\"margin: 10pt\">\r\n    ");
            EndContext();
            BeginContext(703, 105, false);
#line 33 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
Write(await Component.InvokeAsync("BMEDAttainFileList", new { id = Model.DocId, typ = "1", viewType = "Edit" }));

#line default
#line hidden
            EndContext();
            BeginContext(808, 601, true);
            WriteLiteral(@"
</div>
<div class=""form-group"">
    <div>
        <input id=""btnFILES"" type=""button"" value=""夾帶附件檔案"" class=""btn btn-default"" data-toggle=""modal"" data-target=""#modalFILES"">
    </div>
</div>
<!-- 夾帶檔案 Modal -->
<div id=""modalFILES"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                <h4 class=""modal-title"">選擇上傳檔案</h4>
            </div>
            <div class=""modal-body"">
                ");
            EndContext();
            BeginContext(1410, 110, false);
#line 49 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
           Write(await Component.InvokeAsync("BMEDAttainFileUpload", new { doctype = "1", docid = Model.DocId, viewType = "" }));

#line default
#line hidden
            EndContext();
            BeginContext(1520, 239, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"modal-footer\">\r\n                <button type=\"button\" class=\"btn btn-default\" data-dismiss=\"modal\">離開</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div id=\"pnlREPDTL2\">\r\n");
            EndContext();
#line 59 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
     if (UserManager.IsInRole(User, "MedEngineer") == true || UserManager.IsInRole(User, "MedAdmin") == true ||
         UserManager.IsInRole(User, "Admin") == true)
    {
        

#line default
#line hidden
            BeginContext(1943, 68, false);
#line 62 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
   Write(await Component.InvokeAsync("BMEDRepEdit", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
#line 62 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
                                                                             
    }
    else
    {
        

#line default
#line hidden
            BeginContext(2046, 71, false);
#line 66 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
   Write(await Component.InvokeAsync("BMEDRepDetail2", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
#line 66 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
                                                                                
    }

#line default
#line hidden
            BeginContext(2126, 198, true);
            WriteLiteral("</div>\r\n\r\n<ul class=\"nav nav-pills\" style=\"font-size:120%\">\r\n    <li role=\"presentation\" id=\"page1\" class=\"active\"><a href=\"#repairdtl\" data-toggle=\"tab\" style=\"padding-left:20px\">請修紀錄與工時</a></li>\r\n");
            EndContext();
            BeginContext(2687, 120, true);
            WriteLiteral("    <li role=\"presentation\" id=\"page2\"><a href=\"#repaircost\" data-toggle=\"tab\" style=\"padding-left:20px\">費用明細</a></li>\r\n");
            EndContext();
            BeginContext(2932, 244, true);
            WriteLiteral("    <li role=\"presentation\" id=\"page3\"><a href=\"#repairflow\" data-toggle=\"tab\" style=\"padding-left:20px\">簽核作業</a></li>\r\n</ul>\r\n<hr />\r\n<div class=\"tab-content\">\r\n    <div id=\"repairdtl\" class=\"tab-pane fad in active\">\r\n        <p>\r\n            ");
            EndContext();
            BeginContext(3177, 71, false);
#line 83 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
       Write(await Component.InvokeAsync("BMEDRepDtlEdit", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(3248, 41, true);
            WriteLiteral("\r\n        </p>\r\n        <p>\r\n            ");
            EndContext();
            BeginContext(3290, 74, false);
#line 86 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
       Write(await Component.InvokeAsync("BMEDRepEmpEdit", new { DocId = Model.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(3364, 104, true);
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div id=\"repaircost\" class=\"tab-pane fade\">\r\n        <div>\r\n            ");
            EndContext();
            BeginContext(3469, 72, false);
#line 91 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
       Write(await Component.InvokeAsync("BMEDRepCostEdit", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(3541, 106, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div id=\"repairflow\" class=\"tab-pane fade\">\r\n        <div>\r\n            ");
            EndContext();
            BeginContext(3648, 72, false);
#line 96 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
       Write(await Component.InvokeAsync("BMEDRepNextFlow", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(3720, 45, true);
            WriteLiteral("\r\n        </div>\r\n        <div>\r\n            ");
            EndContext();
            BeginContext(3766, 72, false);
#line 99 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
       Write(await Component.InvokeAsync("BMEDRepFlowList", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(3838, 77, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <a class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3915, "\"", 3970, 1);
#line 105 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
WriteAttributeValue("", 3922, Url.Action("Index", "Home", new { Area = "" } ), 3922, 48, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3971, 56, true);
            WriteLiteral(" id=\"homeBtn\">回到簽核列表</a>\r\n    <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4027, "\"", 4118, 1);
#line 106 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\Edit.cshtml"
WriteAttributeValue("", 4034, Url.Action("PrintRepairDoc", "Repair", new { Area = "BMED", DocId = Model.DocId } ), 4034, 84, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4119, 35, true);
            WriteLiteral(" target=\"_blank\">列印</a>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4172, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4178, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35de07487f41479cbcbbd6d2af03673b", async() => {
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
                BeginContext(4249, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4255, 90, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6811032c975433691af48ccf626a086", async() => {
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
                BeginContext(4345, 2, true);
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
