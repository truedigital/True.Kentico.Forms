using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using True.Kentico.Forms.Forms.FormParts;

namespace True.Kentico.Forms.Forms.Emailer
{
    public class FormValueEmailParser : IFormValueEmailParser
    {
        public string Parse(string input, IEnumerable<IControl> controls)
        {
            var inputParts = input.Split(new[] { '\r', '\n', '\t' });

            var pattern = new Regex(@"\$\$\w+:\w+\$\$", RegexOptions.IgnoreCase); // matches e.g. $$label:JobID$$
            var patternMatches = pattern.Matches(input);
            var controlNameMatches = new Dictionary<Match, string>();

            foreach (Match match in patternMatches)
            {
                var controlNamePattern = new Regex(@"(\w+:)(\w+)"); // matches e.g. label:JobID
                if (controlNamePattern.IsMatch(match.Value))
                {
                    var controlName = controlNamePattern.Match(match.Value).Groups[2].Value;
                    if (string.IsNullOrWhiteSpace(controlName)) continue;
                    var control = controls.FirstOrDefault(item => item.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase));
                    if (control == null) continue;
                    controlNameMatches.Add(match, match.Value.Contains("label") ? control.Label : control.SubmittedValue);
                }
            }

            var output = new StringBuilder(input);

            foreach (var item in controlNameMatches)
            {
                output.Replace(item.Key.Value, item.Value);
            }

            return output.ToString();
        }
    }
}
