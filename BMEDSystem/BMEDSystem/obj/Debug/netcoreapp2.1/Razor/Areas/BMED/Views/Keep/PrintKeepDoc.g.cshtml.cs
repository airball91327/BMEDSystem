#pragma checksum "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25ff1ad4348f02ba0ff8e2ad9ab3f920fb01e2a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BMED_Views_Keep_PrintKeepDoc), @"mvc.1.0.view", @"/Areas/BMED/Views/Keep/PrintKeepDoc.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/BMED/Views/Keep/PrintKeepDoc.cshtml", typeof(AspNetCore.Areas_BMED_Views_Keep_PrintKeepDoc))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25ff1ad4348f02ba0ff8e2ad9ab3f920fb01e2a0", @"/Areas/BMED/Views/Keep/PrintKeepDoc.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaee19cff3e25be11b47c0eee670891a16c7d999", @"/Areas/BMED/Views/_ViewImports.cshtml")]
    public class Areas_BMED_Views_Keep_PrintKeepDoc : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EDIS.Models.KeepPrintVModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin:0px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onload", new global::Microsoft.AspNetCore.Html.HtmlString("window.print(); setTimeout(window.close, 500); "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(68, 47, true);
            WriteLiteral("\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            EndContext();
            BeginContext(115, 578, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf132765dc504f0baf6f088cb48005b5", async() => {
                BeginContext(121, 565, true);
                WriteLiteral(@"
    <title></title>
    <style type=""text/css"">
        .style1 {
            width: 700px;
        }

        .style2 {
            width: 100%;
            font-size: 10pt;
        }

        .style3 {
            height: 30px;
            width: 125px;
        }

        .style4 {
            height: 30px;
            width: 75px;
            text-align: center;
        }

        .style5 {
            text-align: center;
            height: 25px;
        }

        .style6 {
            width: 100%;
        }
    </style>
");
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
            BeginContext(693, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(695, 19002, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "138535cbd43f494e8cf24e10419bd089", async() => {
                BeginContext(777, 662, true);
                WriteLiteral(@"
    <div>

        <table cellpadding=""0"" cellspacing=""0"" class=""style1"">
            <tr>
                <td>
                    <table cellpadding=""0"" cellspacing=""0"" class=""style2""
                           style=""border: 2px solid #000000"">
                        <tr>
                            <td colspan=""4"" align=""center""
                                style=""font-size: 2em; border-bottom-style: solid; border-bottom-width: 1px; border-right-style: solid; border-right-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                &nbsp; 保&nbsp; 養&nbsp; 單
                            </td>
");
                EndContext();
                BeginContext(1877, 593, true);
                WriteLiteral(@"                            <td style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000; text-align: center""
                                width=""70"">
                                表單編號
                            </td>
                            <td class=""style5""
                                style=""border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000""
                                width=""100"">
                                ");
                EndContext();
                BeginContext(2471, 37, false);
#line 65 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.Docid));

#line default
#line hidden
                EndContext();
                BeginContext(2508, 754, true);
                WriteLiteral(@"
                            </td>
                        </tr>
                        <tr>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""92"">
                                送單日期
                            </td>
                            <td style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""150px"">
                                ");
                EndContext();
                BeginContext(3263, 43, false);
#line 76 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Model.SentDate.Value.ToString("yyyy/MM/dd"));

#line default
#line hidden
                EndContext();
                BeginContext(3306, 610, true);
                WriteLiteral(@"
                            </td>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""70"">
                                成本中心
                            </td>
                            <td style=""border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000""
                                colspan=""3"">
                                ");
                EndContext();
                BeginContext(3917, 38, false);
#line 85 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.AccDpt));

#line default
#line hidden
                EndContext();
                BeginContext(3955, 35, true);
                WriteLiteral("\r\n                                (");
                EndContext();
                BeginContext(3991, 41, false);
#line 86 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                            Write(Html.DisplayFor(model => model.AccDptNam));

#line default
#line hidden
                EndContext();
                BeginContext(4032, 708, true);
                WriteLiteral(@")
                            </td>
                        </tr>
                        <tr>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""92"">
                                申請部門
                            </td>
                            <td style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                ");
                EndContext();
                BeginContext(4741, 39, false);
#line 96 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.Company));

#line default
#line hidden
                EndContext();
                BeginContext(4780, 646, true);
                WriteLiteral(@"
                            </td>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""70"">
                                申請人員
                            </td>
                            <td style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                ");
                EndContext();
                BeginContext(5427, 40, false);
#line 104 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
                EndContext();
                BeginContext(5467, 565, true);
                WriteLiteral(@"
                            </td>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""70"">
                                聯絡電話
                            </td>
                            <td style=""border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"">
                                ");
                EndContext();
                BeginContext(6033, 39, false);
#line 112 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.Contact));

#line default
#line hidden
                EndContext();
                BeginContext(6072, 707, true);
                WriteLiteral(@"
                            </td>
                        </tr>
                        <tr>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""92"">
                                財產編號
                            </td>
                            <td style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                ");
                EndContext();
                BeginContext(6780, 39, false);
#line 122 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.AssetNo));

#line default
#line hidden
                EndContext();
                BeginContext(6819, 691, true);
                WriteLiteral(@"
                            </td>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""70"">
                                設備名稱
                            </td>
                            <td colspan=""3""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                ");
                EndContext();
                BeginContext(7511, 40, false);
#line 131 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.AssetNam));

#line default
#line hidden
                EndContext();
                BeginContext(7551, 707, true);
                WriteLiteral(@"
                            </td>
                        </tr>
                        <tr>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""92"">
                                保養地點
                            </td>
                            <td style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                ");
                EndContext();
                BeginContext(8259, 40, false);
#line 141 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.PlaceLoc));

#line default
#line hidden
                EndContext();
                BeginContext(8299, 646, true);
                WriteLiteral(@"
                            </td>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""70"">
                                保養周期
                            </td>
                            <td style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                ");
                EndContext();
                BeginContext(8946, 37, false);
#line 149 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.Cycle));

#line default
#line hidden
                EndContext();
                BeginContext(8983, 565, true);
                WriteLiteral(@"個月
                            </td>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""70"">
                                數量
                            </td>
                            <td style=""border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"">
                                ");
                EndContext();
                BeginContext(9549, 35, false);
#line 157 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.Amt));

#line default
#line hidden
                EndContext();
                BeginContext(9584, 752, true);
                WriteLiteral(@"
                            </td>
                        </tr>
                        <tr>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""92"">
                                保養結果
                            </td>
                            <td colspan=""5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                ");
                EndContext();
                BeginContext(10337, 38, false);
#line 168 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.Result));

#line default
#line hidden
                EndContext();
                BeginContext(10375, 762, true);
                WriteLiteral(@"
                            </td>
                        </tr>
                        <tr>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""92"">
                                備註
                            </td>
                            <td colspan=""5""
                                style=""height:80px;border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                ");
                EndContext();
                BeginContext(11138, 36, false);
#line 179 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.Memo));

#line default
#line hidden
                EndContext();
                BeginContext(11174, 593, true);
                WriteLiteral(@"
                            </td>
                        </tr>
                        <tr>
                            <td class=""style5""
                                style=""border-right-style: solid; border-right-width: 1px; border-right-color: #000000; ""
                                width=""92"">
                                完工日期
                            </td>
                            <td style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
");
                EndContext();
#line 189 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                 if (Model.EndDate.HasValue)
                                {
                                    

#line default
#line hidden
                BeginContext(11901, 42, false);
#line 191 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                               Write(Model.EndDate.Value.ToString("yyyy/MM/dd"));

#line default
#line hidden
                EndContext();
#line 191 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                                                               
                                }
                                else
                                {
                                    

#line default
#line hidden
                BeginContext(12090, 18, false);
#line 195 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                               Write(Html.Raw("&nbsp;"));

#line default
#line hidden
                EndContext();
#line 195 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                                       
                                }

#line default
#line hidden
                BeginContext(12145, 642, true);
                WriteLiteral(@"                            </td>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""70"">
                                工時
                            </td>
                            <td style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                ");
                EndContext();
                BeginContext(12788, 36, false);
#line 204 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.Hour));

#line default
#line hidden
                EndContext();
                BeginContext(12824, 565, true);
                WriteLiteral(@"
                            </td>
                            <td class=""style5""
                                style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000""
                                width=""70"">
                                保養方式
                            </td>
                            <td style=""border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000"">
                                ");
                EndContext();
                BeginContext(13390, 37, false);
#line 212 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(Html.DisplayFor(model => model.InOut));

#line default
#line hidden
                EndContext();
                BeginContext(13427, 176, true);
                WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td colspan=\"6\">\r\n                                ");
                EndContext();
                BeginContext(13604, 81, false);
#line 217 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                           Write(await Component.InvokeAsync("BMEDKeepCostPrintList", new { docid = Model.Docid }));

#line default
#line hidden
                EndContext();
                BeginContext(13685, 939, true);
                WriteLiteral(@"
                            </td>
                        </tr>
                        <tr>
                            <td colspan=""6"">
                                <table cellpadding=""0"" cellspacing=""0"" class=""style2"">
                                    <tr>
                                        <td class=""style4""
                                            style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                            驗收日期
                                        </td>
                                        <td colspan=""2"" class=""style3""
                                            style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
");
                EndContext();
#line 230 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                             if (Model.CloseDate.HasValue)
                                            {
                                                

#line default
#line hidden
                BeginContext(14796, 44, false);
#line 232 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                           Write(Model.CloseDate.Value.ToString("yyyy/MM/dd"));

#line default
#line hidden
                EndContext();
#line 232 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                                                                             
                                            }
                                            else
                                            {
                                                

#line default
#line hidden
                BeginContext(15035, 18, false);
#line 236 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                           Write(Html.Raw("&nbsp;"));

#line default
#line hidden
                EndContext();
#line 236 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                                                   
                                            }

#line default
#line hidden
                BeginContext(15102, 756, true);
                WriteLiteral(@"                                        </td>
                                        <td class=""style4""
                                            style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                            專責主管
                                        </td>
                                        <td colspan=""2"" class=""style3""
                                            style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                            ");
                EndContext();
                BeginContext(15859, 12, false);
#line 245 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                       Write(Model.EngMgr);

#line default
#line hidden
                EndContext();
                BeginContext(15871, 810, true);
                WriteLiteral(@"
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class=""style5"" width=""92""
                                            style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                            驗收員工
                                        </td>
                                        <td colspan=""2"" class=""style3""
                                            style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
");
                EndContext();
#line 255 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                             if (Model.DelivEmpName != "" && Model.DelivEmpName != null)
                                            {

#line default
#line hidden
                BeginContext(16834, 54, true);
                WriteLiteral("                                                <span>");
                EndContext();
                BeginContext(16889, 18, false);
#line 257 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                                 Write(Model.DelivEmpName);

#line default
#line hidden
                EndContext();
                BeginContext(16907, 2, true);
                WriteLiteral(" (");
                EndContext();
                BeginContext(16910, 14, false);
#line 257 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                                                      Write(Model.DelivEmp);

#line default
#line hidden
                EndContext();
                BeginContext(16924, 10, true);
                WriteLiteral(")</span>\r\n");
                EndContext();
#line 258 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                            }

#line default
#line hidden
                BeginContext(16981, 756, true);
                WriteLiteral(@"                                        </td>
                                        <td class=""style4""
                                            style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                            專責主任
                                        </td>
                                        <td colspan=""2"" class=""style3""
                                            style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                            ");
                EndContext();
                BeginContext(17738, 17, false);
#line 266 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                       Write(Model.EngDirector);

#line default
#line hidden
                EndContext();
                BeginContext(17755, 853, true);
                WriteLiteral(@"
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class=""style5"" width=""92""
                                            style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                            工程師
                                        </td>
                                        <td colspan=""2"" class=""style3""
                                            style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                            ");
                EndContext();
                BeginContext(18609, 13, false);
#line 276 "C:\Users\User\Desktop\BMEDSystem0803\BMEDSystem\BMEDSystem\Areas\BMED\Views\Keep\PrintKeepDoc.cshtml"
                                       Write(Model.EngName);

#line default
#line hidden
                EndContext();
                BeginContext(18622, 1068, true);
                WriteLiteral(@"
                                        </td>
                                        <td class=""style4""
                                            style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                            會計
                                        </td>
                                        <td colspan=""2"" class=""style3""
                                            style=""border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000"">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
         ");
                WriteLiteral("   </tr>\r\n        </table>\r\n\r\n    </div>\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
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
            BeginContext(19697, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EDIS.Models.KeepPrintVModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
