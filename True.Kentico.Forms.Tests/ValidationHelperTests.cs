using System;
using System.IO;
using System.Net.Configuration;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using CMS.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using True.Kentico.Forms.Forms.ControlValidationFactory;

namespace True.Kentico.Forms.Tests
{
    [TestClass]
    public class ValidationHelperTests
    {
        [TestMethod]
        public void IsEmail()
        {
            Assert.IsTrue(ValidationHelper.IsEmail("blah@blah.com"));
        }

        [TestMethod]
        public void IsDateTime()
        {
            Assert.IsTrue(ValidationHelper.IsDateTime("12/12/2015"));
        }

        [TestMethod]
        public void IsUsaPhoneNumber()
        {
            Assert.IsTrue(ValidationHelper.IsUsPhoneNumber("555-555-5555"));
        }
    }
}
