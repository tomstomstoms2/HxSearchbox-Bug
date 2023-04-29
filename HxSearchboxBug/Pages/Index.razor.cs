using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using HxSearchboxBug;
using HxSearchboxBug.Shared;
using Havit.Blazor.Components.Web.Bootstrap;
using Havit.Linq;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HxSearchboxBug.Pages
{
    public partial class Index
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        private SearchBoxItem selectedItem;
        private string triggeredTextQuery;

        List<SearchBoxItem> Data { get; set; } = new()
    {
        new() { Title = "Table", Subtitle = "50 000", Icon = BootstrapIcon.Table },
        new() { Title = "Mouse", Subtitle = "400", Icon = BootstrapIcon.Mouse },
        new() { Title = "Door", Subtitle = "1000", Icon = BootstrapIcon.DoorClosed },
        new() { Title = "Big table", Subtitle = "9 000", Icon = BootstrapIcon.Table },
        new() { Title = "Small table", Subtitle = "7 200", Icon = BootstrapIcon.Table }
    };

        private void OnItemSelected(SearchBoxItem item)
        {
            //NavigationManager.NavigateTo(NavigationManager.ToAbsoluteUri("/counter").ToString());
            NavigationManager.NavigateTo("/counter");
            selectedItem = item;
        }

        private void OnTextQueryTriggered(string text)
        {
            triggeredTextQuery = text;
        }

        private async Task<SearchBoxDataProviderResult<SearchBoxItem>> ProvideSearchResults(SearchBoxDataProviderRequest request)
        {
            await Task.Delay(400); // imitate slower server API

            return new()
            {
                Data = Data.Where(i => i.Title.Contains(request.UserInput, StringComparison.OrdinalIgnoreCase))
            };
        }

        internal class SearchBoxItem
        {
            public string Title { get; set; }
            public string Subtitle { get; set; }
            public BootstrapIcon Icon { get; set; }
        }
    }       
}