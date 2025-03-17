using Slot3_CodeFirst.DTO;
using Slot3_CodeFirst.DTO.Player;

namespace Slot3_CodeFirst.PlayerServices
{
    public interface IPlayerService
    {
        Task CreatePlayerAsync(CreatePlayerRequest request);

        Task<bool> DeletePlayerAsync(int id);
        Task<PagedResponse<GetPlayerResponse>> GetAllPlayersAsync(UrlQueryParameters urlQueryParameters);
        Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id);
        Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest);

    }
}
