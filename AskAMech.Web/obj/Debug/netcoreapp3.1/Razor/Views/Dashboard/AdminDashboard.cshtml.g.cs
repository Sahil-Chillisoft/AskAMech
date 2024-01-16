#pragma checksum "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Dashboard\AdminDashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76e7e03af669136c15ec1cc1c2d8cbbf5fa491cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_AdminDashboard), @"mvc.1.0.view", @"/Views/Dashboard/AdminDashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76e7e03af669136c15ec1cc1c2d8cbbf5fa491cb", @"/Views/Dashboard/AdminDashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db23cd206066a77c1f814a3b8c838e39bba6d461", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Dashboard_AdminDashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Dashboard/adminDashboard.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\Dashboard\AdminDashboard.cshtml"
  
    ViewData["Title"] = "Admin Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-md-4"">
        </div>
        <div class=""col-md-1"">
            <i class=""material-icons md-70"">admin_panel_settings</i>
        </div>
        <div class=""col-md-5"">
            <h1 class=""display-4"">Admin Dashboard</h1>
        </div>
    </div>
    <hr/>
    <div class=""row md-Padding-Top-50"">
        <div class=""col-md-4"">
            <div id=""divEmployees"" title=""View All Employees"" onclick=""Navigate(id)"">
                <div class=""info-box bg-blue hover-expand-effect"">
                    <div class=""icon"">
                        <i class=""material-icons"">groups</i>
                    </div>
                    <div class=""content"">
                        <div class=""material-icons-font"">View Employees</div>

                    </div>
                </div>
            </div>
        </div>

        <div class=""col-md-4"">
            <div id=""divNewEmployees"" title=""Create A New Employee Record"" on");
            WriteLiteral(@"click=""Navigate(id)"">
                <div class=""info-box bg-limegreen hover-expand-effect"">
                    <div class=""icon"">
                        <i class=""material-icons"">person_add</i>
                    </div>
                    <div class=""content"">
                        <div class=""material-icons-font"">Create New Employee</div>

                    </div>
                </div>
            </div>
        </div>

        <div class=""col-md-4"">
            <div id=""divCreateUserFromEmployee"" title=""Create A New User From An Employee Record"" onclick=""Navigate(id)"">
                <div class=""info-box bg-yellow hover-expand-effect"">
                    <div class=""icon"">
                        <i class=""material-icons"">group_add</i>
                    </div>
                    <div class=""content"">
                        <div class=""material-icons-font"">Create User From Employee</div>
                    </div>
                </div>
            </div>
        </di");
            WriteLiteral(@"v>

    </div>

    <div class=""row md-Padding-Top-10"">
        <div class=""col-md-4"">
            <div id=""divNewQuestionCategory"" title=""Add New Question Category"" onclick=""Navigate(id)"">
                <div class=""info-box bg-lilac hover-expand-effect"">
                    <div class=""icon"">
                        <i class=""material-icons"">post_add</i>
                    </div>
                    <div class=""content"">
                        <div class=""material-icons-font"">Add New Question Category</div>
                    </div>
                </div>
            </div>
        </div>

        <div class=""col-md-4"">
            <div id=""divUserRole"" title=""Add New UserRole"" onclick=""Navigate(id)"">
                <div class=""info-box bg-turquoise hover-expand-effect"">
                    <div class=""icon"">
                        <i class=""material-icons"">library_add</i>
                    </div>
                    <div class=""content"">
                        <div class=""");
            WriteLiteral(@"material-icons-font"">Add New User Role</div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class=""col-md-4"">
            <div id=""divMyProfile"" title=""View And Edit Your User Profile"" onclick=""Navigate(id)"">
                <div class=""info-box bg-orange hover-expand-effect"">
                    <div class=""icon"">
                        <i class=""material-icons"">account_circle</i>
                    </div>
                    <div class=""content"">
                        <div class=""material-icons-font"">Edit My Profile</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "76e7e03af669136c15ec1cc1c2d8cbbf5fa491cb7931", async() => {
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
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
