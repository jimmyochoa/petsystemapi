using backend.Dtos;

namespace backend.Interfaces
{
    public interface ICityService
    {
        Task<List<CityDto>> GetCity(int? cityId, string? cityName, string? provinceName);
        Task<Boolean> AddCity(CityDto cityDto);
        Task<Boolean> UpdateCity(CityDto cityDto);
        Task<Boolean> DeleteCity(int cityId);
        Task<List<ProvinceDto>> GetProvince(int? ProvinceId, string? ProvinceName);

        Task<Boolean> AddProvince(ProvinceDto provinceDto);
        Task<Boolean> UpdateProvince(ProvinceDto provinceDto);
        Task<Boolean> DeleteProvince(int ProvinceId);
    }
}
