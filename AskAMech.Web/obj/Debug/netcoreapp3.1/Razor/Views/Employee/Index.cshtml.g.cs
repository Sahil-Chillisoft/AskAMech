#pragma checksum "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7689fb01355a5d7a4d58d628a1d8ef543f8f502e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Index), @"mvc.1.0.view", @"/Views/Employee/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7689fb01355a5d7a4d58d628a1d8ef543f8f502e", @"/Views/Employee/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db23cd206066a77c1f814a3b8c838e39bba6d461", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Employee_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AskAMech.Core.Employees.Responses.GetEmployeesResponse>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Employee", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Edit Employee Details"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Paging", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("EmployeeList"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Employee/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
  
    ViewData["Title"] = "Employee List";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7689fb01355a5d7a4d58d628a1d8ef543f8f502e5960", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <h1 class=""display-4 text-center"">
                    <i class=""material-icons md-45"">groups</i>
                    Employees
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
                <div class=""col-md-5 md-Padding-Left-25"">
                    ");
#nullable restore
#line 27 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
               Write(Html.TextBoxFor(x => x.Search,
                        new
                        {
                            id = "Search",
                            name = "Search",
                            @class = "form-control",
                            placeholder = "Start typing to search by Name or Id Number"
                        }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
                <div class=""col-md-2"">
                    <button id=""SearchEmployees"" type=""button"" class=""btn btn-primary full-width"">Search</button>
                </div>
            </div>
            <br />
        </div>

        <div class=""row md-Padding-Top-20"">
            <div class=""col-md-12"">
");
#nullable restore
#line 45 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
                 if (Model.Employees.Any())
                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <table id=""employeesTable"" class=""table full-width"">
                        <thead class=""thead-dark"">
                            <tr>
                                <th></th>
                                <th>FirstName</th>
                                <th>LastName</th>
                                <th>ID Number</th>
                                <th>Email</th>
                            </tr>
                        </thead>
                        <tbody class=""table-striped"">
");
#nullable restore
#line 58 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
                             foreach (var item in Model.Employees)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7689fb01355a5d7a4d58d628a1d8ef543f8f502e9143", async() => {
                    WriteLiteral("\r\n                                            <i class=\"material-icons md-30\">edit</i>\r\n                                        ");
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
#line 62 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
                                                                                          WriteLiteral(item.Id);

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
                WriteLiteral("\r\n                                    </td>\r\n                                    <td>");
#nullable restore
#line 66 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
                                   Write(item.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 67 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
                                   Write(item.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 68 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
                                   Write(item.IdNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 69 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
                                   Write(item.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 71 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
#nullable restore
#line 74 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <h3>No Records Found</h3>\r\n");
#nullable restore
#line 78 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        </div>\r\n        <hr />\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7689fb01355a5d7a4d58d628a1d8ef543f8f502e14117", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 82 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Employee\Index.cshtml"
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7689fb01355a5d7a4d58d628a1d8ef543f8f502e16941", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AskAMech.Core.Employees.Responses.GetEmployeesResponse> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
