NLog.Raygun
===========

A custom [NLog] target that will push exceptions to [Raygun].

[NLog]: http://nlog-project.org/
[Raygun]: http://raygun.io/

## Configuration

You need to configure NLog.config.

#### Settings

* ApiKey - your API key
* Tags - tags you want to send in with every exception
* IgnoreFormFieldNames - form fields you wish to ignore, eg passwords and credit cards
* IgnoreCookieNames - cookies you wish to ignore, eg user tokens
* IgnoreServerVariableNames - Server vars you wish to ignore, eg sessions
* IgnoreHeaderNames - HTTP header to ignore, eg API keys
* UseIdentityNameAsUserId - If you're using a web project, send user name from HttpContext.Current.User.Identity.Name? Used for User Tracking

### NLog Configuration

Your `NLog.config` should look something like this:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

  <extensions>
    <!-- Add the assembly -->
    <add assembly="NLog.Raygun"/>
  </extensions>
  <targets>
    <!-- Set up the target -->
    <target name="asyncRaygun" xsi:type="AsyncWrapper">
		  <target 
        name="RayGunTarget" 
        type="RayGun" 
        ApiKey="" 
        Tags="" 
        IgnoreFormFieldNames="" 
        IgnoreCookieNames=""
				IgnoreServerVariableNames="" 
        IgnoreHeaderNames=""
        UseIdentityNameAsUserId="true"
				layout="${uppercase:${level}} ${message} ${exception:format=ToString,StackTrace}${newline}"
      />
	 </target>
  </targets>
  <rules>
    <!-- Set up the logger. -->
    <logger name="*" minlevel="Error" writeTo="RayGunTarget" />
  </rules>
</nlog>
```
