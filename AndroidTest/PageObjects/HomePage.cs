using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace AndroidTest.PageObjects
{
    public class HomePage
    {
        private AndroidApp app;
        private string nextButton = "name";

        public HomePage(AndroidApp app)
        {
            this.app = app;
        }

        public string[] CountTopics()
        {
            var firstElements = app.Query(c => c.Id(nextButton)).Select(x => x.Text).ToList();
            app.ScrollDown();
            var secondElements = app.Query(c => c.Id(nextButton)).Select(x => x.Text).ToList();

            foreach (var s in secondElements)
                firstElements.Add(s);

            var elements = firstElements.Distinct().ToArray();
            return elements;
        }

        public SearchPage GoToSearchPage()
        {
            app.Tap(c => c.Id("menu_search"));
            return new SearchPage(app);
        }
    }
}
