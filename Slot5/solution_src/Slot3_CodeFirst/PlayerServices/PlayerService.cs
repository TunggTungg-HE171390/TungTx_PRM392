using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Slot3_CodeFirst.Db.Models;
using Slot3_CodeFirst.DTO;
using Slot3_CodeFirst.DTO.Player;
using Slot3_CodeFirst.DTO.PlayerInstrument;

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
        public async Task<bool> DeletePlayerAsync(int id)
        {
            try
            {
                _context.PlayerInstrumentTypes.RemoveRange(
                    _context.PlayerInstrumentTypes.Where(pi => pi.PlayerId == id));

                await _context.SaveChangesAsync();

                _context.Players.Remove(_context.Players.FirstOrDefault(p => p.PlayerId == id));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public async Task<PagedResponse<GetPlayerResponse>> GetAllPlayersAsync(UrlQueryParameters urlQueryParameters)
        {
            try
            {
                var players = _context.Players.Include(i => i.Instruments).AsQueryable();
                if (!string.IsNullOrEmpty(urlQueryParameters.Search))
                {
                    players = players.Where(s => s.NickName.Contains(urlQueryParameters.Search));
                }
                int totalItems = await players.CountAsync();

                List<GetPlayerResponse> data;
                int totalPages = 0;
                var page  = urlQueryParameters.Page;
                var pageSize = urlQueryParameters.PageSize;
                if (page == 0 && pageSize == 0) {
                    data = _mapper.Map<List<GetPlayerResponse>>
                        (await players.ToListAsync());
                }
                else
                {
                    var pageStart = page - 1;
                    totalPages = (int) Math.Ceiling(totalItems / (float)pageSize);
                    data = _mapper.Map<List<GetPlayerResponse>>
                        (await players
                        .Skip(pageStart * pageSize)
                        .Take(pageSize)
                        .ToListAsync());
                }

                var pagedResponse = new PagedResponse<GetPlayerResponse>(data, page, pageSize, totalPages, totalItems);
                return pagedResponse;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public async Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id)
        {
            try
            {
                var player = await _context.Players.Include
                    (i => i.Instruments).FirstOrDefaultAsync(e => e.PlayerId == id);
                var playerMapper = _mapper.Map<GetPlayerDetailResponse>(player);
                playerMapper.PlayerInstrument = _mapper.Map<List<GetPlayerInstrumentResponse>>
                    (player.Instruments);
                return playerMapper;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public async Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest)
        {
            try
            {
                var player = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == id);
                player.NickName = playerRequest.NickName;
                _context.Players.Update(player);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
    }
}
