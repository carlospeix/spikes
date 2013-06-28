using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tecnicas_tdd.Controllers
{
	public interface IClock
	{
		DateTime Now { get; }
	}

	public class FakeClock : IClock
	{
		DateTime time;

		public FakeClock(DateTime time)
		{
			this.time = time;
		}

		public DateTime Now
		{
			get { return time; }
		}
	}
}
