using BookSearchApp.ModelViews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace BookSearchApp.Views
{
    public sealed partial class AuthorPage : Page
    {
        private AuthorPageViewModel _viewModel = null;
        public AuthorPage()
        {
            this.InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)//get the authorkey data from the mainpage
        {            
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))//if the transfered data is not null
            {
                string authorKey = (string)e.Parameter;//get transfered data
                Debug.WriteLine(authorKey);//debug
                _viewModel = new AuthorPageViewModel();
                _viewModel.AuthorKey = authorKey;//transfer data to ViewModel
                await _viewModel.LoadAuthor();//get author data from api
                Debug.WriteLine(_viewModel.Author.photos);
                this.DataContext = _viewModel;//binding data
            }
            base.OnNavigatedTo(e);
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
