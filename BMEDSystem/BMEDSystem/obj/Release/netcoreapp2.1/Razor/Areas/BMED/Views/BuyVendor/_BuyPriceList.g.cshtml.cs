#pragma checksum "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb47ba811eb9076b9953d2ad1662c5b0afffbf3b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_BuyVendor__BuyPriceList), @"mvc.1.0.view", @"/Areas/BMED/Views/BuyVendor/_BuyPriceList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/BuyVendor/_BuyPriceList.cshtml", typeof(AspNetCore.Areas_BMED_Views_BuyVendor__BuyPriceList))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb47ba811eb9076b9953d2ad1662c5b0afffbf3b", @"/Areas/BMED/Views/BuyVendor/_BuyPriceList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_BuyVendor__BuyPriceList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.BuyPriceListVModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/BMED/FileChooseVendor.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(54, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fed571b2774c411eb2d97420dedf2631", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(107, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
  
    int i = 0;
    var s = "";

#line default
#line hidden
            BeginContext(146, 81, true);
            WriteLiteral("    <table style=\"width: 100%\">\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(228, 43, false);
#line 10 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
           Write(Html.DisplayNameFor(model => model.DocType));

#line default
#line hidden
            EndContext();
            BeginContext(271, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(327, 41, false);
#line 13 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
           Write(Html.DisplayNameFor(model => model.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(368, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(424, 43, false);
#line 16 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
           Write(Html.DisplayNameFor(model => model.CustNam));

#line default
#line hidden
            EndContext();
            BeginContext(467, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(523, 45, false);
#line 19 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
           Write(Html.DisplayNameFor(model => model.PlantCnam));

#line default
#line hidden
            EndContext();
            BeginContext(568, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(624, 39, false);
#line 22 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
           Write(Html.DisplayNameFor(model => model.Amt));

#line default
#line hidden
            EndContext();
            BeginContext(663, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(719, 40, false);
#line 25 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
           Write(Html.DisplayNameFor(model => model.Unit));

#line default
#line hidden
            EndContext();
            BeginContext(759, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(815, 44, false);
#line 28 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
           Write(Html.DisplayNameFor(model => model.VendorNo));

#line default
#line hidden
            EndContext();
            BeginContext(859, 84, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n            <th></th>\r\n        </tr>\r\n\r\n");
            EndContext();
#line 34 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
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
            BeginContext(1181, 15, true);
            WriteLiteral("            <tr");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 1196, "\"", 1224, 2);
            WriteAttributeValue("", 1204, "background-color:", 1204, 17, true);
#line 45 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
WriteAttributeValue(" ", 1221, s, 1222, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1225, 46, true);
            WriteLiteral("}>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1272, 42, false);
#line 47 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
               Write(Html.DisplayFor(modelItem => item.DocType));

#line default
#line hidden
            EndContext();
            BeginContext(1314, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1382, 40, false);
#line 50 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
               Write(Html.DisplayFor(modelItem => item.DocId));

#line default
#line hidden
            EndContext();
            BeginContext(1422, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1490, 42, false);
#line 53 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
               Write(Html.DisplayFor(modelItem => item.CustNam));

#line default
#line hidden
            EndContext();
            BeginContext(1532, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1600, 44, false);
#line 56 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
               Write(Html.DisplayFor(modelItem => item.PlantCnam));

#line default
#line hidden
            EndContext();
            BeginContext(1644, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1712, 38, false);
#line 59 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Amt));

#line default
#line hidden
            EndContext();
            BeginContext(1750, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1818, 39, false);
#line 62 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Unit));

#line default
#line hidden
            EndContext();
            BeginContext(1857, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1925, 44, false);
#line 65 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
               Write(Html.DisplayFor(modelItem => item.VendorNam));

#line default
#line hidden
            EndContext();
            BeginContext(1969, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2037, 44, false);
#line 68 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
               Write(await Html.PartialAsync("_AttainFile", item));

#line default
#line hidden
            EndContext();
            BeginContext(2081, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2149, 97, false);
#line 71 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
               Write(Html.ActionLink("上傳完成", "Upload", "BuyVendor", new {id = item.DocId, vno = item.VendorNo }, null));

#line default
#line hidden
            EndContext();
            BeginContext(2246, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 74 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyVendor\_BuyPriceList.cshtml"
        }

#line default
#line hidden
            BeginContext(2301, 16, true);
            WriteLiteral("\r\n    </table>\r\n");
            EndContext();
            BeginContext(2320, 54, true);
            WriteLiteral("<div id=\"AttainFileDialog\" class=\"hidden\">\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.BuyPriceListVModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
