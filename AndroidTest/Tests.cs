using System;
using System.Linq;
using AndroidTest.PageObjects;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace AndroidTest
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the iOS app being tested is included in the solution then 
            // add a reference to the android project from the project containing this file
            app = ConfigureApp
                .Android
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                .ApkFile(@"..\..\Resources\test.apk")
                .StartApp();

            _homePage = StartPage.GoToHomePage();
        }

        private HomePage _homePage;

        private AndroidApp app;
        private StartPage StartPage => new StartPage(app);

        public void CompareTwoArrays<T>(T[] firstArray, T[] secondArray)
        {
            for (var i = 0; i < firstArray.Length; i++)
                Console.WriteLine($"{firstArray[i]} = {secondArray[i]} : {firstArray[i].Equals(secondArray[i])}");
        }

        [Test]
        public void TestSearch()
        {
            var count = _homePage.GoToSearchPage().Search("samsung").CountResults();
            var expectedCount = "16129";

            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void TestTopics()
        {
            string[] expected =
            {
                "Электроника",
                "Компьютеры и сети",
                "Бытовая техника",
                "Стройка и ремонт",
                "Дом и сад",
                "Авто и мото",
                "Красота и спорт",
                "Детям и мамам",
                "Работа и офис"
            };

            var topics = _homePage.CountTopics();


            Assert.AreEqual(9, topics.Length);
            Assert.IsTrue(expected.SequenceEqual(topics));
        }
    }
}