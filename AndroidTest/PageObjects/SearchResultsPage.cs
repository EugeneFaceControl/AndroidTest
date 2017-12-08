using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace AndroidTest.PageObjects
{
    public class SearchResultsPage
    {
        private readonly Func<AppQuery, AppQuery> _resultCount = c => c.Id("text");
        private readonly AndroidApp app;

        public SearchResultsPage(AndroidApp app)
        {
            this.app = app;
        }

        public string CountResults()
        {
            app.WaitForElement(_resultCount);
            var countOfResults = app.Query(_resultCount).Select(x => x.Text).First();
            var result = Regex.Match(countOfResults, @"\D+ (\d+) \D+");
            var count = result.Groups.Cast<Group>().Select(x => x.Value).Skip(1).First();
            return count;
        }
    }
}