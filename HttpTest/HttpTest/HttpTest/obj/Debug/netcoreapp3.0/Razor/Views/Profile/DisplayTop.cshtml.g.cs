#pragma checksum "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\Profile\DisplayTop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99725d90c38505638334e92cbdeaae15b2e617fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_DisplayTop), @"mvc.1.0.view", @"/Views/Profile/DisplayTop.cshtml")]
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
#line 1 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\_ViewImports.cshtml"
using HttpTest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\_ViewImports.cshtml"
using HttpTest.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\_ViewImports.cshtml"
using HttpTest.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\_ViewImports.cshtml"
using HttpTest.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99725d90c38505638334e92cbdeaae15b2e617fc", @"/Views/Profile/DisplayTop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67b13a9ac6a7269d96c8dfb8cefaabce27b03465", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_DisplayTop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\Profile\DisplayTop.cshtml"
  
    ViewData["Title"] = "Showrank";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n\r\n    <h4 class=\"mt-5\">Top profiles</h4>\r\n    <hr class=\"mb-5\" />\r\n\r\n    <div class=\"card\" style=\"width: 1000px;\">\r\n        <ul class=\"list-group list-group-flush\">\r\n\r\n");
#nullable restore
#line 15 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\Profile\DisplayTop.cshtml"
             foreach (var profile in await profileController.GetTopProfiles())
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"list-group-item\">\r\n                    ");
#nullable restore
#line 19 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\Profile\DisplayTop.cshtml"
               Write(profile.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 19 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\Profile\DisplayTop.cshtml"
                                  Write(profile.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 19 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\Profile\DisplayTop.cshtml"
                                                     Write(profile.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(") - ");
#nullable restore
#line 19 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\Profile\DisplayTop.cshtml"
                                                                       Write(profile.HelpsNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" helps\r\n                </li>\r\n");
#nullable restore
#line 21 "C:\Users\David\Data\w\fac\anul 4\sem 1\DAW\ShowRank\HttpTest\HttpTest\HttpTest\Views\Profile\DisplayTop.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </ul>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ProfileController profileController { get; private set; }
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
