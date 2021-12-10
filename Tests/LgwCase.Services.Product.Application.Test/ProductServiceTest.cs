using LgwCase.Services.Product.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LgwCase.Services.Product.Application.Test
{
    public class ProductServiceTest
    {
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
        [Fact]
        public void SearchProductByKey_Test()
        {
            #region Arrange
            //Kaynaklar hazırlanıyor.
            ProductService service = new ProductService(Configuration);

            #endregion
            #region Act
            //İlgili metot Arrange'de ki kaynaklarla test ediliyor.
            var result = service.SearchProductByKey("key");
            #endregion
            #region Assert
            //Test neticesinde gelen data doğrulanıyor.
            Assert.Equal(expected, result);
            #endregion
        }
    }
}
