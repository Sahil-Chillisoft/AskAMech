#pragma checksum "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44c3c03e87908f6008bd2fb016acd7af0354e651"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_ViewUserProfile), @"mvc.1.0.view", @"/Views/User/ViewUserProfile.cshtml")]
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
#nullable restore
#line 1 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
using AskAMech.Core.Domain;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44c3c03e87908f6008bd2fb016acd7af0354e651", @"/Views/User/ViewUserProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db23cd206066a77c1f814a3b8c838e39bba6d461", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_User_ViewUserProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AskAMech.Core.Users.Responses.GetViewUserProfileResponse>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/User/viewUserProfile.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
  
    ViewData["Title"] = "View Profile";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44c3c03e87908f6008bd2fb016acd7af0354e6514294", async() => {
                WriteLiteral("\r\n    <div class=\"container bg-ghost-white\">\r\n        ");
#nullable restore
#line 8 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
   Write(Html.HiddenFor(x => x.UserProfile.Id, new { id = "UserId" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <h1 class=\"display-4 text-center\">\r\n                    <i class=\"material-icons md-45\">account_circle</i>\r\n                    ");
#nullable restore
#line 13 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
               Write(Model.UserProfile.Username);

#line default
#line hidden
#nullable disable
                WriteLiteral(" User Profile\r\n                </h1>\r\n            </div>\r\n        </div>\r\n        <hr />\r\n\r\n");
#nullable restore
#line 19 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
         if (Model.UserProfile.DateDeleted == null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"row md-Padding-Top-10\">\r\n                <div class=\"col-md-12\">\r\n                    <label class=\"text-bold\">Username: ");
#nullable restore
#line 23 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                                                  Write(Model.UserProfile.Username);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                </div>\r\n            </div>\r\n");
                WriteLiteral("            <div class=\"row md-Padding-Top-10\">\r\n                <div class=\"col-md-12\">\r\n                    <label class=\"text-bold\">About: ");
#nullable restore
#line 29 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                                               Write(Model.UserProfile.About);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                </div>\r\n            </div>\r\n");
                WriteLiteral("            <div class=\"row md-Padding-Top-10\">\r\n                <div class=\"col-md-6\">\r\n");
#nullable restore
#line 35 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                     switch (Model.UserProfile.UserRoleId)
                    {
                        case 1:

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <label class=\"text-bold\">Role: ");
#nullable restore
#line 38 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                                                      Write(UserRole.Admin);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <i class=\"material-icons md-15 icon-green\" title=\"Certified Admin\">security</i></label>\r\n");
#nullable restore
#line 39 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                            break;
                        case 2:

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <label class=\"text-bold\">Role: ");
#nullable restore
#line 41 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                                                      Write(UserRole.Mechanic);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <i class=\"material-icons md-15 icon-green\" title=\"Certified Mechanic\">build</i></label>\r\n");
#nullable restore
#line 42 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                            break;
                        case 3:

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <label class=\"text-bold\">Role: General User</label>\r\n");
#nullable restore
#line 45 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                            break;
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </div>\r\n            </div>\r\n");
                WriteLiteral("            <div class=\"row md-Padding-Top-10\">\r\n                <div class=\"col-md-12\">\r\n                    <label class=\"text-bold\">Date Joined: ");
#nullable restore
#line 52 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                                                     Write(Model.UserProfile.DateCreated.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                </div>\r\n            </div>\r\n");
                WriteLiteral("            <div class=\"row md-Padding-Top-10\">\r\n                <div class=\"col-md-12\">\r\n                    <label class=\"text-bold\">Member for: ");
#nullable restore
#line 58 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                                                    Write(Model.UserProfile.MembershipDuration);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Days</label>\r\n                </div>\r\n            </div>\r\n");
                WriteLiteral("            <div class=\"row md-Padding-Top-10\">\r\n                <div class=\"col-md-12\">\r\n                    <label class=\"text-bold\">Last Seen: ");
#nullable restore
#line 64 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                                                   Write(Model.UserProfile.DateLastLoggedIn.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                </div>\r\n            </div>\r\n");
                WriteLiteral("            <div class=\"row md-Padding-Top-10\">\r\n                <div class=\"col-md-12\">\r\n                    <label class=\"text-bold\">No. of Questions Posted: ");
#nullable restore
#line 70 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                                                                 Write(Model.UserProfile.QuestionCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                </div>\r\n            </div>\r\n");
                WriteLiteral("            <div class=\"row md-Padding-Top-10\">\r\n                <div class=\"col-md-12\">\r\n                    <label class=\"text-bold\">No. of Answers Posted: ");
#nullable restore
#line 76 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
                                                               Write(Model.UserProfile.AnswerCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 79 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col-md-12\">\r\n                    ");
#nullable restore
#line 84 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
               Write(Html.HiddenFor(x => x.UserProfile.DateDeleted, new { id = "DateDeleted" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    <h3 class=\"text-danger\">This user does not exist anymore because their user account has been deleted.</h3>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 88 "C:\Users\znkul\Desktop\C#APPs\AskAMech\AskAMech\AskAMech.Web\Views\User\ViewUserProfile.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </div>\r\n    <hr />\r\n    <div id=\"UserQuestionsDiv\"></div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44c3c03e87908f6008bd2fb016acd7af0354e65114223", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AskAMech.Core.Users.Responses.GetViewUserProfileResponse> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591