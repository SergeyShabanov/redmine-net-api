﻿using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System.Collections.Specialized;

namespace UnitTestRedmineNetApi
{
    [TestClass]
    public class NewsTests
    {
        private RedmineManager redmineManager;

        [TestInitialize]
        public void Initialize()
        {
            var uri = ConfigurationManager.AppSettings["uri"];
            var apiKey = ConfigurationManager.AppSettings["apiKey"];
            var mimeFormat = (ConfigurationManager.AppSettings["mimeFormat"].Equals("xml")) ? MimeFormat.xml : MimeFormat.json;
            redmineManager = new RedmineManager(uri, apiKey, mimeFormat);
        }


        [TestMethod]
        public void GetAllNews()
        {
            var result = redmineManager.GetObjectList<News>(null);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RedmineNews_ShouldGetSpecificProjectNews()
        {
            int projectId = 6;

            var news = redmineManager.GetObjectList<News>(new NameValueCollection { { "project_id", projectId.ToString() } });

            Assert.IsNotNull(news);
        }
    }
}
