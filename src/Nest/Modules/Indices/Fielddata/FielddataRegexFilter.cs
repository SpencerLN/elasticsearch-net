﻿using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	[InterfaceDataContract]
	[ReadAs(typeof(FielddataRegexFilter))]
	public interface IFielddataRegexFilter
	{
		[DataMember(Name ="pattern")]
		string Pattern { get; set; }
	}

	public class FielddataRegexFilter : IFielddataRegexFilter
	{
		public string Pattern { get; set; }
	}

	public class FielddataRegexFilterDescriptor
		: DescriptorBase<FielddataRegexFilterDescriptor, IFielddataRegexFilter>, IFielddataRegexFilter
	{
		string IFielddataRegexFilter.Pattern { get; set; }

		public FielddataRegexFilterDescriptor Pattern(string pattern) => Assign(pattern, (a, v) => a.Pattern = v);
	}
}
