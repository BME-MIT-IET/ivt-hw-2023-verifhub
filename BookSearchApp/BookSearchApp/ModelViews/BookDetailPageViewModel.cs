using BookSearchApp.Models;
using BookSearchApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace BookSearchApp.ModelViews
{
    public class BookDetailPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        //get all data from previous page one by one and then show it to UI
        private Book _book;
        public Book Book
        {
            get { return _book; }
            set
            {
                if (_book != value)
                {
                    _book = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Book)));
                }
            }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != null)
                {
                    _title = _book.title;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
                }
            }
        }
        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                if (_imageUrl != null)
                {
                    _imageUrl = _book.ImageUrl;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageUrl)));
                }
            }
        }
        private int _first_publish_year;
        public int First_publish_year
        {
            get { return _first_publish_year; }
            set
            {  
                _first_publish_year = _book.first_publish_year;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(First_publish_year)));
            }
        }
        private string _firstAuthorName;
        public string FirstAuthorName
        {
            get { return _firstAuthorName; }
            set 
            {
                if (_firstAuthorName != null)
                {
                    _firstAuthorName = _book.FirstAuthorName;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstAuthorName)));
                }
            }
        }
        private string[] language;
        public string[] Language
        {
            get { return language; }
            set 
            {
                if (language != null)
                {
                    language = _book.language;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Language)));
                }
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;
        public BookDetailPageViewModel()
        {
            //_book=new Book();
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
