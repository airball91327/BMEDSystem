#pragma checksum "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef41ed650a676fa7342e34653d30b7313e12c987"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Delivery__DeliveryList), @"mvc.1.0.view", @"/Areas/BMED/Views/Delivery/_DeliveryList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Delivery/_DeliveryList.cshtml", typeof(AspNetCore.Areas_BMED_Views_Delivery__DeliveryList))]
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
#line 2 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
using EDIS.Models.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef41ed650a676fa7342e34653d30b7313e12c987", @"/Areas/BMED/Views/Delivery/_DeliveryList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Delivery__DeliveryList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.DeliveryListVModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(82, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(162, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
 if (Model.Count() <= 0)
{

#line default
#line hidden
            BeginContext(193, 39, true);
            WriteLiteral("    <p class=\"text-danger\">無任何資料!</p>\r\n");
            EndContext();
#line 10 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"

}
else
{

#line default
#line hidden
            BeginContext(246, 118, true);
            WriteLiteral("    <table class=\"table\" style=\"width: 100%\">\r\n        <tr>\r\n            <th></th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(365, 43, false);
#line 18 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.DocType));

#line default
#line hidden
            EndContext();
            BeginContext(408, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(464, 41, false);
#line 21 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(505, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(561, 43, false);
#line 24 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.Company));

#line default
#line hidden
            EndContext();
            BeginContext(604, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(660, 45, false);
#line 27 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.AccDptNam));

#line default
#line hidden
            EndContext();
            BeginContext(705, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(761, 46, false);
#line 30 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.ContractNo));

#line default
#line hidden
            EndContext();
            BeginContext(807, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(863, 46, false);
#line 33 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.PurchaseNo));

#line default
#line hidden
            EndContext();
            BeginContext(909, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(965, 45, false);
#line 36 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.CrlItemNo));

#line default
#line hidden
            EndContext();
            BeginContext(1010, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1066, 44, false);
#line 39 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.BudgetId));

#line default
#line hidden
            EndContext();
            BeginContext(1110, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1166, 40, false);
#line 42 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
           Write(Html.DisplayNameFor(model => model.Days));

#line default
#line hidden
            EndContext();
            BeginContext(1206, 36, true);
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n");
            EndContext();
#line 45 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
          
            int i = 0;
            var s = "#efeeef";
        

#line default
#line hidden
            BeginContext(1321, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 49 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1370, 40, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n");
            EndContext();
#line 53 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
                     if (item.Flg == "?" && UserManager.GetCurrentUserId(User) == item.FlowUid)
                    {
                        

#line default
#line hidden
            BeginContext(1555, 93, false);
#line 55 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
                   Write(Html.ActionLink("編輯", "Edit", "Delivery", new { id = item.DocId }, new { target = "_blank" }));

#line default
#line hidden
            EndContext();
#line 55 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
                                                                                                                      
                    }
                    else
                    {
                        

#line default
#line hidden
            BeginContext(1747, 96, false);
#line 59 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
                   Write(Html.ActionLink("查看", "Details", "Delivery", new { id = item.DocId }, new { target = "_blank" }));

#line default
#line hidden
            EndContext();
#line 59 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
                                                                                                                         
                    }

#line default
#line hidden
            BeginContext(1868, 65, true);
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1934, 42, false);
#line 63 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.DocType));

#line default
#line hidden
            EndContext();
            BeginContext(1976, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2044, 40, false);
#line 66 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(2084, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2152, 45, false);
#line 69 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.CompanyNam));

#line default
#line hidden
            EndContext();
            BeginContext(2197, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2265, 44, false);
#line 72 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.AccDptNam));

#line default
#line hidden
            EndContext();
            BeginContext(2309, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2377, 45, false);
#line 75 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.ContractNo));

#line default
#line hidden
            EndContext();
            BeginContext(2422, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2490, 45, false);
#line 78 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.PurchaseNo));

#line default
#line hidden
            EndContext();
            BeginContext(2535, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2603, 44, false);
#line 81 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.CrlItemNo));

#line default
#line hidden
            EndContext();
            BeginContext(2647, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2715, 43, false);
#line 84 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.BudgetId));

#line default
#line hidden
            EndContext();
            BeginContext(2758, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2826, 39, false);
#line 87 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Days));

#line default
#line hidden
            EndContext();
            BeginContext(2865, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 99 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
                   
        }

#line default
#line hidden
            BeginContext(3373, 16, true);
            WriteLiteral("\r\n    </table>\r\n");
            EndContext();
#line 103 "J:\GitHub\Repos\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\Delivery\_DeliveryList.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CustomRoleManager RoleManager { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.DeliveryListVModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
