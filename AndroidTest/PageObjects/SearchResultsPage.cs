using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace AndroidTest.PageObjects
{
    public class SearchResultsPage
    {
        private AndroidApp app;
        private Func<AppQuery, AppQuery> _resultCount = c => c.Id("text");

        public SearchResultsPage(AndroidApp app)
        {
            this.app = app;
        }

        public string CountResults()
        {
            app.WaitForElement(_resultCount);
            string countOfResults = app.Query(_resultCount).Select(x => x.Text).First();
            var result = Regex.Match(countOfResults, @"\D+ (\d+) \D+");
            string count = result.Groups.Cast<Group>().Select(x => x.Value).Skip(1).First();
            return count;
        }
    }
}
