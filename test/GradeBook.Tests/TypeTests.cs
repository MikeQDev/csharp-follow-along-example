using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

        [Fact]
        public void CanSetIntAsRef(){
            var x = 10;
            SetIntByRef(out x, 44);
            Assert.Equal(44,x);
        }
        private void SetIntByRef(out int x, int newNum){
            x = newNum;
        }

        
        [Fact]
        public void CanSetIntAsValue(){
            var x = 10;
            SetInt(x, 44);
            Assert.Equal(10,x);
        }
        private void SetInt(int x, int newNum){
            x = newNum;
        }

        [Fact]
        public void CanPassByRef(){
            var book2 = new Book("initial");
            GetBookSetNameByRef(ref book2,"aaah");
            Assert.Equal("aaah",book2.Name);
        }
        private void GetBookSetNameByRef(ref Book book, string name){
            // also can use out instead of ref, to enforce initialization of param
            book = new Book(name);
        }
        
        [Fact]
        public void CanPassByValueByDefault(){
            var book2 = new Book("initial");
            GetBookSetName(book2,"aaah");
            Assert.Equal("initial",book2.Name);
        }
        private void GetBookSetName(Book book, string name){
            book = new Book(name);
        }

        [Fact]
        public void CanCreateBook()
        {
            var book1 = new Book("book1's Name");
            var book2 = new Book("book2's Name");
            Assert.Equal("book1's Name", book1.Name);
            Assert.Equal("book2's Name", book2.Name);
            Assert.NotSame(book1,book2);
        }
        [Fact]
        public void TwoVarsRefSameObject()
        {
            var book1 = new Book("book1's Name");
            var book2 = book1;
            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }
    }
}
