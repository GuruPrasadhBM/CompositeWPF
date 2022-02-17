namespace CompositeWPF.Services
{
    using CompositeWPF.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class GoogleSearch : ISearchEngine
    {
        /// <summary>
        /// Fetch Search results, filter based on url and return the position of occurance as array
        /// </summary>
        /// <param name="keywords">search keyword</param>
        /// <param name="searchUrl">url to be matched</param>
        /// <returns>url occurance index/position</returns>
        IEnumerable<int> ISearchEngine.FetchAndFilterSearchResults(string keywords, string searchUrl)
        {
            if (!string.IsNullOrEmpty(keywords) && !string.IsNullOrEmpty(searchUrl))
            {
                var searchResults = SearchAsync(keywords).GetAwaiter().GetResult().ToList();
                // var removeGoogleReferences = (from e in searchResults where !e.Contains("google") select e).ToList();
                var matchingInstances = (from e in searchResults where e.Contains(searchUrl) select searchResults.IndexOf(e)).ToList();

                return matchingInstances;
            }

            return null;
        }

        /// <summary>
        /// Fetch Search results
        /// </summary>
        /// <param name="keywords">search keyword</param>
        /// <returns>List of websites from search results as a list of strings</returns>
        IEnumerable<string> ISearchEngine.FetchSearchResults(string keywords)
        {
            if (!string.IsNullOrEmpty(keywords))
            {
                return SearchAsync(keywords).GetAwaiter().GetResult();
            }

            return null;
        }

        /// <summary>
        /// Fetch the results 
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        private async Task<IEnumerable<string>> SearchAsync(string keywords)
        {
            if (!string.IsNullOrEmpty(keywords))
            {
                try
                {
                    string url = QueryBuilder(keywords);
                    if (!string.IsNullOrEmpty(url))
                    {
                        using (HttpClient httpClient = HttpClientFactory.Create())
                        {
                            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

                            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var content = httpResponseMessage.Content;
                                var data = await content.ReadAsStringAsync();

                                return ParseSiteList(data);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ////The caught exception need to be handled and Logged.
                }
            }

            return null;
        }

        /// <summary>
        /// Query Builder- ##Can be improved
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns>query string</returns>
        private string QueryBuilder(string keywords)
        {
            var url = "https://www.google.com.au/search?num=100&q=" + keywords.Replace(" ", "+");
            return url;
        }

        /// <summary>
        /// Parse Search results
        /// </summary>
        /// <param name="data">input results as string</param>
        /// <returns>List of websites</returns>
        private IList<string> ParseSiteList(string data)
        {
            ////RegEx referred from https://stackoverflow.com/questions/6038061/regular-expression-to-find-urls-within-a-string
            IList<string> listOfSites = new List<string>();
            foreach (Match item in Regex.Matches(data, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"))
            {
                if (!listOfSites.Contains(item.Value))
                {
                    listOfSites.Add(item.Value);
                }
            }

            return listOfSites;
        }
    }
}
