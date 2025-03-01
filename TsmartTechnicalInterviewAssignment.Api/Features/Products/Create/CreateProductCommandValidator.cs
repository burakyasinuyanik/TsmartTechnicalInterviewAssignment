using FluentValidation;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün ismi boş olamaz.")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter girebilirsiniz.")
                .MinimumLength(5).WithMessage("Minumum 5 karekter girmelisiniz.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Ürün açıklaması boş olamaz.")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter girebilirsiniz.")
                .MinimumLength(5).WithMessage("Minumum 5 karekter girmelisiniz.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş olamaz")
                .GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.");

            RuleFor(x => x.Barcode).NotEmpty().WithMessage("Barkod boş olamaz.")
                .Matches(@"^\d{13}$")
                .WithMessage("Barkod harf içermemelidir ve 13 karakterli olmalıdır.");

            RuleFor(x => x.ProductNo).NotEmpty().WithMessage("Barkod boş olamaz.")
            .Matches(@"^\d{7}$").WithMessage("Ürün no harf içermemelidir ve 7 karakterli olmalıdır.");

            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stok boş olamaz");
        }
    }
}
