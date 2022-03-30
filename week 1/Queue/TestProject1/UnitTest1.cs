using Xunit;
using QueueTemp;
using System;

namespace TestProject1
{
    public class Test_Queue_Exception
    {
        [Fact]
        public void Dequeue_From_Empty_Queue()
        {
            QueueSM<string> sm = new();
            Assert.Throws<NullReferenceException>(() => sm.Dequeue());
        }
        [Fact]
        public void Peek_From_Empty_Queue()
        {
            QueueSM<string> sm = new();
            Assert.Throws<NullReferenceException>(() => sm.Peek());
        }
        [Fact]
        public void Adding_NullElement()
        {
            string? n = null;
            QueueSM<string> sm = new();
            Assert.Throws<NullReferenceException>(() => sm.Enqueue(n));
        }
    }
    public class Test_Size_And_Peek
    {
        [Fact]
        public void Find_Peek_Element_From_Queue()
        {
            //Arrange
            QueueSM<string> Q = new();
            Q.Enqueue("Lol");
            Q.Enqueue("kek");
            Q.Enqueue("meme");
            var expected = "Lol";

            //Act
            var actual = Q.Peek();

            //assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Find_Size_Of_Current_Queue()
        {
            //Arrange
            QueueSM<string> Q = new();
            Q.Enqueue("Lol");
            Q.Enqueue("kek");
            Q.Enqueue("meme");
            Q.Enqueue("Lol");
            Q.Enqueue("kek");
            Q.Enqueue("meme"); 
            var expected = 6;

            //Act
            var actual = Q.Size();

            //assert
            Assert.Equal(expected, actual);
        }
    }
    public class Enqueue_And_Dequeue_Tests
    {
        [Fact]
        public void Adding_New_Element_To_Int_Queue ()
        {
            //Arrange
            QueueSM<int> Q = new();
            Q.Enqueue(123);
            var expected = 123;
            int size = 1;
            //Act
            var actual = Q.Peek();

            //assert
            Assert.Equal(expected, actual);
            Assert.Equal(size, Q.Size());
        }
        [Fact]
        public void Adding_New_Element_To_String_Queue()
        {
            //Arrange
            QueueSM<string> Q = new();
            Q.Enqueue("lol");
            Q.Enqueue("kek");
            var expected = "lol";
            var size = 2;
            //Act
            var actual = Q.Peek();

            //assert
            Assert.Equal(expected, actual);
            Assert.Equal(size, Q.Size());
        }
        [Fact]
        public void Removing_Element_From_Int_Queue()
        {
            //Arrange
            QueueSM<int> Q = new();
            Q.Enqueue(456);
            var expected = 456;
            int size = 0;

            //Act
            var actual = Q.Dequeue();

            //assert
            Assert.Equal(expected, actual);
            Assert.Equal(size, Q.Size());
        }
        [Fact]
        public void Removing_Element_From_String_Queue()
        {
            //Arrange
            QueueSM<string> Q = new();
            Q.Enqueue("Lol");
            Q.Enqueue("kek");
            Q.Enqueue("meme");
            var expected = "Lol";
            int size = 2;

            //Act
            var actual = Q.Dequeue();

            //assert
            Assert.Equal(expected, actual);
            Assert.Equal(size, Q.Size());
        }
    }
   
}