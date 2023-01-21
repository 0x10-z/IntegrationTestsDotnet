// -------------------------------------------------------------------
// <copyright file="HealthcheckShould.cs" company="Bystronic Laser AG">
//     Copyright (c) Bystronic Laser AG. All rights reserved.
// </copyright>
// -------------------------------------------------------------------

using System.Net.Http;
using System.Threading.Tasks;
using ExampleProject.IntegrationTests.Factory;
using ExampleProject.IntegrationTests.MemberData;
using Xunit;
using Xunit.Categories;

namespace ExampleProject.IntegrationTests;

[Collection("IntegrationTests")]
public class WhoamiShould : BaseTestControllerShould
{
	public WhoamiShould(CustomWebApplicationFactory<Program> factory)
		: base(factory)
	{
	}

	[Theory]
	[IntegrationTest]
	[MemberData(nameof(WhoamiMemberData.PeopleData), MemberType = typeof(WhoamiMemberData))]
	public async Task WhoamiShouldReturnCorrect200(string expectedResult)
	{
		// Arrange
		using var request = new HttpRequestMessage(
			HttpMethod.Get,
			"/whoami");

		// Act
		var response = await Client.SendAsync(request).ConfigureAwait(false);

        // Assert
        var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        Assert.Equal(expectedResult, jsonString);
	}
}
