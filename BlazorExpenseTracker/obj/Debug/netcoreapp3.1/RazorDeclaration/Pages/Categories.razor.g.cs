// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorExpenseTracker.Pages
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using BlazorExpenseTracker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using BlazorExpenseTracker.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using ChartJs.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using ChartJs.Blazor.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using ChartJs.Blazor.Common.Axes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using ChartJs.Blazor.Common.Axes.Ticks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using ChartJs.Blazor.Common.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using ChartJs.Blazor.Common.Handlers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using ChartJs.Blazor.Common.Time;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using ChartJs.Blazor.Util;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\_Imports.razor"
using ChartJs.Blazor.Interop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\Pages\Categories.razor"
using Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\Pages\Categories.razor"
using Interfaces;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/categories")]
    public partial class Categories : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 41 "C:\Users\Andres\DoctorApp\BlazorExpenseTracker\BlazorExpenseTracker\Pages\Categories.razor"
       
    public IEnumerable<Category> categories{ get;set; }
    public string Message { get; set; }

    protected async override Task OnInitializedAsync()
    {
        try
        {
            categories = await Categoryservice.GetAllCategories();

        }
        catch (Exception ex)
        {
            Message = "algo salio Mal" +  ex.Message;
        }   
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICategoryServices Categoryservice { get; set; }
    }
}
#pragma warning restore 1591
