#pragma checksum "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepFormatDtl\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35d17f27180840efb9a37a76a64182fdf608baf1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDKeepFormatDtl_Default), @"mvc.1.0.view", @"/Areas/BMED/Views/Shared/Components/BMEDKeepFormatDtl/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Shared/Components/BMEDKeepFormatDtl/Default.cshtml", typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDKeepFormatDtl_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35d17f27180840efb9a37a76a64182fdf608baf1", @"/Areas/BMED/Views/Shared/Components/BMEDKeepFormatDtl/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Shared_Components_BMEDKeepFormatDtl_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.KeepFormatDtlModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 43, true);
            WriteLiteral("\r\n<h2>格式細項</h2>\r\n<a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 95, "\"", 185, 1);
#line 4 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepFormatDtl\Default.cshtml"
WriteAttributeValue("", 102, Url.Action("Create", "KeepFormatDtl", new { Area = "BMED", id = ViewData["fid"] }), 102, 83, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(186, 17, true);
            WriteLiteral(">新增</a>\r\n<hr />\r\n");
            EndContext();
#line 6 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepFormatDtl\Default.cshtml"
 if (Model.Count() > 0)
{

#line default
#line hidden
            BeginContext(231, 82, true);
            WriteLiteral("    <table style=\"width: 100%;\">\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(314, 39, false);
#line 11 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepFormatDtl\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.Sno));

#line default
#line hidden
            EndContext();
            BeginContext(353, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(409, 44, false);
#line 14 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepFormatDtl\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.Descript));

#line default
#line hidden
            EndContext();
            BeginContext(453, 61, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n\r\n");
            EndContext();
#line 19 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepFormatDtl\Default.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(563, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(624, 38, false);
#line 23 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepFormatDtl\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.Sno));

#line default
#line hidden
            EndContext();
            BeginContext(662, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(730, 43, false);
#line 26 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepFormatDtl\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.Descript));

#line default
#line hidden
            EndContext();
            BeginContext(773, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(841, 105, false);
#line 29 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepFormatDtl\Default.cshtml"
               Write(Html.ActionLink("修改", "Edit", "KeepFormatDtl", new { Area = "BMED", id = item.FormatId, sno = item.Sno }));

#line default
#line hidden
            EndContext();
            BeginContext(946, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(971, 107, false);
#line 30 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepFormatDtl\Default.cshtml"
               Write(Html.ActionLink("刪除", "Delete", "KeepFormatDtl", new { Area = "BMED", id = item.FormatId, sno = item.Sno }));

#line default
#line hidden
            EndContext();
            BeginContext(1078, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 33 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepFormatDtl\Default.cshtml"
        }

#line default
#line hidden
            BeginContext(1133, 16, true);
            WriteLiteral("\r\n    </table>\r\n");
            EndContext();
#line 36 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepFormatDtl\Default.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.KeepFormatDtlModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591