# True.Kentico.Forms

A library that enables easy integration of Kentico BizForms into an MVC web application.

## Installation

Run NuGet command: `install-package True.Kentico.Forms`

1. Clone the repo (or fork it)

        git clone https://github.com/truedigital/True.Kentico.Forms.git

2. Install:

        Include the assemblies to your Kentico v8.2 project and reference them where appropriate


## Introduction

The package is designed to work inside an MVC web application project (minimum MVC v4), so ensure you install it into the correct project type. The project is compatible with .NET 4.5 upwards.

The package provides you with a single library that provides:

 1. A class that represents the BizForm object
 2. Html helpers to render the form fields, including:
	a. Field validation as configured in the form in Kentico
	b. Tool tips and help text as configured in Kentico; and
	c. Extensible to replace default renderers with custom ones
 4. A repository to load the form from, and save the submitted data back to, Kentico
 5. A custom model binder to convert the request data into an IForm type
 6. An assets folder, containing basic styles and the necessary JavaScript files

The package is dependent on several Kentico libraries, which are included in the package. Also included are dependent JavaScript libraries: jQuery, jQuery validate and pikaday, a date picker plugin.

## Getting Started

First, you will need at least a controller and a view. The controller should have an action to render the form; this can use the FormRepository.GetForm method to retrieve the form from Kentico by form name. An appropriate route or routing convention should be in place to ensure the controller action can be hit by the application. For the model you can either use the package's type Form, or make your own custom model that implements IForm.

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
    		public ActionResult Index()
    		{
    		    var form = new FormRepository().GetForm("myform");
    		    return View(form);
    		}
    
    		// save action is shown later
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
    
    <label data-submit-message class="is-invalid"></label>

The controller is a standard MVC controller. This example constructs a new FormRepository and makes a call to retrieve the form details. GetForm uses Kentico's BizFormInfoProvider to retrieve the form data and maps it into a type that implements IForm. So, your application should be hooked up to Kentico and be targeting an existing Kentico form object. IForm exposes the necessary form fields (named 'Controls' in the interface), submission options, notification options and autoresponder options that are consistent with Kentico's form builder interface.

The Htmlhelper @Html.KenticoForm() provides html renderers that take data from the control and render the appropriate html. The example code above uses the convenience method 'RenderFormControls', which iterates over all controls and renders each one complete with its own label. Alternatively, there are overloads to allow rendering each control individually, by name:

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

In the case where you would prefer to use your own set of custom renderers, you can replace the default renderers with custom ones. This should sit in the `Application_Start` method inside `Global.asax.cs`.

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
    
    			// this replaces the default label renderer
    			ControlRendererRegistrar
    			.RegisterCustomRenderer(ControlType.Label, new CustomLabelRenderer());
    	    }
    	}
    }

The package offers client-side validation using jQuery validate. The scripts are in ~\Assets\js\partials\. _form-submit.js handles the form post ajax call and callback. _validation.js contains some additional logic to cover some messaging on fields in a more attractive way than jQuery validate does. It also registers the submit handler as _form-submit.js. If you want to write your own submit logic, change the submitHandler in _validation.js:

    submitHandler: function(form) {
        $(form).find('[data-submit]').attr('disabled', true).addClass('is-disabled');
        // replace this line with a call to your own js
        formSubmit.submission(event, $(form));
    }

In order to wire up the client validation, you'll need to include some scripts in your layout view. The basic set up is to load in jQuery in the head and the partials at the bottom of the page. They need to be at the bottom because they are looking for particular elements on the page, so if those elements aren't loaded yet, then the script doesn't do anything. An example layout view is shown below, which shows  the basic styles and JavaScript needed:

    <!DOCTYPE html>
    <html>
    <head>
        <meta name="viewport" content="width=device-width" />
        <title>@ViewBag.Title</title>
        <link href="@Url.Content("/Assets/css/pikaday.css")"/>
        <link href="@Url.Content("/Assets/css/style.css")"/>
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

The styles provided are very basic and likely will need to be altered to suit your application's style sheet.

IForm exposes an IsValid property that calls through to the form's control validators and performs server-side validation. Currently supported validations from Kentico are:

1. Date From
2. Date To
3. Email
4. Maximum Length
5. Minimum Length
6. Maximum Value
7. Minimum Value
8. Regular Expression

For the submit action, the package takes care of the model binding to map the HttpRequest back into an IForm type. In order to submit the form back to Kentico, use the repository's 'Submit' method. A basic example of what a submit action might look like is below. This is designed to work with the ajax callback in the provided JavaScript file _form-submit.js.

    [HttpPost]
    public ActionResult Save(IForm form)
    {
    	// this is a try-catch because the repository's submit method throws an exception if it cannot save the form back to Kentico
        try
        {
            if (model.IsValid)
            {
                new FormRepository().Submit(model);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            // model has validation errors, return an error code
            // this ensures it hits the $.ajax error callback
            HttpContext.Response.StatusCode = 400;
            HttpContext.Response.StatusDescription = "Server validation failed";
            return Json(model.ValidationErrors);
        }
        catch (Exception ex)
        {
            HttpContext.Response.StatusDescription = ex.Message;
            HttpContext.Response.StatusCode = 500;
            return Json(ex);
        }
    }

