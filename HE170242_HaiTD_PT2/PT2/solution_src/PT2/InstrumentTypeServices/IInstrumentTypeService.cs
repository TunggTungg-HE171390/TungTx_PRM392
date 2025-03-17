
using PT2.DTO.InstrumentType;
using Slot3_CodeFirst.DTO;

namespace PT2.InstrumentTypeServices
{
    public interface IInstrumentTypeService
    {
        Task CreateInstrumentTypeAsync(CreateInstrumentTypeRequest request);

        Task<bool> DeleteInstrumentTypeAsync(int id);
        Task<PagedResponse<GetInstrumentTypeResponse>> GetAllInstrumentTypeAsync(UrlQueryParameters urlQueryParameters);
        Task<GetInstrumentTypeDetailResponse> GetDetailInstrumentTypeAsync(int id);
        Task<bool> UpdateInstrumentTypeAsync(int id, UpdateInstrumentTypeRequest instrumentTypeRequest);
    }
}
