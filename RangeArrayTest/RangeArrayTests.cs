using NUnit.Framework;
using RangeIndexArray;

namespace RangeArrayTest
{
    public class Tests
    {
        RangeArray<int> array;
        [SetUp]
        public void Setup()
        {
            array = new RangeArray<int>(-2);
            for (int i = 1; i<6; i++)
            {
                array.Add(i);
            }
        }
        [Test]
        public void ToString_Array12345ToString_12345StringExpected()
        {
            //Arrange
            string expected = "1 2 3 4 5 ";
            //Act
            string result = array.ToString();
            //Assert
            Assert.AreEqual(expected, result);
            
        }
        [Test]
        public void Remove_Remove1FromArray12345_2345Expected()
        {
            //Arrange
            string expected = "2 3 4 5 ";
            //Act
            array.Remove(1);
            string result = array.ToString();
            //Assert
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void RemoveAt_RemoveFromIndexMinus1_1345Expected()
        {
            //Arrange
            string expected = "1 3 4 5 ";
            //Act
            array.RemoveAt(-1);
            string result = array.ToString();
            //Assert
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void Array12345StartsWithMinus2Index_NumberAtMinus1_2Expected()
        {
            //Arrange
            int expected = 2;
            //Act
            int result = array[-1];
            //Assert
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void Count_Array12345Count_5Expected()
        {
            //Arrange
            int expected = 5;
            //Act
            int result = array.Count;
            //Assert
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void Clear_Array12345Clear_IsEmpty()
        {
            //Arrange
            //Act
            array.Clear();
            //Assert
            Assert.IsEmpty(array);
        }
        [Test]
        public void Contains_Array12345Contains1_True()
        {
            //Arrange
            //Act
            //Assert
            Assert.IsTrue(array.Contains(1));
        }
        [Test]
        public void CopyTo_Array12345CopyToArraySize5_12345ArrayExpected()
        {
            //Arrange
            int[] expected = new int[] { 1, 2, 3, 4, 5 };
            int[] result = new int[5];
            //Act
            array.CopyTo(result, 0);
            //Assert
            Assert.AreEqual(result.ToString(), expected.ToString());
        }
        [Test]
        public void IndexOf_Array12345IndexOf1_Minus2Expected()
        {
            //Arrange
            int expected = -2;
            //Act
            int result = array.IndexOf(1);
            //Assert
            Assert.AreEqual(expected,result);
        }
        [Test]
        public void InsertAt_Array12345Insert9At0_129345Expected()
        {
            //Arrange
            string expected = "1 2 9 3 4 5 ";
            //Act
            array.Insert(0, 9);
            //Assert
            Assert.AreEqual(array.ToString(),expected);
        }
    }
}