#pragma checksum "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormat\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d210b768a82949227cb4fa00a37dbfb28d39c1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_KeepFormat_Details), @"mvc.1.0.view", @"/Areas/BMED/Views/KeepFormat/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/KeepFormat/Details.cshtml", typeof(AspNetCore.Areas_BMED_Views_KeepFormat_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d210b768a82949227cb4fa00a37dbfb28d39c1c", @"/Areas/BMED/Views/KeepFormat/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_KeepFormat_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.KeepFormatModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(36, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormat\Details.cshtml"
  
    Layout = "~/Views/Shared/_PassedLayout.cshtml";
    ViewBag.Title = "預覽/保養格式";

#line default
#line hidden
            BeginContext(130, 119, true);
            WriteLiteral("\r\n<h2>預覽</h2>\r\n\r\n<fieldset>\r\n    <legend style=\"color:white\">保養格式</legend>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(250, 42, false);
#line 14 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormat\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Plants));

#line default
#line hidden
            EndContext();
            BeginContext(292, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(348, 38, false);
#line 17 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormat\Details.cshtml"
   Write(Html.DisplayFor(model => model.Plants));

#line default
#line hidden
            EndContext();
            BeginContext(386, 57, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"display-label\">\r\n        ");
            EndContext();
            BeginContext(444, 42, false);
#line 21 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormat\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Format));

#line default
#line hidden
            EndContext();
            BeginContext(486, 55, true);
            WriteLiteral("\r\n    </div>\r\n    <div class=\"display-field\">\r\n        ");
            EndContext();
            BeginContext(542, 38, false);
#line 24 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormat\Details.cshtml"
   Write(Html.DisplayFor(model => model.Format));

#line default
#line hidden
            EndContext();
            BeginContext(580, 74, true);
            WriteLiteral("\r\n    </div>\r\n</fieldset>\r\n\r\n<br />\r\n<div>\r\n    <a class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 654, "\"", 737, 1);
#line 30 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormat\Details.cshtml"
WriteAttributeValue("", 661, Url.Action("Edit","KeepFormat", new { Area = "BMED", id = Model.FormatId }), 661, 76, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(738, 39, true);
            WriteLiteral(">編輯</a>\r\n    <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 777, "\"", 804, 1);
#line 31 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormat\Details.cshtml"
WriteAttributeValue("", 784, Url.Action("Index"), 784, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(805, 19, true);
            WriteLiteral(">回到列表</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.KeepFormatModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
