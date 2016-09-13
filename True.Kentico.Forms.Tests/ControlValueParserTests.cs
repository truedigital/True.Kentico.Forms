using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using True.Kentico.Forms.Forms.Emailer;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Tests
{
    [TestClass]
    public class ControlValueParserTests
    {
        [TestMethod]
        public void FormValueEmailParser()
        {
            var controls = new List<IControl> {
                new Control { Name = "JobID", Label = "Job ID", SubmittedValue = "100" },
                new Control { Name= "JobReferenceID", Label = "Job Ref.", SubmittedValue = "ds09fj" }
            };

            var emailBody = "<html>\n<head>\n<title></title>\n</head>\n<body><p>$$label:nothing$$</p>\n<table>\n<tbody>\n<tr>\n<td>$$label:JobID$$</td>\n<td>$$value:JobID$$</td>\n</tr>\n<tr>\n<td>$$label:JobReferenceID$$</td>\n<td>$$value:JobReferenceID$$</td>\n</tr>\n</tbody>\n<table>\n</body>\n</html>";

            var parser = new FormValueEmailParser();
            var result = parser.Parse(emailBody, controls);

            Assert.IsTrue(result.Contains("Job ID"));
            Assert.IsTrue(result.Contains("ds09fj"));
        }
    }
}
