﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	[InterfaceDataContract]
	[ReadAs(typeof(Suggest<>))]
	public interface ISuggest<out T> where T : class
	{
		[DataMember(Name = "length")]
		int Length { get; }

		[DataMember(Name = "offset")]
		int Offset { get; }

		[DataMember(Name = "options")]
		IReadOnlyCollection<ISuggestOption<T>> Options { get; }

		[DataMember(Name = "text")]
		string Text { get; }

	}
	public class Suggest<T> : ISuggest<T>
		where T : class
	{
		public int Length { get; internal set; }

		public int Offset { get; internal set; }

		public IReadOnlyCollection<ISuggestOption<T>> Options { get; internal set; } = EmptyReadOnly<ISuggestOption<T>>.Collection;

		public string Text { get; internal set; }
	}
}
