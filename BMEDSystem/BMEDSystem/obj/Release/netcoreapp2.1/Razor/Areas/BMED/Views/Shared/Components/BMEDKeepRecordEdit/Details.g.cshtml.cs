#pragma checksum "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "efe4eb87921b0dbdcbea4a3bf1fb3d7aa12b22ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDKeepRecordEdit_Details), @"mvc.1.0.view", @"/Areas/BMED/Views/Shared/Components/BMEDKeepRecordEdit/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Shared/Components/BMEDKeepRecordEdit/Details.cshtml", typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDKeepRecordEdit_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efe4eb87921b0dbdcbea4a3bf1fb3d7aa12b22ff", @"/Areas/BMED/Views/Shared/Components/BMEDKeepRecordEdit/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Shared_Components_BMEDKeepRecordEdit_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.KeepFormatListVModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(54, 61, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <tr>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(116, 39, false);
#line 6 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Sno));

#line default
#line hidden
            EndContext();
            BeginContext(155, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(199, 42, false);
#line 9 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Plants));

#line default
#line hidden
            EndContext();
            BeginContext(241, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(285, 44, false);
#line 12 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Descript));

#line default
#line hidden
            EndContext();
            BeginContext(329, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(373, 43, false);
#line 15 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.KeepDes));

#line default
#line hidden
            EndContext();
            BeginContext(416, 30, true);
            WriteLiteral("\r\n        </th>\r\n    </tr>\r\n\r\n");
            EndContext();
#line 19 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(487, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(536, 39, false);
#line 23 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
           Write(Html.HiddenFor(modelItem => item.Docid));

#line default
#line hidden
            EndContext();
            BeginContext(575, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(594, 42, false);
#line 24 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
           Write(Html.HiddenFor(modelItem => item.FormatId));

#line default
#line hidden
            EndContext();
            BeginContext(636, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(655, 37, false);
#line 25 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
           Write(Html.HiddenFor(modelItem => item.Sno));

#line default
#line hidden
            EndContext();
            BeginContext(692, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(711, 42, false);
#line 26 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
           Write(Html.HiddenFor(modelItem => item.Descript));

#line default
#line hidden
            EndContext();
            BeginContext(753, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(772, 38, false);
#line 27 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item.Sno));

#line default
#line hidden
            EndContext();
            BeginContext(810, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(866, 41, false);
#line 30 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item.Plants));

#line default
#line hidden
            EndContext();
            BeginContext(907, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(963, 43, false);
#line 33 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item.Descript));

#line default
#line hidden
            EndContext();
            BeginContext(1006, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1062, 106, false);
#line 36 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
           Write(Html.TextAreaFor(modelItem => item.KeepDes, 5, 50, new { @class = "form-control", disabled = "disabled" }));

#line default
#line hidden
            EndContext();
            BeginContext(1168, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 39 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepRecordEdit\Details.cshtml"
    }

#line default
#line hidden
            BeginContext(1211, 10, true);
            WriteLiteral("\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.KeepFormatListVModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
