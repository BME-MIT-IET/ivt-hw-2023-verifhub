
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSearchApp.ModelViews;
using BookSearchApp.Views;
using BookSearchApp.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using BookSearchApp.Models;
using System.Diagnostics;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium;
using System.Linq;

namespace UnitTestProject_Verification
{
    [TestClass]
    public class UnitTest1
    {
        private AuthorPageViewModel AuthorPageViewModel;
        private MainPageViewModel ViewModel;
        [TestInitialize]
        public void TestInitialize() 
        {
            ViewModel = new MainPageViewModel();
            AuthorPageViewModel = new AuthorPageViewModel();
        }
        [TestMethod]
        public async Task Search_WithValidKeyword_ReturnsResults()//test title as searchkey book search
        {
            // Arrange
             ViewModel.SearchTerm = "Harry Potter";
            // Act
            await ViewModel.SearchBooksAsync();
            // Assert
            Assert.IsTrue(ViewModel.Books.Count > 0);
            foreach (var book in ViewModel.Books)
            {
                Assert.IsNotNull(book.title);
                Assert.IsNotNull(book.FirstAuthorName);
                Assert.IsNotNull(book.first_publish_year);
                Assert.IsNotNull(book.ImageUrl);
            }
        }
        [TestMethod]
        public async Task SearchAuthor_WithValidKeyWord_ReturnResults()//test author as searchkey book search
        {
            ViewModel.SearchTerm = "J.K Rowling";

            await ViewModel.SearchBooksWithAuthorAsync();
            
            // Assert
            Assert.IsTrue(ViewModel.Books.Count > 0);
            foreach (var book in ViewModel.Books)
            {
                Assert.IsNotNull(book.title);
                Assert.IsNotNull(book.FirstAuthorName);
                Assert.IsNotNull(book.first_publish_year);
                Assert.IsNotNull(book.ImageUrl);
            }
        }
        [TestMethod]
        public async Task GetAuthor_WithValidKeyWord_ReturnResults()//test author search 
        {
            AuthorPageViewModel.AuthorKey = "OL23919A";

            await AuthorPageViewModel.LoadAuthor();
            Assert.IsNotNull(AuthorPageViewModel.Author.name);
            Assert.IsNotNull(AuthorPageViewModel.Author.alternate_names[0]);
            Assert.IsNotNull(AuthorPageViewModel.Author.birth_date);
            Assert.IsNotNull(AuthorPageViewModel.Author.bio);
        }

        [TestCleanup]
        public void CleanUp() 
        {
            ViewModel = null;
            AuthorPageViewModel = null;
        }
    }
    //[TestClass]
    //public class UwpAppTests
    //{
    //    private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/";
    //    private const string UwpAppId = "App";

    //    private WindowsDriver<WindowsElement> driver;

    //    [TestInitialize]
    //    public void TestInitialize()
    //    {
    //        AppiumOptions appiumOptions = new AppiumOptions();
    //        appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, UwpAppId);
    //        driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
    //        Assert.IsNotNull(driver);
    //    }

    //    [TestCleanup]
    //    public void TestCleanup()
    //    {
    //        driver?.Quit();
    //    }

    //    [TestMethod]
    //    public void TestButtonClicked()
    //    {
    //        // 找到输入框元素
    //        WindowsElement inputBox = driver.FindElementByAccessibilityId("SearchBox_Title");

    //        // 输入文本 "Harry" 到输入框
    //        inputBox.SendKeys("Harry");

    //        // 找到"Search"按钮元素
    //        WindowsElement searchButton = driver.FindElementByAccessibilityId("SearchButton_Title");

    //        // 模拟点击"Search"按钮
    //        searchButton.Click();

    //        // 等待一定时间，确保数据加载完成
    //        System.Threading.Thread.Sleep(2000);

    //        // 找到ListView元素
    //        WindowsElement listView = driver.FindElementByAccessibilityId("MainGridView");

    //        // 验证输入框的数据是否为 "Harry"
    //        Assert.AreEqual("Harry", inputBox.Text);

    //        // 验证ListView是否显示了书籍
    //        Assert.IsTrue(listView.FindElementsByClassName("Books").Any());
    //    }
    //}
}
