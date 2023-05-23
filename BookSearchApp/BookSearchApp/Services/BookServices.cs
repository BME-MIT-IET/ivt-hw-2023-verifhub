using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BookSearchApp.Models;

namespace BookSearchApp.Services
{
    public class BookServices
    {
        private readonly Uri serverUrl = new Uri("https://openlibrary.org/");//static Uri

        private async Task<T> GetAsync<T>(Uri uri)//Get and convert data from api
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
        public async Task<List<Book>> SearchBooksAsync(string searchTerm)
        {
            var booksResponse = await GetAsync<BooksResponse>(new Uri(serverUrl, $"search.json?title={searchTerm}"));//Get data from a specific api which search the book with the title

            var bookItems = new List<Book>();
            foreach (var book in booksResponse.Docs)//book's data from list 
            {
                var bookItem = new Book//Save only the data needed, not all
                { 
                    title = book.title,
                    author_name = book.author_name,
                    first_publish_year = book.first_publish_year,
                    language= book.language,
                    ImageUrl= $"https://covers.openlibrary.org/b/id/{book.cover_i}-S.jpg"
                };
                bookItems.Add(bookItem);//add books to a new list
            }
            return bookItems;
        }
        public async Task<List<Book>> SearchBooksWithAuthorAsync(string searchTerm)
        {
            var booksResponse = await GetAsync<BooksResponse>(new Uri(serverUrl, $"search.json?author={searchTerm}"));//Get data from a specific api which search the books of the author

            var bookItems = new List<Book>();
            foreach (var book in booksResponse.Docs)
            {
                var bookItem = new Book//Save only the data needed, not all
                {
                    title = book.title,
                    author_name = book.author_name,
                    author_key= book.author_key,
                    first_publish_year = book.first_publish_year,
                    language = book.language,
                    ImageUrl = $"https://covers.openlibrary.org/b/id/{book.cover_i}-M.jpg"
                };
                bookItems.Add(bookItem);//add books to a new list
            }
            return bookItems;
        }
        public async Task<Author> GetAuthorAsync(string authorKey)
        {
            var author = await GetAsync<Author>(new Uri(serverUrl, $"authors/{authorKey}.json"));//get the info about the author with the authorkey
            return author;
        }
    }
}
