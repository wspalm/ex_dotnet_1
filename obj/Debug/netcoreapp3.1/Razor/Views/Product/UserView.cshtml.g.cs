#pragma checksum "C:\Users\wspal\Desktop\FINAL_6013532\Views\Product\UserView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50ad5d75be4aa4c901e94c5905a30cb484b046d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_UserView), @"mvc.1.0.view", @"/Views/Product/UserView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50ad5d75be4aa4c901e94c5905a30cb484b046d7", @"/Views/Product/UserView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd4ffb7483c43284bcf94cd8810437fd9513cdf3", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_UserView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav aria-label='breadcrumb'>
    <ol class='breadcrumb breadcrumb-arrow'>

        <li class='breadcrumb-item active' aria-current='page'>
            As User you can select the product below</li>
    </ol>
</nav>
<div id='app1' v-cloak>

    <v-app>
        <v-main>
            <v-data-table :headers='headers' :items='products' class='elevation-1' />
            <template v-slot:item.actions='{item}'>
                <v-btn class=""white--text"" color=""blue darken-1"" ");
            WriteLiteral(@"@click=""add(item)"">
                    <v-icon>
                        mdi-plus
                    </v-icon>

                </v-btn>
            </template>

            </v-data-table>
            <hr>


            <nav aria-label='breadcrumb'>
                <ol class='breadcrumb breadcrumb-arrow'>

                    <li class='breadcrumb-item active' aria-current='page'>Your Selection</li>
                </ol>
            </nav>

            <v-data-table :headers='headers2' :items='selection' class='elevation-1' />
            </v-data-table>
        </v-main>
    </v-app>
</div>
");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
<script>
    var app;
    var component = {
        vuetify: new Vuetify(),
        el: '#app1',
        data: {
            products: {} //this is the empty object that reserve for coming data from user
            ,
            selection: [] //this will be the user's selection 
                ,
            list1: [] //just in case 
                ,
            headers: [{
                        text: 'Product Name',
                        value: 'name',
                        align: 'center',
                        sortable: true
                    },
                    {
                        text: 'Quantity',
                        value: 'qty',
                        align: 'center',
                        sortable: true
                    },
                    {
                        text: 'Price',
                        value: 'price',
                        align: 'center',
                        sortable: true
                    },
                ");
                WriteLiteral(@"    {
                        text: 'Material',
                        value: 'typeName',
                        align: 'center',
                        sortable: true
                    },
                    {
                        text: 'Select',
                        value: 'actions',
                        align: 'center'
                    },

                ] //end of header array
                ,
            headers2: [{
                        text: 'Product Name',
                        value: 'name',
                        align: 'center',
                        sortable: true
                    },
                    {
                        text: 'Quantity',
                        value: 'qty',
                        align: 'center',
                        sortable: true
                    },
                    {
                        text: 'Price',
                        value: 'price',
                        align: 'center',
              ");
                WriteLiteral("          sortable: true\r\n                    },\r\n\r\n                ] //end of header array\r\n                ,\r\n        } //end of data\r\n        ,\r\n        created() {\r\n            this.products = ");
#nullable restore
#line 107 "C:\Users\wspal\Desktop\FINAL_6013532\Views\Product\UserView.cshtml"
                       Write(Html.Raw(Json.Serialize(@ViewBag.products)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        },
        methods: {
            // I want to make the user edit the database only for the qty
            // User click select and then the qty in the db will update by -1 from total
            // then add that product into the user database and increase the qty number by one      
            edit_byUser() {
                var url = ""/product/edit_byUser/"" + item.productID;
                var param = this.products;
                $.post(url, param)
                    .done(res => {

                        if (res.error == -1) {
                            window.location = '/product/index';
                        } else {
                            alert(res.exception);
                        }
                    });
            } //end of function
            ,
            add(item) {
                this.selection.push(item);
            },

        },
        computed: {

        }
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
