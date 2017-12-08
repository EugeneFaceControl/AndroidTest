using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.Android;

namespace AndroidTest.PageObjects
{
    public class SearchPage
    {
        private AndroidApp app;

        public SearchPage(AndroidApp app)
        {
            this.app = app;
        }

        public SearchResultsPage Search(string searchQuery)
        {
            app.EnterText(c => c.Id("menu_search"), searchQuery);
            app.DismissKeyboard();
            return new SearchResultsPage(app);
        }
    }
}
