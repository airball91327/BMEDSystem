#pragma checksum "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eddb03db8f664c310d55f0911b51473060e43396"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDAttainFileList_AjaxView), @"mvc.1.0.view", @"/Areas/BMED/Views/Shared/Components/BMEDAttainFileList/AjaxView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Shared/Components/BMEDAttainFileList/AjaxView.cshtml", typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDAttainFileList_AjaxView))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eddb03db8f664c310d55f0911b51473060e43396", @"/Areas/BMED/Views/Shared/Components/BMEDAttainFileList/AjaxView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Shared_Components_BMEDAttainFileList_AjaxView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.AttainFileModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
  
    Layout = "";

#line default
#line hidden
#line 6 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
 if (Model.Count() > 0)
{

#line default
#line hidden
            BeginContext(104, 100, true);
            WriteLiteral("    <table style=\"width: 100%;margin-left: 30px;\">\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(205, 41, false);
#line 11 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
           Write(Html.DisplayNameFor(model => model.SeqNo));

#line default
#line hidden
            EndContext();
            BeginContext(246, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(302, 41, false);
#line 14 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(343, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(399, 44, false);
#line 17 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
           Write(Html.DisplayNameFor(model => model.FileLink));

#line default
#line hidden
            EndContext();
            BeginContext(443, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(499, 39, false);
#line 20 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
           Write(Html.DisplayNameFor(model => model.Rtp));

#line default
#line hidden
            EndContext();
            BeginContext(538, 59, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n");
            EndContext();
#line 24 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(646, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(685, 40, false);
#line 27 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
               Write(Html.DisplayFor(modelItem => item.SeqNo));

#line default
#line hidden
            EndContext();
            BeginContext(725, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(753, 40, false);
#line 28 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
               Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
            EndContext();
            BeginContext(793, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 29 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
                 if (item.DocType == "2")
                {

#line default
#line hidden
            BeginContext(862, 52, true);
            WriteLiteral("                    <td>\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 914, "\'", 964, 2);
#line 32 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
WriteAttributeValue("", 921, Url.Content("~/Files/BMED/"), 921, 29, false);

#line default
#line hidden
#line 32 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
WriteAttributeValue("", 950, item.FileLink, 950, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(965, 52, true);
            WriteLiteral(" target=\"_blank\">下載</a>\r\n                    </td>\r\n");
            EndContext();
#line 34 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1077, 52, true);
            WriteLiteral("                    <td>\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 1129, "\'", 1179, 2);
#line 38 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
WriteAttributeValue("", 1136, Url.Content("~/Files/BMED/"), 1136, 29, false);

#line default
#line hidden
#line 38 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
WriteAttributeValue("", 1165, item.FileLink, 1165, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1180, 52, true);
            WriteLiteral(" target=\"_blank\">下載</a>\r\n                    </td>\r\n");
            EndContext();
#line 40 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
                }

#line default
#line hidden
            BeginContext(1251, 20, true);
            WriteLiteral("                <td>");
            EndContext();
            BeginContext(1272, 43, false);
#line 41 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
               Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(1315, 49, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1365, 630, false);
#line 43 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
               Write(Html.ActionLink("刪除", "Delete", "AttainFile",  new { Area = "BMED", id = item.DocId, seq = item.SeqNo, typ = item.DocType },
                                                                   new
                                                                   {
                                                                       data_ajax = "true",
                                                                       data_ajax_method = "GET",
                                                                       data_ajax_update = "#pnlFILES"
                                                                   }));

#line default
#line hidden
            EndContext();
            BeginContext(1995, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 52 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
        }

#line default
#line hidden
            BeginContext(2050, 14, true);
            WriteLiteral("    </table>\r\n");
            EndContext();
#line 54 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDAttainFileList\AjaxView.cshtml"
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
