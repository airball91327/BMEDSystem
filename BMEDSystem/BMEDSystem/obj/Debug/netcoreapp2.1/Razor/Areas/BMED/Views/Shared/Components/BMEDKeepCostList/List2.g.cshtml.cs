#pragma checksum "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11cca94704cfaf2d685d6b5382216f50f7f2457c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDKeepCostList_List2), @"mvc.1.0.view", @"/Areas/BMED/Views/Shared/Components/BMEDKeepCostList/List2.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Shared/Components/BMEDKeepCostList/List2.cshtml", typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BMEDKeepCostList_List2))]
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
#line 2 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
using EDIS.Models.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11cca94704cfaf2d685d6b5382216f50f7f2457c", @"/Areas/BMED/Views/Shared/Components/BMEDKeepCostList/List2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Shared_Components_BMEDKeepCostList_List2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.KeepCostModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(76, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(160, 19, true);
            WriteLiteral("\r\n<h3>費用明細</h3>\r\n\r\n");
            EndContext();
#line 10 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
 if ((ViewData["HideCost"].ToString() == "Y") &&
   (UserManager.IsInRole(User, "Admin") || UserManager.IsInRole(User, "MedAdmin") ||
    UserManager.IsInRole(User, "MedAssetMgr") || UserManager.IsInRole(User, "MedMgr") ||
    UserManager.IsInRole(User, "MedEngineer") || UserManager.IsInRole(User, "Engineer")) == false)
{

#line default
#line hidden
            BeginContext(539, 75, true);
            WriteLiteral("    <table class=\"table\">\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(615, 41, false);
#line 18 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.SeqNo));

#line default
#line hidden
            EndContext();
            BeginContext(656, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(712, 45, false);
#line 21 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.StockType));

#line default
#line hidden
            EndContext();
            BeginContext(757, 76, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                料號/\r\n                ");
            EndContext();
            BeginContext(834, 44, false);
#line 25 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.PartName));

#line default
#line hidden
            EndContext();
            BeginContext(878, 76, true);
            WriteLiteral("/\r\n                規格\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(955, 39, false);
#line 29 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.Qty));

#line default
#line hidden
            EndContext();
            BeginContext(994, 36, true);
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n");
            EndContext();
#line 32 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
         if (Model.Count() > 0)
        {
            foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1130, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1203, 40, false);
#line 38 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.SeqNo));

#line default
#line hidden
            EndContext();
            BeginContext(1243, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1323, 44, false);
#line 41 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.StockType));

#line default
#line hidden
            EndContext();
            BeginContext(1367, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1447, 41, false);
#line 44 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PartNo));

#line default
#line hidden
            EndContext();
            BeginContext(1488, 58, true);
            WriteLiteral("\r\n                        <br />\r\n                        ");
            EndContext();
            BeginContext(1547, 43, false);
#line 46 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PartName));

#line default
#line hidden
            EndContext();
            BeginContext(1590, 58, true);
            WriteLiteral("\r\n                        <br />\r\n                        ");
            EndContext();
            BeginContext(1649, 43, false);
#line 48 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Standard));

#line default
#line hidden
            EndContext();
            BeginContext(1692, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1772, 38, false);
#line 51 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Qty));

#line default
#line hidden
            EndContext();
            BeginContext(1810, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 54 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(1888, 14, true);
            WriteLiteral("    </table>\r\n");
            EndContext();
#line 57 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1914, 75, true);
            WriteLiteral("    <table class=\"table\">\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1990, 41, false);
#line 63 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.SeqNo));

#line default
#line hidden
            EndContext();
            BeginContext(2031, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2087, 45, false);
#line 66 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.StockType));

#line default
#line hidden
            EndContext();
            BeginContext(2132, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2188, 46, false);
#line 69 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.VendorName));

#line default
#line hidden
            EndContext();
            BeginContext(2234, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2290, 57, false);
#line 72 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.TicketDtl.TicketDtlNo));

#line default
#line hidden
            EndContext();
            BeginContext(2347, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2403, 47, false);
#line 75 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.AccountDate));

#line default
#line hidden
            EndContext();
            BeginContext(2450, 76, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                料號/\r\n                ");
            EndContext();
            BeginContext(2527, 44, false);
#line 79 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.PartName));

#line default
#line hidden
            EndContext();
            BeginContext(2571, 76, true);
            WriteLiteral("/\r\n                規格\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2648, 39, false);
#line 83 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.Qty));

#line default
#line hidden
            EndContext();
            BeginContext(2687, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2743, 41, false);
#line 86 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(2784, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2840, 45, false);
#line 89 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalCost));

#line default
#line hidden
            EndContext();
            BeginContext(2885, 36, true);
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n");
            EndContext();
#line 92 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
         if (Model.Count() > 0)
        {
            foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(3021, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3094, 40, false);
#line 98 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.SeqNo));

#line default
#line hidden
            EndContext();
            BeginContext(3134, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3214, 44, false);
#line 101 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.StockType));

#line default
#line hidden
            EndContext();
            BeginContext(3258, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3338, 43, false);
#line 104 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.VendorId));

#line default
#line hidden
            EndContext();
            BeginContext(3381, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(3408, 45, false);
#line 105 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.VendorName));

#line default
#line hidden
            EndContext();
            BeginContext(3453, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3533, 56, false);
#line 108 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TicketDtl.TicketDtlNo));

#line default
#line hidden
            EndContext();
            BeginContext(3589, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3669, 45, false);
#line 111 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(item.AccountDate.Value.ToString("yyyy/MM/dd"));

#line default
#line hidden
            EndContext();
            BeginContext(3714, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3794, 41, false);
#line 114 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PartNo));

#line default
#line hidden
            EndContext();
            BeginContext(3835, 58, true);
            WriteLiteral("\r\n                        <br />\r\n                        ");
            EndContext();
            BeginContext(3894, 43, false);
#line 116 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PartName));

#line default
#line hidden
            EndContext();
            BeginContext(3937, 58, true);
            WriteLiteral("\r\n                        <br />\r\n                        ");
            EndContext();
            BeginContext(3996, 43, false);
#line 118 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Standard));

#line default
#line hidden
            EndContext();
            BeginContext(4039, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4119, 38, false);
#line 121 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Qty));

#line default
#line hidden
            EndContext();
            BeginContext(4157, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4237, 40, false);
#line 124 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(4277, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4357, 44, false);
#line 127 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TotalCost));

#line default
#line hidden
            EndContext();
            BeginContext(4401, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 130 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(4479, 14, true);
            WriteLiteral("    </table>\r\n");
            EndContext();
#line 133 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BMEDKeepCostList\List2.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CustomSignInManager SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CustomUserManager UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.KeepCostModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591