#pragma checksum "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b71bfa3da1b44c20f29325c0ec4c22e44661b96f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDAttainFileList_List2), @"mvc.1.0.view", @"/Areas/BMED/Views/Shared/Components/BMEDAttainFileList/List2.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Shared/Components/BMEDAttainFileList/List2.cshtml", typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDAttainFileList_List2))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b71bfa3da1b44c20f29325c0ec4c22e44661b96f", @"/Areas/BMED/Views/Shared/Components/BMEDAttainFileList/List2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Shared_Components_BMEDAttainFileList_List2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.AttainFileModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
  
    Layout = "";

#line default
#line hidden
#line 6 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
 if (Model.Count() > 0)
{

#line default
#line hidden
            BeginContext(104, 100, true);
            WriteLiteral("    <table style=\"width: 100%;margin-left: 30px;\">\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(205, 41, false);
#line 11 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.SeqNo));

#line default
#line hidden
            EndContext();
            BeginContext(246, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(302, 41, false);
#line 14 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(343, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(399, 44, false);
#line 17 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.FileLink));

#line default
#line hidden
            EndContext();
            BeginContext(443, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(499, 39, false);
#line 20 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.Rtp));

#line default
#line hidden
            EndContext();
            BeginContext(538, 59, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n");
            EndContext();
#line 24 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(646, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(685, 40, false);
#line 27 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
               Write(Html.DisplayFor(modelItem => item.SeqNo));

#line default
#line hidden
            EndContext();
            BeginContext(725, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(753, 40, false);
#line 28 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
               Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
            EndContext();
            BeginContext(793, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 29 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
                 if (item.DocType == "2")
                {

#line default
#line hidden
            BeginContext(862, 26, true);
            WriteLiteral("                    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 888, "\'", 938, 2);
#line 31 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
WriteAttributeValue("", 895, Url.Content("~/Files/BMED/"), 895, 29, false);

#line default
#line hidden
#line 31 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
WriteAttributeValue("", 924, item.FileLink, 924, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(939, 30, true);
            WriteLiteral(" target=\"_blank\">下載</a></td>\r\n");
            EndContext();
#line 32 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1029, 26, true);
            WriteLiteral("                    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 1055, "\'", 1105, 2);
#line 35 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
WriteAttributeValue("", 1062, Url.Content("~/Files/BMED/"), 1062, 29, false);

#line default
#line hidden
#line 35 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
WriteAttributeValue("", 1091, item.FileLink, 1091, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1106, 30, true);
            WriteLiteral(" target=\"_blank\">下載</a></td>\r\n");
            EndContext();
#line 36 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
                }

#line default
#line hidden
            BeginContext(1155, 20, true);
            WriteLiteral("                <td>");
            EndContext();
            BeginContext(1176, 43, false);
#line 37 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
               Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(1219, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 39 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
        }

#line default
#line hidden
            BeginContext(1256, 26, true);
            WriteLiteral("    </table>\r\n    <hr />\r\n");
            EndContext();
#line 42 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\List2.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.AttainFileModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
