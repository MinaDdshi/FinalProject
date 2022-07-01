using Newtonsoft.Json;
using QuestionAnswerBackend.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Common.Helpers;

public static class InternalResourceHelper
{
	#region [Method]
	public static string LoadAllResources() =>
		JsonConvert.SerializeObject(typeof(Messages)
				.GetProperties()
				.Select(x => new ResourceViewModel(x.Name, x.GetValue(new Messages())?.ToString()!)).ToList())
			.ToString();

	#endregion
}
