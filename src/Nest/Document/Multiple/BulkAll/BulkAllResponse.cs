﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nest
{
	/// <inheritdoc />
	[DataContract]
	public class BulkAllResponse
	{
		// TODO: why is this here?
		/// <inheritdoc />
		public bool IsValid => true;

		/// <summary>This is the Nth buffer.</summary>
		public long Page { get; internal set; }

		/// <summary>The number of back off retries were needed to store this document.</summary>
		public int Retries { get; internal set; }

		/// <summary>The items returned from the bulk response</summary>
		public IReadOnlyCollection<BulkResponseItemBase> Items { get; internal set; } = EmptyReadOnly<BulkResponseItemBase>.Collection;
	}
}
