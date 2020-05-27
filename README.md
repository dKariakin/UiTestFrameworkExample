# framework-.net-example

Here is just a simple example of test automation framework for web UI testing.
What do we use here?
-
1. .NET Core 
2. Specflow
3. Selenium

What projects do we have here?
-
Drivers
-
This is a project with basic logic for web drivers:
1. Configuration - simple configuration for timeouts customization and driver parameters (most important here is list of arguments)
2. Configuration manager - configuration consumer
3. Driver builder - builder pattern realization for Chrome, Opera and FireFox web drivers

Extensions
-
The most interesting project in whole solution. There are:
1. PagesFactory - factory pattern realization for created page objects in our tests. You can create a Page (using page object pattern) and add to this factory with custom name. Why? You can call pages later just typing names in your SpecFlow scenarios.
2. PageManager - simple manager that manages page transitions (throughout page name). You need to specify all transitions in page constructor and when you call Click method it might lead to changing page name if that transition has been specified earlier.
3. PagePrototype - page prototype (apparently) with essential virtual methods like Click()/SendText()/SetUrl()/OpenUrl() and logic based on those methods and Page Manager.

If you want to use this framework for your own automation, having Drivers and Extensions projects would be enough to start your test framework implementation.

Pages
-
Example how we can create pages based on logic described above.

Scenarios
-
Example how we can create SpecFlow scenarios and configuration for the whole solution.

Steps
-
Example how we can define steps for SpecFlow scenarios.
