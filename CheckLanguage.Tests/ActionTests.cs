using System;
using System.Collections.Generic;
using System.Text;
using CheckLanguage.Controllers;
using Xunit;

namespace CheckLanguage.Tests
{
    public class ActionTests
    {
        [Fact]
        public void TextToCheckToLower()
        {
            // Preparation
            string TextToLower = "My Example Text";
            string RealTextAfterToLower = "my example text";

            // Action
            string TextAfterToLower = TextToLower.ToLower();

            // Asserts
            Assert.Equal(RealTextAfterToLower, TextAfterToLower);

        }
    }
}
