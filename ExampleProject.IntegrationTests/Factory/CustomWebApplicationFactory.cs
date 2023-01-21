// -------------------------------------------------------------------
// <copyright file="CustomWebApplicationFactory.cs" company="Bystronic Laser AG">
//     Copyright (c) Bystronic Laser AG. All rights reserved.
// </copyright>
// -------------------------------------------------------------------

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ExampleProject.IntegrationTests.Factory;

public class CustomWebApplicationFactory<TProgram>
	: WebApplicationFactory<TProgram>
	where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // ... Configure test services
            // var descriptor = new ServiceDescriptor(typeof(IEventPublisher), typeof(InMemoryCommandPublisher), ServiceLifetime.Transient);
            // services.Replace(descriptor);
        });
    }
}
