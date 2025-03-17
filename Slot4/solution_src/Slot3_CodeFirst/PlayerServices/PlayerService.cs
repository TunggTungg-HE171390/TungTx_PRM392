using AutoMapper;
using Slot3_CodeFirst.Db.Models;
using Slot3_CodeFirst.DTO;
using Slot3_CodeFirst.DTO.Player;

namespace Slot3_CodeFirst.PlayerServices
{
    public class PlayerService : IPlayerService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public PlayerService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePlayerAsync(CreatePlayerRequest playerRequest)
        {
            var player = _mapper.Map<Player>(playerRequest);
            player.JoinedDate = DateTime.Now;
            var playerAdded = await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();

            var playerInstruments = _mapper.Map<List<PlayerInstrument>>(playerRequest.PlayerInstruments);
            playerInstruments.ForEach(id => id.PlayerId = playerAdded.Entity.PlayerId);
            await _context.PlayerInstrumentTypes.AddRangeAsync(playerInstruments);
            await _context.SaveChangesAsync();
        }
        public Task<bool> DeletePlayerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<GetPlayerResponse>> GetAllPlayersAsync(UrlQueryParameters urlQueryParameters)
        {
            throw new NotImplementedException();
        }

        public Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest)
        {
            throw new NotImplementedException();
        }
    }
}
