#pragma checksum "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb2518496cc5121313a45d8370a37dbc4cb76ca0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Report_RepeatFail), @"mvc.1.0.view", @"/Areas/BMED/Views/Report/RepeatFail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Report/RepeatFail.cshtml", typeof(AspNetCore.Areas_BMED_Views_Report_RepeatFail))]
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
#line 2 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb2518496cc5121313a45d8370a37dbc4cb76ca0", @"/Areas/BMED/Views/Report/RepeatFail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Report_RepeatFail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.RepeatFailVModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
  
    Layout = null;
    var qry = JsonConvert.DeserializeObject<ReportQryVModel>(TempData["qry"].ToString());

#line default
#line hidden
            BeginContext(192, 37, true);
            WriteLiteral("\r\n<p>\r\n    <a class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 229, "\"", 263, 1);
#line 9 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
WriteAttributeValue("", 236, Url.Action("ExcelRF", qry), 236, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(264, 119, true);
            WriteLiteral(">匯出Excel</a>\r\n</p>\r\n<table class=\"table\">\r\n    <tr>\r\n        <th style=\"width: 100px; text-align: right\">\r\n            ");
            EndContext();
            BeginContext(384, 41, false);
#line 14 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
       Write(Html.DisplayNameFor(model => model.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(425, 83, true);
            WriteLiteral("\r\n        </th>\r\n        <th style=\"width: 100px; text-align: right\">\r\n            ");
            EndContext();
            BeginContext(509, 45, false);
#line 17 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
       Write(Html.DisplayNameFor(model => model.ApplyDate));

#line default
#line hidden
            EndContext();
            BeginContext(554, 69, true);
            WriteLiteral("\r\n        </th>\r\n        <th style=\"text-align: right\">\r\n            ");
            EndContext();
            BeginContext(624, 43, false);
#line 20 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
       Write(Html.DisplayNameFor(model => model.CustNam));

#line default
#line hidden
            EndContext();
            BeginContext(667, 83, true);
            WriteLiteral("\r\n        </th>\r\n        <th style=\"width: 100px; text-align: right\">\r\n            ");
            EndContext();
            BeginContext(751, 43, false);
#line 23 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
       Write(Html.DisplayNameFor(model => model.AssetNo));

#line default
#line hidden
            EndContext();
            BeginContext(794, 83, true);
            WriteLiteral("\r\n        </th>\r\n        <th style=\"width: 100px; text-align: right\">\r\n            ");
            EndContext();
            BeginContext(878, 40, false);
#line 26 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
       Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
            EndContext();
            BeginContext(918, 65, true);
            WriteLiteral("\r\n        </th>\r\n        <th style=\"width: 100px;\">\r\n            ");
            EndContext();
            BeginContext(984, 46, false);
#line 29 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
       Write(Html.DisplayNameFor(model => model.TroubleDes));

#line default
#line hidden
            EndContext();
            BeginContext(1030, 65, true);
            WriteLiteral("\r\n        </th>\r\n        <th style=\"width: 100px;\">\r\n            ");
            EndContext();
            BeginContext(1096, 46, false);
#line 32 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
       Write(Html.DisplayNameFor(model => model.FailFactor));

#line default
#line hidden
            EndContext();
            BeginContext(1142, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1186, 43, false);
#line 35 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
       Write(Html.DisplayNameFor(model => model.DealDes));

#line default
#line hidden
            EndContext();
            BeginContext(1229, 83, true);
            WriteLiteral("\r\n        </th>\r\n        <th style=\"width: 100px; text-align: right\">\r\n            ");
            EndContext();
            BeginContext(1313, 43, false);
#line 38 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
       Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(1356, 30, true);
            WriteLiteral("\r\n        </th>\r\n    </tr>\r\n\r\n");
            EndContext();
#line 42 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(1427, 74, true);
            WriteLiteral("        <tr>\r\n            <td style=\"text-align: right\">\r\n                ");
            EndContext();
            BeginContext(1502, 40, false);
#line 46 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
           Write(Html.DisplayFor(modelItem => item.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(1542, 81, true);
            WriteLiteral("\r\n            </td>\r\n            <td style=\"text-align: right\">\r\n                ");
            EndContext();
            BeginContext(1624, 37, false);
#line 49 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
           Write(item.ApplyDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
            EndContext();
            BeginContext(1661, 81, true);
            WriteLiteral("\r\n            </td>\r\n            <td style=\"text-align: right\">\r\n                ");
            EndContext();
            BeginContext(1743, 42, false);
#line 52 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
           Write(Html.DisplayFor(modelItem => item.CustNam));

#line default
#line hidden
            EndContext();
            BeginContext(1785, 81, true);
            WriteLiteral("\r\n            </td>\r\n            <td style=\"text-align: right\">\r\n                ");
            EndContext();
            BeginContext(1867, 12, false);
#line 55 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
           Write(item.AssetNo);

#line default
#line hidden
            EndContext();
            BeginContext(1879, 25, true);
            WriteLiteral(" <br />\r\n                ");
            EndContext();
            BeginContext(1905, 13, false);
#line 56 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
           Write(item.AssetNam);

#line default
#line hidden
            EndContext();
            BeginContext(1918, 81, true);
            WriteLiteral("\r\n            </td>\r\n            <td style=\"text-align: right\">\r\n                ");
            EndContext();
            BeginContext(2000, 39, false);
#line 59 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
           Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
            EndContext();
            BeginContext(2039, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2095, 45, false);
#line 62 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
           Write(Html.DisplayFor(modelItem => item.TroubleDes));

#line default
#line hidden
            EndContext();
            BeginContext(2140, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2196, 45, false);
#line 65 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
           Write(Html.DisplayFor(modelItem => item.FailFactor));

#line default
#line hidden
            EndContext();
            BeginContext(2241, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2297, 42, false);
#line 68 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
           Write(Html.DisplayFor(modelItem => item.DealDes));

#line default
#line hidden
            EndContext();
            BeginContext(2339, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2395, 35, false);
#line 71 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
           Write(item.EndDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
            EndContext();
            BeginContext(2430, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 74 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RepeatFail.cshtml"
    }

#line default
#line hidden
            BeginContext(2473, 12, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.RepeatFailVModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
