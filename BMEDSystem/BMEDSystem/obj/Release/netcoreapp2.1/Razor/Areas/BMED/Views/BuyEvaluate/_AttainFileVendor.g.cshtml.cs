#pragma checksum "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_AttainFileVendor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f6eba7d6b107998fd6f43bf281c1049a7aed380"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_BuyEvaluate__AttainFileVendor), @"mvc.1.0.view", @"/Areas/BMED/Views/BuyEvaluate/_AttainFileVendor.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/BuyEvaluate/_AttainFileVendor.cshtml", typeof(AspNetCore.Areas_BMED_Views_BuyEvaluate__AttainFileVendor))]
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
#line 1 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS;

#line default
#line hidden
#line 3 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models;

#line default
#line hidden
#line 4 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f6eba7d6b107998fd6f43bf281c1049a7aed380", @"/Areas/BMED/Views/BuyEvaluate/_AttainFileVendor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_BuyEvaluate__AttainFileVendor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.BuyPriceListVModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(39, 84, true);
            WriteLiteral("\r\n<table>\r\n    <tr>\r\n        <td>\r\n            <div id=\"FileList\">\r\n                ");
            EndContext();
            BeginContext(124, 92, false);
#line 7 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_AttainFileVendor.cshtml"
           Write(await Component.InvokeAsync("BMEDAttainFileVendorList", new { id = Model.DocId, typ = "3" }));

#line default
#line hidden
            EndContext();
            BeginContext(216, 66, true);
            WriteLiteral("\r\n            </div>\r\n        </td>\r\n        <td><a class=\"button\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 282, "\"", 358, 1);
#line 10 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_AttainFileVendor.cshtml"
WriteAttributeValue("", 289, Url.Content("~/BMED/AttainFile/Create?id=" + Model.DocId + "&typ=3"), 289, 69, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(359, 119, true);
            WriteLiteral(" \r\n    id=\"FileChooseLink\">夾帶檔案</a></td>\r\n    </tr>\r\n\r\n</table>\r\n\r\n<div id=\"AttainFileDialog\" class=\"hidden\">\r\n</div>\r\n");
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
