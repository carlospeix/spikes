using System;
using System.Collections.Generic;

namespace Tenis.Tests.Controllers
{
	public class TestSessionStore : ISessionStore
	{
		private Dictionary<string, object> values = new Dictionary<string, object>();

		public object this[string index]
		{
			get { return values[index]; }
			set { values[index] = value; }
		}
	}
}
