#pragma checksum "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9903c6ba2f1dadf6e6821e41145e91ca3eeb0b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Keep_Views), @"mvc.1.0.view", @"/Areas/BMED/Views/Keep/Views.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Keep/Views.cshtml", typeof(AspNetCore.Areas_BMED_Views_Keep_Views))]
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
#line 3 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
using EDIS.Models.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9903c6ba2f1dadf6e6821e41145e91ca3eeb0b2", @"/Areas/BMED/Views/Keep/Views.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Keep_Views : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.KeepModel>
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
            BeginContext(30, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(139, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
  
    Layout = "~/Views/Shared/_PassedLayout.cshtml";
    ViewBag.Title = "預覽/保養";

    if (TempData["SendMsg"] != null)
    {

#line default
#line hidden
            BeginContext(275, 44, true);
            WriteLiteral("        <script>\r\n            var message = ");
            EndContext();
            BeginContext(320, 35, false);
#line 14 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
                     Write(Json.Serialize(TempData["SendMsg"]));

#line default
#line hidden
            EndContext();
            BeginContext(355, 51, true);
            WriteLiteral(";\r\n            alert(message);\r\n        </script>\r\n");
            EndContext();
#line 17 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
    }

#line default
#line hidden
            BeginContext(416, 82, true);
            WriteLiteral("\r\n<h2>預覽</h2>\r\n<h4>保養</h4>\r\n<hr />\r\n<div id=\"pnlFILES\" style=\"margin: 10pt\">\r\n    ");
            EndContext();
            BeginContext(499, 106, false);
#line 24 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
Write(await Component.InvokeAsync("BMEDAttainFileList", new { id = Model.DocId, typ = "2", viewType = "Views" }));

#line default
#line hidden
            EndContext();
            BeginContext(605, 23, true);
            WriteLiteral("\r\n</div>\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(629, 71, false);
#line 28 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
Write(await Component.InvokeAsync("BMEDKeepDetail", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(700, 635, true);
            WriteLiteral(@"
</div>

<ul class=""nav nav-pills"" style=""font-size:120%"">
    <li role=""presentation"" class=""active""><a href=""#keepdtl"" data-toggle=""tab"" style=""padding-left:20px"">保養紀錄與工時</a></li>
    <li role=""presentation""><a href=""#keeprecord"" data-toggle=""tab"" style=""padding-left:20px"">保養項目登錄</a></li>
    <li role=""presentation""><a href=""#keepcost"" data-toggle=""tab"" style=""padding-left:20px"">費用明細</a></li>
    <li role=""presentation""><a href=""#flowlist"" data-toggle=""tab"" style=""padding-left:20px"">流程紀錄</a></li>
</ul>
<hr />
<div class=""tab-content"">
    <div id=""keepdtl"" class=""tab-pane fade in active"">
        <p>
            ");
            EndContext();
            BeginContext(1336, 74, false);
#line 41 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
       Write(await Component.InvokeAsync("BMEDKeepDtlDetail", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(1410, 41, true);
            WriteLiteral("\r\n        </p>\r\n        <p>\r\n            ");
            EndContext();
            BeginContext(1452, 92, false);
#line 44 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
       Write(await Component.InvokeAsync("BMEDKeepEmpList", new { id = Model.DocId, viewType = "Views" }));

#line default
#line hidden
            EndContext();
            BeginContext(1544, 102, true);
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div id=\"keeprecord\" class=\"tab-pane fade\">\r\n        <p>\r\n            ");
            EndContext();
            BeginContext(1647, 77, false);
#line 49 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
       Write(await Component.InvokeAsync("BMEDKeepRecordDetail", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(1724, 102, true);
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div id=\"keepcost\" class=\"tab-pane fade\">\r\n        <div>\r\n            ");
            EndContext();
            BeginContext(1827, 93, false);
#line 54 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
       Write(await Component.InvokeAsync("BMEDKeepCostList", new { id = Model.DocId, viewType = "Views" }));

#line default
#line hidden
            EndContext();
            BeginContext(1920, 104, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div id=\"flowlist\" class=\"tab-pane fade\">\r\n        <div>\r\n            ");
            EndContext();
            BeginContext(2025, 73, false);
#line 59 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
       Write(await Component.InvokeAsync("BMEDKeepFlowList", new { id = Model.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(2098, 77, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <a class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2175, "\"", 2230, 1);
#line 65 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
WriteAttributeValue("", 2182, Url.Action("Index", "Home", new { Area = "" } ), 2182, 48, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2231, 43, true);
            WriteLiteral(">回到簽核列表</a>\r\n    <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2274, "\"", 2361, 1);
#line 66 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Views.cshtml"
WriteAttributeValue("", 2281, Url.Action("PrintKeepDoc", "Keep", new { Area = "BMED", DocId = Model.DocId } ), 2281, 80, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2362, 35, true);
            WriteLiteral(" target=\"_blank\">列印</a>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2415, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2421, 75, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f15f725c079f4e0cba41be156951c92b", async() => {
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
                BeginContext(2496, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2502, 94, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1e0d5799a9b45d483fba8b948194821", async() => {
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
                BeginContext(2596, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.KeepModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
