#pragma checksum "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a426dc22f8658bdbc399553b2da414ae2ade33f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Keep_Delete), @"mvc.1.0.view", @"/Areas/BMED/Views/Keep/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Keep/Delete.cshtml", typeof(AspNetCore.Areas_BMED_Views_Keep_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a426dc22f8658bdbc399553b2da414ae2ade33f2", @"/Areas/BMED/Views/Keep/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Keep_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.KeepModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
  
    Layout = "~/Views/Shared/_PassedLayout.cshtml";
    ViewData["Title"] = "廢除/保養";

#line default
#line hidden
            BeginContext(126, 132, true);
            WriteLiteral("\r\n<h2>廢除</h2>\r\n\r\n<h3>確定要廢除此保養單?</h3>\r\n<div>\r\n    <h4>保養</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(259, 41, false);
#line 16 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(300, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(346, 37, false);
#line 20 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(383, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(429, 47, false);
#line 24 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.UserAccount));

#line default
#line hidden
            EndContext();
            BeginContext(476, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(522, 43, false);
#line 28 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayFor(model => model.UserAccount));

#line default
#line hidden
            EndContext();
            BeginContext(565, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(611, 44, false);
#line 32 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(655, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(701, 40, false);
#line 36 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(741, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(787, 41, false);
#line 40 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DptId));

#line default
#line hidden
            EndContext();
            BeginContext(828, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(874, 39, false);
#line 44 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DptName));

#line default
#line hidden
            EndContext();
            BeginContext(913, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(959, 39, false);
#line 48 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Ext));

#line default
#line hidden
            EndContext();
            BeginContext(998, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1044, 35, false);
#line 52 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Ext));

#line default
#line hidden
            EndContext();
            BeginContext(1079, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1125, 40, false);
#line 56 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Mvpn));

#line default
#line hidden
            EndContext();
            BeginContext(1165, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1211, 36, false);
#line 60 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Mvpn));

#line default
#line hidden
            EndContext();
            BeginContext(1247, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1293, 44, false);
#line 64 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SentDate));

#line default
#line hidden
            EndContext();
            BeginContext(1337, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1383, 40, false);
#line 68 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SentDate));

#line default
#line hidden
            EndContext();
            BeginContext(1423, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1469, 42, false);
#line 72 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AccDpt));

#line default
#line hidden
            EndContext();
            BeginContext(1511, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1557, 42, false);
#line 76 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AccDptName));

#line default
#line hidden
            EndContext();
            BeginContext(1599, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1645, 43, false);
#line 80 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AssetNo));

#line default
#line hidden
            EndContext();
            BeginContext(1688, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1734, 39, false);
#line 84 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AssetNo));

#line default
#line hidden
            EndContext();
            BeginContext(1773, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1819, 45, false);
#line 88 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AssetName));

#line default
#line hidden
            EndContext();
            BeginContext(1864, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1910, 41, false);
#line 92 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AssetName));

#line default
#line hidden
            EndContext();
            BeginContext(1951, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1997, 44, false);
#line 96 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PlaceLoc));

#line default
#line hidden
            EndContext();
            BeginContext(2041, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2087, 40, false);
#line 100 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PlaceLoc));

#line default
#line hidden
            EndContext();
            BeginContext(2127, 32, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n\r\n");
            EndContext();
#line 105 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
     using (Html.BeginForm())
    {
        

#line default
#line hidden
            BeginContext(2206, 23, false);
#line 107 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(2233, 133, true);
            WriteLiteral("        <div class=\"form-actions no-color\">\r\n            <input type=\"submit\" value=\"確定送出\" class=\"btn btn-default\" /> |\r\n            ");
            EndContext();
            BeginContext(2367, 100, false);
#line 111 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
       Write(Html.ActionLink("回到案件列表", "Index", "Home", new { Area = "" }, new { style = "color : deepskyblue" }));

#line default
#line hidden
            EndContext();
            BeginContext(2467, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 113 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\Delete.cshtml"
    }

#line default
#line hidden
            BeginContext(2492, 8, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.KeepModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
