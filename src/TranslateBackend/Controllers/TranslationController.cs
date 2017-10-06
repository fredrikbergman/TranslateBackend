namespace TranslateBackend.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Microsoft.AspNetCore.Mvc;
    using TranslateBackend.Model;
    using HtmlAgilityPack;

    // For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
    [Route("api/[controller]")]
    public class TranslationController : Controller
    {
        private const string MatchPatternStart = "** ";
        private const string MatchPatternEnd = " **";

        private string htmlMarkupTemplate;
        private string stringsText;
        private XDocument xdoc;
        private HtmlDocument htmlDoc = new HtmlDocument();
        private string extractedName = string.Empty;

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "translation1", "translation2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Värde: " + id;
        }

        // POST api/values
        [HttpPost]
        public TestModel1 Post([FromBody] TestModel1 model)
        {
            try
            {
                this.FetchData();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception message: {e.Message}");
                throw e;
            }

            //foreach (var item in htmlMarkupTemplate)
            //{
            //    if (item.Length > 0 && item.Contains(MatchPatternStart))
            //    {
            //        // Regexp?
            //        var startIndex = item.IndexOf(MatchPatternStart) + MatchPatternStart.Length;
            //        var wordLength = item.IndexOf(MatchPatternEnd) - startIndex;
            //        var totLength = item.Length;
            //        extractedName = item.Substring(startIndex, wordLength);
            //    }

            //    if (extractedName.Length > 0)
            //    {
            //        var result = this.xdoc.Descendants()
            //            .FirstOrDefault(p => p.FirstAttribute.Value == extractedName);

            //        if (result is null)
            //        {

            //        }
            //        else
            //        {
            //            var resultText = result.Value.ToString();
            //            htmlMarkupTemplate.FirstOrDefault(p => p.Contains(item.ToString()))
            //                .Replace( MatchPatternStart + extractedName + MatchPatternEnd, resultText);
            //        }

            //        foreach (var line in htmlMarkupTemplate)
            //        {
            //            Debug.WriteLine(item);
            //            Debug.WriteLine(line);
            //        }
            //    }
            //}

            var isValid = this.ModelState.IsValid;
            TestModel1 testModel = new TestModel1
            {
                Type = model.Type + " backend@back",
                Language = model.Language + " backend@back",
                IsFallback = false,
                Html = "",
            };
            return testModel;
        }

        private void FetchData()
        {
            // HTMLMarkupTemplate from DS?
            htmlMarkupTemplate = System.IO.File.ReadAllText(@"C:\Users\Administrator\Downloads\html-newAccount.html");

            // Language strings from DS as XML
            stringsText = System.IO.File.ReadAllText(@"C:\Users\Administrator\Downloads\strings-newAccount.xml");

            xdoc = XDocument.Parse(stringsText);
            htmlDoc.LoadHtml(htmlMarkupTemplate);
            htmlDoc.Load(@"C:\Users\Administrator\Downloads\html-newAccount.html");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
