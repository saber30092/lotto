using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UBOT_ART.Common.Enums;
using UBOT_ART.Controllers.ViewModel;
using UBOT_ART.Models;
using UBOT_ART.Repositories.Entities;
using UBOT_ART.Repositories.Interfaces;
using UBOT_ART.Services.Interfaces;

namespace UBOT_ART.Controllers
{
    public class ArtRouteController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAddressService _addressService;
        private readonly IGameItemRepository _gameItemRepository;

        private readonly IHostingEnvironment _env;
        public ArtRouteController(IUserService userService, IAddressService addressService, IGameItemRepository gameItemRepository, IHostingEnvironment environment)
        {
            _userService = userService;
            _addressService = addressService;
            _gameItemRepository = gameItemRepository;
            _env = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewPersonIntroData()
        {
            return View();
        }

        public IActionResult IntroData()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] PostUserViewModel postUserViewModel)
        {
            var result = await _userService.PostUser(postUserViewModel);
            return Ok(result);
        }
        public IActionResult AcademicExperience(int uid)
        {
            ViewBag.uid = uid;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AcademicExperience([FromBody] PostExperienceViewModel postExperienceViewModel)
        {
            var result = await _userService.PostExperience(postExperienceViewModel);
            return Ok(result);
        }

        public IActionResult Entries(int uid)
        {
            ViewBag.uid = uid;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Entries(string uid, [FromForm] IEnumerable<PostPaintingViewModel> postPaintingViewModel)
        {
            var result = await _userService.PostPainting(uid, postPaintingViewModel);
            return Ok(result);
        }

        public IActionResult DataConfirmation()
        {
            return View();
        }
        public IActionResult Finish()
        {
            return View();
        }
        public IActionResult SignUpQuery()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUpQuery([FromBody] QueryUserViewModel queryViewModel)
        {
            var result = await _userService.QueryUser(queryViewModel);
            var user = result.RtnData as User;
            int step = (int)user.Step;
            ViewBag.Uid = user.Uid;
            if (step == (int)StepEnum.FirstPage)
                return RedirectToAction("AcademicExperience");
            else if (step == (int)StepEnum.SecondPage)
                return RedirectToAction("Entries");
            else if (step == (int)StepEnum.ThirdPage)
                return RedirectToAction("DataConfirmation");
            return RedirectToAction("SignUp");
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfCity()
        {
            var result = await _addressService.GetListOfCity();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetDistrictsByCity(string cityID)
        {
            var result = await _addressService.GetDistrictsByCity(cityID);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfCompetitionItems()
        {
            var result = await _gameItemRepository.GetListOfCompetitionItems();
            return Ok(result);
        }

        //public async Task<IActionResult> UploadPhotos(PostPaintingViewModel postPaintingViewModel)
        //{

        //}
        [HttpPost]
        public async Task<IActionResult> ImageUpload(IEnumerable<PostPaintingViewModel> Files)
        {
            var uid = 0;
            foreach (var file in Files)
            {
                if (uid < 0)
                    uid = file.Uid;
                if (file.ProfileFile == null)
                    break;
                if (file.ProfileFile.Length > 0)
                {
                    var imagePath = @"\Upload\Images";
                    //抓取環境是否有這個資料夾
                    var uploadPath = _env.WebRootPath + imagePath;

                    //沒有資料夾創造資料夾
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    //創造圖檔名字
                    var uniqFileName = Guid.NewGuid().ToString();
                    var filename = Path.GetFileName(uniqFileName + "." + file.ProfileFile.FileName.Split(".")[1].ToLower());
                    //圖檔完整路徑
                    string fullPath = uploadPath + @"\" + filename;

                    //複製圖檔到資料夾
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.ProfileFile.CopyToAsync(fileStream);
                    }

                    imagePath = imagePath + @"\";
                    var filePath = @".." + Path.Combine(imagePath, filename);
                }
            }

            return RedirectToAction("DataConfirmation", uid);
        }

    }
}
