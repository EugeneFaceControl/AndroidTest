using System;
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
                .ApkFile (TestSettings.ApkPath)
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
//            app.Screenshot("First screen.");
            app
                .Repl();
        }
    }
}