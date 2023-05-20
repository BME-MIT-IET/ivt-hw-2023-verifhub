using BookSearchApp.Models;
using BookSearchApp.ModelViews;
using BookSearchApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void SearchClicked(object sender, RoutedEventArgs e)
        {
            await viewModel.SearchBooksAsync();
        }
        private async void SearchClickedAccordingToAuthor(object sender, RoutedEventArgs e)
        {
            await viewModel.SearchBooksWithAuthorAsync();
        }
        private void Image_Tapped(object sender, TappedRoutedEventArgs e)//zoom in image
        {
            var imageUrl = (string)((Image)sender).Tag;//get the uri of image
            viewModel.ShowImagePopup(imageUrl);
        }
        private void AuthorButton_Clicked(object sender, RoutedEventArgs e)//go to author detail page
        {
            try 
            {
                var hyperlinkButton = (HyperlinkButton)sender;
                var book = (Book)hyperlinkButton.DataContext;//get the book data which are chosed
                Frame.Navigate(typeof(AuthorPage), book.FirstAuthorKey);//transfer the authorkey data to AuthorPage
            }
            catch(Exception ex) //Debug
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }
        private void Book_Clicked(object sender, ItemClickEventArgs e)
        {
            var book = (Book)e.ClickedItem;
            Frame.Navigate(typeof(BookDetailPage), book);//sent data'book' to a new page
        }
    }
}
