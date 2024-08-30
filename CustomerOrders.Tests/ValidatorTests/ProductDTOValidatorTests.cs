using CustomerOrders.API.DTOs;
using CustomerOrders.Domain.Domain;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.Tests.ValidatorTests
{
    [TestFixture]
    public class ProductDTOValidatorTests
    {     
            private ProductDtoValidator _validator;

            [SetUp]
            public void SetUp()
            {
                _validator = new ProductDtoValidator();
            }

            [Test]
            public void ShouldHaveValidationErrorWhenNameIsNull()
            {
                var model = new CreateProductDTO { Name = null };
                var result = _validator.TestValidate(model);
                result.ShouldHaveValidationErrorFor(x => x.Name);
            }

            [Test]
            public void ShouldHaveValidationErrorWhenNameIsTooShort()
            {
                var model = new CreateProductDTO { Name = "A" };
                var result = _validator.TestValidate(model);
                result.ShouldHaveValidationErrorFor(x => x.Name);
            }

            [Test]
            public void ShouldNotHaveValidationErrorWhenNameIsValid()
            {
                var model = new CreateProductDTO { Name = "Valid Name" };
                var result = _validator.TestValidate(model);
                result.ShouldNotHaveValidationErrorFor(x => x.Name);
            }
        
    }
}
