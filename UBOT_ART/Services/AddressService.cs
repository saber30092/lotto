using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_ART.Common.Enums;
using UBOT_ART.Controllers.ViewModel;
using UBOT_ART.Repositories.Interfaces;
using UBOT_ART.Services.Interfaces;

namespace UBOT_ART.Services
{
    public class AddressService: IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<ResponseViewModel> GetListOfCity()
        {
            var allCity = await _addressRepository.GetAllCity();
            if (allCity == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnMessage = ReturnCodeEnum.NotFound.ToString() };
            return new ResponseViewModel() {RtnData = allCity };
        }

        public async Task<ResponseViewModel> GetDistrictsByCity(string cityID)
        {
            var districts = await _addressRepository.GetDistrictsByCity(cityID);
            if (districts == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnMessage = ReturnCodeEnum.NotFound.ToString() };
            return new ResponseViewModel() { RtnCode = ReturnCodeEnum.Ok, RtnData = districts };
        }

    }
}
