#Test introduction
## A unit test is way to test a unit in a program, unit means a function, a method and a property.
As our project is a UWP application, we are going to use UWP unit test, which is contained in the .NET framework.
Visual Studio offers UWP unit test project templates for C#
![](new_uwp.png)

#Test
All Object intances we need before we can start unit tests.
![](test_initial.PNG)
##Test #1: Searching books based on the title of the book
This test will check the returned data from remote api if it is null or not.This test will cover the associated ViewModel class, BookService class, and associated Model class.
![](title_search_test.PNG)

### Covered methods of the test #1

![](VM_search_title.PNG)

![](Service_search_title.PNG)

---
##Test #2: Searching books based on the author name of the book
This test will check the returned data from remote api if it is null or not, but this one is based on book's author.This test will cover the associated ViewModel class, BookService class, and associated Model class.
![](author_search_test.PNG)

### Covered methods of the test #2

![](VM_search_authorname.PNG)

![](Service_search_authorname.PNG)

---
##Test #3： Searching author's detail based on the author key
This test will check the author's data retrieval from remote api is null or not.This test will cover the associated ViewModel class, BookService class, and associated Model class.
![](authorInfo_search_test.PNG)

### Covered methods of the test #3

![](VM_authorInfo.PNG)

![](Service_search_authorInfo.PNG)

---
#Test Result
All three tests are successful.
![](Unit_test_result.PNG)

