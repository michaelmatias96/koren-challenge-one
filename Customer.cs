using System;
using System.Collections.Generic; 

namespace Library
{
    public class Customer
    {
        /* This class represents a single customer of the library. 
         * A customer is one person. 
         * A customer has a library membership, so he can check out books (the limit however is 3). 
         * A customer holds a list of books that he currently has checked out under his name. 
         */

        private string customerName;
        private List<Book> customerCheckedOutBooks;
     

        // constructor - for every customer, input his name and list of books checked out 
        public Customer(string customerName, List<Book> customerBooks)
        {
            this.customerName = customerName;
            this.customerCheckedOutBooks = customerBooks; 
        }

        public int GetNumBooksCheckedOut()
        {
            return customerCheckedOutBooks.Count; 
        }

        public void AddBookToList(Book bookToAdd)
        {
            customerCheckedOutBooks.Add(bookToAdd);
        }

        public void RemoveBookFromList(Book bookToRemove)
        {
            customerCheckedOutBooks.Remove(bookToRemove);
        }

        public Book GetFirstBook()
        {
            return customerCheckedOutBooks[0]; 
        }
    }
}
