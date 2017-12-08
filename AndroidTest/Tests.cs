using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AndroidTest.PageObjects;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace AndroidTest
{
    [TestFixture]
    public class Tests
    {
        private HomePage _homePage;

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

        private AndroidApp app;
        private StartPage StartPage => new StartPage(app);

        public void Steps()
        {
            //x5
            app.Tap(c => c.Id("nextView"));
            app
                .Repl()
                ;
        }

        [Test]
        public void AppLaunches()
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

            for (var i = 0; i < topics.Length; i++)
                Console.WriteLine($"{topics[i]} = {expected[i]} : {topics[i] == expected[i]}");

            Assert.AreEqual(9, topics.Length);
            Assert.IsTrue(expected.SequenceEqual(topics));
        }

        [Test]
        public void TestSearch()
        {
            string count = _homePage.GoToSearchPage().Search("samsung").CountResults();
            string expectedCount = "16129";

            Assert.AreEqual(expectedCount, count);
        }
    }
}