#pragma checksum "C:\Users\wspal\Desktop\FINAL_6013532\Views\ProductType\add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c7444971cbe14271f245262e4519979692bf71d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductType_add), @"mvc.1.0.view", @"/Views/ProductType/add.cshtml")]
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
#line 1 "C:\Users\wspal\Desktop\FINAL_6013532\Views\_ViewImports.cshtml"
using FINAL_6013532;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\wspal\Desktop\FINAL_6013532\Views\_ViewImports.cshtml"
using FINAL_6013532.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c7444971cbe14271f245262e4519979692bf71d", @"/Views/ProductType/add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd4ffb7483c43284bcf94cd8810437fd9513cdf3", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductType_add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav aria-label='breadcrumb'>
    <ol class='breadcrumb breadcrumb-arrow'>
        <li class='breadcrumb-item'><a href='/producttype/index'>Back</a></li>
        <li class='breadcrumb-item'>This is the page for product addition</li>
        
    </ol>
</nav>
<div id='app1' v-cloak>

    <v-app>
         
        <v-card>
          <v-card-title>
          </v-card-title>
          <v-card-text>
            <!--prod is used instead of product for myown better understanding-->
            <v-text-field v-model=""prod.productTypeName"" label=""name"" ></v-text-field>
          </v-card-text>
          <v-card-actions>
             <v-btn ");
            WriteLiteral("@click=\'add_producttype\' color=\'blue\' outlined>\r\n                <v-icon>\r\n                    mdi-content-save-edit\r\n                </v-icon>\r\n             </v-btn>\r\n          </v-card-actions>\r\n          \r\n        </v-card>\r\n    </v-app>\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var app;
            var component = {
                vuetify: new Vuetify()
                ,
                el:'#app1'
                ,
                data:{
                    prod:{} //this is not array because we want to send the object{}
                    ,
                    
                }//edata
                ,
                created(){
                     
                }//ecreated
                ,
                methods:{
                //I do really need explanation about this
                  add_producttype(){
                   
                    var url = '/producttype/add';
                    var param= this.prod;
                    $.post(url,param)
                    .done(res =>{
                          if(res.error == 0){
                               window.location = '/producttype/index';
                          }
                          else{
                             //alert(res.exception);
      ");
                WriteLiteral(@"                       alert(""added with some error"");
                          }
                    });
                    
                  }//emethod

                }//emethod
                ,
                 computed:{

                 }//ecomputed
            };
            app = new Vue(component);


    </script>

");
            }
            );
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
