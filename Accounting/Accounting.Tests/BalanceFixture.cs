using System;
using NUnit.Framework;

namespace Accounting.Tests
{
	[TestFixture()]
	public class BalanceFixture
	{
		[Test()]
		public void InitialBalanceShouldBeZero()
		{
			var accounting = new Accounting();
			Assert.That(accounting.GetAccountBalance("my-account"), Is.EqualTo(0));
		}

		[Test()]
		public void SimpleEntry()
		{
			var accounting = new Accounting();

			var entry = new Entry("debit-account", "credit-account", 100m);
			accounting.Register(entry);

			Assert.That(accounting.GetAccountBalance("debit-account"), Is.EqualTo(-100));
			Assert.That(accounting.GetAccountBalance("credit-account"), Is.EqualTo(100));
		}
	}
	
}

