using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Accounting.Tests
{
	public class Accounting
	{
		IDictionary<string, decimal> accounts = new Dictionary<string, decimal>();

		public void Register (Entry entry)
		{
			foreach (var acc in entry.DebitAccounts)
			{
				if (!accounts.Keys.Contains(acc.Key))
				    accounts.Add(acc.Key, 0m);
				accounts[acc.Key] -= acc.Value;
			}
			foreach (var acc in entry.CreditAccounts)
			{
				if (!accounts.Keys.Contains(acc.Key))
				    accounts.Add(acc.Key, 0m);
				accounts[acc.Key] += acc.Value;
			}
		}

		public decimal GetAccountBalance(string accountId)
		{
			if (accounts.Keys.Contains(accountId))
			    return accounts[accountId];
			return 0m;
		}
	}
}
