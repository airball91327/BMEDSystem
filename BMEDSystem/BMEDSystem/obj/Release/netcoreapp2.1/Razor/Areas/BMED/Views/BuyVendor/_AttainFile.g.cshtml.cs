#pragma checksum "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_AttainFile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b68d59fe60908152d51c4f6d434282489a12f7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_BuyVendor__AttainFile), @"mvc.1.0.view", @"/Areas/BMED/Views/BuyVendor/_AttainFile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/BuyVendor/_AttainFile.cshtml", typeof(AspNetCore.Areas_BMED_Views_BuyVendor__AttainFile))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b68d59fe60908152d51c4f6d434282489a12f7b", @"/Areas/BMED/Views/BuyVendor/_AttainFile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_BuyVendor__AttainFile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.BuyPriceListVModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(39, 52, true);
            WriteLiteral("\r\n<div style=\"margin-left: 30px\">\r\n<a class=\"button\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 91, "\"", 191, 1);
#line 4 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_AttainFile.cshtml"
WriteAttributeValue("", 98, Url.Content("~/BMED/AttainFile/Create?id="+ Model.DocId + "&typ=3&uniteno=" + Model.UniteNo), 98, 93, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(192, 53, true);
            WriteLiteral(" \r\n    id=\"FileChooseLink\">夾帶檔案</a>\r\n    </div>\r\n<div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 245, "\"", 285, 1);
#line 7 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_AttainFile.cshtml"
WriteAttributeValue("", 250, Html.Raw("FileList" + Model.DocId), 250, 35, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(286, 7, true);
            WriteLiteral(">\r\n    ");
            EndContext();
            BeginContext(294, 116, false);
#line 8 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_AttainFile.cshtml"
Write(await Component.InvokeAsync("BMEDAttainFileVendorList", new { id = Model.DocId, typ = "3", uniteno = Model.UniteNo}));

#line default
#line hidden
            EndContext();
            BeginContext(410, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.BuyPriceListVModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
