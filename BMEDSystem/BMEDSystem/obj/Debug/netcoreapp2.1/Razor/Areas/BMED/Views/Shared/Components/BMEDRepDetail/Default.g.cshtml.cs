#pragma checksum "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24380fccc3df6b6dd7ad90a74667401c5da7ae35"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDRepDetail_Default), @"mvc.1.0.view", @"/Areas/BMED/Views/Shared/Components/BMEDRepDetail/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Shared/Components/BMEDRepDetail/Default.cshtml", typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDRepDetail_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24380fccc3df6b6dd7ad90a74667401c5da7ae35", @"/Areas/BMED/Views/Shared/Components/BMEDRepDetail/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Shared_Components_BMEDRepDetail_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.RepairDtlModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
  
    ViewBag.Title = "Details";

#line default
#line hidden
            BeginContext(76, 100, true);
            WriteLiteral("\r\n\r\n<div>\r\n    <h3>請修明細</h3>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(177, 45, false);
#line 13 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.DealState));

#line default
#line hidden
            EndContext();
            BeginContext(222, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(268, 46, false);
#line 17 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayFor(model => model.DealStateTitle));

#line default
#line hidden
            EndContext();
            BeginContext(314, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(360, 43, false);
#line 21 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.DealDes));

#line default
#line hidden
            EndContext();
            BeginContext(403, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(449, 39, false);
#line 25 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayFor(model => model.DealDes));

#line default
#line hidden
            EndContext();
            BeginContext(488, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(534, 46, false);
#line 29 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.FailFactor));

#line default
#line hidden
            EndContext();
            BeginContext(580, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(626, 47, false);
#line 33 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayFor(model => model.FailFactorTitle));

#line default
#line hidden
            EndContext();
            BeginContext(673, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(719, 41, false);
#line 37 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.InOut));

#line default
#line hidden
            EndContext();
            BeginContext(760, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(806, 37, false);
#line 41 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayFor(model => model.InOut));

#line default
#line hidden
            EndContext();
            BeginContext(843, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(889, 40, false);
#line 45 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.Hour));

#line default
#line hidden
            EndContext();
            BeginContext(929, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(975, 36, false);
#line 49 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayFor(model => model.Hour));

#line default
#line hidden
            EndContext();
            BeginContext(1011, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1057, 45, false);
#line 53 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.IsCharged));

#line default
#line hidden
            EndContext();
            BeginContext(1102, 33, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");
            EndContext();
#line 57 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
             if (@Model.IsCharged == "N")
            {
                

#line default
#line hidden
            BeginContext(1210, 13, false);
#line 59 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
           Write(Html.Raw("無"));

#line default
#line hidden
            EndContext();
#line 59 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
                              
            }
            else if (@Model.IsCharged == "Y")
            {
                

#line default
#line hidden
            BeginContext(1319, 13, false);
#line 63 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
           Write(Html.Raw("有"));

#line default
#line hidden
            EndContext();
#line 63 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
                              
            }

#line default
#line hidden
            BeginContext(1349, 43, true);
            WriteLiteral("        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1393, 40, false);
#line 68 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(1433, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1479, 36, false);
#line 72 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayFor(model => model.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(1515, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1561, 53, false);
#line 76 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.NotInExceptDevice));

#line default
#line hidden
            EndContext();
            BeginContext(1614, 33, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");
            EndContext();
#line 80 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
             if (@Model.NotInExceptDevice == "Y")
            {
                

#line default
#line hidden
            BeginContext(1730, 13, false);
#line 82 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
           Write(Html.Raw("是"));

#line default
#line hidden
            EndContext();
#line 82 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
                              
            }
            else if (@Model.NotInExceptDevice == "N")
            {
                

#line default
#line hidden
            BeginContext(1847, 13, false);
#line 86 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
           Write(Html.Raw("否"));

#line default
#line hidden
            EndContext();
#line 86 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
                              
            }

#line default
#line hidden
            BeginContext(1877, 43, true);
            WriteLiteral("        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1921, 48, false);
#line 91 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.IsInstrument));

#line default
#line hidden
            EndContext();
            BeginContext(1969, 33, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");
            EndContext();
#line 95 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
             if (@Model.IsInstrument == "Y")
            {
                

#line default
#line hidden
            BeginContext(2080, 13, false);
#line 97 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
           Write(Html.Raw("是"));

#line default
#line hidden
            EndContext();
#line 97 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
                              
            }
            else if (@Model.IsInstrument == "N")
            {
                

#line default
#line hidden
            BeginContext(2192, 13, false);
#line 101 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
           Write(Html.Raw("否"));

#line default
#line hidden
            EndContext();
#line 101 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
                              
            }

#line default
#line hidden
            BeginContext(2222, 43, true);
            WriteLiteral("        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2266, 43, false);
#line 106 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(2309, 33, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");
            EndContext();
#line 110 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
             if (@Model.EndDate != null)
            {
                

#line default
#line hidden
            BeginContext(2416, 42, false);
#line 112 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
           Write(Model.EndDate.Value.ToString("yyyy/MM/dd"));

#line default
#line hidden
            EndContext();
#line 112 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
                                                           ;
            }

#line default
#line hidden
            BeginContext(2476, 43, true);
            WriteLiteral("        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2520, 45, false);
#line 117 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.CloseDate));

#line default
#line hidden
            EndContext();
            BeginContext(2565, 33, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");
            EndContext();
#line 121 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
             if (@Model.CloseDate != null)
            {
                

#line default
#line hidden
            BeginContext(2674, 44, false);
#line 123 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
           Write(Model.CloseDate.Value.ToString("yyyy/MM/dd"));

#line default
#line hidden
            EndContext();
#line 123 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
                                                             ;
            }

#line default
#line hidden
            BeginContext(2736, 43, true);
            WriteLiteral("        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2780, 47, false);
#line 128 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.CheckerName));

#line default
#line hidden
            EndContext();
            BeginContext(2827, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2873, 43, false);
#line 132 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayFor(model => model.CheckerName));

#line default
#line hidden
            EndContext();
            BeginContext(2916, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2962, 44, false);
#line 136 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.ShutDate));

#line default
#line hidden
            EndContext();
            BeginContext(3006, 33, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");
            EndContext();
#line 140 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
             if (@Model.ShutDate != null)
            {
                

#line default
#line hidden
            BeginContext(3114, 43, false);
#line 142 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
           Write(Model.ShutDate.Value.ToString("yyyy/MM/dd"));

#line default
#line hidden
            EndContext();
#line 142 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepDetail\Default.cshtml"
                                                            ;
            }

#line default
#line hidden
            BeginContext(3175, 36, true);
            WriteLiteral("        </dd>\r\n\r\n    </dl>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.RepairDtlModel> Html { get; private set; }
    }
}
#pragma warning restore 1591