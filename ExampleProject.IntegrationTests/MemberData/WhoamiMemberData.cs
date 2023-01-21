// -------------------------------------------------------------------
// <copyright file="WhoamiMemberData.cs" company="Bystronic Laser AG">
//     Copyright (c) Bystronic Laser AG. All rights reserved.
// </copyright>
// -------------------------------------------------------------------

using System.Collections.Generic;

namespace ExampleProject.IntegrationTests.MemberData;

internal static class WhoamiMemberData
{
	private static readonly List<string> People = new()
	{
		"Iker Ocio"
	};

	public static IEnumerable<object[]> PeopleData
	{
		get
		{
			var result = new List<object[]>();
			foreach (var response in People)
			{
				result.Add(new object[] { response });
			}

			return result;
		}
	}
}
