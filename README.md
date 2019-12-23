# CoreMailer

Send email from .NET Core 2.0 with razor template Check the exmple code for details :) happy coding

How to Use:

**To Install**

    npm install CoreMailer -Version 1.0.0

**In Startup.cs add**

    services.AddScoped<ITemplateRenderer, TemplateRenderer>();
    services.AddScoped<ICoreMvcMailer, CoreMvcMailer>();

Create cshtml template under any views folder e.g.

    Views/Emails/Registration.cshtml

**The content of cshtml can be**

    @model UserInfo
    Hello <strong>@Model.UserName</strong> you are <strong>Awxam</strong>

**NOTE: For emails you have to use inline styling.**

in the controller use following:

**Constructor**

    private readonly ICoreMvcMailer _mailer;
    public HomeController(ICoreMvcMailer mailer)
    {
      _mailer = mailer;
    }

**ActionMethod**

    public IActionResult About()
        {
            MailerModel mdl = new MailerModel("YourHostName",1234)
            {
                FromAddress = "Your Address",
                IsHtml = true,
                User = "YourUserName",
                Key ="YourKey",
                ViewFile = "Emails/Register",
                Subject = "Registration",
                Model = new // Your actual class model
                {
                }
            };
            
            _mailer.Send(mdl);
            return View();
        

**UPDATE 2019-12-23**

Added support to use local folder instead of using paid or free mail servers.

Added supporte to use SSL to send mails.

Method Mailer.SendAsync renamed - missing "c" at end of it.

**HOW TO USE ?**

It is really simple to use. Just create MVCMailer model with **pickup directory location**. When you send the email make sure you set sender and reciver email. Once done, you can see email in your provided pickup directory.

            MailerModel mdl = new MailerModel(**"Your Directory Here"**)
            {
                FromAddress = "Your Address",
                IsHtml = true,
                User = "YourUserName",
                Key ="YourKey",
                ViewFile = "Emails/Register",
                Subject = "Registration",
                Model = new // Your actual class model
                {
                }
            };
            mdl.ToAddresses.Add("test@test.com");
            _mailer.Send(mdl);
