using System;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace AndroidTest.PageObjects
{
    public class StartPage
    {
        private readonly AndroidApp app;
        private readonly Func<AppQuery, AppQuery> nextButton = c => c.Id("nextView");

        public StartPage(AndroidApp app)
        {
            this.app = app;
        }

        public HomePage GoToHomePage()
        {
            for (var i = 0; i < 5; i++)
                app.Tap(nextButton);
            return new HomePage(app);
        }
    }
}