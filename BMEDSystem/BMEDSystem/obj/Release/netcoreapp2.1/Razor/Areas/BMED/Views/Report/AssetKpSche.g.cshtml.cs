#pragma checksum "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad703e3386701463aef4c1e934e625c587351b95"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Report_AssetKpSche), @"mvc.1.0.view", @"/Areas/BMED/Views/Report/AssetKpSche.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Report/AssetKpSche.cshtml", typeof(AspNetCore.Areas_BMED_Views_Report_AssetKpSche))]
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
#line 2 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad703e3386701463aef4c1e934e625c587351b95", @"/Areas/BMED/Views/Report/AssetKpSche.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Report_AssetKpSche : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.AssetKpScheVModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
  
    Layout = null;
    var qry2 = JsonConvert.DeserializeObject<ReportQryVModel>(TempData["qry2"].ToString());

#line default
#line hidden
            BeginContext(195, 288, true);
            WriteLiteral(@"<style type=""text/css"">
    .Sche {
        font-size: 2.5em;
        text-align: center;
    }

    .hdtitle {
        margin-top: 5px;
    }

    .table-hover > tbody > tr:hover {
        background-color: cornflowerblue;
    }
</style>
<p>
    <a class=""btn btn-default""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 483, "\"", 527, 1);
