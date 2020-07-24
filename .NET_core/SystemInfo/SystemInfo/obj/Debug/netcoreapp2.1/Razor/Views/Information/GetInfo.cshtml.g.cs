#pragma checksum "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d582a61d9582a062a3abd6c34f287fb06b99b1f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Information_GetInfo), @"mvc.1.0.view", @"/Views/Information/GetInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Information/GetInfo.cshtml", typeof(AspNetCore.Views_Information_GetInfo))]
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
#line 1 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\_ViewImports.cshtml"
using SystemInfo;

#line default
#line hidden
#line 2 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\_ViewImports.cshtml"
using SystemInfo.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d582a61d9582a062a3abd6c34f287fb06b99b1f0", @"/Views/Information/GetInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d0db606cec9ec6916078087619e57fb84a3c42a", @"/Views/_ViewImports.cshtml")]
    public class Views_Information_GetInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SystemInfo.Models.InformationModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
  
    ViewData["Title"] = "GetInfo";

#line default
#line hidden
            BeginContext(88, 37, true);
            WriteLiteral("\r\n<h2>\r\n    System Information for : ");
            EndContext();
            BeginContext(126, 41, false);
#line 8 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                        Write(Html.DisplayFor(model => model.InfoTitle));

#line default
#line hidden
            EndContext();
            BeginContext(167, 149, true);
            WriteLiteral("\r\n</h2>\r\n\r\n<div>\r\n\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            Operating System\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(317, 47, false);
#line 19 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
       Write(Html.DisplayFor(model => model.OperatingSystem));

#line default
#line hidden
            EndContext();
            BeginContext(364, 107, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Framework Description\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(472, 52, false);
#line 25 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
       Write(Html.DisplayFor(model => model.FrameworkDescription));

#line default
#line hidden
            EndContext();
            BeginContext(524, 106, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Process Architecture\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(631, 51, false);
#line 31 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
       Write(Html.DisplayFor(model => model.ProcessArchitecture));

#line default
#line hidden
            EndContext();
            BeginContext(682, 95, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            Public IP\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(778, 47, false);
#line 37 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
       Write(Html.DisplayFor(model => model.IPAddressString));

#line default
#line hidden
            EndContext();
            BeginContext(825, 74, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n\r\n<hr />\r\n<h2>\r\n    Current Location: ");
            EndContext();
            BeginContext(900, 43, false);
#line 44 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                 Write(Html.DisplayFor(model => model.CurrentCity));

#line default
#line hidden
            EndContext();
            BeginContext(943, 59, true);
            WriteLiteral("\r\n</h2>\r\n<div>\r\n    <table>\r\n        <tr>\r\n            <td>");
            EndContext();
            BeginContext(1003, 27, false);
#line 49 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
           Write(Html.Raw(Model.CurrentIcon));

#line default
#line hidden
            EndContext();
            BeginContext(1030, 45, true);
            WriteLiteral("</td>\r\n            <td>\r\n                <h3>");
            EndContext();
            BeginContext(1076, 24, false);
#line 51 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
               Write(Model.CurrentTemperature);

#line default
#line hidden
            EndContext();
            BeginContext(1100, 33, true);
            WriteLiteral("</h3>\r\n                <h5>Max : ");
            EndContext();
            BeginContext(1134, 27, false);
#line 52 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                     Write(Model.CurrentMaxTemperature);

#line default
#line hidden
            EndContext();
            BeginContext(1161, 33, true);
            WriteLiteral("</h5>\r\n                <h5>Min : ");
            EndContext();
            BeginContext(1195, 27, false);
#line 53 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                     Write(Model.CurrentMinTemperature);

#line default
#line hidden
            EndContext();
            BeginContext(1222, 145, true);
            WriteLiteral("</h5>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n    <table class=\"center\">\r\n        <tr>\r\n            <td>\r\n                <h5>Summary : ");
            EndContext();
            BeginContext(1368, 44, false);
#line 60 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                         Write(Html.DisplayFor(model => model.DailySummary));

#line default
#line hidden
            EndContext();
            BeginContext(1412, 38, true);
            WriteLiteral("</h5>\r\n                <h5>Pressure : ");
            EndContext();
            BeginContext(1451, 21, false);
#line 61 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                          Write(Model.CurrentPressure);

#line default
#line hidden
            EndContext();
            BeginContext(1472, 38, true);
            WriteLiteral("</h5>\r\n                <h5>Humidity : ");
            EndContext();
            BeginContext(1511, 21, false);
#line 62 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                          Write(Model.CurrentHumidity);

#line default
#line hidden
            EndContext();
            BeginContext(1532, 40, true);
            WriteLiteral("</h5>\r\n                <h5>Wind Speed : ");
            EndContext();
            BeginContext(1573, 22, false);
#line 63 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                            Write(Model.CurrentWindSpeed);

#line default
#line hidden
            EndContext();
            BeginContext(1595, 44, true);
            WriteLiteral("</h5>\r\n                <h5>Wind Direction : ");
            EndContext();
            BeginContext(1640, 20, false);
#line 64 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                                Write(Model.CurrentWindDir);

#line default
#line hidden
            EndContext();
            BeginContext(1660, 40, true);
            WriteLiteral("</h5>\r\n                <h5>Cloudiness : ");
            EndContext();
            BeginContext(1701, 23, false);
#line 65 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                            Write(Model.CurrentCloudiness);

#line default
#line hidden
            EndContext();
            BeginContext(1724, 37, true);
            WriteLiteral("</h5>\r\n                <h5>Sunrise : ");
            EndContext();
            BeginContext(1762, 20, false);
#line 66 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                         Write(Model.CurrentSunrise);

#line default
#line hidden
            EndContext();
            BeginContext(1782, 36, true);
            WriteLiteral("</h5>\r\n                <h5>Sunset : ");
            EndContext();
            BeginContext(1819, 19, false);
#line 67 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                        Write(Model.CurrentSunset);

#line default
#line hidden
            EndContext();
            BeginContext(1838, 41, true);
            WriteLiteral("</h5>\r\n                <h5>Weather Info: ");
            EndContext();
            BeginContext(1880, 41, false);
#line 68 "D:\Workspace\C-sharp\.NET_core\SystemInfo\SystemInfo\Views\Information\GetInfo.cshtml"
                             Write(Html.DisplayFor(model => model.WeatherBy));

#line default
#line hidden
            EndContext();
            BeginContext(1921, 242, true);
            WriteLiteral("</h5>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</div>\r\n\r\n<style>\r\n    h1,h2,h5 {\r\n        display: block;\r\n        margin-top: 0.67em;\r\n        margin-bottom: 0.67em;\r\n        margin-left: 0;\r\n        margin-right: 0;\r\n    }\r\n</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SystemInfo.Models.InformationModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
