﻿using Croppilot.Core.Features.Carts.Command.Models;

namespace Croppilot.Core.Features.Carts.Command.Validators;

public class AddProductToCartCommandValidator
    : AbstractValidator<AddProductToCartCommand>
{
    private readonly IProductServices _productServices;

    public AddProductToCartCommandValidator(IProductServices productServices)
    {
        _productServices = productServices;
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.");

        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId must be greater than 0.")
            .MustAsync(ProductExists)
            .WithMessage("Product does not exist.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0.");
    }

    private async Task<bool> ProductExists(int productId, CancellationToken cancellationToken)
    {
        return await _productServices.GetByIdAsync(productId, cancellationToken: cancellationToken) != null;
    }
}