#line 22 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
WriteAttributeValue("", 490, Url.Action("AssetKpScheExcel", qry2), 490, 37, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(528, 106, true);
            WriteLiteral(">匯出Excel</a>\r\n</p>\r\n<table class=\"table table-bordered table-hover\">\r\n    <tr>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(635, 43, false);
#line 27 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.AssetNo));

#line default
#line hidden
            EndContext();
            BeginContext(678, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(722, 45, false);
#line 30 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.AssetName));

#line default
#line hidden
            EndContext();
            BeginContext(767, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(811, 48, false);
#line 33 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.DelivDptName));

#line default
#line hidden
            EndContext();
            BeginContext(859, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(903, 41, false);
#line 36 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Brand));

#line default
#line hidden
            EndContext();
            BeginContext(944, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(988, 40, false);
#line 39 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
            EndContext();
            BeginContext(1028, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1072, 39, false);
#line 42 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Jan));

#line default
#line hidden
            EndContext();
            BeginContext(1111, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1155, 39, false);
#line 45 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Feb));

#line default
#line hidden
            EndContext();
            BeginContext(1194, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1238, 39, false);
#line 48 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Mar));

#line default
#line hidden
            EndContext();
            BeginContext(1277, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1321, 39, false);
#line 51 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Apr));

#line default
#line hidden
            EndContext();
            BeginContext(1360, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1404, 39, false);
#line 54 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.May));

#line default
#line hidden
            EndContext();
            BeginContext(1443, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1487, 39, false);
#line 57 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Jun));

#line default
#line hidden
            EndContext();
            BeginContext(1526, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1570, 39, false);
#line 60 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Jul));

#line default
#line hidden
            EndContext();
            BeginContext(1609, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1653, 39, false);
#line 63 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Aug));

#line default
#line hidden
            EndContext();
            BeginContext(1692, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1736, 39, false);
#line 66 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Sep));

#line default
#line hidden
            EndContext();
            BeginContext(1775, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1819, 39, false);
#line 69 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Oct));

#line default
#line hidden
            EndContext();
            BeginContext(1858, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1902, 39, false);
#line 72 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Nov));

#line default
#line hidden
            EndContext();
            BeginContext(1941, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1985, 39, false);
#line 75 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
       Write(Html.DisplayNameFor(model => model.Dec));

#line default
#line hidden
            EndContext();
            BeginContext(2024, 30, true);
            WriteLiteral("\r\n        </th>\r\n    </tr>\r\n\r\n");
            EndContext();
#line 79 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(2095, 67, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                <p class=\"hdtitle\">");
            EndContext();
            BeginContext(2163, 42, false);
#line 83 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
                              Write(Html.DisplayFor(modelItem => item.AssetNo));

#line default
#line hidden
            EndContext();
            BeginContext(2205, 78, true);
            WriteLiteral("</p>\r\n            </td>\r\n            <td>\r\n                <p class=\"hdtitle\">");
            EndContext();
            BeginContext(2284, 44, false);
#line 86 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
                              Write(Html.DisplayFor(modelItem => item.AssetName));

#line default
#line hidden
            EndContext();
            BeginContext(2328, 78, true);
            WriteLiteral("</p>\r\n            </td>\r\n            <td>\r\n                <p class=\"hdtitle\">");
            EndContext();
            BeginContext(2407, 47, false);
#line 89 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
                              Write(Html.DisplayFor(modelItem => item.DelivDptName));

#line default
#line hidden
            EndContext();
            BeginContext(2454, 78, true);
            WriteLiteral("</p>\r\n            </td>\r\n            <td>\r\n                <p class=\"hdtitle\">");
            EndContext();
            BeginContext(2533, 40, false);
#line 92 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
                              Write(Html.DisplayFor(modelItem => item.Brand));

#line default
#line hidden
            EndContext();
            BeginContext(2573, 78, true);
            WriteLiteral("</p>\r\n            </td>\r\n            <td>\r\n                <p class=\"hdtitle\">");
            EndContext();
            BeginContext(2652, 39, false);
#line 95 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
                              Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
            EndContext();
            BeginContext(2691, 72, true);
            WriteLiteral("</p>\r\n            </td>\r\n            <td class=\"Sche\">\r\n                ");
            EndContext();
            BeginContext(2764, 38, false);
#line 98 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
           Write(Html.DisplayFor(modelItem => item.Jan));

#line default
#line hidden
            EndContext();
            BeginContext(2802, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td class=\"Sche\">\r\n                ");
            EndContext();
            BeginContext(2871, 38, false);
#line 101 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
           Write(Html.DisplayFor(modelItem => item.Feb));

#line default
#line hidden
            EndContext();
            BeginContext(2909, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td class=\"Sche\">\r\n                ");
            EndContext();
            BeginContext(2978, 38, false);
#line 104 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
           Write(Html.DisplayFor(modelItem => item.Mar));

#line default
#line hidden
            EndContext();
            BeginContext(3016, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td class=\"Sche\">\r\n                ");
            EndContext();
            BeginContext(3085, 38, false);
#line 107 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
           Write(Html.DisplayFor(modelItem => item.Apr));

#line default
#line hidden
            EndContext();
            BeginContext(3123, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td class=\"Sche\">\r\n                ");
            EndContext();
            BeginContext(3192, 38, false);
#line 110 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
           Write(Html.DisplayFor(modelItem => item.May));

#line default
#line hidden
            EndContext();
            BeginContext(3230, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td class=\"Sche\">\r\n                ");
            EndContext();
            BeginContext(3299, 38, false);
#line 113 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
           Write(Html.DisplayFor(modelItem => item.Jun));

#line default
#line hidden
            EndContext();
            BeginContext(3337, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td class=\"Sche\">\r\n                ");
            EndContext();
            BeginContext(3406, 38, false);
#line 116 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
           Write(Html.DisplayFor(modelItem => item.Jul));

#line default
#line hidden
            EndContext();
            BeginContext(3444, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td class=\"Sche\">\r\n                ");
            EndContext();
            BeginContext(3513, 38, false);
#line 119 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
           Write(Html.DisplayFor(modelItem => item.Aug));

#line default
#line hidden
            EndContext();
            BeginContext(3551, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td class=\"Sche\">\r\n                ");
            EndContext();
            BeginContext(3620, 38, false);
#line 122 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
           Write(Html.DisplayFor(modelItem => item.Sep));

#line default
#line hidden
            EndContext();
            BeginContext(3658, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td class=\"Sche\">\r\n                ");
            EndContext();
            BeginContext(3727, 38, false);
#line 125 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
           Write(Html.DisplayFor(modelItem => item.Oct));

#line default
#line hidden
            EndContext();
            BeginContext(3765, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td class=\"Sche\">\r\n                ");
            EndContext();
            BeginContext(3834, 38, false);
#line 128 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nov));

#line default
#line hidden
            EndContext();
            BeginContext(3872, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td class=\"Sche\">\r\n                ");
            EndContext();
            BeginContext(3941, 38, false);
#line 131 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
           Write(Html.DisplayFor(modelItem => item.Dec));

#line default
#line hidden
            EndContext();
            BeginContext(3979, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 134 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\AssetKpSche.cshtml"
    }

#line default
#line hidden
            BeginContext(4022, 12, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.AssetKpScheVModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
