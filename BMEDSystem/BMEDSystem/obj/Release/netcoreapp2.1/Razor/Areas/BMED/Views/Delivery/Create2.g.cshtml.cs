#pragma checksum "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98d04f48dfcfc22f27c23a9c9fb65528ebbce12b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Delivery_Create2), @"mvc.1.0.view", @"/Areas/BMED/Views/Delivery/Create2.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Delivery/Create2.cshtml", typeof(AspNetCore.Areas_BMED_Views_Delivery_Create2))]
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
#line 1 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS;

#line default
#line hidden
#line 3 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models;

#line default
#line hidden
#line 4 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98d04f48dfcfc22f27c23a9c9fb65528ebbce12b", @"/Areas/BMED/Views/Delivery/Create2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Delivery_Create2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.DeliveryModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/jquery-1.7.1.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/jquery.unobtrusive-ajax.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/BMED/VendorChoose.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30e38392067440c0a4dde2867b4aa37e", async() => {
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
            BeginContext(83, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(85, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bdf05eb13303493dbf7ff1e4a1123aa5", async() => {
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
            BeginContext(145, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 5 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
  
    ViewBag.Title = "驗收單/新增";

#line default
#line hidden
            BeginContext(187, 21, true);
            WriteLiteral("\r\n<h2>驗收單/新增</h2>\r\n\r\n");
            EndContext();
#line 11 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(243, 23, false);
#line 13 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(273, 28, false);
#line 14 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
            EndContext();
            BeginContext(305, 59, true);
            WriteLiteral("    <fieldset>\r\n        <legend>Delivery</legend>\r\n        ");
            EndContext();
            BeginContext(365, 36, false);
#line 18 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
   Write(Html.HiddenFor(model => model.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(401, 50, true);
            WriteLiteral("\r\n        <div class=\"editor-label\">\r\n            ");
            EndContext();
            BeginContext(452, 36, false);
#line 20 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.UserId));

#line default
#line hidden
            EndContext();
            BeginContext(488, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(555, 37, false);
#line 23 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.EditorFor(model => model.UserId));

#line default
#line hidden
            EndContext();
            BeginContext(592, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(607, 39, false);
#line 24 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.EditorFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(646, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(661, 48, false);
#line 25 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.UserId));

#line default
#line hidden
            EndContext();
            BeginContext(709, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(724, 50, false);
#line 26 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(774, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-label\">\r\n            ");
            EndContext();
            BeginContext(841, 37, false);
#line 29 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.Company));

#line default
#line hidden
            EndContext();
            BeginContext(878, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(945, 38, false);
#line 32 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.EditorFor(model => model.Company));

#line default
#line hidden
            EndContext();
            BeginContext(983, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(998, 49, false);
#line 33 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.Company));

#line default
#line hidden
            EndContext();
            BeginContext(1047, 68, true);
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"editor-label\">\r\n            ");
            EndContext();
            BeginContext(1116, 37, false);
#line 37 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.Contact));

#line default
#line hidden
            EndContext();
            BeginContext(1153, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(1220, 38, false);
#line 40 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.EditorFor(model => model.Contact));

#line default
#line hidden
            EndContext();
            BeginContext(1258, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1273, 49, false);
#line 41 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.Contact));

#line default
#line hidden
            EndContext();
            BeginContext(1322, 68, true);
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"editor-label\">\r\n            ");
            EndContext();
            BeginContext(1391, 39, false);
#line 45 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.ApplyDate));

#line default
#line hidden
            EndContext();
            BeginContext(1430, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(1497, 40, false);
#line 48 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.EditorFor(model => model.ApplyDate));

#line default
#line hidden
            EndContext();
            BeginContext(1537, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1552, 51, false);
#line 49 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.ApplyDate));

#line default
#line hidden
            EndContext();
            BeginContext(1603, 68, true);
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"editor-label\">\r\n            ");
            EndContext();
            BeginContext(1672, 36, false);
#line 53 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.AccDpt));

#line default
#line hidden
            EndContext();
            BeginContext(1708, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(1775, 37, false);
#line 56 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.EditorFor(model => model.AccDpt));

#line default
#line hidden
            EndContext();
            BeginContext(1812, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1827, 40, false);
#line 57 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.EditorFor(model => model.AccDptNam));

#line default
#line hidden
            EndContext();
            BeginContext(1867, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1882, 48, false);
#line 58 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.AccDpt));

#line default
#line hidden
            EndContext();
            BeginContext(1930, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1945, 51, false);
#line 59 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.AccDptNam));

#line default
#line hidden
            EndContext();
            BeginContext(1996, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-label\">\r\n            ");
            EndContext();
            BeginContext(2063, 40, false);
#line 62 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.ContractNo));

#line default
#line hidden
            EndContext();
            BeginContext(2103, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(2170, 41, false);
#line 65 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.EditorFor(model => model.ContractNo));

#line default
#line hidden
            EndContext();
            BeginContext(2211, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(2226, 52, false);
#line 66 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.ContractNo));

#line default
#line hidden
            EndContext();
            BeginContext(2278, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-label\">\r\n            ");
            EndContext();
            BeginContext(2345, 38, false);
#line 69 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.WartyMon));

#line default
#line hidden
            EndContext();
            BeginContext(2383, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(2450, 39, false);
#line 72 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.EditorFor(model => model.WartyMon));

#line default
#line hidden
            EndContext();
            BeginContext(2489, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(2504, 50, false);
#line 73 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.WartyMon));

#line default
#line hidden
            EndContext();
            BeginContext(2554, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-label\">\r\n            ");
            EndContext();
            BeginContext(2621, 40, false);
#line 76 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.PurchaseNo));

#line default
#line hidden
            EndContext();
            BeginContext(2661, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(2728, 41, false);
#line 79 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.EditorFor(model => model.PurchaseNo));

#line default
#line hidden
            EndContext();
            BeginContext(2769, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(2784, 52, false);
#line 80 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.PurchaseNo));

#line default
#line hidden
            EndContext();
            BeginContext(2836, 68, true);
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"editor-label\">\r\n            ");
            EndContext();
            BeginContext(2905, 40, false);
#line 84 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.DelivDateR));

#line default
#line hidden
            EndContext();
            BeginContext(2945, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(3012, 41, false);
#line 87 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.EditorFor(model => model.DelivDateR));

#line default
#line hidden
            EndContext();
            BeginContext(3053, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(3068, 52, false);
#line 88 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.DelivDateR));

#line default
#line hidden
            EndContext();
            BeginContext(3120, 67, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"display-label\">\r\n            ");
            EndContext();
            BeginContext(3188, 35, false);
#line 91 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.EngId));

#line default
#line hidden
            EndContext();
            BeginContext(3223, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(3290, 73, false);
#line 94 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.DropDownListFor(model => model.EngId, ViewData["ENG"] as SelectList));

#line default
#line hidden
            EndContext();
            BeginContext(3363, 67, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"display-label\">\r\n            ");
            EndContext();
            BeginContext(3431, 41, false);
#line 97 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.PurchaserId));

#line default
#line hidden
            EndContext();
            BeginContext(3472, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(3539, 79, false);
#line 100 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.DropDownListFor(model => model.PurchaserId, ViewData["PUR"] as SelectList));

#line default
#line hidden
            EndContext();
            BeginContext(3618, 67, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"display-label\">\r\n            ");
            EndContext();
            BeginContext(3686, 38, false);
#line 103 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.VendorId));

#line default
#line hidden
            EndContext();
            BeginContext(3724, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(3791, 100, false);
#line 106 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.DropDownListFor(model => model.VendorId, ViewData["Vendors"] as SelectList, optionLabel: "請選擇"));

#line default
#line hidden
            EndContext();
            BeginContext(3891, 1970, true);
            WriteLiteral(@"<span id=""msg"" style=""color: red""></span>
            <script>
                $('#VendorNo').change(function () {
                    $.fn.addItems = function (data) {

                        return this.each(function () {
                            var list = this;
                            list.add(new Option(""請選擇"", """"));
                            $.each(data, function (val, text) {

                                var option = new Option(text.Text, text.Value);
                                list.add(option);
                            });
                        });
                    };
                    var select = $('#SelDelivPson');
                    $('option', select).remove();
                    $.ajax({
                        url: '../../Vendor/IsInVendor',
                        type: ""POST"",
                        async: true,
                        dataType: ""json"",
                        data: ""uniteno="" + $(this).val(),
                        succe");
            WriteLiteral(@"ss: function (data) {
                            $('#msg').html(data);
                            if (data != """") {
                                $('#btnSEND').prop(""disabled"", true);
                            }
                            else {
                                $('#btnSEND').removeProp(""disabled"");
                            }
                        }
                    });
                    $.ajax({
                        url: '../../Vendor/GetMembers',
                        type: ""POST"",
                        async: true,
                        dataType: ""json"",
                        data: ""uniteno="" + $(this).val(),
                        success: function (data) {
                            select.addItems(data);
                        }
                    });
                });

            </script>
        </div>
        <div class=""display-label"">
            ");
            EndContext();
            BeginContext(5862, 39, false);
#line 154 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.DelivPson));

#line default
#line hidden
            EndContext();
            BeginContext(5901, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(5968, 116, false);
#line 157 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.DropDownListFor(model => model.DelivPson, ViewData["Item2"] as SelectList, "請選擇", new { @id = "SelDelivPson" }));

#line default
#line hidden
            EndContext();
            BeginContext(6084, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(6099, 51, false);
#line 158 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.DelivPson));

#line default
#line hidden
            EndContext();
            BeginContext(6150, 139, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"display-label\">\r\n            使用單位人員\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(6290, 97, false);
#line 164 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.DropDownListFor(model => model.UserDpt, ViewData["Users"] as SelectList, optionLabel: "請選擇"));

#line default
#line hidden
            EndContext();
            BeginContext(6387, 67, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"display-label\">\r\n            ");
            EndContext();
            BeginContext(6455, 34, false);
#line 167 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.LabelFor(model => model.Memo));

#line default
#line hidden
            EndContext();
            BeginContext(6489, 66, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-field\">\r\n            ");
            EndContext();
            BeginContext(6556, 37, false);
#line 170 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.TextAreaFor(model => model.Memo));

#line default
#line hidden
            EndContext();
            BeginContext(6593, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(6608, 46, false);
#line 171 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
       Write(Html.ValidationMessageFor(model => model.Memo));

#line default
#line hidden
            EndContext();
            BeginContext(6654, 144, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"display-label\">\r\n            儀器列表\r\n        </div>\r\n        <div style=\"padding-left: 20px; color: gray\">\r\n");
            EndContext();
            BeginContext(6907, 123, true);
            WriteLiteral("        </div>\r\n        <p>\r\n            <input id=\"btnSEND\" type=\"submit\" value=\"確定送出\" />\r\n        </p>\r\n    </fieldset>\r\n");
            EndContext();
#line 183 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
}

#line default
#line hidden
            BeginContext(7033, 13, true);
            WriteLiteral("\r\n<div>\r\n    ");
            EndContext();
            BeginContext(7047, 32, false);
#line 186 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
Write(Html.ActionLink("回到列表", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(7079, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(7109, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 190 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
                BeginContext(7179, 4, true);
                WriteLiteral("    ");
                EndContext();
                BeginContext(7183, 75, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "902d0deeab864a67bdf53a863673aaf3", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 191 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\Create2.cshtml"
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
                BeginContext(7258, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.DeliveryModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
