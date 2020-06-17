using NUnit.Framework;
using System.Collections;

namespace Loans.Tests
{
    public class MonthlyRepaymentTestDataWithReturn
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(200_000m, 6.5m, 30).Returns(1264.14);
                yield return new TestCaseData(500_000m, 10m, 30).Returns(4387.86);
            }
        }
    }
}
