using Calculator1;

namespace TestProject1
{
    public class Tests
    {
        [TestFixture]
        public class CalculatorTests
        {
           
            Calculator _calculator = new Calculator();
            

            [Test]
            public void Add_ShouldReturnCorrectResult_WhenGivenValidInputs()
            {
                double result = _calculator.Add(2, 3);
                Assert.That(result.Equals(5));
            }

            [Test]
            public void Subtract_ShouldReturnCorrectResult_WhenGivenValidInputs()
            {
                double result = _calculator.Subtract(5, 3);
                Assert.That(result.Equals(2));
            }

            [Test]
            public void Multiply_ShouldReturnCorrectResult_WhenGivenValidInputs()
            {
                double result = _calculator.Multiply(2, 3);
                Assert.That(result.Equals(6));
            }

            [Test]
            public void Divide_ShouldReturnCorrectResult_WhenGivenValidInputs()
            {
                double result = _calculator.Divide(6, 3);
                Assert.That(result.Equals(2));
            }

            [Test]
            public void Divide_ShouldThrowDivideByZeroException_WhenDividingByZero()
            {
                Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
            }

            
        }
    }
 
}
