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
            string[] expectedElements =
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


            var firstElements = app.Query(c => c.Id("name")).Select(x => x.Text).ToList();
            app.ScrollDown();
            var secondElements = app.Query(c => c.Id("name")).Select(x => x.Text).ToList();

            foreach (var s in secondElements)
                firstElements.Add(s);

            var elements = firstElements.Distinct().ToArray();

            var expected = expectedElements.ToArray();

            for (var i = 0; i < elements.Length; i++)
                Console.WriteLine($"{elements[i]} = {expected[i]} : {elements[i] == expected[i]}");

            Assert.AreEqual(9, elements.Length);
            Assert.IsTrue(expected.SequenceEqual(elements));

            app.ScrollUp();
            app
                .Repl()
                ;
        }

        private string _searchMenu = "menu_search";
        private string _expectedCount = "16129";
        private Func<AppQuery, AppQuery> _resultCount = c => c.Id("text");

        [Test]
        public void TestSearch()
        {
            app.Tap(c => c.Id(_searchMenu));
            app.EnterText(c => c.Id(_searchMenu), "samsung");
            app.DismissKeyboard();

            app.WaitForElement(_resultCount);
            string countOfResults = app.Query(_resultCount).Select(x => x.Text).First();
            var result = Regex.Match(countOfResults, @"\D+ (\d+) \D+");
            string count = result.Groups.Cast<Group>().Select(x => x.Value).Skip(1).First();

            Assert.AreEqual(_expectedCount, count);
        }
    }
}