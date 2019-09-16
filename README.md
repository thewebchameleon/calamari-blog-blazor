[![Build Status](https://dev.azure.com/adrianbrink/Calamari%20Blog/_apis/build/status/thewebchameleon.calamari-blog-blazor?branchName=master)](https://dev.azure.com/adrianbrink/Calamari%20Blog/_build/latest?definitionId=23&branchName=master)
# Calamari Blog
A light-weight blogging client written in Blazor and ASP.NET Core that reads from a headless CMS system called Squidex.

- Focuses on Seperation of Concerns (SOC) and scalability
- Uses the HTML template [Clean Blog](https://github.com/BlackrockDigital/startbootstrap-clean-blog) by [startbootstrap.com](https://startbootstrap.com/)
- Serilog is used for logging events to [any location](https://github.com/serilog/serilog/wiki/Provided-Sinks) 
- Responses are gzipped and cached

API Caching
-------

The client will cache Squidex API calls via an ICacheProvider. Cached items are cleared via a Webhook configured in Squidex.

[Demo](https://calamari-blog-blazor.azurewebsites.net) 
----
