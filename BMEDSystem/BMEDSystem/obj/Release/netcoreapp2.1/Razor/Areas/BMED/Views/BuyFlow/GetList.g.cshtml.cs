#pragma checksum "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24a9dbdada1e8f81be373bd4d135e4fabed1478b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_BuyFlow_GetList), @"mvc.1.0.view", @"/Areas/BMED/Views/BuyFlow/GetList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/BuyFlow/GetList.cshtml", typeof(AspNetCore.Areas_BMED_Views_BuyFlow_GetList))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24a9dbdada1e8f81be373bd4d135e4fabed1478b", @"/Areas/BMED/Views/BuyFlow/GetList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_BuyFlow_GetList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.BuyFlowModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 103, true);
            WriteLiteral("\r\n\r\n<h2>流程資訊</h2>\r\n<table style=\"width: 100%;margin-left: 30px;\">\r\n    <tr>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(150, 42, false);
#line 8 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
       Write(Html.DisplayNameFor(model => model.StepId));

#line default
#line hidden
            EndContext();
            BeginContext(192, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(236, 42, false);
#line 11 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
       Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
            EndContext();
            BeginContext(278, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(322, 44, false);
#line 14 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
       Write(Html.DisplayNameFor(model => model.Opinions));

#line default
#line hidden
            EndContext();
            BeginContext(366, 17, true);
            WriteLiteral("\r\n        </th>\r\n");
            EndContext();
            BeginContext(471, 26, true);
            WriteLiteral("        <th>\r\n            ");
            EndContext();
            BeginContext(498, 42, false);
#line 20 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(540, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(584, 39, false);
#line 23 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
       Write(Html.DisplayNameFor(model => model.Rtt));

#line default
#line hidden
            EndContext();
            BeginContext(623, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(667, 39, false);
#line 26 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
       Write(Html.DisplayNameFor(model => model.Cls));

#line default
#line hidden
            EndContext();
            BeginContext(706, 30, true);
            WriteLiteral("\r\n        </th>\r\n    </tr>\r\n\r\n");
            EndContext();
#line 30 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(768, 36, true);
            WriteLiteral("    <tr>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(805, 41, false);
#line 33 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
       Write(Html.DisplayFor(modelItem => item.StepId));

#line default
#line hidden
            EndContext();
            BeginContext(846, 44, true);
            WriteLiteral("\r\n        </td>\r\n         <td>\r\n            ");
            EndContext();
            BeginContext(891, 42, false);
#line 36 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
       Write(Html.DisplayFor(modelItem => item.UserNam));

#line default
#line hidden
            EndContext();
            BeginContext(933, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(977, 43, false);
#line 39 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
       Write(Html.DisplayFor(modelItem => item.Opinions));

#line default
#line hidden
            EndContext();
            BeginContext(1020, 17, true);
            WriteLiteral("\r\n        </td>\r\n");
            EndContext();
            BeginContext(1124, 14, true);
            WriteLiteral("        <td>\r\n");
            EndContext();
#line 45 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
             if (item.Status == "1")
            {

#line default
#line hidden
            BeginContext(1191, 32, true);
            WriteLiteral("                <div>已處理</div>\r\n");
            EndContext();
#line 48 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
            }
            else if (item.Status == "?")
            {

#line default
#line hidden
            BeginContext(1295, 32, true);
            WriteLiteral("                <div>未處理</div>\r\n");
            EndContext();
#line 52 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
            }
            else if (item.Status == "2")
            {

#line default
#line hidden
            BeginContext(1399, 31, true);
            WriteLiteral("                <div>結案</div>\r\n");
            EndContext();
#line 56 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
            }

#line default
#line hidden
            BeginContext(1445, 41, true);
            WriteLiteral("        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1487, 38, false);
#line 59 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
       Write(Html.DisplayFor(modelItem => item.Rtt));

#line default
#line hidden
            EndContext();
            BeginContext(1525, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1569, 38, false);
#line 62 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
       Write(Html.DisplayFor(modelItem => item.Cls));

#line default
#line hidden
            EndContext();
            BeginContext(1607, 28, true);
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n");
            EndContext();
#line 65 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
}

#line default
#line hidden
            BeginContext(1638, 38, true);
            WriteLiteral("</table>\r\n<h3>目前關卡：<span id=\"cls_now\">");
            EndContext();
            BeginContext(1677, 19, false);
#line 67 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyFlow\GetList.cshtml"
                       Write(ViewData["cls_now"]);

#line default
#line hidden
            EndContext();
            BeginContext(1696, 595, true);
            WriteLiteral(@"</span></h3>
<script>
    $(document).ready(function () {
        $('#pnlUSUAL').hide();
        $('#pnlMEDENG').hide();
        $('#pnlMEDMGR').hide();
        var c = $('span[id=""cls_now""]').text();
        if (c != ""採購人員"" && c != ""採購主管"") {
            $('#pnlBUYVENDOR').hide();
            $('#pnlSList').hide();
        }
        if (c == ""設備工程師"" || c == ""評估工程師"") {
            $('#pnlMEDENG').show();
        }
        else if (c == ""設備主管"") {
            $('#pnlMEDMGR').show();
        }
        else {
            $('#pnlUSUAL').show();
        }
    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.BuyFlowModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
