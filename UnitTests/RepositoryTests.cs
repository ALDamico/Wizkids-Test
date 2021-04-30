using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Wizkids_Test.Repositories;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class RepositoryTests
    {
        private string _currentPath = Directory.GetCurrentDirectory();
        [TestMethod]
        public void TestMatches()
        {
            var databasePath = _currentPath + "/Files/Dictionary.db";
            var connectionString = $"Data Source = {databasePath}; Version = 3;";
            var repository = new WordRepository(connectionString);
            var matches = repository.GetMatches("DONE");
            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count() > 0);
        }
    }
}
