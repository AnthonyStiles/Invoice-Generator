using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Models;

namespace Invoice_Generator.Adapters;

internal static class AddressFromAdapter
{
    internal static List<AddressFromModel> ToAddressFromModels(this List<AddressFrom> addresses) 
        => addresses.ConvertAll(address => new AddressFromModel()
        {
            Email = address.Email,
            ID = address.Id,
            Line1 = address.Line1,
            Line2 = address.Line2,
            Name = address.Name,
            Phone = address.Phone,
            PostCode = address.PostCode
        });

    internal static AddressFrom ToAddressFrom(this AddressFromModel address) 
        => new AddressFrom()
        {
            Email = address.Email,
            Id = address.ID,
            Line1 = address.Line1,
            Line2 = address.Line2,
            Name = address.Name,
            Phone = address.Phone,
            PostCode = address.PostCode
        };
}
