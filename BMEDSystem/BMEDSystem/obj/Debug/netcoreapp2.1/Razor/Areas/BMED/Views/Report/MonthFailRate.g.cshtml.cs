#pragma checksum "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25b8925a0a571b75250fdea967ecf7b7756ab364"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Report_MonthFailRate), @"mvc.1.0.view", @"/Areas/BMED/Views/Report/MonthFailRate.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Report/MonthFailRate.cshtml", typeof(AspNetCore.Areas_BMED_Views_Report_MonthFailRate))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25b8925a0a571b75250fdea967ecf7b7756ab364", @"/Areas/BMED/Views/Report/MonthFailRate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Report_MonthFailRate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.MonthFailRateVModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/HtmltoExcel.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(80, 43, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "687029275aa748e99e917c04cff7da79", async() => {
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
            BeginContext(123, 216, true);
            WriteLiteral("\r\n\r\n<input id=\"exportExcel\" type=\"button\" value=\"匯出Excel\" class=\"btn btn-default\"\r\n       onclick=\"javascript:exportExcel(\'tbFailRate\')\" />\r\n<table class=\"table\" id=\"tbFailRate\">\r\n    <tr>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(340, 43, false);
#line 12 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
       Write(Html.DisplayNameFor(model => model.AssetNo));

#line default
#line hidden
            EndContext();
            BeginContext(383, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(427, 41, false);
#line 15 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
       Write(Html.DisplayNameFor(model => model.Cname));

#line default
#line hidden
            EndContext();
            BeginContext(468, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(512, 42, false);
#line 18 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
       Write(Html.DisplayNameFor(model => model.CustId));

#line default
#line hidden
            EndContext();
            BeginContext(554, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(598, 43, false);
#line 21 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
       Write(Html.DisplayNameFor(model => model.CustNam));

#line default
#line hidden
            EndContext();
            BeginContext(641, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(685, 46, false);
#line 24 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
       Write(Html.DisplayNameFor(model => model.RepairMins));

#line default
#line hidden
            EndContext();
            BeginContext(731, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(775, 45, false);
#line 27 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalMins));

#line default
#line hidden
            EndContext();
            BeginContext(820, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(864, 44, false);
#line 30 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
       Write(Html.DisplayNameFor(model => model.FailRate));

#line default
#line hidden
            EndContext();
            BeginContext(908, 30, true);
            WriteLiteral("\r\n        </th>\r\n    </tr>\r\n\r\n");
            EndContext();
#line 34 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(979, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1028, 42, false);
#line 38 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
           Write(Html.DisplayFor(modelItem => item.AssetNo));

#line default
#line hidden
            EndContext();
            BeginContext(1070, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1126, 40, false);
#line 41 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
           Write(Html.DisplayFor(modelItem => item.Cname));

#line default
#line hidden
            EndContext();
            BeginContext(1166, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1222, 41, false);
#line 44 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
           Write(Html.DisplayFor(modelItem => item.CustId));

#line default
#line hidden
            EndContext();
            BeginContext(1263, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1319, 42, false);
#line 47 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
           Write(Html.DisplayFor(modelItem => item.CustNam));

#line default
#line hidden
            EndContext();
            BeginContext(1361, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1417, 45, false);
#line 50 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
           Write(Html.DisplayFor(modelItem => item.RepairMins));

#line default
#line hidden
            EndContext();
            BeginContext(1462, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1518, 44, false);
#line 53 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalMins));

#line default
#line hidden
            EndContext();
            BeginContext(1562, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1618, 43, false);
#line 56 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
           Write(Html.DisplayFor(modelItem => item.FailRate));

#line default
#line hidden
            EndContext();
            BeginContext(1661, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 59 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\MonthFailRate.cshtml"
    }

#line default
#line hidden
            BeginContext(1704, 12, true);
            WriteLiteral("\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.MonthFailRateVModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
