#pragma checksum "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5714185672e0027d798fb83f4a1227e2edcca0d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDKeepDtlEdit_Details), @"mvc.1.0.view", @"/Areas/BMED/Views/Shared/Components/BMEDKeepDtlEdit/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Shared/Components/BMEDKeepDtlEdit/Details.cshtml", typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDKeepDtlEdit_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5714185672e0027d798fb83f4a1227e2edcca0d0", @"/Areas/BMED/Views/Shared/Components/BMEDKeepDtlEdit/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Shared_Components_BMEDKeepDtlEdit_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.KeepDtlModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 67, true);
            WriteLiteral("\r\n<div>\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(101, 42, false);
#line 6 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Result));

#line default
#line hidden
            EndContext();
            BeginContext(143, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(189, 43, false);
#line 10 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayFor(model => model.ResultTitle));

#line default
#line hidden
            EndContext();
            BeginContext(232, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(278, 40, false);
#line 14 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Memo));

#line default
#line hidden
            EndContext();
            BeginContext(318, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(364, 36, false);
#line 18 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayFor(model => model.Memo));

#line default
#line hidden
            EndContext();
            BeginContext(400, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(446, 41, false);
#line 22 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.InOut));

#line default
#line hidden
            EndContext();
            BeginContext(487, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(533, 37, false);
#line 26 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayFor(model => model.InOut));

#line default
#line hidden
            EndContext();
            BeginContext(570, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(616, 45, false);
#line 30 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsCharged));

#line default
#line hidden
            EndContext();
            BeginContext(661, 33, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");
            EndContext();
#line 34 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
             if (@Model.IsCharged == "N")
            {
                

#line default
#line hidden
            BeginContext(769, 13, false);
#line 36 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
           Write(Html.Raw("無"));

#line default
#line hidden
            EndContext();
#line 36 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
                              
            }
            else if (@Model.IsCharged == "Y")
            {
                

#line default
#line hidden
            BeginContext(878, 13, false);
#line 40 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
           Write(Html.Raw("有"));

#line default
#line hidden
            EndContext();
#line 40 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
                              
            }

#line default
#line hidden
            BeginContext(908, 43, true);
            WriteLiteral("        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(952, 41, false);
#line 45 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Hours));

#line default
#line hidden
            EndContext();
            BeginContext(993, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1039, 37, false);
#line 49 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayFor(model => model.Hours));

#line default
#line hidden
            EndContext();
            BeginContext(1076, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1122, 40, false);
#line 53 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(1162, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1208, 36, false);
#line 57 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayFor(model => model.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(1244, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1290, 53, false);
#line 61 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.NotInExceptDevice));

#line default
#line hidden
            EndContext();
            BeginContext(1343, 33, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");
            EndContext();
#line 65 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
             if (@Model.NotInExceptDevice == "Y")
            {
                

#line default
#line hidden
            BeginContext(1459, 13, false);
#line 67 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
           Write(Html.Raw("是"));

#line default
#line hidden
            EndContext();
#line 67 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
                              
            }
            else if (@Model.NotInExceptDevice == "N")
            {
                

#line default
#line hidden
            BeginContext(1576, 13, false);
#line 71 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
           Write(Html.Raw("否"));

#line default
#line hidden
            EndContext();
#line 71 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
                              
            }

#line default
#line hidden
            BeginContext(1606, 43, true);
            WriteLiteral("        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1650, 48, false);
#line 76 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsInstrument));

#line default
#line hidden
            EndContext();
            BeginContext(1698, 33, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");
            EndContext();
#line 80 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
             if (@Model.IsInstrument == "Y")
            {
                

#line default
#line hidden
            BeginContext(1809, 13, false);
#line 82 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
           Write(Html.Raw("是"));

#line default
#line hidden
            EndContext();
#line 82 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
                              
            }
            else if (@Model.IsInstrument == "N")
            {
                

#line default
#line hidden
            BeginContext(1921, 13, false);
#line 86 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
           Write(Html.Raw("否"));

#line default
#line hidden
            EndContext();
#line 86 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
                              
            }

#line default
#line hidden
            BeginContext(1951, 43, true);
            WriteLiteral("        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1995, 43, false);
#line 91 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(2038, 33, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n");
            EndContext();
#line 95 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
             if (@Model.EndDate != null)
            {
                

#line default
#line hidden
            BeginContext(2145, 42, false);
#line 97 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
           Write(Model.EndDate.Value.ToString("yyyy/MM/dd"));

#line default
#line hidden
            EndContext();
#line 97 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
                                                           ;
            }

#line default
#line hidden
            BeginContext(2205, 43, true);
            WriteLiteral("        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2249, 47, false);
#line 102 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CheckerName));

#line default
#line hidden
            EndContext();
            BeginContext(2296, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2342, 43, false);
#line 106 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepDtlEdit\Details.cshtml"
       Write(Html.DisplayFor(model => model.CheckerName));

#line default
#line hidden
            EndContext();
            BeginContext(2385, 19, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n");
            EndContext();
            BeginContext(2923, 21, true);
            WriteLiteral("\r\n    </dl>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.KeepDtlModel> Html { get; private set; }
    }
}
#pragma warning restore 1591