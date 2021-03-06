﻿using System.Collections.Generic;

namespace Nest
{
	public class NodesHotThreadsResponse : ResponseBase
	{
		public NodesHotThreadsResponse() { }

		internal NodesHotThreadsResponse(IReadOnlyCollection<HotThreadInformation> threadInfo) => HotThreads = threadInfo;

		public IReadOnlyCollection<HotThreadInformation> HotThreads { get; internal set; } = EmptyReadOnly<HotThreadInformation>.Collection;
	}

	public class HotThreadInformation
	{
		public IReadOnlyCollection<string> Hosts { get; internal set; } = EmptyReadOnly<string>.Collection;
		public string NodeId { get; internal set; }
		public string NodeName { get; internal set; }
		public IReadOnlyCollection<string> Threads { get; internal set; } = EmptyReadOnly<string>.Collection;
	}

}
