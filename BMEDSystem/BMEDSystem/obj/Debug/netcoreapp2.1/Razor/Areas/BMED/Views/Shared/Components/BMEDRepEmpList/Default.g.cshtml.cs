#pragma checksum "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepEmpList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d8a9c1f9712b397e66348962d64fcee8c39b734"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDRepEmpList_Default), @"mvc.1.0.view", @"/Areas/BMED/Views/Shared/Components/BMEDRepEmpList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Shared/Components/BMEDRepEmpList/Default.cshtml", typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDRepEmpList_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d8a9c1f9712b397e66348962d64fcee8c39b734", @"/Areas/BMED/Views/Shared/Components/BMEDRepEmpList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Shared_Components_BMEDRepEmpList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.RepairEmpModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 77, true);
            WriteLiteral("\r\n<h3>工程師列表</h3>\r\n<table class=\"table\">\r\n    <tr>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(126, 44, false);
#line 7 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepEmpList\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(170, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(214, 44, false);
#line 10 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepEmpList\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(258, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(302, 40, false);
#line 13 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepEmpList\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.Hour));

#line default
#line hidden
            EndContext();
            BeginContext(342, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(386, 42, false);
#line 16 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepEmpList\Default.cshtml"
       Write(Html.DisplayNameFor(model => model.Minute));

#line default
#line hidden
            EndContext();
            BeginContext(428, 49, true);
            WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n\r\n");
            EndContext();
#line 21 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepEmpList\Default.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(518, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(567, 43, false);
#line 25 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepEmpList\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(610, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(666, 43, false);
#line 28 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepEmpList\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(709, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(765, 39, false);
#line 31 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepEmpList\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.Hour));

#line default
#line hidden
            EndContext();
            BeginContext(804, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(860, 41, false);
#line 34 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepEmpList\Default.cshtml"
           Write(Html.DisplayFor(modelItem => item.Minute));

#line default
#line hidden
            EndContext();
            BeginContext(901, 124, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a class=\"btn btn-primary\">刪除</a>\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 40 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDRepEmpList\Default.cshtml"
    }

#line default
#line hidden
            BeginContext(1032, 10, true);
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.RepairEmpModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
