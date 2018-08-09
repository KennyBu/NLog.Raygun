NLog.Raygun
===========

A custom [NLog] target that will push exceptions to [Raygun].

[NLog]: http://nlog-project.org/
[Raygun]: http://raygun.io/

## Configuration

You need to configure NLog.config.

#### Settings

* ApiKey - Your API key.
* Tags - Tags you want to send in with every exception.
* IgnoreFormFieldNames - Form fields you wish to ignore, eg passwords and credit cards.
* IgnoreCookieNames - Cookies you wish to ignore, eg user tokens.
* IgnoreServerVariableNames - Server variables you wish to ignore, eg sessions.
* IgnoreHeaderNames - HTTP headers to ignore, eg API keys.
* IsRawDataIgnored - RawData from web requests is ignored. Default is ```false```.
* UserIdentityInfo - Explicitly defines lookup of user identity for Raygun events.
* UseExecutingAssemblyVersion - Attempt to get the executing assembly version, or root ASP.Net assembly version for Raygun events. Default is ```false```.
* ApplicationVersion - Explicitly defines an application version for Raygun events. This will be ignored if UseExecutingAssemblyVersion is set to true and returns a value.
    
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
    <!-- Set up the target (Avoid using async=true or AsyncWrapper) -->
	<target 
		name="RayGunTarget" 
		type="RayGun" 
		ApiKey="" 
		Tags="" 
		IgnoreFormFieldNames="" 
		IgnoreCookieNames="" 
		IgnoreServerVariableNames="" 
		IgnoreHeaderNames="" 
		UserIdentityInfo="" 
		UseExecutingAssemblyVersion="false" 
		ApplicationVersion="" 
		layout="${uppercase:${level}} ${message} ${exception:format=ToString,StackTrace}${newline}"
      />
  </targets>
  <rules>
    <!-- Set up the logger. -->
    <logger name="*" minlevel="Error" writeTo="RayGunTarget" />
  </rules>
</nlog>
```

## Tags

You can add tags per exception by putting a List<string> of tags into your Exception.Data array using the `Tags` key

```csharp
var e = new Exception("Test Exception");
e.Data["Tags"] = new List<string> { "Tester123" }; 
```
