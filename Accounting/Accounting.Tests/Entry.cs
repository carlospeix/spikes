using System;
using System.Collections.Generic;

namespace Accounting.Tests
{
	public class Entry
	{
		IDictionary<string, decimal> debitAccounts = new Dictionary<string, decimal>();
		IDictionary<string, decimal> creditAccounts = new Dictionary<string, decimal>();

		public Entry (string debitAccount, string creditAccount, decimal ammount)
		{
			if (creditAccount == null)
				throw new ArgumentNullException ("creditAccount");
			if (debitAccount == null)
				throw new ArgumentNullException ("debitAccount");

			debitAccounts.Add(debitAccount, ammount);
			creditAccounts.Add(creditAccount, ammount);
		}

		public IEnumerable<KeyValuePair<string, decimal>> DebitAccounts
		{
			get
			{
				foreach (var account in debitAccounts)
					yield return account;
			}
		}

		public IEnumerable<KeyValuePair<string, decimal>> CreditAccounts
		{
			get
			{
				foreach (var account in creditAccounts)
					yield return account;
			}
		}
	}
}