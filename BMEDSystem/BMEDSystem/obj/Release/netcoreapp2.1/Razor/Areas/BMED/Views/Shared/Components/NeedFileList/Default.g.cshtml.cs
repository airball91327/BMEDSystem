#pragma checksum "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fed4daeeb92e860fcf48ae463e188b8612ca4a3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Shared_Components_NeedFileList_Default), @"mvc.1.0.view", @"/Areas/BMED/Views/Shared/Components/NeedFileList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Shared/Components/NeedFileList/Default.cshtml", typeof(AspNetCore.Areas_BMED_Views_Shared_Components_NeedFileList_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fed4daeeb92e860fcf48ae463e188b8612ca4a3c", @"/Areas/BMED/Views/Shared/Components/NeedFileList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Shared_Components_NeedFileList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.NeedFileModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/BMED/MutiFileUpload.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 8, true);
            WriteLiteral("<html>\r\n");
            EndContext();
            BeginContext(55, 93, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72c34e2853344af9a86ef287d3ae4c00", async() => {
                BeginContext(61, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(67, 51, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01aeeb2cf2634ec984b2b3b76bcd7678", async() => {
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
                BeginContext(118, 23, true);
                WriteLiteral("\r\n    <title></title>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(148, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
            BeginContext(187, 1615, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f26e48333c0b497f948342e9309ce1c3", async() => {
                BeginContext(193, 63, true);
                WriteLiteral("\r\n    <table>\r\n        <tr>\r\n            <th>\r\n                ");
                EndContext();
                BeginContext(257, 41, false);
#line 14 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.SeqNo));

#line default
#line hidden
                EndContext();
                BeginContext(298, 55, true);
                WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
                EndContext();
                BeginContext(354, 41, false);
#line 17 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
                EndContext();
                BeginContext(395, 55, true);
                WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
                EndContext();
                BeginContext(451, 43, false);
#line 20 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
           Write(Html.DisplayNameFor(model => model.FileDes));

#line default
#line hidden
                EndContext();
                BeginContext(494, 61, true);
                WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n\r\n");
                EndContext();
#line 25 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
                BeginContext(604, 60, true);
                WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
                EndContext();
                BeginContext(665, 40, false);
#line 29 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.SeqNo));

#line default
#line hidden
                EndContext();
                BeginContext(705, 67, true);
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
                EndContext();
                BeginContext(773, 40, false);
#line 32 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
                EndContext();
                BeginContext(813, 67, true);
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
                EndContext();
                BeginContext(881, 42, false);
#line 35 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
               Write(Html.DisplayFor(modelItem => item.FileDes));

#line default
#line hidden
                EndContext();
                BeginContext(923, 84, true);
                WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a class=\"button\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1007, "\"", 1136, 1);
#line 38 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
WriteAttributeValue("", 1014, Url.Content("~/BMED/AssetFile/Create?id=" + ViewData["ano"] +
            "&sno=" + item.SeqNo + "&title=" + item.Title), 1014, 122, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1137, 97, true);
                WriteLiteral("\r\n                       id=\"AssetFileChooseLink\">上傳檔案</a>\r\n                    <a class=\"button\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1234, "\"", 1338, 1);
#line 41 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
WriteAttributeValue("", 1241, Url.Content("~/BMED/AssetFile/CopyTo?id=" + ViewData["ano"] +
            "&sno=" + item.SeqNo), 1241, 97, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1339, 176, true);
                WriteLiteral("\r\n                       id=\"AssetFileCopyLink\">複製檔案</a>\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td colspan=\"4\">\r\n                    <div");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 1515, "\"", 1573, 1);
#line 48 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
WriteAttributeValue("", 1520, Html.Raw("AssetFileList"+ViewData["ano"]+item.Title), 1520, 53, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1574, 27, true);
                WriteLiteral(">\r\n                        ");
                EndContext();
                BeginContext(1602, 94, false);
#line 49 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
                   Write(await Component.InvokeAsync("AssetFileList", new { id = ViewData["ano"], title = item.Title }));

#line default
#line hidden
                EndContext();
                BeginContext(1696, 72, true);
                WriteLiteral("\r\n                    </div>\r\n                </td>\r\n            </tr>\r\n");
                EndContext();
#line 53 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Shared\Components\NeedFileList\Default.cshtml"
        }

#line default
#line hidden
                BeginContext(1779, 16, true);
                WriteLiteral("\r\n    </table>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1802, 13, true);
            WriteLiteral("\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.NeedFileModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
