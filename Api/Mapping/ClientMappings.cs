using Application.Models.Client;
using Contracts.Client.BirthdayClients;
using Contracts.Client.Categories;
using Contracts.Client.RecentPurchases;
using Mapster;

namespace Api.Mapping;

public class ClientMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ClientBithdayModel, BirthdayClientsResponseItem>()
            .Map(dest => dest.Fullname, src => src.FirstName + " " + src.SecondName + " " + src.LastName);

        config.NewConfig<ClientCategoriesModel, CategoriesResponseItem>();

        config.NewConfig<RecentPurchaseModel, RecentPurchasesResponseItem>()
            .Map(dest => dest.Fullname, src => src.FirstName + " " + src.SecondName + " " + src.LastName);
    }
}
