#pragma checksum "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b787f4f7e112e24379257d0f4b0801ea26354327"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Search_RepQryList), @"mvc.1.0.view", @"/Areas/BMED/Views/Search/RepQryList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Search/RepQryList.cshtml", typeof(AspNetCore.Areas_BMED_Views_Search_RepQryList))]
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
#line 3 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
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
#line 2 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
using System.Security.Claims;

#line default
#line hidden
#line 4 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
using EDIS.Models.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b787f4f7e112e24379257d0f4b0801ea26354327", @"/Areas/BMED/Views/Search/RepQryList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Search_RepQryList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.RepairSearchListVModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(154, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(222, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 11 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
 if (Model.Count() <= 0)
{

#line default
#line hidden
            BeginContext(253, 39, true);
            WriteLiteral("    <p class=\"text-danger\">無任何資料!</p>\r\n");
            EndContext();
#line 14 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"

}
else
{

#line default
#line hidden
            BeginContext(306, 118, true);
            WriteLiteral("    <table class=\"table\" style=\"width: 100%\">\r\n        <tr>\r\n            <th></th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(425, 43, false);
#line 22 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
           Write(Html.DisplayNameFor(model => model.RepType));

#line default
#line hidden
            EndContext();
            BeginContext(468, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(524, 41, false);
#line 25 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
           Write(Html.DisplayNameFor(model => model.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(565, 42, true);
            WriteLiteral("\r\n                <br />\r\n                ");
            EndContext();
            BeginContext(608, 45, false);
#line 27 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
           Write(Html.DisplayNameFor(model => model.ApplyDate));

#line default
#line hidden
            EndContext();
            BeginContext(653, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(709, 46, false);
#line 30 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
           Write(Html.DisplayNameFor(model => model.AccDptName));

#line default
#line hidden
            EndContext();
            BeginContext(755, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(811, 45, false);
#line 33 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
           Write(Html.DisplayNameFor(model => model.AssetName));

#line default
#line hidden
            EndContext();
            BeginContext(856, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(912, 44, false);
#line 36 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
           Write(Html.DisplayNameFor(model => model.PlaceLoc));

#line default
#line hidden
            EndContext();
            BeginContext(956, 77, true);
            WriteLiteral("\r\n            </th>\r\n            <th style=\"width: 300px;\">\r\n                ");
            EndContext();
            BeginContext(1034, 46, false);
#line 39 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
           Write(Html.DisplayNameFor(model => model.TroubleDes));

#line default
#line hidden
            EndContext();
            BeginContext(1080, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1136, 45, false);
#line 42 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
           Write(Html.DisplayNameFor(model => model.DealState));

#line default
#line hidden
            EndContext();
            BeginContext(1181, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1237, 43, false);
#line 45 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
           Write(Html.DisplayNameFor(model => model.DealDes));

#line default
#line hidden
            EndContext();
            BeginContext(1280, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1336, 40, false);
#line 48 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
           Write(Html.DisplayNameFor(model => model.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(1376, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1432, 40, false);
#line 51 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
           Write(Html.DisplayNameFor(model => model.Days));

#line default
#line hidden
            EndContext();
            BeginContext(1472, 114, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                文件狀態\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1587, 47, false);
#line 57 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
           Write(Html.DisplayNameFor(model => model.FlowUidName));

#line default
#line hidden
            EndContext();
            BeginContext(1634, 36, true);
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n");
            EndContext();
#line 60 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1719, 74, true);
            WriteLiteral("            <tr>\r\n                <td width=\"100px\">\r\n                    ");
            EndContext();
            BeginContext(1794, 107, false);
#line 64 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.ActionLink("預覽", "Views", "Repair", new { Area = "BMED", id = item.DocId }, new { target = "_blank" }));

#line default
#line hidden
            EndContext();
            BeginContext(1901, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1924, 14, false);
#line 65 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.Raw(" |"));

#line default
#line hidden
            EndContext();
            BeginContext(1938, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1961, 119, false);
#line 66 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.ActionLink("列印", "PrintRepairDoc", "Repair", new { Area = "BMED", DocId = item.DocId }, new { target = "_blank" }));

#line default
#line hidden
            EndContext();
            BeginContext(2080, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2148, 42, false);
#line 69 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.RepType));

#line default
#line hidden
            EndContext();
            BeginContext(2190, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2258, 40, false);
#line 72 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(2298, 50, true);
            WriteLiteral("\r\n                    <br />\r\n                    ");
            EndContext();
            BeginContext(2349, 44, false);
#line 74 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.ApplyDate));

#line default
#line hidden
            EndContext();
            BeginContext(2393, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2461, 45, false);
#line 77 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.AccDptName));

#line default
#line hidden
            EndContext();
            BeginContext(2506, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2574, 42, false);
#line 80 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.AssetNo));

#line default
#line hidden
            EndContext();
            BeginContext(2616, 50, true);
            WriteLiteral("\r\n                    <br />\r\n                    ");
            EndContext();
            BeginContext(2667, 44, false);
#line 82 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.AssetName));

#line default
#line hidden
            EndContext();
            BeginContext(2711, 50, true);
            WriteLiteral("\r\n                    <br />\r\n                    ");
            EndContext();
            BeginContext(2762, 40, false);
#line 84 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Brand));

#line default
#line hidden
            EndContext();
            BeginContext(2802, 50, true);
            WriteLiteral("\r\n                    <br />\r\n                    ");
            EndContext();
            BeginContext(2853, 39, false);
#line 86 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
            EndContext();
            BeginContext(2892, 97, true);
            WriteLiteral("\r\n                    <br />\r\n\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2990, 43, false);
#line 91 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.PlaceLoc));

#line default
#line hidden
            EndContext();
            BeginContext(3033, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3101, 45, false);
#line 94 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.TroubleDes));

#line default
#line hidden
            EndContext();
            BeginContext(3146, 80, true);
            WriteLiteral("\r\n                </td>\r\n                <td width=\"75px\">\r\n                    ");
            EndContext();
            BeginContext(3227, 44, false);
#line 97 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.DealState));

#line default
#line hidden
            EndContext();
            BeginContext(3271, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 98 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
                     if (item.DealState == "報廢")
                    {

#line default
#line hidden
            BeginContext(3346, 58, true);
            WriteLiteral("                        <br />\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 3404, "\'", 3480, 2);
            WriteAttributeValue("", 3411, "http://eform2.cch.org.tw/Public/Purchase/FmNew.aspx?recno=", 3411, 58, true);
#line 101 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
WriteAttributeValue("", 3469, item.DocId, 3469, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3481, 25, true);
            WriteLiteral(" target=\"_blank\">請購</a>\r\n");
            EndContext();
#line 102 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
                    }

#line default
#line hidden
            BeginContext(3529, 65, true);
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3595, 42, false);
#line 105 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.DealDes));

#line default
#line hidden
            EndContext();
            BeginContext(3637, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3705, 39, false);
#line 108 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(3744, 47, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            EndContext();
#line 111 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
                     if (item.Flg != "2")
                    {
                        

#line default
#line hidden
            BeginContext(3882, 39, false);
#line 113 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Days));

#line default
#line hidden
            EndContext();
#line 113 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
                                                                
                    }

#line default
#line hidden
            BeginContext(3946, 45, true);
            WriteLiteral("                </td>\r\n                <td>\r\n");
            EndContext();
#line 117 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
                     if (item.Flg == "2")
                    {

#line default
#line hidden
            BeginContext(4057, 42, true);
            WriteLiteral("                        <span>已結案</span>\r\n");
            EndContext();
#line 120 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(4171, 42, true);
            WriteLiteral("                        <span>未結案</span>\r\n");
            EndContext();
#line 124 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
                    }

#line default
#line hidden
            BeginContext(4236, 65, true);
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(4302, 46, false);
#line 127 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.FlowUidName));

#line default
#line hidden
            EndContext();
            BeginContext(4348, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 130 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
        }

#line default
#line hidden
            BeginContext(4403, 16, true);
            WriteLiteral("\r\n    </table>\r\n");
            EndContext();
#line 133 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Search\RepQryList.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.RepairSearchListVModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591