using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Exercises
{
    [TestFixture]
    public class Exercises02
    {
        /**
         * TODO: rewrite these three tests into a single, parameterized test.
         * You decide if you want to use [TestCase] or [TestCaseSource], but
         * I would like to know why you chose the option you chose afterwards.
         */

        [TestCase(100, 50, 50, TestName = "Deposit 100, Withdraw 50")]
        [TestCase(1000, 1000, 0, TestName = "Deposit 1000, Withdraw 1000")]
        [TestCase(250, 1, 249, TestName = "Deposit 250, Withdraw 1")]

        public void CreateNewSavingsAccount_Deposit_Num_Withdraw_Num_CheckTotal
            (int dep,int wit,int expectedresult)
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(dep);
            account.Withdraw(wit);

            Assert.That(account.Balance, Is.EqualTo(expectedresult));
            //Assert
        }

        //private static IEnumerable<TestCaseData> CalcAdditionTest()
       // {
          // yield return new TestCaseData(50, 2, 4).SetName("")

          
        //}

        

                    //**************************************************//
        [Test]
        public void CreateNewSavingsAccount_Deposit100Withdraw50_BalanceShouldBe50()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(100);
            account.Withdraw(50);

            Assert.That(account.Balance, Is.EqualTo(50));
        }

        [Test]
        public void CreateNewSavingsAccount_Deposit1000Withdraw1000_BalanceShouldBe0()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(1000);
            account.Withdraw(1000);

            Assert.That(account.Balance, Is.EqualTo(0));
        }

        [Test]
        public void CreateNewSavingsAccount_Deposit250Withdraw1_BalanceShouldBe249()
        {
            var account = new Account(AccountType.Savings);

            account.Deposit(250);
            account.Withdraw(1);

            Assert.That(account.Balance, Is.EqualTo(249));
        }
    }
}
