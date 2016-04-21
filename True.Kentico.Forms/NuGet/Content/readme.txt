True.Kentico.Forms

A library that enables easy integration of Kentico BizForms into an MVC web application.

By True Digital

Installation

Run NuGet command: install-package True.Kentico.Forms

Introduction

The package is designed to work inside an MVC web application project (minimum MVC v4), so ensure you install it into the correct project type. The project is compatible with .NET 4.5 upwards.

The package provides you with a single library that provides: 
1. mapping of form fields from Kentico into a poco that implements IForm
2. html helpers to render the form fields, including
	a. validation as configured in the form in Kentico
	b. tool tips and help text as configured in Kentico; and
	c. note that custom renderers can be registered and used in place of the default ones
3. a repository to load the form from, and save the submitted data back to, Kentico
4. an assets folder, containing basic styles and jQuery validation plugin and logic

The package is dependent on several Kentico libraries, which are included in the package as well as jQuery and jQuery validate, which are also included in the package.

Getting Started

The parts your application will need are outlined below. First, you will need at least a controller and a view. The controller should have an action to render the form; this can use the FormRepository.GetForm method. An appropriate route or routing convention should be in place to ensure the controller action can be hit by the application. For the model you can either use the package's type Form, or make your own custom model that implements IForm.

Controller:

using System;
using System.Net;
using System.Web.Mvc;
using True.Kentico.Forms.Forms;
using True.Kentico.Forms.Forms.FormParts;

namespace $rootnamespace$.Web.Controllers
{
    public class KenticoFormController : Controller
    {
		public ActionResult Example()
		{
		    var form = new FormRepository().GetForm("myform");
		    return View("~/Views/KenticoForm/Index.cshtml", form);
		}
	}
}

View:

@using True.Kentico.Forms.Forms.FormParts
@using True.Kentico.Forms.Html.Extensions
@using True.Kentico.Forms.Infrastructure

@model IForm

@Html.KenticoForm().BeginForm("Save", "KenticoForm", Model.Name, Model.SubmissionOptions)

@Html.KenticoForm().RenderFormControls(Model.Controls)

@Html.KenticoForm().SubmitButton(Model.SubmitText)

@Html.KenticoForm().EndForm()

<div data-submit-message></div>

The controller is a standard MVC controller. This example constructs a new FormRepository and makes a call to retrieve the form details. GetForm uses Kentico's BizFormInfoProvider to retrieve the form data and maps it into an IForm. So, your application should be hooked up to Kentico and be targeting an existing Kentico form object. IForm exposes the necessary form fields (named 'Controls' in the interface), submission options, notification options and autoresponder options that are consistent with Kentico's form builder interface.

The Htmlhelper @Html.KenticoForm() provides html renderers that take data from the control and render the appropriate html. The example code uses the convenience method 'RenderFormControls', which iterates over all controls and renders each one complete with its own label. The helper also provides the individual renderers, for example, @Html.KenticoForm().TextBoxFor("FirstName"). To be clear, a 'control' is a custom class that represents a Kentico BizForm field. The html helper has overloads to allow you to render controls individually. 

@Html.KenticoForm().LabelFor(Model, "FirstName") // render a label for the 'FirstName' field
@Html.KenticoForm().TextBoxFor(Model, "FirstName") // render a text input for the 'FirstName' field

The html helpers also allow you to pass in a custom renderer, to cover cases where some fields may need different html attributes to the default ones.

@Html.KenticoForm().LabelFor(Model, "FirstName", new CustomLabelRenderer()) // html helper syntax

A custom renderer must implement IControlRenderer. An example of the CustomLabelRenderer used above is:

using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Html;
using True.Kentico.Forms.Html.Renderers;

namespace True.Kentico.Forms.Web.Renderers
{
	public class CustomLabelRenderer : IControlRenderer
	{
	    public string Render(IControl control)
	    {
	        if (string.IsNullOrWhiteSpace(control.Label))
	            return "";

	        var id = control.Name;
	        var required = control.IsRequired ? " form-label--required" : string.Empty;
	        var tb = new MultiLevelTag("label") { InnerHtml = $"{control.Label}" };
	        tb.Attributes.Add("for", id);
	        tb.Attributes.Add("class", $"form-label{required}");
	        return tb.ToString();
	    }
	}
}

In the case where you would prefer to use your own set of custom renderers, you can replace the default renderers with custom ones. This should sit in the Application_Start method inside Global.asax.cs.

using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using True.Kentico.Forms.Forms.FormParts;
using True.Kentico.Forms.Infrastructure;
using True.Kentico.Forms.Web.Renderers;

namespace True.Kentico.Forms.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
	    protected void Application_Start()
	    {
	        AreaRegistration.RegisterAllAreas();
	        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
	        RouteConfig.RegisterRoutes(RouteTable.Routes);
	        BundleConfig.RegisterBundles(BundleTable.Bundles);

			// this replaces the default label renderer with my custom one
	        ControlRendererRegistrar.RegisterCustomRenderer(ControlType.Label, new CustomLabelRenderer());
	    }
	}
}

The package offers client-side validation using jQuery validate. The scripts are in ~\Assets\js\partials\. _form-submit.js handles the form post ajax call and callback. _validation.js contains some additional logic to cover some messaging on fields in a more attractive way than jQuery validate does. It also registers the submit handler as _form-submit.js. If you want to write your own submit logic, change the submitHandler in _validation.js:

submitHandler: function(form) {
    $(form).find('[data-submit]').attr('disabled', true).addClass('is-disabled');
    // replace this line with a call to your own js
    formSubmit.submission(event, $(form));
}

In order to wire up the client validation, you'll need to include some scripts in your layout view. The basic set up is to load in jQuery in the head and the partials JavaScript at the bottom of the page. They need to be at the bottom because they are looking for particular elements on the page, so if those elements aren't loaded yet, then the script doesn't do anything. An example layout view is here:

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>@ViewBag.Title</title>
    <script src="@Url.Content("/Assets/js/vendor/jquery-1.11.2.js")"></script>
</head>
<body>
    <div>
        @RenderBody()
    </div>
    <script src="@Url.Content("/Assets/js/partials/_form-submit.js")"></script>
    <script src="@Url.Content("/Assets/js/partials/_validation.js")"></script>
</body>
</html>

The package comes with some basic styles. The originals were written in Sass and have been compiled to a css file here: ~\Assets\css\style.css. 

For the submit action, the package takes care of the model binding to map the HttpRequest back into an IForm type. However, server-side validation must be implemented by the application. In order to submit the form back to Kentico, use the FormRepository.Submit(IForm form) method. A basic example of what a submit action might look like is below:

[HttpPost]
public ActionResult Save(IForm form)
{
    try
    {
        _formRepository.Submit(form);
        return new HttpStatusCodeResult(HttpStatusCode.OK);
    }
    catch (InvalidOperationException ex)
    {
        return Json(ex.Message);
    }
    catch
    {
        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
    }
}