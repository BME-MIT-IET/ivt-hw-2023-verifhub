using BookSearchApp.Models;
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
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class BookDetailPage : Page
    {
        private BookDetailPageViewModel viewModel;//initial VM here cause page has data get in
        public BookDetailPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)//get the data
        {
            if (e.Parameter is Book && e.Parameter != null)//check data
            {
                var book = (Book)e.Parameter;
                viewModel = new BookDetailPageViewModel();
                viewModel.Book = book;
                Debug.WriteLine(viewModel.Book.FirstAuthorName);//Debug
                DataContext = viewModel;
            }
            base.OnNavigatedTo(e);
        }
        private void Image_Tapped(object sender, TappedRoutedEventArgs e)//zoom in image
        {
            var imageUrl = (string)((Image)sender).Tag;//get the uri of image
            viewModel.ShowImagePopup(imageUrl);
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
