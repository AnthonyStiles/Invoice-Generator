using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Models;

namespace Invoice_Generator.Adapters;

internal static class AddressToAdapter
{
    internal static List<AddressToModel> ToAddressToModels(this List<AddressTo> addresses)
    {
        return addresses.ConvertAll(address => address.ToAddressToModel());
    }

    private static AddressToModel ToAddressToModel(this AddressTo address)
    {
        return new AddressToModel
        {
            Id = address.Id,
            Line1 = address.Line1,
            Line2 = address.Line2,
            Name = address.Name,
            PostCode = address.PostCode
        };
    }

    internal static AddressTo ToAddressTo(this AddressToModel address)
    {
        return new AddressTo
        {
            Id = address.Id,
            Line1 = address.Line1,
            Line2 = address.Line2,
            Name = address.Name,
            PostCode = address.PostCode
        };
    }
}