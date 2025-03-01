using FluentValidation;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Ürün Id boş olamaz");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün ismi boş olamaz.")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter girebilirsiniz.")
                .MinimumLength(5).WithMessage("Minumum 5 karekter girmelisiniz.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Ürün açıklaması boş olamaz.")
                .MaximumLength(50).WithMessage("Maksimum 50 karakter girebilirsiniz.")
                .MinimumLength(5).WithMessage("Minumum 5 karekter girmelisiniz.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş olamaz").GreaterThan(0)
                    .WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.")
                    .ChildRules(x=>BeValidDouble(x.ToString())).WithMessage("Ürün fiyatı için geçerli bir değer olmalıdır.");


            RuleFor(x => x.Barcode).NotEmpty().WithMessage("Barkod boş olamaz.")
                .Matches(@"^\d{13}$")
                .WithMessage("Barkod harf içermemelidir ve 13 karakterli olmalıdır.");

            RuleFor(x => x.ProductNo).NotEmpty().WithMessage("Barkod boş olamaz.")
            .Matches(@"^\d{7}$").WithMessage("Ürün no harf içermemelidir ve 7 karakterli olmalıdır.");

            RuleFor(x => x.Stock).Must(x=>x==0||x>0).WithMessage("Geçerli bir stok giriniz.");
                
            RuleFor(x => x.IsActive).Must(x => x == true || x == false).WithMessage("Ürünün aktif durumu boş olamaz");
            RuleFor(x => x.IsDeleted).Must(x => x == true || x == false).WithMessage("Ürünün silme durumu boş olamaz");


        }

        private bool BeValidDouble(string price)
        {
            return double.TryParse(price, out _);
        }
    }
}
