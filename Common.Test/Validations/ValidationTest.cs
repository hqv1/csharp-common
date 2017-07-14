using FluentValidation;
using Hqv.CSharp.Common.Exceptions;
using Hqv.CSharp.Common.Validations;
using Xunit;

namespace Hqv.Csharp.Common.Test.Validations
{
    public class ValidationTest
    {
        private Widget _widget;

        [Fact]
        [Trait("Category", "Unit")]
        public void Should_Validate_WhenCalleeCreatesValidator()
        {
            GivenAValidWidget();
            Validator.Validate<Widget, WidgetValidator>(_widget);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Should_ThrowValidationError_WhenCalleeCreatesValidator()
        {
            GivenAinvalidWidget();

            var ex = Assert.Throws<HqvException>(() => Validator.Validate<Widget, WidgetValidator>(_widget));
        }
        
        [Fact]
        [Trait("Category", "Unit")]
        public void Should_Validate_WhenCallerCreatesValidator()
        {
            GivenAValidWidget();
            Validator.Validate(_widget, new WidgetValidator());
        }


        [Fact]
        [Trait("Category", "Unit")]
        public void Should_ThrowValidationError_WhenCallerCreatesValidator()
        {
            GivenAinvalidWidget();

            var ex = Assert.Throws<HqvException>(() => Validator.Validate(_widget, new WidgetValidator()));
        }

        private void GivenAValidWidget()
        {
            _widget = new Widget("Blue", 10);
        }

        private void GivenAinvalidWidget()
        {
            _widget = new Widget("Blue", 130);
        }
    }

    public class Widget
    {
        public Widget(string color, int width)
        {
            Color = color;
            Width = width;
        }
        public string Color { get; set; }
        public int Width { get; set; }
    }

    public class WidgetValidator : AbstractValidator<Widget>
    {
        public WidgetValidator()
        {
            RuleFor(x => x.Color).NotNull().NotEmpty();
            RuleFor(x => x.Width).GreaterThan(0).LessThanOrEqualTo(100);
        }
    }
}
