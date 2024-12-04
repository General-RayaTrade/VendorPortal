using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core.IServices;
using VendorPortal.Core.Models;
using VendorPortal.EF.IRepositories;

namespace VendorPortal.Service.Services
{
    public class CitiesDistrictsService : ICitiesDistrictsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CitiesDistrictsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<VWcityDistrict>> GetCityDistrictsAsync()
        {
            var result = await _unitOfWork.vwcityDistrict.GetAllAsync();
            return result.Distinct().ToList();
        }
    }
}
