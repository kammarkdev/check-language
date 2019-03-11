using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using CheckLanguage.Controllers;
using CheckLanguage.Models;

namespace HomeControllerTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController controller = null;
        private TextToCheck textToCheck = null;
        [SetUp]
        public void Setup()
        {
            controller = new HomeController();
            textToCheck = new TextToCheck();
        }
        [Test]
        public void Index_HttpGet_ReturnsView ()
        {
            ViewResult result = controller.Index();

            Assert.AreEqual("Index", result.ViewName);
        }

        [TestCase("Na bezrybiu i rak ryba")]
        public void Index_TextLength_CheckLength(string TestText)
        {
            textToCheck.Text = TestText;
            textToCheck.TextLength = textToCheck.Text.Length;

            Assert.AreEqual(22, textToCheck.TextLength);
        }

        [TestCase("Na bezrybiu i rak ryba")]
        public void Index_TextToLower_IsLower(string TestText)
        {
            HomeController controller = new HomeController();

            TextToCheck textToCheck = new TextToCheck();

            textToCheck.Text = TestText;
            textToCheck.Text = textToCheck.Text.ToLower();

            Assert.AreEqual("na bezrybiu i rak ryba", textToCheck.Text);
        }
    }
}