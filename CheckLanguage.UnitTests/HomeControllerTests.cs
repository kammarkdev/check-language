using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using CheckLanguage.Controllers;
using CheckLanguage.Models;

namespace HomeControllerTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_HttpGet_ReturnsView ()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index();

            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void Index_TextLength_CheckLength()
        {
            HomeController controller = new HomeController();

            TextToCheck textToCheck = new TextToCheck();

            textToCheck.Text = "Na bezrybiu i rak ryba";
            textToCheck.TextLength = textToCheck.Text.Length;

            Assert.AreEqual(22, textToCheck.TextLength);
        }

        [Test]
        public void Index_TextToLower_IsLower()
        {
            HomeController controller = new HomeController();

            TextToCheck textToCheck = new TextToCheck();

            textToCheck.Text = "Na bezrybiu i rak ryba";
            textToCheck.Text = textToCheck.Text.ToLower();

            Assert.AreEqual("na bezrybiu i rak ryba", textToCheck.Text);
        }
    }
}