using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Models;

namespace Invoice_Generator.Adapters;

internal static class AddressFromAdapter
{
    internal static List<AddressFromModel> ToAddressFromModels(this List<AddressFrom> addresses)
    {
        return addresses.ConvertAll(address => address.ToAddressFromModel());
    }

    private static AddressFromModel ToAddressFromModel(this AddressFrom address)
    {
        return new AddressFromModel
        {
            Email = address.Email,
            Id = address.Id,
            Line1 = address.Line1,
            Line2 = address.Line2,
            Name = address.Name,
            Phone = address.Phone,
            PostCode = address.PostCode
        };
    }

    internal static AddressFrom ToAddressFrom(this AddressFromModel address)
    {
        return new AddressFrom
        {
            Email = address.Email,
            Id = address.Id,
            Line1 = address.Line1,
            Line2 = address.Line2,
            Name = address.Name,
            Phone = address.Phone,
            PostCode = address.PostCode
        };
    }
}