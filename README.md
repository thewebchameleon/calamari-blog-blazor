## *this project has been archived and is no longer in development ##
![VSTS](https://adrianbrink.visualstudio.com/_apis/public/build/definitions/d997519b-4e10-4936-b403-69ea97908441/10/badge)
# Calamari Blog
A light-weight blogging client written in Blazor and ASP.NET Core that reads from a headless CMS system called Squidex.

- Focuses on Seperation of Concerns (SOC) and scalability
- Uses the UI framework [Blazorise](https://blazorise.com/) for rapid development
- Serilog is used for logging events to [any location](https://github.com/serilog/serilog/wiki/Provided-Sinks) 
- Responses are gzipped and cached

API Caching
-------

The client will cache Squidex API calls via an ICacheProvider. Cached items are cleared via a Webhook configured in Squidex.

[Demo](https://calamari-blog-blazor.azurewebsites.net) 
----
