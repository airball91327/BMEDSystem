#pragma checksum "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6526c69b87c462dab3965a5d27bb36e8e7f4af98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AppUser_Delete), @"mvc.1.0.view", @"/Views/AppUser/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AppUser/Delete.cshtml", typeof(AspNetCore.Views_AppUser_Delete))]
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
#line 1 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\_ViewImports.cshtml"
using EDIS;

#line default
#line hidden
#line 3 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\_ViewImports.cshtml"
using EDIS.Models;

#line default
#line hidden
#line 4 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\_ViewImports.cshtml"
using EDIS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\_ViewImports.cshtml"
using EDIS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6526c69b87c462dab3965a5d27bb36e8e7f4af98", @"/Views/AppUser/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5dac140ed5edfa1968e0107fb9101271cf40612", @"/Views/_ViewImports.cshtml")]
    public class Views_AppUser_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.AppUserModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
  
    ViewBag.Title = "刪除/使用者";

#line default
#line hidden
            BeginContext(73, 133, true);
            WriteLiteral("\r\n<h2>刪除</h2>\r\n\r\n<h3>您確定要刪除此資料?</h3>\r\n<div>\r\n    <h4>使用者</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(207, 44, false);
#line 15 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(251, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(297, 40, false);
#line 19 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
       Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(337, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(383, 44, false);
#line 23 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
            EndContext();
            BeginContext(427, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(473, 40, false);
#line 27 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Password));

#line default
#line hidden
            EndContext();
            BeginContext(513, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(559, 41, false);
#line 31 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(600, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(646, 37, false);
#line 35 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(683, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(729, 47, false);
#line 39 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
            EndContext();
            BeginContext(776, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(822, 43, false);
#line 43 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DateCreated));

#line default
#line hidden
            EndContext();
            BeginContext(865, 45, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(911, 52, false);
#line 47 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.LastActivityDate));

#line default
#line hidden
            EndContext();
            BeginContext(963, 45, true);
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1009, 48, false);
#line 51 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
       Write(Html.DisplayFor(model => model.LastActivityDate));

#line default
#line hidden
            EndContext();
            BeginContext(1057, 32, true);
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n\r\n");
            EndContext();
#line 56 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
     using (Html.BeginForm()) {
        

#line default
#line hidden
            BeginContext(1131, 23, false);
#line 57 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(1158, 133, true);
            WriteLiteral("        <div class=\"form-actions no-color\">\r\n            <input type=\"submit\" value=\"確定刪除\" class=\"btn btn-default\" /> |\r\n            ");
            EndContext();
            BeginContext(1292, 35, false);
#line 61 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
       Write(Html.ActionLink("回到使用者列表", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(1327, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 63 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Views\AppUser\Delete.cshtml"
    }

#line default
#line hidden
            BeginContext(1352, 8, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.AppUserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
