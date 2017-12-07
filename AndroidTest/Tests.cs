using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace AndroidTest
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;
        TestSettings TestSettings => new TestSettings();

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the iOS app being tested is included in the solution then 
            // add a reference to the android project from the project containing this file
            app = ConfigureApp
                .Android
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                .ApkFile(TestSettings.ApkPath)
                .StartApp();
        }

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
//            app.Screenshot("First screen.");
            for (int i = 0; i < 5; i++)
            {
                app.Tap(c => c.Id("nextView"));
            }

            var firstElements = app.Query(c => c.Id("name")).Select(x => x.Text).ToList();
            app.ScrollDown();
            var secondElements = app.Query(c => c.Id("name")).Select(x => x.Text).ToList();


            foreach (var s in secondElements)
            {
                firstElements.Add(s);
            }

            var elements = firstElements.Distinct().ToArray();
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

            var expected = expectedElements.ToArray();

            for (int i = 0; i < elements.Count(); i++)
            {
                Console.WriteLine($"{elements[i]} = {expected[i]} : {elements[i] == expected[i]}");
            }

            Assert.AreEqual(9, elements.Count());
            Assert.IsTrue(expected.SequenceEqual(elements));
        }
    }
}