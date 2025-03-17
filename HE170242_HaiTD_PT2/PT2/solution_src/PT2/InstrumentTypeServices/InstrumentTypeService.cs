using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PT2.DTO.InstrumentType;
using Slot3_CodeFirst;
using Slot3_CodeFirst.Db.Models;
using Slot3_CodeFirst.DTO;
using Slot3_CodeFirst.DTO.Player;
using Slot3_CodeFirst.DTO.PlayerInstrument;
using System.Numerics;

namespace PT2.InstrumentTypeServices
{
    public class InstrumentTypeService : IInstrumentTypeService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public InstrumentTypeService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public InstrumentTypeService()
        {
        }

        public async Task CreateInstrumentTypeAsync(CreateInstrumentTypeRequest request)
        {
            var instrumentType = _mapper.Map<InstrumentType>(request);
            var instrumentTypeAdded = await _context.InstrumentTypes.AddAsync(instrumentType);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteInstrumentTypeAsync(int id)
        {
            try
            {
                _context.PlayerInstrumentTypes.RemoveRange(
                    _context.PlayerInstrumentTypes.Where(pi => pi.InstrumentTypeId == id));
                await _context.SaveChangesAsync();

                _context.InstrumentTypes.Remove(_context.InstrumentTypes.FirstOrDefault(p => p.InstrumentTypeId == id));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public async Task<PagedResponse<GetInstrumentTypeResponse>> GetAllInstrumentTypeAsync(UrlQueryParameters urlQueryParameters)
        {
            try
            {
                var instrumentType = _context.InstrumentTypes.AsQueryable();
                if (!string.IsNullOrEmpty(urlQueryParameters.Search))
                {
                    instrumentType = instrumentType.Where(s => s.Name.Contains(urlQueryParameters.Search));
                }
                int totalItems = await instrumentType.CountAsync();

                List<GetInstrumentTypeResponse> data;
                int totalPages = 0;
                var page = urlQueryParameters.Page;
                var pageSize = urlQueryParameters.PageSize;
                if (page == 0 && pageSize == 0)
                {
                    data = _mapper.Map<List<GetInstrumentTypeResponse>>
                        (await instrumentType.ToListAsync());
                }
                else
                {
                    var pageStart = page - 1;
                    totalPages = (int)Math.Ceiling(totalItems / (float)pageSize);
                    data = _mapper.Map<List<GetInstrumentTypeResponse>>
                        (await instrumentType
                        .Skip(pageStart * pageSize)
                        .Take(pageSize)
                        .ToListAsync());
                }

                var pagedResponse = new PagedResponse<GetInstrumentTypeResponse>(data, page, pageSize, totalPages, totalItems);
                return pagedResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GetInstrumentTypeDetailResponse> GetDetailInstrumentTypeAsync(int id)
        {
            try
            {
                var instrumentType = await _context.InstrumentTypes.FirstOrDefaultAsync(pi => pi.InstrumentTypeId == id);
                var playerInstrument = await _context.PlayerInstrumentTypes.Where(pi => pi.InstrumentTypeId == id).ToListAsync();
                instrumentType.Instruments = playerInstrument;
                var instrumentMapper = _mapper.Map<GetInstrumentTypeDetailResponse>(instrumentType);
                instrumentMapper.PlayerInstrument = _mapper.Map<List<GetPlayerInstrumentResponse>>
                    (instrumentType.Instruments);
                return instrumentMapper;

            }
            catch (Exception ex) {
                return null;
            }
        }

        public async Task<bool> UpdateInstrumentTypeAsync(int id, UpdateInstrumentTypeRequest instrumentTypeRequest)
        {
            try
            {
                var instrumentType = await _context.InstrumentTypes.FirstOrDefaultAsync(p => p.InstrumentTypeId == id);
                if (instrumentType == null) return false;
                instrumentType.Name = instrumentTypeRequest.Name;
                _context.InstrumentTypes.Update(instrumentType);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
