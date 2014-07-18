NLog.Raygun
===========

A custom [NLog] target that will push errors to [Raygun].

[NLog]: http://nlog-project.org/
[Raygun]: http://raygun.io/

## Configuration

You need to configure NLog.

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
		<target name="RayGunTarget" type="RayGun" ApiKey="" Tags="" IgnoreFormFieldNames="" IgnoreCookieNames=""
				IgnoreServerVariableNames="" IgnoreHeaderNames=""
				layout="${uppercase:${level}} ${message} ${exception:format=ToString,StackTrace}${newline}"/>
	</target>
  </targets>
  <rules>
    <!-- Set up the logger. -->
    <logger name="*" minlevel="Info" writeTo="RayGunTarget" />
  </rules>
</nlog>
```
