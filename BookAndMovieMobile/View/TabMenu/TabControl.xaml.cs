using BookAndMovieMobile.Model.Movie;
using BookAndMovieMobile.Model.TMDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace BookAndMovieMobile.View.TabMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabControl : Xamarin.Forms.TabbedPage
    {
        public TabControl()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
           
        }
    }
}