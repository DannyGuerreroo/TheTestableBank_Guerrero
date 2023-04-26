namespace BankLibraryDG
{
	public class Bank
	{
		private readonly string _customer;
		private double _balance;

		private Bank() { }

		public Bank(string customer, double balance)
		{
			if (balance > 10000 || balance <= 0)
				throw new ArgumentOutOfRangeException("amount");
			_customer = customer;
			_balance = balance;
		}

		public string Customer
		{
			get { return _customer; }
		}

		public double Balance
		{
			get { return _balance; }
		}

		public double Withdraw(double amount)
		{
			if (amount > 500)
				amount = 500;

			if (amount <= 0)
			{
				throw new ArgumentOutOfRangeException("amount");
			}

			if (amount > _balance)
			{
				throw new ArgumentOutOfRangeException("amount");
			}

			// Commented out this if statement to reach 100% coverage,
			// as it is made redundant by the (amount <= 0) if statement

			//if (amount < 0)
			//{
			//	throw new ArgumentOutOfRangeException("amount");
			//}

			_balance -= amount; // Changed '+=' to '-=' in order to correctly withdraw from the balance
			return _balance;
		}

		public double Deposit(double amount)
		{
			if (amount <= 0)
			{
				throw new ArgumentOutOfRangeException("amount");
			}
			_balance += amount;
			return _balance;
		}
	}
}