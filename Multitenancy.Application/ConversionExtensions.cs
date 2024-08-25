using Multitenancy.Application.Requests;
using Multitenancy.Database.Tenant;

namespace Multitenancy.Application;

public static class ConversionExtensions
{
    public static Data ToData(this AddDataRequest model) => new Data{Attribute = model.Attribute, Field = model.Field};
}