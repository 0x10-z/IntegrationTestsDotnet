// -------------------------------------------------------------------
// <copyright file="BaseTestControllerShould.cs" company="Bystronic Laser AG">
//     Copyright (c) Bystronic Laser AG. All rights reserved.
// </copyright>
// -------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Threading.Tasks;
using ExampleProject.IntegrationTests.Factory;
using Newtonsoft.Json;
using Xunit;

namespace ExampleProject.IntegrationTests;

public class BaseTestControllerShould : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private const string BaseAddress = @"http://localhost:8888";
	private readonly CustomWebApplicationFactory<Program> factory;

    protected BaseTestControllerShould(CustomWebApplicationFactory<Program> factory)
    {
        this.factory = factory;

        Client = factory.CreateClient();
        Client.BaseAddress = new Uri(BaseAddress);
    }

    protected HttpClient Client { get; }

	public void Dispose()
	{
		Client.Dispose();
		factory.Dispose();
	}

    protected static async Task<T> ConvertResponseAsync<T>(HttpResponseMessage response)
    {
        var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return ConvertJson<T>(jsonString);
    }
    protected static T ConvertJson<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json)!;
    }
}
