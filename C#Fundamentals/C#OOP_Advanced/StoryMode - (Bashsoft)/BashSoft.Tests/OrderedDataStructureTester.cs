namespace BashSoft.Tests
{
    using Contracts;
    using DataStructures;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class OrderedDataStructureTester
    {
        private const int DefaultCapacity = 16;
        private const int DefaultSize = 0;

        private ISimpleOrderedBag<string> names;

        [TestInitialize]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        // Constructor
        [TestMethod]
        public void TestCtorEmpty()
        {
            // Act
            this.names = new SimpleSortedList<string>();

            // Arrange
            Assert.AreEqual(DefaultCapacity, this.names.Capacity); // reversed expected/actual in Lab
            Assert.AreEqual(DefaultSize, this.names.Size);
        }

        [TestMethod]
        public void TestCtorWithInitialCapacity()
        {
            // Arrange
            var initialCapacity = 20;

            // Act
            this.names = new SimpleSortedList<string>(initialCapacity);

            // Assert
            Assert.AreEqual(initialCapacity, this.names.Capacity);
            Assert.AreEqual(DefaultSize, this.names.Size);
        }

        [TestMethod]
        public void TestCtorWithInitialComparer()
        {
            // Arrange
            var initialComparer = StringComparer.OrdinalIgnoreCase;

            // Act
            this.names = new SimpleSortedList<string>(initialComparer);

            // Assert
            Assert.AreEqual(DefaultCapacity, this.names.Capacity);
            Assert.AreEqual(DefaultSize, this.names.Size);
        }

        [TestMethod]
        public void TestCtorWithAllParams()
        {
            // Arrange
            var initialCapacity = 30;
            var initialComparer = StringComparer.OrdinalIgnoreCase;

            // Act
            this.names = new SimpleSortedList<string>(initialComparer, initialCapacity);

            // Assert
            Assert.AreEqual(initialCapacity, this.names.Capacity);
            Assert.AreEqual(DefaultSize, this.names.Size);
        }

        // Add
        [TestMethod]
        public void TestAddIncreasesSize()
        {
            // Act
            this.names.Add("Nasko");

            // Assert
            Assert.AreEqual(1, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullThrowsException()
        {
            // Act
            this.names.Add(null);
        }

        [TestMethod]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            // Act
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            // Assert
            Assert.AreEqual("Balkan,Georgi,Rosen", string.Join(",", this.names));
        }

        [TestMethod]
        public void TestAddingMoreThanInitialCapacity()
        {
            // Arrange
            var testedSize = 17;

            // Act
            for (int i = 0; i < testedSize; i++)
            {
                this.names.Add("SoftUni");
            }

            // Assert
            Assert.AreEqual(testedSize, this.names.Size);
            Assert.AreNotEqual(DefaultCapacity, this.names.Capacity);
        }

        [TestMethod]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            // Arrange
            var list = new List<string>();
            list.Add("Soft");
            list.Add("Uni");
            var listSize = list.Count;

            // Act
            this.names.AddAll(list);

            // Assert
            Assert.AreEqual(listSize, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingAllFromNullThrowsException()
        {
            // Act
            this.names.AddAll(null);
        }

        [TestMethod]
        public void TestAddAllKeepsSorted()
        {
            // Arrange
            var list = new List<string>();
            list.Add("Uni");
            list.Add("Soft");
            list.Add("JS");
            list.Add("C#");
            var listSize = list.Count;

            // Act
            this.names.AddAll(list);

            // Assert
            Assert.AreEqual("C#,JS,Soft,Uni", string.Join(",", this.names));
        }

        // Remove
        [TestMethod]
        public void TestRemoveValidElementDecreasesSize()
        {
            var elements = new[] { "Rosen", "Georgi", "Balkan" };
            var sut = new SimpleSortedList<string>();
            sut.AddAll(elements);

            sut.Remove("Rosen");

            Assert.AreEqual(2, sut.Size);
        }

        [TestMethod]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            // Arrange
            this.names.Add("Ivan");
            this.names.Add("Nasko");

            // Act
            this.names.Remove("Ivan");

            // Assert
            Assert.AreEqual(null,
                            this.names.FirstOrDefault(e => e == "Ivan"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemovingNullThrowsException()
        {
            // Act
            this.names.Remove(null);
        }

        // JoinWith
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJoinWithNull()
        {
            // Arrange
            this.names.Add("Soft");
            this.names.Add("Uni");
            this.names.Add("JS");
            this.names.Add("C#");

            // Act
            this.names.JoinWith(null);
        }

        [TestMethod]
        public void TestJoinWorksFine()
        {
            // Arrange
            this.names.Add("Soft");
            this.names.Add("Uni");
            this.names.Add("JS");
            this.names.Add("C#");

            // Assert
            Assert.AreEqual("C#, JS, Soft, Uni", this.names.JoinWith(", "));
        }
    }
}
