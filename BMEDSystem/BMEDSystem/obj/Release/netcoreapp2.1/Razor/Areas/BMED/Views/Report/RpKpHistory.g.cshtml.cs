#pragma checksum "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2580fcfd2507252a6a4ab23caf4970d1810fcf4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Report_RpKpHistory), @"mvc.1.0.view", @"/Areas/BMED/Views/Report/RpKpHistory.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Report/RpKpHistory.cshtml", typeof(AspNetCore.Areas_BMED_Views_Report_RpKpHistory))]
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
#line 2 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2580fcfd2507252a6a4ab23caf4970d1810fcf4", @"/Areas/BMED/Views/Report/RpKpHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Report_RpKpHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.RpKpHistoryVModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
  
    Layout = null;
    var qry = JsonConvert.DeserializeObject<ReportQryVModel>(TempData["qry"].ToString());

#line default
#line hidden
            BeginContext(193, 37, true);
            WriteLiteral("\r\n<p>\r\n    <a class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 230, "\"", 273, 1);
#line 9 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
WriteAttributeValue("", 237, Url.Action("ExcelRpKpHistory", qry), 237, 36, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(274, 31, true);
            WriteLiteral(">匯出Excel</a>\r\n</p>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(306, 70, false);
#line 12 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
Write(await Component.InvokeAsync("AssetView", new { id = ViewData["Ano"] }));

#line default
#line hidden
            EndContext();
            BeginContext(376, 105, true);
            WriteLiteral("\r\n</div>\r\n<div>\r\n    <h4>維修保養履歷</h4>\r\n</div>\r\n<table class=\"table\">\r\n    <tr>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(482, 43, false);
#line 20 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.DocType));

#line default
#line hidden
            EndContext();
            BeginContext(525, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(569, 41, false);
#line 23 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(610, 17, true);
            WriteLiteral("\r\n        </th>\r\n");
            EndContext();
            BeginContext(827, 26, true);
            WriteLiteral("        <th>\r\n            ");
            EndContext();
            BeginContext(854, 45, false);
#line 32 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.ApplyDate));

#line default
#line hidden
            EndContext();
            BeginContext(899, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(943, 43, false);
#line 35 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(986, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1030, 43, false);
#line 38 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.EngName));

#line default
#line hidden
            EndContext();
            BeginContext(1073, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1117, 41, false);
#line 41 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.Hours));

#line default
#line hidden
            EndContext();
            BeginContext(1158, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1202, 40, false);
#line 44 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(1242, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1286, 46, false);
#line 47 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.TroubleDes));

#line default
#line hidden
            EndContext();
            BeginContext(1332, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(1376, 43, false);
#line 50 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
       Write(Html.DisplayNameFor(model => model.DealDes));

#line default
#line hidden
            EndContext();
            BeginContext(1419, 30, true);
            WriteLiteral("\r\n        </th>\r\n    </tr>\r\n\r\n");
            EndContext();
#line 54 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(1490, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1539, 42, false);
#line 58 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
           Write(Html.DisplayFor(modelItem => item.DocType));

#line default
#line hidden
            EndContext();
            BeginContext(1581, 39, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
            EndContext();
#line 61 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
                 if (item.DocType == "請修")
                {
                    

#line default
#line hidden
            BeginContext(1704, 99, false);
#line 63 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
               Write(Html.ActionLink(item.DocId, "Views", "Repairs", new { id = item.DocId }, new { target = "_blank" }));

#line default
#line hidden
            EndContext();
#line 63 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
                                                                                                                        
                }
                else
                {
                    

#line default
#line hidden
            BeginContext(1886, 97, false);
#line 67 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
               Write(Html.ActionLink(item.DocId, "Views", "Keeps", new { id = item.DocId }, new { target = "_blank" }));

#line default
#line hidden
            EndContext();
#line 67 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
                                                                                                                      
                }

#line default
#line hidden
            BeginContext(2004, 19, true);
            WriteLiteral("            </td>\r\n");
            EndContext();
            BeginContext(2245, 34, true);
            WriteLiteral("            <td>\r\n                ");
            EndContext();
            BeginContext(2280, 37, false);
#line 77 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
           Write(item.ApplyDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
            EndContext();
            BeginContext(2317, 39, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
            EndContext();
#line 80 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
                 if (@item.EndDate != null)
                {
                    

#line default
#line hidden
            BeginContext(2441, 41, false);
#line 82 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
               Write(item.EndDate.Value.ToString("yyyy/MM/dd"));

#line default
#line hidden
            EndContext();
#line 82 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
                                                              ;
                }

#line default
#line hidden
            BeginContext(2504, 53, true);
            WriteLiteral("            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2558, 42, false);
#line 86 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
           Write(Html.DisplayFor(modelItem => item.EngName));

#line default
#line hidden
            EndContext();
            BeginContext(2600, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2656, 40, false);
#line 89 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
           Write(Html.DisplayFor(modelItem => item.Hours));

#line default
#line hidden
            EndContext();
            BeginContext(2696, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2752, 39, false);
#line 92 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
           Write(Html.DisplayFor(modelItem => item.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(2791, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2847, 45, false);
#line 95 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
           Write(Html.DisplayFor(modelItem => item.TroubleDes));

#line default
#line hidden
            EndContext();
            BeginContext(2892, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2948, 42, false);
#line 98 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
           Write(Html.DisplayFor(modelItem => item.DealDes));

#line default
#line hidden
            EndContext();
            BeginContext(2990, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 101 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
    }

#line default
#line hidden
            BeginContext(3033, 23, true);
            WriteLiteral("\r\n</table>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(3057, 91, false);
#line 105 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Report\RpKpHistory.cshtml"
Write(await Html.PartialAsync("AssetAnalysis", ViewData["Analysis"] as EDIS.Models.AssetAnalysis));

#line default
#line hidden
            EndContext();
            BeginContext(3148, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.RpKpHistoryVModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
