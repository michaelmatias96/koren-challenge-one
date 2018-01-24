using System;
namespace Library
{
    public class Book : IComparable<Book>
    {
        /* This class represents a single book in the library. 
         * A given book has a title, author, and unique ID number.
         * The class implements the IComparable Interface in order to compare two given books by the implementation given below. 
         */

        private string bookTitle;
        private string bookAuthor;
        public int bookIDNum; 

        // constructor -- for every book, input its name, author, and ID number. Availability status is set to available by default. 
        public Book(string bookTitle, string bookAuthor, int bookIDNum)
        {
            this.bookTitle = bookTitle;
            this.bookAuthor = bookAuthor;
            this.bookIDNum = bookIDNum;
        }

        public string GetBookTitle()
        {
            return bookTitle; 
        }

        public string GetBookAuthor()
        {
            return bookAuthor; 
        }

        public override string ToString()
        {
            return bookTitle + "written by: " + bookAuthor; 
        }

        // implementing the IComparable Interface method CompareTo  
        // a comparison between two books will return 0 (same) if they have the same title and author 
        public int CompareTo(Book otherBook)
        {
            if(this.GetBookTitle().Equals(otherBook.GetBookTitle())  && this.GetBookAuthor().Equals(otherBook.GetBookAuthor()))
            {
                return 0; 
            }
               
            else 
            {
                return -1; 
            }
            
        }

    }
}
