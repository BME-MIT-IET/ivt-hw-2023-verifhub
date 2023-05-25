using BookSearchApp.Models;
using BookSearchApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace BookSearchApp.ModelViews
{
    public class AuthorPageViewModel:ViewModelBase,INotifyPropertyChanged
    {
        public AuthorPageViewModel()
        {
            _bookServices = new BookServices();
            //_authorKey = authorKey;
            //_ = LoadAuthor();
        }
        private readonly BookServices _bookServices;
        private string _authorKey;//Accept the selected author's key
        public string AuthorKey
        {
            get { return _authorKey; }
            set
            {
                if (_authorKey != value)
                {
                    _authorKey = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthorKey)));
                }
            }
        }
        private Author _author;
        public Author Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Author)));
                }
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        public async Task LoadAuthor()
        {
            Author = await _bookServices.GetAuthorAsync(_authorKey);//get author data from api
            Debug.WriteLine("The author key passed from MainPage"+_authorKey);
        }
    }
}
