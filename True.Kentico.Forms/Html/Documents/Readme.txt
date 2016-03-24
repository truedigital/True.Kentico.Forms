20160302 - Nathan Pearce

Here is a test model class that uses the new html5 helper. Under this is some markup for a razor view to render them:

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


======================================================================================================================

* Take note that you need BeginForm and EndForm. This is because they render markup directly and do not hook into the viewstate as the standard Html helkper does.
* This could be an addition at a leter stage.
*
* Also check the arguments for the BeginForm if you require extra options on rendering the form tag
*

@using True.Html5Helper.Extensions
@using True.Html5Helper

@model TrueMVCForms.Models.TestModel
@{
	ViewBag.Title = "Index";
	var Html5 = new Html5<TrueMVCForms.Models.TestModel>(Model);
}

@Html5.BeginForm()
<div class="form-row">
	@Html5.LabelFor(m => m.Textbox)
	@Html5.TextBoxFor(m => m.Textbox)
</div>
<div class="form-row">
	@Html5.LabelFor(m => m.Email)
	@Html5.EmailFor(m => m.Email)
</div>
<div class="form-row">
	@Html5.LabelFor(m => m.EmailEqTo)
	@Html5.EmailFor(m => m.EmailEqTo)
</div>
<div class="form-row">
	@Html5.LabelFor(m => m.Calendar)
	@Html5.CalendarFor(m => m.Calendar)
</div>
<div class="form-row">
	@Html5.LabelFor(m => m.TextArea)
	@Html5.TextAreaFor(m => m.TextArea)
</div>
<div class="form-row">
	@Html5.LabelFor(m => m.RichTextEditor)
	@Html5.RichTextEditorFor(m => m.RichTextEditor)
</div>
<div class="form-row">
	@Html5.LabelFor(m => m.DropDownList)
	@Html5.DropDownListFor(m => m.DropDownList)
</div>
<div class="form-row">
	@Html5.LabelFor(m => m.ListBox)
	@Html5.ListBoxFor(m => m.ListBox)
</div>
<div class="form-row">
	@Html5.LabelFor(m => m.RadioButtons)
	@Html5.RadioButtonFor(m => m.RadioButtons)
</div>
<div class="form-row">
	@Html5.LabelFor(m => m.MultipleChoices)
	@Html5.MultipleChoiceFor(m => m.MultipleChoices)
</div>
<div class="form-row">
	@Html5.LabelFor(m => m.Checkbox)
	@Html5.CheckboxFor(m => m.Checkbox)
</div>
<div>
	@Html5.SubmitButton("Submit")
</div>
@Html5.EndForm()

======================================================================================================================

* Following is a controller method that creates the test model and populates the lists within it.

public ActionResult Test()
{
	var model = new TestModel {
		DropDownList = new List<KeyValuePair<int, string>> {
			new KeyValuePair<int, string>(1, "Select dd option 1"),
			new KeyValuePair<int, string>(1, "Select dd option 2"),
			new KeyValuePair<int, string>(1, "Select dd option 3")
		},
		ListBox = new List<KeyValuePair<int, string>> {
			new KeyValuePair<int, string>(1, "Select lb option 1"),
			new KeyValuePair<int, string>(1, "Select lb option 2"),
			new KeyValuePair<int, string>(1, "Select lb option 3")
		},
		RadioButtons = new List<KeyValuePair<int, string>> {
			new KeyValuePair<int, string>(1, "Select rb option 1"),
			new KeyValuePair<int, string>(1, "Select rb option 2"),
			new KeyValuePair<int, string>(1, "Select rb option 3")
		},
		MultipleChoices = new List<KeyValuePair<int, string>> {
			new KeyValuePair<int, string>(1, "Select mc option 1"),
			new KeyValuePair<int, string>(1, "Select mc option 2"),
			new KeyValuePair<int, string>(1, "Select mc option 3")
		}
	};
	return View(model);
}

