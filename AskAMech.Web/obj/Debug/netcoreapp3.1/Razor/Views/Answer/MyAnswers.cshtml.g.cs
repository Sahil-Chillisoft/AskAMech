#pragma checksum "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74a12e5caf5c4d59067e33a3f66ba481e493a882"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Answer_MyAnswers), @"mvc.1.0.view", @"/Views/Answer/MyAnswers.cshtml")]
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
#nullable restore
#line 1 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\_ViewImports.cshtml"
using AskAMech.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\_ViewImports.cshtml"
using AskAMech.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74a12e5caf5c4d59067e33a3f66ba481e493a882", @"/Views/Answer/MyAnswers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db23cd206066a77c1f814a3b8c838e39bba6d461", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Answer_MyAnswers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AskAMech.Core.Answers.Responses.GetUserQuestionAnswersResponse>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Question", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewQuestion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("View Question"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Paging", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("EmployeeList"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Answers/myAnswers.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
  
    ViewData["Title"] = "My Answers Based in These Questions";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74a12e5caf5c4d59067e33a3f66ba481e493a8826005", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <h1 class=""display-4 text-center"">
                    <i class=""material-icons md-45"">star</i>
                    Questions Which You Posted Answers To
                </h1>
            </div>
        </div>
        <hr />
        <div class=""row"">
            <div class=""col-md-12 text-right"">
                <a id=""SearchButton"" title=""Search"" href=""#""><i class=""material-icons md-45"">search</i></a>
            </div>
        </div>
        <div id=""searchDiv"" class=""bg-ghost-white hide"">
            <div class=""row md-Padding-Top-10"">
                <div class=""col-md-1""></div>
                <div class=""col-md-4"">
                    ");
#nullable restore
#line 26 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
               Write(Html.LabelFor(x => x.CategoryId, "Category", new { @class = "text-bold" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
#nullable restore
#line 27 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
               Write(Html.DropDownListFor(x => x.CategoryId,
                        new SelectList(Model.Categories, "Id", "Description"), "--All--",
                        new { @class = "form-control full-width", data_val = false }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
                <div class=""col-md-2"">
                    <label>&nbsp;</label>
                    <button id=""Search"" type=""button"" class=""btn btn-primary full-width"">Search</button>
                </div>
            </div>
            <br />
        </div>

        <div class=""row md-Padding-Top-20"">
            <div class=""col-md-12"">
");
#nullable restore
#line 41 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
                 if (Model.UserQuestionAnswers.Any())
                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <table id=""My AnswersTable"" class=""table full-width"">
                        <thead class=""thead-dark"">
                            <tr>
                                <th></th>
                                <th>Question</th>
                                <th>Category</th>
                                <th>Date Asked</th>
                                <th>Asked By</th>
                            </tr>
                        </thead>
                        <tbody class=""table-striped"">
");
#nullable restore
#line 54 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
                             foreach (var item in Model.UserQuestionAnswers)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74a12e5caf5c4d59067e33a3f66ba481e493a8829491", async() => {
                    WriteLiteral("\r\n                                        <i class=\"material-icons md-30\">info</i>\r\n                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
                                                                                             WriteLiteral(item.QuestionId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                </td>\r\n                                <td>");
#nullable restore
#line 62 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
                               Write(item.QuestionTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 63 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
                               Write(item.CategoryDescription);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 64 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
                               Write(item.QuestionCreationDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 65 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
                               Write(item.AskedBy);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 67 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
#nullable restore
#line 70 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <h3>No Records Found</h3>\r\n");
#nullable restore
#line 74 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        </div>\r\n        <hr />\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "74a12e5caf5c4d59067e33a3f66ba481e493a88214496", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 78 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Answer\MyAnswers.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.Pagination;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74a12e5caf5c4d59067e33a3f66ba481e493a88217322", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AskAMech.Core.Answers.Responses.GetUserQuestionAnswersResponse> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
