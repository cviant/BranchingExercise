namespace RefactoringExerciseTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RefactoringExercise;

    [TestClass]
    public class MyExpandableListTest
    {
        private MyExpandableList list;

        [TestInitialize]
        public void Initialize()
        {
            list = new MyExpandableList();
        }

        [TestMethod]
        public void NumberOfElementsInList_ShouldBeZero_Initially()
        {
            Assert.AreEqual(0, list.NumberOfElementsInList);
        }

        [TestMethod]
        public void Capacity_ShouldBeTen_Initially()
        {
            Assert.AreEqual(10, list.Capacity);
        }

        [TestMethod]
        public void NumberOfElementsInList_ShouldStillBeZero_AfterAddingAnObject_WhenReadOnlyIsTrue()
        {
            list.ReadOnly = true;
            list.Add("Fred");
            Assert.AreEqual(0, list.NumberOfElementsInList);
        }

        [TestMethod]
        public void NumberOfElementsInList_ShouldBeOne_AfterAddingOneObject()
        {
            list.Add("Fred");
            Assert.AreEqual(1, list.NumberOfElementsInList);
        }

        [TestMethod]
        public void Capacity_ShouldNotBeIncreased_AfterAddingOneObject()
        {
            list.Add("Fred");
            Assert.AreEqual(10, list.Capacity);
        }

        [TestMethod]
        public void Capacity_ShouldNotBeIncreased_WhenAtCapacity()
        {
            AddObjectsToList(list.Capacity);

            Assert.AreEqual(10, list.Capacity);
        }

        [TestMethod]
        public void Capacity_ShouldNotBeIncreased_WhenBelowCapacity()
        {
            AddObjectsToList(list.Capacity - 1);

            Assert.AreEqual(10, list.Capacity);
        }

        [TestMethod]
        public void Capacity_ShouldBeIncreasedToTwenty_WhenCapacityExceeded()
        {
            AddObjectsToList(list.Capacity + 1);

            Assert.AreEqual(20, list.Capacity);
        }

        [TestMethod]
        public void Capacity_ShouldBeIncreasedToThirty_WhenCapacityExceededTwice()
        {
            AddObjectsToList(list.Capacity * 2 + 1);

            Assert.AreEqual(30, list.Capacity);
        }

        private void AddObjectsToList(int numberOfObjectsToAdd)
        {
            for (int i = 0; i < numberOfObjectsToAdd; i++)
            {
                list.Add("Fred");
            }
        }
    }
}
