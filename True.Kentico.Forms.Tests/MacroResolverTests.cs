using System;
using CMS.MacroEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace True.Kentico.Forms.Tests
{
    [TestClass]
    public class MacroResolverTests
    {
        private readonly MacroResolver _resolver = MacroResolver.GetInstance();

        [TestMethod]
        public void TestMethod1()
        {
            var inputValue = "Mark";

            string macroRule1 = "{%Rule(\"(Value.Matches(\"^([0-9])+\"))\", \"<rules><r pos=\"0\" par=\"\" op=\"and\" n=\"RegExp\" ><p n=\"regexp\"><t>^([0-9])+</t><v>^([0-9])+</v><r>0</r><d></d><vt>text</vt><tv>0</tv></p></r></rules>\") | (user)administrator | (hash)80926522b00d9a1ed56d02f35f78cfa75eed4d18c4e6e250842f741aad9b5f01 %}";
            string macroRule2 = $"{{%Rule(\"({inputValue}.Matches(\"^([0-9])+\"))\", \"<rules><r pos=\"0\" par=\"\" op=\"and\" n=\"RegExp\" ><p n=\"regexp\"><t>^([0-9])+</t><v>^([0-9])+</v><r>0</r><d></d><vt>text</vt><tv>0</tv></p></r></rules>\") | (user)administrator | (hash)80926522b00d9a1ed56d02f35f78cfa75eed4d18c4e6e250842f741aad9b5f01 %}}";
            var result1 = _resolver.ResolveMacros(inputValue, new EvaluationContext(_resolver, macroRule1));
            var result2 = _resolver.ResolveMacros(macroRule2);//, new EvaluationContext(_resolver, macroRule1));
            
            Assert.Inconclusive();
        }

        [TestMethod]
        public void MyTestMethod()
        {
            var inputValue = "0213";
            string macroRule = string.Format("{{%Rule(\"({0}.Matches(\"^([0-9])+\"))\", \"<rules><r pos=\"0\" par=\"\" op=\"and\" n=\"RegExp\" ><p n=\"regexp\"><t>^([0-9])+</t><v>^([0-9])+</v><r>0</r><d></d><vt>text</vt><tv>0</tv></p></r></rules>\") | (user)administrator | (hash)80926522b00d9a1ed56d02f35f78cfa75eed4d18c4e6e250842f741aad9b5f01 %}}", inputValue);

            var result = _resolver.ResolveMacros(macroRule);

            Assert.Inconclusive();
        }

        [TestMethod]
        public void MyTestMethod2()
        {
            var inputValue = "0213";
            string macroRule = string.Format("Rule(\"({0}.Matches(\"^([0-9])+\"))\", \"<rules><r pos=\"0\" par=\"\" op=\"and\" n=\"RegExp\" ><p n=\"regexp\"><t>^([0-9])+</t><v>^([0-9])+</v><r>0</r><d></d><vt>text</vt><tv>0</tv></p></r></rules>\") | (user)administrator | (hash)80926522b00d9a1ed56d02f35f78cfa75eed4d18c4e6e250842f741aad9b5f01", inputValue);

            var result = _resolver.ResolveMacroExpression(macroRule);

            Assert.Inconclusive();
        }

        [TestMethod]
        public void MyTestMethod3()
        {
            var inputValue = "0213";
            string macroRule = string.Format("{{%Rule(\"({0}.Matches(\"^([0-9])+\"))\", \"<rules><r pos=\"0\" par=\"\" op=\"and\" n=\"RegExp\" ><p n=\"regexp\"><t>^([0-9])+</t><v>^([0-9])+</v><r>0</r><d></d><vt>text</vt><tv>0</tv></p></r></rules>\") | (user)administrator | (hash)80926522b00d9a1ed56d02f35f78cfa75eed4d18c4e6e250842f741aad9b5f01%}}", inputValue);

            var result = _resolver.ResolveMacros(macroRule, new MacroSettings());

            Assert.Inconclusive();
        }

        [TestMethod]
        public void CaseExample()
        {
            var inputValue = "Test";
            // string macroRule = string.Format("{{%Rule(\"({0}.Matches(\"^([0-9])+\"))\", \"<rules><r pos=\"0\" par=\"\" op=\"and\" n=\"RegExp\" ><p n=\"regexp\"><t>^([0-9])+</t><v>^([0-9])+</v><r>0</r><d></d><vt>text</vt><tv>0</tv></p></r></rules>\") | (user)administrator | (hash)80926522b00d9a1ed56d02f35f78cfa75eed4d18c4e6e250842f741aad9b5f01%}}", inputValue);

            // var result = _resolver.ResolveMacros($"{{% (Value.Matches(\"^([0-9])+\")), {inputValue}) %}}", new MacroSettings());

            var result = _resolver.ResolveMacroExpression($"{inputValue}.ToUpper()");

            Assert.Inconclusive();
        }
    }
}
