#pragma checksum "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e510734507fc10cd34e5ad004b3f226f45be5f41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BuyEvaluateList_Default), @"mvc.1.0.view", @"/Areas/BMED/Views/Shared/Components/BuyEvaluateList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Shared/Components/BuyEvaluateList/Default.cshtml", typeof(AspNetCore.Areas_BMED_Views_Shared_Components_BuyEvaluateList_Default))]
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
#line 1 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS;

#line default
#line hidden
#line 3 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models;

#line default
#line hidden
#line 4 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\_ViewImports.cshtml"
using EDIS.Models.ManageViewModels;

#line default
#line hidden
#line 2 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
using EDIS.Models.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e510734507fc10cd34e5ad004b3f226f45be5f41", @"/Areas/BMED/Views/Shared/Components/BuyEvaluateList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Shared_Components_BuyEvaluateList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.BuyEvaluateListVModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/BMED/AssetFileUpload.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(84, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(164, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(166, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebf40de4c6304d0eb6966dc142dfcf3e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 7 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(244, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 9 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
  
    int i = 0;
    var s = "";
    if (ViewData["Sdate"] != null)
    {
        

#line default
#line hidden
            BeginContext(337, 140, false);
#line 14 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
   Write(Html.ActionLink("匯出規格", "ExcelStandard", new { sd = ViewData["Sdate"], ed = ViewData["Edate"] }
               , new { @class = "button" }));

#line default
#line hidden
            EndContext();
#line 15 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                                           
    }


#line default
#line hidden
            BeginContext(488, 81, true);
            WriteLiteral("    <table style=\"width: 100%\">\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(570, 43, false);
#line 21 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.DocType));

#line default
#line hidden
            EndContext();
            BeginContext(613, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(669, 41, false);
#line 24 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(710, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(766, 44, false);
#line 27 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.BudgetId));

#line default
#line hidden
            EndContext();
            BeginContext(810, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(866, 43, false);
#line 30 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.CustNam));

#line default
#line hidden
            EndContext();
            BeginContext(909, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(965, 45, false);
#line 33 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.PlantCnam));

#line default
#line hidden
            EndContext();
            BeginContext(1010, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1066, 43, false);
#line 36 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.EngName));

#line default
#line hidden
            EndContext();
            BeginContext(1109, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1165, 45, false);
#line 39 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.FlowUname));

#line default
#line hidden
            EndContext();
            BeginContext(1210, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1266, 45, false);
#line 42 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.AgreeDate));

#line default
#line hidden
            EndContext();
            BeginContext(1311, 122, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                廠商上傳狀況\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n\r\n");
            EndContext();
#line 50 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
         foreach (var item in Model)
        {
            i++;
            if (i % 2 == 0)
            {
                s = "#efeeef";
            }
            else
            {
                s = "#ffffff";
            }

#line default
#line hidden
            BeginContext(1671, 15, true);
            WriteLiteral("            <tr");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 1686, "\"", 1714, 2);
            WriteAttributeValue("", 1694, "background-color:", 1694, 17, true);
#line 61 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
WriteAttributeValue(" ", 1711, s, 1712, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1715, 47, true);
            WriteLiteral(" }>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1763, 42, false);
#line 63 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.DocType));

#line default
#line hidden
            EndContext();
            BeginContext(1805, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1873, 40, false);
#line 66 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(1913, 87, true);
            WriteLiteral("\r\n                </td>\r\n                <td style=\"color: blue\">\r\n                    ");
            EndContext();
            BeginContext(2001, 43, false);
#line 69 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.BudgetId));

#line default
#line hidden
            EndContext();
            BeginContext(2044, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2112, 41, false);
#line 72 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.CustId));

#line default
#line hidden
            EndContext();
            BeginContext(2153, 28, true);
            WriteLiteral("<br />\r\n                    ");
            EndContext();
            BeginContext(2182, 42, false);
#line 73 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.CustNam));

#line default
#line hidden
            EndContext();
            BeginContext(2224, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2292, 44, false);
#line 76 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.PlantCnam));

#line default
#line hidden
            EndContext();
            BeginContext(2336, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2404, 42, false);
#line 79 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.EngName));

#line default
#line hidden
            EndContext();
            BeginContext(2446, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2514, 44, false);
#line 82 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.FlowUname));

#line default
#line hidden
            EndContext();
            BeginContext(2558, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2626, 44, false);
#line 85 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.AgreeDate));

#line default
#line hidden
            EndContext();
            BeginContext(2670, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2738, 75, false);
#line 88 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
               Write(await Component.InvokeAsync("BuyVendorStatusList", new { id = item.DocId }));

#line default
#line hidden
            EndContext();
            BeginContext(2813, 47, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            EndContext();
#line 91 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                     if (item.Flg == "?" && UserManager.GetCurrentUserId(User) == item.FlowUid)
                    {
                        

#line default
#line hidden
            BeginContext(3005, 94, false);
#line 93 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                   Write(Html.ActionLink("編輯", "Edit", "BuyEvaluate", new { id = item.DocId, sid = item.DocSid }, null));

#line default
#line hidden
            EndContext();
#line 93 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                                                                                                                       
                        if (UserManager.IsInRole(User, "BuyerMgr"))
                        {
                            

#line default
#line hidden
            BeginContext(3226, 14, false);
#line 96 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                       Write(Html.Raw("| "));

#line default
#line hidden
            EndContext();
            BeginContext(3271, 77, false);
#line 97 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                       Write(Html.ActionLink("刪除", "Delete", "BuyEvaluate", new { id = item.DocId }, null));

#line default
#line hidden
            EndContext();
#line 97 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                                                                                                          
                        }
                    }
                    else
                    {
                        

#line default
#line hidden
            BeginContext(3474, 78, false);
#line 102 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                   Write(Html.ActionLink("查看", "Details", "BuyEvaluate", new { id = item.DocId }, null));

#line default
#line hidden
            EndContext();
#line 102 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                                                                                                       
                    }

#line default
#line hidden
            BeginContext(3577, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 104 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                     if (UserManager.IsInRole(User, "Buyer"))
                    {
                        if (item.Flg == "2" || item.Flg == "E")
                        {
                            

#line default
#line hidden
            BeginContext(3784, 14, false);
#line 108 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                       Write(Html.Raw("| "));

#line default
#line hidden
            EndContext();
            BeginContext(3829, 74, false);
#line 109 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                       Write(Html.ActionLink("驗收", "Create", "Delivery", new { id = item.DocId }, null));

#line default
#line hidden
            EndContext();
#line 109 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                                                                                                       
                        }
                    }

#line default
#line hidden
            BeginContext(3955, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 115 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
            if (item.Flg == "2")
            {

#line default
#line hidden
            BeginContext(4048, 19, true);
            WriteLiteral("                <tr");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 4067, "\"", 4095, 2);
            WriteAttributeValue("", 4075, "background-color:", 4075, 17, true);
#line 117 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
WriteAttributeValue(" ", 4092, s, 4093, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4096, 112, true);
            WriteLiteral(" }>\r\n                    <td colspan=\"5\" style=\"padding-left: 30px; color: lightgray\">\r\n                        ");
            EndContext();
            BeginContext(4209, 97, false);
#line 119 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
                   Write(await Component.InvokeAsync("BuyEvaluateAssetListItem", new { id = item.DocId, upload = "採購人員" }));

#line default
#line hidden
            EndContext();
            BeginContext(4306, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 122 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\BuyEvaluateList\Default.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(4384, 16, true);
            WriteLiteral("\r\n    </table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.BuyEvaluateListVModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
