﻿using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	//TODO: Remove this interface


	/// <summary>
	/// An item within a bulk response
	/// </summary>
	[JsonFormatter(typeof(BulkResponseItemFormatter))]
	public abstract class BulkResponseItemBase
	{
		/// <summary>
		/// The error associated with the bulk operation
		/// </summary>
		[DataMember(Name = "error")]
		public BulkError Error { get; internal set; }

		/// <summary>
		/// The id of the document for the bulk operation
		/// </summary>
		[DataMember(Name = "_id")]
		public string Id { get; internal set; }

		/// <summary>
		/// The index against which the bulk operation ran
		/// </summary>
		[DataMember(Name = "_index")]
		public string Index { get; internal set; }

		/// <summary> The type of bulk operation </summary>
		public abstract string Operation { get; }

		[DataMember(Name = "_primary_term")]
		public long PrimaryTerm { get; internal set; }

		/// <summary> The result of the bulk operation</summary>
		[DataMember(Name = "result")]
		public string Result { get; internal set; }

		[DataMember(Name = "_seq_no")]
		public long SequenceNumber { get; internal set; }

		/// <summary>
		/// The shards associated with the bulk operation
		/// </summary>
		[DataMember(Name = "_shards")]
		public ShardStatistics Shards { get; internal set; }

		/// <summary> The status of the bulk operation </summary>
		[DataMember(Name = "status")]
		public int Status { get; internal set; }

		/// <summary>
		/// The type against which the bulk operation ran
		/// </summary>
		[DataMember(Name = "_type")]
		public string Type { get; internal set; }

		/// <summary> The version of the document </summary>
		[DataMember(Name = "_version")]
		public long Version { get; internal set; }

		/// <summary>
		/// Specifies whether this particular bulk operation succeeded or not
		/// </summary>
		public bool IsValid
		{
			get
			{
				if (Error != null || Type.IsNullOrEmpty()) return false;

				switch (Operation.ToLowerInvariant())
				{
					case "delete": return Status == 200 || Status == 404;
					case "update":
					case "index":
					case "create":
						return Status == 200 || Status == 201;
					default:
						return false;
				}
			}
		}
		public override string ToString() =>
			$"{Operation} returned {Status} _index: {Index} _type: {Type} _id: {Id} _version: {Version} error: {Error}";
	}

}
