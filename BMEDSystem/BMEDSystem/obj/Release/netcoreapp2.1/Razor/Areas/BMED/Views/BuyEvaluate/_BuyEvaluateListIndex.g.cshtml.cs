#pragma checksum "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c797e5c92998afbc4089eefd2a612804c73ecc8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_BuyEvaluate__BuyEvaluateListIndex), @"mvc.1.0.view", @"/Areas/BMED/Views/BuyEvaluate/_BuyEvaluateListIndex.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/BuyEvaluate/_BuyEvaluateListIndex.cshtml", typeof(AspNetCore.Areas_BMED_Views_BuyEvaluate__BuyEvaluateListIndex))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c797e5c92998afbc4089eefd2a612804c73ecc8b", @"/Areas/BMED/Views/BuyEvaluate/_BuyEvaluateListIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_BuyEvaluate__BuyEvaluateListIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BuyEvaluateListIndex", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "BuyEvaluate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "BMED", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("BuyEvaluateListIdx"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("POST"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-begin", new global::Microsoft.AspNetCore.Html.HtmlString("$.Toast.showToast({\r\n      \'title\':\'作業進行中，請稍待...\',\r\n      \'icon\':\'loading\',\r\n      \'duration\':0\r\n      })"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-complete", new global::Microsoft.AspNetCore.Html.HtmlString("$.Toast.hideToast()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-update", new global::Microsoft.AspNetCore.Html.HtmlString("#pnlEVALUATELIST"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2, 1685, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec4fa4913ef44fbabde132f5c601b21b", async() => {
                BeginContext(388, 65, true);
                WriteLiteral("\r\n\r\n    <table>\r\n        <tr>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(454, 22, false);
#line 16 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.Label("", "表單編號"));

#line default
#line hidden
                EndContext();
                BeginContext(476, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(495, 24, false);
#line 17 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.TextBox("qtyDOCID"));

#line default
#line hidden
                EndContext();
                BeginContext(519, 55, true);
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(575, 22, false);
#line 20 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.Label("", "預算編號"));

#line default
#line hidden
                EndContext();
                BeginContext(597, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(616, 27, false);
#line 21 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.TextBox("qtyBUDGETID"));

#line default
#line hidden
                EndContext();
                BeginContext(643, 55, true);
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(699, 22, false);
#line 24 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.Label("", "申請單位"));

#line default
#line hidden
                EndContext();
                BeginContext(721, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(740, 25, false);
#line 25 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.TextBox("qtyCUSTID"));

#line default
#line hidden
                EndContext();
                BeginContext(765, 55, true);
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(821, 27, false);
#line 28 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.Label("", "儀器名稱(關鍵字)"));

#line default
#line hidden
                EndContext();
                BeginContext(848, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(867, 24, false);
#line 29 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.TextBox("qtyCNAME"));

#line default
#line hidden
                EndContext();
                BeginContext(891, 84, true);
                WriteLiteral("\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(976, 23, false);
#line 34 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.Label("", "規格已確定"));

#line default
#line hidden
                EndContext();
                BeginContext(999, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1018, 28, false);
#line 35 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.CheckBox("qtySTANDARD"));

#line default
#line hidden
                EndContext();
                BeginContext(1046, 67, true);
                WriteLiteral("\r\n            </td>\r\n            <td colspan=\"2\">\r\n                ");
                EndContext();
                BeginContext(1114, 22, false);
#line 38 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.Label("", "規格日期"));

#line default
#line hidden
                EndContext();
                BeginContext(1136, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1155, 40, false);
#line 39 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.Editor("qtyAGREEDATE1", "DateTime"));

#line default
#line hidden
                EndContext();
                BeginContext(1195, 1, true);
                WriteLiteral("~");
                EndContext();
                BeginContext(1197, 40, false);
#line 39 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
                                                     Write(Html.Editor("qtyAGREEDATE2", "DateTime"));

#line default
#line hidden
                EndContext();
                BeginContext(1237, 107, true);
                WriteLiteral("\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n        <tr>\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(1345, 22, false);
#line 45 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.Label("", "流程狀態"));

#line default
#line hidden
                EndContext();
                BeginContext(1367, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1386, 63, false);
#line 46 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
           Write(Html.DropDownList("qtyFLOWTYP", ViewData["Item"] as SelectList));

#line default
#line hidden
                EndContext();
                BeginContext(1449, 231, true);
                WriteLiteral("\r\n            </td>\r\n            <td></td>\r\n            <td></td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n    <div style=\"display:inline-block\">\r\n        <input id=\"btnQTY\" type=\"submit\" value=\"查詢\" />\r\n    </div>\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1687, 61, true);
            WriteLiteral("\r\n\r\n<div id=\"pnlEVALUATELIST\" style=\"margin-top: 20px\">\r\n    ");
            EndContext();
            BeginContext(1749, 46, false);
#line 61 "C:\Users\User\source\repos\airball91327\BMEDSystem\BMEDSystem\BMEDSystem\Areas\BMED\Views\BuyEvaluate\_BuyEvaluateListIndex.cshtml"
Write(await Component.InvokeAsync("BuyEvaluateList"));

#line default
#line hidden
            EndContext();
            BeginContext(1795, 10, true);
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
