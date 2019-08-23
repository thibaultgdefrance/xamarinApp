using MasterCodeMobile.Models;
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
    public partial class ListeCategoriesPage : ContentPage
    {
        CategorieViewModel viewModel;

        public ListeCategoriesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CategorieViewModel();
        }

        /*async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var categorie = args.SelectedItem as Categorie;
            if (categorie == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new CategorieDetailViewModel(categorie)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }*/

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            //await Navigation.PushAsync(new ForumDetailPage());
            if (viewModel.Categories.Count == 0)
                viewModel.LoadCategoriesCommand.Execute(null);
        }
    }
}