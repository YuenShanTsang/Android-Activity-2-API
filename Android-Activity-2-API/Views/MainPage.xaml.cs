using Android_Activity_2_API.Model;
using Android_Activity_2_API.ViewModels;
using System.Net.Http;
using System.Text.Json;

namespace Android_Activity_2_API.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();

            this.BindingContext = viewModel;
        }
    }
}
