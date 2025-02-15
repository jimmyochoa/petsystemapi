using Azure;
using backend.Dtos;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace backend.Services
{
    public class CityService : ICityService
    {
        private readonly PetSystemContext _petSystemContext;

        public CityService(PetSystemContext petSystemContext)
        {
            _petSystemContext = petSystemContext;
        }

        public async Task<List<CityDto>> GetCity(int? cityId, string? cityName, string? provinceName)
        {
            IQueryable<CityDto> query = from c in _petSystemContext.Cities
                                        join p in _petSystemContext.Provinces on c.ProvinceId equals p.ProvinceId
                                        where c.IsActive == true
                                        select new CityDto
                                        {
                                            CityId = c.CityId,
                                            CityName = c.CityName,
                                            Description = c.Description,
                                            CreatedAt = c.CreatedAt,
                                            ModifiedAt = c.ModifiedAt,
                                            IsActive = c.IsActive,
                                            ProvinceId = p.ProvinceId,
                                            ProvinceName = p.ProvinceName
                                        };

            if (cityId.HasValue)
            {
                query = query.Where(c => c.CityId == cityId.Value);
            }

            if (!string.IsNullOrEmpty(cityName))
            {
                query = query.Where(c => c.CityName.Contains(cityName));
            }

            if (!string.IsNullOrEmpty(provinceName))
            {
                query = query.Where(c => c.ProvinceName.Contains(provinceName));
            }

            return await query.ToListAsync();
        }

        public async Task<bool> AddCity(CityDto cityDto)
        {
            if (string.IsNullOrEmpty(cityDto.CityName))
                return false;

            var newCity = new City
            {
                CityName = cityDto.CityName,
                Description = cityDto.Description,
                ProvinceId = cityDto.ProvinceId ?? 0, // Default to 0 if null
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            };

            _petSystemContext.Cities.Add(newCity);
            await _petSystemContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCity(int cityId)
        {
            var city = await _petSystemContext.Cities.FindAsync(cityId);
            if (city == null)
                return false;

            city.IsActive = false;
            city.ModifiedAt = DateTime.Now;

            await _petSystemContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCity(CityDto cityDto)
        {
            var city = await _petSystemContext.Cities.FindAsync(cityDto.CityId);
            if (city == null)
                return false;

            city.CityName = cityDto.CityName;
            city.Description = cityDto.Description;
            city.ProvinceId = cityDto.ProvinceId ?? city.ProvinceId;
            city.ModifiedAt = DateTime.Now;

            await _petSystemContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProvinceDto>> GetProvince(int? provinceId, string? provinceName)
        {
            IQueryable<ProvinceDto> query = from p in _petSystemContext.Provinces
                                            where p.IsActive == true
                                            select new ProvinceDto
                                            {
                                                ProvinceId = p.ProvinceId,
                                                ProvinceName = p.ProvinceName,
                                                Description = p.Description,
                                                CreatedAt = p.CreatedAt,
                                                ModifiedAt = p.ModifiedAt
                                            };

            if (provinceId.HasValue)
            {
                query = query.Where(p => p.ProvinceId == provinceId.Value);
            }

            if (!string.IsNullOrEmpty(provinceName))
            {
                query = query.Where(p => p.ProvinceName.Contains(provinceName));
            }

            return await query.ToListAsync();
        }

        public async Task<bool> AddProvince(ProvinceDto provinceDto)
        {
            if (string.IsNullOrEmpty(provinceDto.ProvinceName))
                return false;

            var newProvince = new Province
            {
                ProvinceName = provinceDto.ProvinceName,
                Description = provinceDto.Description,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                IsActive = true
            };

            _petSystemContext.Provinces.Add(newProvince);
            await _petSystemContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateProvince(ProvinceDto provinceDto)
        {
            var province = await _petSystemContext.Provinces.FindAsync(provinceDto.ProvinceId);
            if (province == null)
                return false;

            province.ProvinceName = provinceDto.ProvinceName;
            province.Description = provinceDto.Description;
            province.ModifiedAt = DateTime.Now;

            await _petSystemContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProvince(int provinceId)
        {
            var province = await _petSystemContext.Provinces.FindAsync(provinceId);
            if (province == null)
                return false;

            province.IsActive = false;
            province.ModifiedAt = DateTime.Now;

            await _petSystemContext.SaveChangesAsync();
            return true;
        }
    }
}
