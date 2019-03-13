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

        [TestCase(null)]
        public void Index_TextToCheck_EmptyText(string TestText)
        {
            textToCheck.Text = TestText;
            ViewResult result = controller.Index(textToCheck, null, null);
            string ExpectedView = "Error";
            string ExpectedStatement = "Nale¿y podaæ tekst do przet³umaczenia!";

            Assert.AreEqual(ExpectedView, result.ViewName);
            Assert.AreEqual(ExpectedStatement, result.Model);
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
            textToCheck.Text = TestText;
            textToCheck.Text = textToCheck.Text.ToLower();

            Assert.AreEqual("na bezrybiu i rak ryba", textToCheck.Text);
        }

        [TestCase("Na bezrybiu i rak ryba")]
        public void Index_MakeFrequency_IsMaked(string TestText)
        {
            textToCheck.Text = TestText;
            textToCheck = textToCheck.MakeFrequency(textToCheck);

            double[] CorrectFrequency = new double[] { 3, 3, 0, 0, 1, 0, 0, 0, 2, 0, 1, 0, 0, 0, 0, 0, 0, 3, 0, 0, 1, 0, 0, 0, 2, 1, 5 };

            Assert.AreEqual(CorrectFrequency, textToCheck.Frequency);
        }


    }
}