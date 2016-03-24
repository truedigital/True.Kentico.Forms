using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using True.Kentico.Forms.Html.ExtraAttributes;

namespace True.Kentico.Forms.Web.Models
{
	public class TestModel
	{
		[Display(Name = "Text box")]
		[Required]
		[MinLength(3)]
		[HelpText("This is help text")]
		public string Textbox { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = "Email is invalid")]
		[HelpText("This is help text")]
		public string Email { get; set; }

		[Display(Name = "Email (equal to)")]
		[Required]
		[EmailAddress(ErrorMessage = "Email is invalid")]
		[Compare(nameof(Email))]
		[HelpText("This is help text")]
		public string EmailEqTo { get; set; }

		[Required]
		[HelpText("This is help text")]
		public string Calendar { get; set; }

		[Display(Name = "Text area")]
		[Required]
		[HelpText("This is help text")]
		public string TextArea { get; set; }

		[Display(Name = "Rich text editor")]
		[Required]
		[HelpText("This is help text")]
		public string RichTextEditor { get; set; }

		[Display(Name = "Drop-down list")]
		[HelpText("This is help text")]
		public List<KeyValuePair<int, string>> DropDownList { get; set; }

		[Display(Name = "List box")]
		[Required]
		[HelpText("This is help text")]
		public List<KeyValuePair<int, string>> ListBox { get; set; }

		[Display(Name = "Radio buttons")]
		[Required]
		[HelpText("This is help text")]
		public List<KeyValuePair<int, string>> RadioButtons { get; set; }

		[Display(Name = "Multiple choice")]
		[HelpText("This is help text")]
		public List<KeyValuePair<int, string>> MultipleChoices { get; set; }

		[Required]
		[HelpText("This is help text")]
		public bool Checkbox { get; set; }
	}
}
