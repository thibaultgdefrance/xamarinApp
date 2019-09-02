using MasterCodeMobile.Models;
using MasterCodeMobile.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterCodeMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForumDetailPage : ContentPage
    {
        HttpClient htc = new HttpClient();
        Forum Forum { get; set; }

        ForumDetailViewModels viewModels;
        public ForumDetailPage()
        {
            InitializeComponent();
            Forum = new Forum();
            List<Message> messages = new List<Message>();
        }
        public ForumDetailPage(ForumDetailViewModels viewModel)
        {

            InitializeComponent();
            Forum = new Forum();
            BindingContext = this.viewModels = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModels.LoadMessagesCommand.Execute(null);
        }
    }
}