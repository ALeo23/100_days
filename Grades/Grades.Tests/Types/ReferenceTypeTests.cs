using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];
            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseAString()
        {
            string name = "alex";
            string upperCaseName = name.ToUpper();

            Assert.AreEqual("ALEX", upperCaseName);
        }
        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 01, 31);
            DateTime dayAfter = date.AddDays(1);

            Assert.AreEqual(01, dayAfter.Day);
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;

            IncrementNumberByOne(x);

            Assert.AreEqual(46, x);
        }

        [TestMethod]
        public void RefPassesValuesByReference()
        {
            int x = 46;
            // using ref like this is not generally something we would do irl
            // but good for understanding how this works
            IncrementNumberByOneByRef(ref x);

            Assert.AreEqual(47, x);
        }

        private void IncrementNumberByOne(int number)
        {
            number += 1;
        }

        private void IncrementNumberByOneByRef(ref int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("A Gradebook", book1.Name);
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A Gradebook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "alex";
            string name2 = "Alex";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;

            Assert.AreNotEqual(x1, x2);

        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            book1.Name = "Scott's Grade Book";
            Assert.AreEqual(book1.Name, book2.Name);
        }
    }
}
