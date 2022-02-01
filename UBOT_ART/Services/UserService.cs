using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UBOT_ART.Common.Enums;
using UBOT_ART.Controllers.ViewModel;
using UBOT_ART.Repositories.Entities;
using UBOT_ART.Repositories.Interfaces;
using UBOT_ART.Services.DTO;
using UBOT_ART.Services.Interfaces;

namespace UBOT_ART.Services
{
    public class UserService: IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPaintingRepository _paintingRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserService(IMapper mapper, IUserRepository userRepository, IPaintingRepository paintingRepository, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _paintingRepository = paintingRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseViewModel> PostUser(PostUserViewModel postUserViewModel)
        {
            PostUserReq userReq = _mapper.Map<PostUserReq>(postUserViewModel);
            userReq.Step = (int)StepEnum.FirstPage;
            var response = await _userRepository.PostUser(userReq);
            if (response)
            {
                QueryUserReq queryUserReq = _mapper.Map<QueryUserReq>(postUserViewModel);
                var userInfo = _userRepository.QueryUserStepByIDNumberAndCellphone(queryUserReq);
                return new ResponseViewModel() { RtnMessage = "新增成功",RtnData=userInfo.Result.Uid };
            }
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "新增失敗" };
        }


        public async Task<ResponseViewModel> PostExperience(PostExperienceViewModel postExperienceViewModel)
        {
            PostExperienceReq experienceReq = _mapper.Map<PostExperienceReq>(postExperienceViewModel);
            experienceReq.Step = (int)StepEnum.SecondPage;
            var response = await _userRepository.PostExperience(experienceReq);
            if (response)
                return new ResponseViewModel() { RtnMessage = "新增成功" ,RtnData=postExperienceViewModel.Uid};
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "新增失敗" };
        }

        public async Task<ResponseViewModel> PostPainting(string uid,IEnumerable<PostPaintingViewModel> postPaintingViewModel)
        {
            var userInfo = _userRepository.GetUserByUid(uid);
            string name = userInfo.Result.CompetitionID;
            int saveCount = 0;
            int count = postPaintingViewModel.ToList().Count();
            foreach (var item in postPaintingViewModel)
            {
                string fileName = await UploadPhotos(item, name);
                item.FileName = fileName;
                saveCount += 1;
            }
            if (saveCount == count)
            {
                saveCount = 0;
                PostPaintingReq paintingReq = null;
                foreach (var item in postPaintingViewModel)
                {
                    paintingReq = _mapper.Map<PostPaintingReq>(item);
                    paintingReq.PaintingNum += 1;
                }
                //var response = await _paintingRepository.PostPaiting(paintingReq);
                //if (response)
                //    saveCount += 1;
                if (saveCount==count)
                    return new ResponseViewModel() { RtnMessage = "新增成功" };
                else
                    return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "新增失敗" };
            }
            else
            {                
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "新增失敗" };
            }
        }


        public async Task<ResponseViewModel> QueryUser(QueryUserViewModel queryUserViewModel)
        {
            QueryUserReq queryUserReq = _mapper.Map<QueryUserReq>(queryUserViewModel);
            var userInfo = await _userRepository.QueryUserStepByIDNumberAndCellphone(queryUserReq);
            if (userInfo == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnMessage = "查無資料"};
            return new ResponseViewModel() { RtnCode = ReturnCodeEnum.Ok, RtnMessage = "查詢成功", RtnData = userInfo };
        }

        public async Task<string> UploadPhotos(PostPaintingViewModel postPaintingViewModel,string name)
        {
            string fileName = "";
            if (postPaintingViewModel.ProfileFile != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, $"images\\{name}");
                if(!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                fileName = name + "_" + postPaintingViewModel.FileName;
                string filePath = Path.Combine(uploadFolder, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    File.Create(filePath);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await postPaintingViewModel.ProfileFile.CopyToAsync(fileStream);
                    
                }
            }
            return fileName;
        }
    }
}
