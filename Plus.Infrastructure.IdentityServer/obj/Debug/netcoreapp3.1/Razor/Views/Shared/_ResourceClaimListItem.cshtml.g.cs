#pragma checksum "F:\IdentityServer\Plus.Infrastructure.IdentityServer\Views\Shared\_ResourceClaimListItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9b9a68c7d1e46b177c78a4c7ebfc82e40a0d3b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ResourceClaimListItem), @"mvc.1.0.view", @"/Views/Shared/_ResourceClaimListItem.cshtml")]
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
#line 1 "F:\IdentityServer\Plus.Infrastructure.IdentityServer\Views\_ViewImports.cshtml"
using Plus.Infrastructure.IdentityServer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9b9a68c7d1e46b177c78a4c7ebfc82e40a0d3b9", @"/Views/Shared/_ResourceClaimListItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8884a9e3ba54e92902dafbe2be30896c1c20a2a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ResourceClaimListItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Plus.Infrastructure.IdentityServer.Models.ClaimItem>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<li class=\"list-group-item\">\r\n    <label>\r\n        <strong>");
#nullable restore
#line 5 "F:\IdentityServer\Plus.Infrastructure.IdentityServer\Views\Shared\_ResourceClaimListItem.cshtml"
           Write(Model.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n    </label>\r\n</li>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Plus.Infrastructure.IdentityServer.Models.ClaimItem> Html { get; private set; }
    }
}
#pragma warning restore 1591
