#pragma checksum "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\ResignEng.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe76e1b1bb97625619494b0b198eb55677ab4147"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Repair_ResignEng), @"mvc.1.0.view", @"/Areas/BMED/Views/Repair/ResignEng.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Repair/ResignEng.cshtml", typeof(AspNetCore.Areas_BMED_Views_Repair_ResignEng))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe76e1b1bb97625619494b0b198eb55677ab4147", @"/Areas/BMED/Views/Repair/ResignEng.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Repair_ResignEng : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\ResignEng.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(27, 13, true);
            WriteLiteral("\r\n<div>\r\n    ");
            EndContext();
            BeginContext(41, 44, false);
#line 6 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Repair\ResignEng.cshtml"
Write(await Component.InvokeAsync("BMEDRepResign"));

#line default
#line hidden
            EndContext();
            BeginContext(85, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
