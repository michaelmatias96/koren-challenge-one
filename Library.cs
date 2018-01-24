using System;
using System.Collections.Generic; 

namespace Library
{
    public class Library 
    {
        /* This class represents the overall library. 
         * The library has a list of books that it owns. Every book has a status of availability -- whether the book is availble to be checked out at a given time 
         * (whether someone has checked it out or not). There is a dictionary with key as a Book object and value as bool isAvailable 
         * The library has a list of its registered customers, who may check out books. 
         * The library has a defined set of working hours (represented by a WorkingHours object). 
         */

        private string libraryName;
        private List<Book> libraryListBooks = new List<Book>();
        private List<Customer> libraryListCustomers;
        private WorkingHours libraryWorkingHours;
        private Dictionary<Book, bool> bookAvailabilityList = new Dictionary<Book, bool>(); 
        private int MAX_NUM_BOOKS_ALLOWED = 3;
        private Dictionary<DateTime, int> booksCheckedOutByDate = new Dictionary<DateTime, int>(); 

        public Library()
        {
            
        }

        // constructor -- input the name of library, its list of books, list of customers, and working hours 
        public Library(string libraryName, List<Book> libraryListBooks, List<Customer> libraryListCustomers, WorkingHours libraryWorkingHours)
        {
            this.libraryName = libraryName;
            this.libraryListBooks = libraryListBooks;
            this.libraryListCustomers = libraryListCustomers;
            this.libraryWorkingHours = libraryWorkingHours; 
        }

        // fill the dictionary with entries for every book, making each available (to begin with) 
        public void InitiateDictionary()
        {
            foreach (Book book in libraryListBooks)
            {
                bookAvailabilityList.Add(book, true);
            }
        }

        // method to check if the library has a given book
        public bool BookIsInLibrary(Book bookToCheck)
        {
            foreach (Book book in libraryListBooks)
            {
                // utilizes the IComparable implementation of CompareTo (implemented in Book class) 
                if(book.CompareTo(bookToCheck) == 0)
                {
                    return true; 
                }
            }
            return false; 
        }

        // method to check if a given book is available to be checked out (if no one has it)  
        public bool BookIsAvailable(Book bookToCheck)
        {
            return (bookAvailabilityList[bookToCheck] == true); 
        }

        // method to check if a given customer doesn't have too many books checked out already 
        public bool CustomerIsAllowed(Customer customerToCheck)
        {
            int numBooksCustomerHas = customerToCheck.GetNumBooksCheckedOut();
            return (numBooksCustomerHas < MAX_NUM_BOOKS_ALLOWED); 
        }

        // method to check out a book 
        public void CheckOutBook(Customer customer, Book bookToCheckOut)
        {
            if(BookIsInLibrary(bookToCheckOut) && BookIsAvailable(bookToCheckOut) && CustomerIsAllowed(customer))
            {
                // add that book to the customer's list of books checked out
                customer.AddBookToList(bookToCheckOut);
                // set the availability status of the book to false 
                bookAvailabilityList[bookToCheckOut] = false;
                // update the dictionary entry for today of how many books were checked out
                DateTime todayDate = new DateTime();
                booksCheckedOutByDate[todayDate] += 1; 
            }
        }

        // method to return a book -- update the customer's list of checked out books, update the book's status to available. 
        public void ReturnOutBook(Customer customer, Book bookToReturn)
        {
            customer.RemoveBookFromList(bookToReturn);
            bookAvailabilityList[bookToReturn] = true; 
        }


        public void InitiateValues()
        {
            Book book1 = new Book("Catcher in the Rye", "Koren", 1); 
            Book book2 = new Book("All My Sons", "Arthur Miller", 1); 
            Book book3 = new Book("Lord of the Flies", "Bob", 1); 
            Book book4 = new Book("Romeo & Juliet", "Shakespeare", 1);

            List<Book> listOfBooks = new List<Book>(); 
            listOfBooks.Add(book1); 
            listOfBooks.Add(book2); 
            listOfBooks.Add(book3); 
            listOfBooks.Add(book4);

            List<Book> customerBooks = new List<Book>(); 


            WorkingHours workingHours = new WorkingHours(8, 2000);

            Customer myCustomer = new Customer("Koren", customerBooks);
            List<Customer> myCustomers = new List<Customer>(); 
            myCustomers.Add(myCustomer);

            Library myLibrary = new Library("Harvard Library", listOfBooks, myCustomers, workingHours); 
            myLibrary.InitiateDictionary();
            Console.WriteLine(myLibrary.bookAvailabilityList[book1]);
            myLibrary.CheckOutBook(myCustomer, book1);
            Console.WriteLine(myCustomer.GetFirstBook());

            Console.WriteLine(myLibrary.BookIsAvailable(book1));
        }

    }
}
