#pragma checksum "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormatDtl\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01e758077394188f5c964c7324d955d847502fbf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_KeepFormatDtl_Delete), @"mvc.1.0.view", @"/Areas/BMED/Views/KeepFormatDtl/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/KeepFormatDtl/Delete.cshtml", typeof(AspNetCore.Areas_BMED_Views_KeepFormatDtl_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01e758077394188f5c964c7324d955d847502fbf", @"/Areas/BMED/Views/KeepFormatDtl/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_KeepFormatDtl_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.KeepFormatDtlModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(39, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormatDtl\Delete.cshtml"
  
    Layout = "~/Views/Shared/_PassedLayout.cshtml";
    ViewBag.Title = "刪除/保養格式明細";

#line default
#line hidden
            BeginContext(135, 139, true);
            WriteLiteral("\r\n<h2>刪除</h2>\r\n\r\n<h3>您確定要刪除此記錄嗎?</h3>\r\n<div>\r\n    <h4>保養格式明細</h4>\r\n    <hr />\r\n\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(275, 53, false);
#line 17 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormatDtl\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.KeepFormat.Plants));

#line default
#line hidden
            EndContext();
            BeginContext(328, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(374, 49, false);
#line 21 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormatDtl\Delete.cshtml"
       Write(Html.DisplayFor(model => model.KeepFormat.Plants));

#line default
#line hidden
            EndContext();
            BeginContext(423, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(469, 44, false);
#line 25 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormatDtl\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Descript));

#line default
#line hidden
            EndContext();
            BeginContext(513, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(559, 40, false);
#line 29 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormatDtl\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Descript));

#line default
#line hidden
            EndContext();
            BeginContext(599, 32, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n\r\n");
            EndContext();
#line 34 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormatDtl\Delete.cshtml"
     using (Html.BeginForm())
    {
        

#line default
#line hidden
            BeginContext(678, 23, false);
#line 36 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormatDtl\Delete.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(712, 39, false);
#line 37 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormatDtl\Delete.cshtml"
   Write(Html.HiddenFor(model => model.FormatId));

#line default
#line hidden
            EndContext();
            BeginContext(762, 34, false);
#line 38 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormatDtl\Delete.cshtml"
   Write(Html.HiddenFor(model => model.Sno));

#line default
#line hidden
            EndContext();
            BeginContext(798, 157, true);
            WriteLiteral("        <div class=\"form-actions no-color\">\r\n            <input type=\"submit\" value=\"確定刪除\" class=\"btn btn-default\" />\r\n            <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 955, "\"", 1039, 1);
#line 41 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormatDtl\Delete.cshtml"
WriteAttributeValue("", 962, Url.Action("Edit", "KeepFormat", new { Area = "BMED", id = Model.FormatId }), 962, 77, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1040, 27, true);
            WriteLiteral(">回到列表</a>\r\n        </div>\r\n");
            EndContext();
#line 43 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\KeepFormatDtl\Delete.cshtml"
    }

#line default
#line hidden
            BeginContext(1074, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.KeepFormatDtlModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
