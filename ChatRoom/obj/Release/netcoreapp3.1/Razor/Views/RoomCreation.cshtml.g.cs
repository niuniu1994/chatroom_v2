#pragma checksum "/Users/kainingxin/RiderProjects/ChatRoom/ChatRoom/Views/RoomCreation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "577ddf1783a32df95a4ff20c8753ab24ab7cb6c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RoomCreation), @"mvc.1.0.view", @"/Views/RoomCreation.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"577ddf1783a32df95a4ff20c8753ab24ab7cb6c7", @"/Views/RoomCreation.cshtml")]
    public class Views_RoomCreation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<html lang=\"en\">\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "577ddf1783a32df95a4ff20c8753ab24ab7cb6c73885", async() => {
                WriteLiteral("\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 215, "\"", 225, 0);
                EndWriteAttribute();
                WriteLiteral(">\n    <meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 251, "\"", 261, 0);
                EndWriteAttribute();
                WriteLiteral(">\n    <title>Main page</title>\n    <!-- Bootstrap core CSS -->\n    <link>\n    <title>ChatRoom</title>\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "577ddf1783a32df95a4ff20c8753ab24ab7cb6c74787", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    <link type=\"text/css\" href=\"css/style.css\" rel=\"stylesheet\"/>\n    <style>\n        .row {\n            margin-top: 10px;\n            margin-bottom: 10px;\n        }\n    </style>\n");
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "577ddf1783a32df95a4ff20c8753ab24ab7cb6c76917", async() => {
                WriteLiteral(@"

<main>
    <nav class=""navbar navbar-dark bg-info static-top"">
        <div class=""navbar-brand"" style=""margin-left: 10px"">
            <a href=""#"">
                <img src=""image/efrei.png"" width=""130"" height=""45"" alt=""background-images""/>
            </a>
        </div>
        <a class=""btn btn-danger my-2 my-sm-0"" href=""#"" style=""margin-right: 10px"">Logout</a>
    </nav>
    <div id=""wrapper"" class=""toggled"">

        <!-- Sidebar -->
        <div id=""sidebar-wrapper"" class=""bg-secondary"">
            <ul class=""list-group"">
                
                <li class=""list-group-item  list-group-item-primary"">
                    <a class=""ml-5"" href=""/chatRoom""> < </a>
                </li>
            </ul>

        </div>
        <!-- Page Content -->
        <div id=""page-content-wrapper"">
            <div class=""container"">
                <form id=""myForm"" action=""/room"" method=""post"" onsubmit=""return check()"">
                    <div class=""form-group row"">
                        <label for=""n");
                WriteLiteral(@"ame"" class=""col-sm-2 col-form-label"">Room name</label>
                        <div class=""col-sm-10"">
                            <input type=""text"" class=""form-control"" id=""name"" name=""name"" placeholder=""Room name"">
                        </div>
                        <small id=""alert"" class=""text-danger form-text"" style=""display: none"">Name alreadly exist, please change the name</small>
                    </div>
               
                    <div class=""form-group row"">
                        <div class=""col-sm-10"">
                            <button id=""subBtn"" type=""submit"" class=""btn btn-primary"">Confirm</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <!-- /#page-content-wrapper -->

    </div>
    <script src=""lib/bootstrap/dist/js/bootstrap.js""></script>
    <script src=""lib/jquery/dist/jquery.js""></script>
    <script>
        
        function check(){
                    let name = $('#name').val();
    ");
                WriteLiteral(@"                let res = false;
                    $.ajax({
                                    url:""/roomName"",
                                    type:""get"",
                                    data: {
                                        'name':name
                                    },
                                    dataType:'json',
                                    contentType:'application/json',
                                    success: function(data) {
                                          if (data.msg === 'dispo'){
                                              if ($('#number').val() <= 0){
                                                 $('#alert1').css('display','inline-block'); 
                                                
                                              }else{
                                                  res = true;
                                              }                        
                                          }else{
                   ");
                WriteLiteral(@"                           $('#alert').css('display','inline-block');
                                             
                                          }
                                        
                                    }
                                   
                                })    
                     return res;
        }
      // $('#myForm').submit(function(e) {
      // 
      // })
    
 
   
    </script>
</main>


");
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
            WriteLiteral("\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591