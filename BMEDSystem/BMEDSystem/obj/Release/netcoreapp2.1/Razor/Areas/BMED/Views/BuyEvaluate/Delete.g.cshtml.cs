#pragma checksum "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da7f6bb331b34e81241a91335af48fa7365ef528"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_BuyEvaluate_Delete), @"mvc.1.0.view", @"/Areas/BMED/Views/BuyEvaluate/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/BuyEvaluate/Delete.cshtml", typeof(AspNetCore.Areas_BMED_Views_BuyEvaluate_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da7f6bb331b34e81241a91335af48fa7365ef528", @"/Areas/BMED/Views/BuyEvaluate/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_BuyEvaluate_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.BuyEvaluateModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(37, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
  
    ViewBag.Title = "採購評估/刪除";

#line default
#line hidden
            BeginContext(78, 122, true);
            WriteLiteral("\r\n<h2>刪除</h2>\r\n\r\n<h3>您確定要刪除此案件嗎?</h3>\r\n<fieldset>\r\n    <legend>採購評估</legend>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(201, 44, false);
#line 14 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(245, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(301, 40, false);
#line 17 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(341, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(400, 43, false);
#line 21 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.Company));

#line default
#line hidden
            EndContext();
            BeginContext(443, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(499, 39, false);
#line 24 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.DisplayFor(model => model.Company));

#line default
#line hidden
            EndContext();
            BeginContext(538, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(597, 43, false);
#line 28 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.Contact));

#line default
#line hidden
            EndContext();
            BeginContext(640, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(696, 39, false);
#line 31 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.DisplayFor(model => model.Contact));

#line default
#line hidden
            EndContext();
            BeginContext(735, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(794, 42, false);
#line 35 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.AccDpt));

#line default
#line hidden
            EndContext();
            BeginContext(836, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(892, 38, false);
#line 38 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.DisplayFor(model => model.AccDpt));

#line default
#line hidden
            EndContext();
            BeginContext(930, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(989, 45, false);
#line 42 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.PlantType));

#line default
#line hidden
            EndContext();
            BeginContext(1034, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1090, 41, false);
#line 45 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.DisplayFor(model => model.PlantType));

#line default
#line hidden
            EndContext();
            BeginContext(1131, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(1190, 45, false);
#line 49 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.PlantCnam));

#line default
#line hidden
            EndContext();
            BeginContext(1235, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1291, 41, false);
#line 52 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.DisplayFor(model => model.PlantCnam));

#line default
#line hidden
            EndContext();
            BeginContext(1332, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(1391, 45, false);
#line 56 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.PlantEnam));

#line default
#line hidden
            EndContext();
            BeginContext(1436, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1492, 41, false);
#line 59 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.DisplayFor(model => model.PlantEnam));

#line default
#line hidden
            EndContext();
            BeginContext(1533, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(1592, 39, false);
#line 63 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.Amt));

#line default
#line hidden
            EndContext();
            BeginContext(1631, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1687, 35, false);
#line 66 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.DisplayFor(model => model.Amt));

#line default
#line hidden
            EndContext();
            BeginContext(1722, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(1781, 40, false);
#line 70 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.Unit));

#line default
#line hidden
            EndContext();
            BeginContext(1821, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(1877, 36, false);
#line 73 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.DisplayFor(model => model.Unit));

#line default
#line hidden
            EndContext();
            BeginContext(1913, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(1972, 41, false);
#line 77 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(2013, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(2069, 37, false);
#line 80 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(2106, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(2165, 46, false);
#line 84 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.TotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(2211, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(2267, 42, false);
#line 87 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.DisplayFor(model => model.TotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(2309, 58, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n         ");
            EndContext();
            BeginContext(2368, 41, false);
#line 91 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
    Write(Html.DisplayNameFor(model => model.Place));

#line default
#line hidden
            EndContext();
            BeginContext(2409, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(2465, 37, false);
#line 94 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.DisplayFor(model => model.Place));

#line default
#line hidden
            EndContext();
            BeginContext(2502, 29, true);
            WriteLiteral("\r\n    </div>\r\n</fieldset>\r\n\r\n");
            EndContext();
#line 98 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
 using (Html.BeginForm()) {

#line default
#line hidden
            BeginContext(2560, 65, true);
            WriteLiteral("    <p>\r\n        <input type=\"submit\" value=\"確定刪除\" /> |\r\n        ");
            EndContext();
            BeginContext(2626, 59, false);
#line 101 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
   Write(Html.ActionLink("回到列表", "Index", "Home", new { Area = "" }));

#line default
#line hidden
            EndContext();
            BeginContext(2685, 12, true);
            WriteLiteral("\r\n    </p>\r\n");
            EndContext();
#line 103 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\Delete.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.BuyEvaluateModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
