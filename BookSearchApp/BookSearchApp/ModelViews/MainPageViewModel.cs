using BookSearchApp.Models;
using BookSearchApp.Services;
using BookSearchApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Template10.Mvvm;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace BookSearchApp.ModelViews
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly BookServices bookServices;//to use service methods
        public MainPageViewModel()//initialization
        {
            bookServices = new BookServices();
            _books = new ObservableCollection<Book>();
        }
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books//get/sent data from/to outside
        {
            get { return _books; }
            set
            {
                if (_books != value)
                {
                    _books = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Books)));
                }
            }
        }
        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                if (_searchTerm != value)
                {
                    _searchTerm = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchTerm)));
                }
            }
        }
       

        public new event PropertyChangedEventHandler PropertyChanged;
        public async Task SearchBooksWithAuthorAsync()//search with author name
        {
            _books.Clear();//clear the list which was searched before

            if (!string.IsNullOrWhiteSpace(_searchTerm))//if has any result from api
            {
                var results = await bookServices.SearchBooksWithAuthorAsync(_searchTerm);//get data
                foreach (var book in results)
                {
                    _books.Add(book);//put data into list
                }
            }
        }
        public async Task SearchBooksAsync()//search with book title
        {
            _books.Clear();//clear the list which was searched before

            if (!string.IsNullOrWhiteSpace(_searchTerm))//if has any result from api
            {
                var results = await bookServices.SearchBooksAsync(_searchTerm);
                foreach (var book in results)
                {
                    _books.Add(book);//save the data to the viewmodel
                }
            }
        }
        public void ShowImagePopup(string imageUrl)//Zoom in picture
        {
            var dialog = new ContentDialog
            {
                Content = new Image { Source = new BitmapImage(new Uri(imageUrl)) },
                PrimaryButtonText = "OK",
                FullSizeDesired = true//occupy the entire subwindow
            };

            _ = dialog.ShowAsync();//show the zoomed in picture to a Pop-ups
        }
       
    }
}
