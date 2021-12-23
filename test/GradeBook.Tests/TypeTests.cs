using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string MyDelegate(string foo); // signature and return type must always match
    public class TypeTests
    {

        [Fact]
        public void CanUseMulticastDelegate(){
            MyDelegate myDelegate = changeString;
            myDelegate+=changeStringLower;
            Assert.Equal("hello",myDelegate("hello"));
        }

        [Fact]
        public void CanUseDelegate(){
            MyDelegate myDelegate = changeString;
            Assert.Equal("HELLO",myDelegate("hello"));
        }

        private string changeString(string bar){
            return bar.ToUpper();
        }
        private string changeStringLower(string bar){
            return bar.ToLower();
        }

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
            var book2 = new MemoryBook("initial");
            GetBookSetNameByRef(ref book2,"aaah");
            Assert.Equal("AAAH",book2.Name);
        }
        private void GetBookSetNameByRef(ref MemoryBook book, string name){
            // also can use out instead of ref, to enforce initialization of param
            book = new MemoryBook(name);
        }
        
        [Fact]
        public void CanPassByValueByDefault(){
            var book2 = new MemoryBook("initial");
            GetBookSetName(book2,"aaah");
            Assert.Equal("INITIAL",book2.Name);
        }
        private void GetBookSetName(MemoryBook book, string name){
            book = new MemoryBook(name);
        }

        [Fact]
        public void CanCreateBook()
        {
            var book1 = new MemoryBook("book1");
            var book2 = new MemoryBook("book2");
            Assert.Equal("BOOK1", book1.Name);
            Assert.Equal("BOOK2", book2.Name);
            Assert.NotSame(book1,book2);
        }
        [Fact]
        public void TwoVarsRefSameObject()
        {
            var book1 = new MemoryBook("book1");
            var book2 = book1;
            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }
    }
}
