using BankLibraryDG;

namespace BankLibraryTestsDG
{
	// I determined the methods that needed testing were
	// Bank, Withdraw, and Deposit, as their complexities were over 1

	[TestClass]
	public class BankTests
	{
		[TestMethod] // Tests a successful bank account creation
		public void BankAccountIsSetPass()
		{
			string customer = "D G";
			double balance = 3500;
			Bank testbank = new Bank(customer, balance);
			Assert.AreEqual(customer, testbank.Customer);
			Assert.AreEqual(balance, testbank.Balance);
		}
		[TestMethod] // Tests a bank balance amount less than or equal to zero exception
		public void BankAccountAmountTooLittleError() 
		{
			string customer = "D G";
			double balance = -100;
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Bank(customer, balance));
		}
		[TestMethod] // Tests a bank balance higher than 10000 error
		public void BankAccountAmountTooHighError()
		{
			string customer = "D G";
			double balance = 15000;
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Bank(customer, balance));
		}



		[TestMethod] // Tests a successful withdrawal from the bank balance
		public void WithdrawSuccess()
		{
			Bank testbank = new Bank("D G", 1000);
			testbank.Withdraw(400);
			Assert.AreEqual(600, testbank.Balance);
		}
		[TestMethod] // Tests a successful withdrawal from the bank balance,
					 // but the withdrawal amount is set to 500,
					 // as the amount withdrawn was too high
		public void WithdrawAmountTooHighSuccess()
		{
			Bank testbank = new Bank("D G", 1000);
			testbank.Withdraw(600);
			Assert.AreEqual(500, testbank.Balance);
		}
		[TestMethod] // Tests exception when withdrawing 0 from bank balance
		public void WithdrawLessThanOrEqualToZeroError()
		{
			Bank testbank = new Bank("D G", 1000);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => testbank.Withdraw(0));
		}
		[TestMethod] // Tests exception when withdrawing more than the bank balance
		public void WithdrawAmountOverBalanceError()
		{
			Bank testbank = new Bank("D G", 300);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => testbank.Withdraw(350));
		}



		[TestMethod]
		public void DepositSuccess()
		{
			Bank testbank = new Bank("D G", 1000);
			testbank.Deposit(300);
			Assert.AreEqual(1300, testbank.Balance);
		}
		[TestMethod] // Tests exception when depositing <= 0
		public void DepositAmountTooLowError()
		{
			Bank testbank = new Bank("D G", 300);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => testbank.Deposit(-100));
		}
	}
}