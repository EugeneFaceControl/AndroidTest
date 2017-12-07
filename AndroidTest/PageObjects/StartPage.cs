using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace AndroidTest.PageObjects
{
    public class StartPage
    {
        private Func<AppQuery, AppQuery> nextButton = c => c.Id("nextView");

        private AndroidApp app;

        public StartPage(AndroidApp app)
        {
            this.app = app;
        }
        public HomePage GoToHomePage()
        {
            for (var i = 0; i < 5; i++)
                app.Tap(c => c.Id("nextView"));
            return new HomePage(app);
        }
    }
}
