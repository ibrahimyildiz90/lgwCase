using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Tests
{
    public class ProdutcServiceTest
    {
        [Fact]
        public void SearchProductByKey_Test()
        {

            #region Arrange       
            ProductService service = new ProductService();
            
            int number1 = 10;
            int number2 = 20;
            int expected = -10;
            Mathematics mathematics = new Mathematics();
            #endregion

            #region Act           
            int result = mathematics.Subtract(number1, number2);
            #endregion

            #region Assert            
            Assert.Equal(expected, result);
            #endregion
        }
    }
}
