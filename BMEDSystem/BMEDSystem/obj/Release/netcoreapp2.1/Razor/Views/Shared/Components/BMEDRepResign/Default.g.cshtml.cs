#pragma checksum "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d0a7db7b0363c8536f2ae7a92a165022a6645377"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_BMEDRepResign_Default), @"mvc.1.0.view", @"/Views/Shared/Components/BMEDRepResign/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/BMEDRepResign/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_BMEDRepResign_Default))]
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
#line 1 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\_ViewImports.cshtml"
using EDIS;

#line default
#line hidden
#line 3 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\_ViewImports.cshtml"
using EDIS.Models;

#line default
#line hidden
#line 4 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\_ViewImports.cshtml"
using EDIS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\_ViewImports.cshtml"
using EDIS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0a7db7b0363c8536f2ae7a92a165022a6645377", @"/Views/Shared/Components/BMEDRepResign/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5dac140ed5edfa1968e0107fb9101271cf40612", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_BMEDRepResign_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EDIS.Models.RepairListVModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/bootstrap-combobox.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bootstrap-combobox.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ResignEng", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Repair", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "BMED", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-update", new global::Microsoft.AspNetCore.Html.HtmlString("#unsignListDiv"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("POST"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-begin", new global::Microsoft.AspNetCore.Html.HtmlString("$.Toast.showToast({\r\n              \'title\':\'作業進行中，請稍待...\',\r\n              \'icon\':\'loading\',\r\n              \'duration\':0\r\n              })"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-complete", new global::Microsoft.AspNetCore.Html.HtmlString("$.Toast.hideToast()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("updateFailed"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
  
    ViewData["Title"] = "分派案件";

#line default
#line hidden
            BeginContext(92, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4abb931412a7466b967eac0a0e53d4e7", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(153, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(155, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f6dfd610168471ebf8e3c341d1a02f3", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(205, 1180, true);
            WriteLiteral(@"

<style>
    /* Style the scale of checkbox. */
    input[class='IsSelected'], input[name=""checkAll""] {
        -ms-transform: scale(1.5) !important; /* IE */
        -moz-transform: scale(1.5) !important; /* FireFox */
        -webkit-transform: scale(1.5) !important; /* Safari and Chrome */
        -o-transform: scale(1.5) !important; /* Opera */
    }
</style>

<script>
    var updateFailed = function (data) {
        alert(data.responseText);
        $.Toast.hideToast();
    };

    $(function () {
        $("".combobox3"").combobox();
        // Default setting
        $(""input[class='IsSelected']"").each(function () {
            $(this).prop(""checked"", false);
        });

        $('input[name=""checkAll""]').change(function () {
            if ($(this).prop(""checked"")) {
                $(""input[class='IsSelected']"").each(function () {
                    $(this).prop(""checked"", true);
                });
            }
            else {
                $(""input[class='IsS");
            WriteLiteral("elected\']\").each(function () {\r\n                    $(this).prop(\"checked\", false);\r\n                });\r\n            }\r\n        });\r\n    });\r\n</script>\r\n\r\n");
            EndContext();
            BeginContext(1385, 3844, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f48c1c0659304101ac8c6bdfd2a1d07f", async() => {
                BeginContext(1787, 196, true);
                WriteLiteral("\r\n\r\n    <div class=\"form-inline\">\r\n        <div class=\"form-group col-md-7\">\r\n            <label class=\"control-label col-md-3\">指派工程師:</label>\r\n            <div class=\"col-md-5\">\r\n                ");
                EndContext();
                BeginContext(1984, 132, false);
#line 61 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
           Write(Html.DropDownList("BMEDassignEngId", null, "選擇人員", htmlAttributes: new { @class = "form-control combobox3", required = "required" }));

#line default
#line hidden
                EndContext();
                BeginContext(2116, 459, true);
                WriteLiteral(@"
            </div>
            <div class=""col-md-4"">
                <input type=""submit"" class=""btn btn-primary"" value=""確定送出"" />
            </div>
        </div>
    </div>
    <br /><br />

    <table class=""table"">
        <thead>
            <tr>
                <th class=""col-md-1"" style=""text-align:center"">
                    <input type=""checkbox"" name=""checkAll"" />
                </th>
                <th>
                    ");
                EndContext();
                BeginContext(2576, 43, false);
#line 77 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.DocType));

#line default
#line hidden
                EndContext();
                BeginContext(2619, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(2687, 41, false);
#line 80 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.DocId));

#line default
#line hidden
                EndContext();
                BeginContext(2728, 50, true);
                WriteLiteral("\r\n                    <br />\r\n                    ");
                EndContext();
                BeginContext(2779, 45, false);
#line 82 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.ApplyDate));

#line default
#line hidden
                EndContext();
                BeginContext(2824, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(2892, 46, false);
#line 85 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.AccDptName));

#line default
#line hidden
                EndContext();
                BeginContext(2938, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(3006, 45, false);
#line 88 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.AssetName));

#line default
#line hidden
                EndContext();
                BeginContext(3051, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(3119, 44, false);
#line 91 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.PlaceLoc));

#line default
#line hidden
                EndContext();
                BeginContext(3163, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(3231, 46, false);
#line 94 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.TroubleDes));

#line default
#line hidden
                EndContext();
                BeginContext(3277, 67, true);
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
                EndContext();
                BeginContext(3345, 40, false);
#line 97 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
               Write(Html.DisplayNameFor(model => model.Days));

#line default
#line hidden
                EndContext();
                BeginContext(3385, 79, true);
                WriteLiteral("\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
                EndContext();
#line 102 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
              int i = 0; 

#line default
#line hidden
                BeginContext(3492, 12, true);
                WriteLiteral("            ");
                EndContext();
#line 103 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
                BeginContext(3549, 42, true);
                WriteLiteral("                <tr>\r\n                    ");
                EndContext();
                BeginContext(3592, 48, false);
#line 106 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
               Write(Html.Hidden("data[" + i + "].DocId", item.DocId));

#line default
#line hidden
                EndContext();
                BeginContext(3640, 78, true);
                WriteLiteral("\r\n                    <td style=\"text-align:center\">\r\n                        ");
                EndContext();
                BeginContext(3719, 91, false);
#line 108 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                   Write(Html.CheckBox("data[" + i + "].IsSelected", item.IsSelected, new { @class = "IsSelected" }));

#line default
#line hidden
                EndContext();
                BeginContext(3810, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(3890, 42, false);
#line 111 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DocType));

#line default
#line hidden
                EndContext();
                BeginContext(3932, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(4012, 40, false);
#line 114 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DocId));

#line default
#line hidden
                EndContext();
                BeginContext(4052, 58, true);
                WriteLiteral("\r\n                        <br />\r\n                        ");
                EndContext();
                BeginContext(4111, 44, false);
#line 116 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ApplyDate));

#line default
#line hidden
                EndContext();
                BeginContext(4155, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(4235, 45, false);
#line 119 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                   Write(Html.DisplayFor(modelItem => item.AccDptName));

#line default
#line hidden
                EndContext();
                BeginContext(4280, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(4360, 42, false);
#line 122 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                   Write(Html.DisplayFor(modelItem => item.AssetNo));

#line default
#line hidden
                EndContext();
                BeginContext(4402, 58, true);
                WriteLiteral("\r\n                        <br />\r\n                        ");
                EndContext();
                BeginContext(4461, 44, false);
#line 124 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                   Write(Html.DisplayFor(modelItem => item.AssetName));

#line default
#line hidden
                EndContext();
                BeginContext(4505, 58, true);
                WriteLiteral("\r\n                        <br />\r\n                        ");
                EndContext();
                BeginContext(4564, 40, false);
#line 126 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Brand));

#line default
#line hidden
                EndContext();
                BeginContext(4604, 58, true);
                WriteLiteral("\r\n                        <br />\r\n                        ");
                EndContext();
                BeginContext(4663, 39, false);
#line 128 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
                EndContext();
                BeginContext(4702, 111, true);
                WriteLiteral("\r\n                        <br />\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(4814, 43, false);
#line 132 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PlaceLoc));

#line default
#line hidden
                EndContext();
                BeginContext(4857, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(4937, 45, false);
#line 135 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TroubleDes));

#line default
#line hidden
                EndContext();
                BeginContext(4982, 79, true);
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                EndContext();
                BeginContext(5062, 39, false);
#line 138 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Days));

#line default
#line hidden
                EndContext();
                BeginContext(5101, 52, true);
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
                EndContext();
#line 141 "C:\Users\Inori\Desktop\頁面設計\BMEDSystem_0807\BMEDSystem\BMEDSystem\Views\Shared\Components\BMEDRepResign\Default.cshtml"
                i++;
            }

#line default
#line hidden
                BeginContext(5190, 32, true);
                WriteLiteral("        </tbody>\r\n    </table>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5229, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EDIS.Models.RepairListVModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591