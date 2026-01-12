using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Models;

namespace Invoice_Generator.Adapters;

internal static class AddressToAdapter
{
    internal static List<AddressToModel> ToAddressToModels(this List<AddressTo> addresses) 
        => addresses.ConvertAll(address => new AddressToModel()
        {
            ID = address.Id,
            Line1 = address.Line1,
            Line2 = address.Line2,
            Name = address.Name,
            PostCode = address.PostCode
        });

    internal static AddressTo ToAddressTo(this AddressToModel address) 
        => new AddressTo()
        {
            Id = address.ID,
            Line1 = address.Line1,
            Line2 = address.Line2,
            Name = address.Name,
            PostCode = address.PostCode
        };
}
