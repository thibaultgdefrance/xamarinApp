using MasterCodeMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterCodeMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeForumsPage : ContentPage
    {
        ForumViewModel viewModel;
        public ListeForumsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ForumViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //await Navigation.PushAsync(new ForumDetailPage());
            if (viewModel.Forums.Count == 0)
                viewModel.LoadForumsCommand.Execute(null);
        }
        
    }
}