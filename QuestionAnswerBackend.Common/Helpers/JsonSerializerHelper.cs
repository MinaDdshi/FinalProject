using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Common.Helpers;

public class JsonSerializerHelper
{
	public static JsonSerializerOptions DefaultSerializerOptions => new()
	{
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
	};

	public static JsonSerializerOptions DefaultDeserializerOptions => new()
	{
		PropertyNameCaseInsensitive = true
	};
}