using MegaMinds_WebApp.Models;
using MegaMinds_WebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaMinds_WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, IStateRepository stateRepository, ICityRepository cityRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }

        public IActionResult GetAll()
        {
            var users = _userRepository.GetAllUsersAsync();
            foreach (var user in users)
            {
                user.City = _cityRepository.GetCityById(user.CityId);
                user.State = _stateRepository.GetStateById(user.StateId);
            }

            return View("Index", users);
        }

        public IActionResult Check()
        {

            return View("View");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        public IActionResult Create()
        {
            var userModel = new UserModel();
            userModel.StatesList = (List<StateModel>)_stateRepository.GetAllStates();
            // Assign a default value for StateId
            userModel.StateId = userModel.StatesList.FirstOrDefault()?.StateId ?? 0;
            // Get the selected State
            var selectedState = _stateRepository.GetStateById(userModel.StateId);

            // Get the Cities for the selected State
            userModel.CitiesList = _cityRepository.GetCitiesByStateId(selectedState.StateId);
            return View(userModel);
        }
        // POST: /User/Create
        [HttpPost]
        public IActionResult Create(UserModel userModel)
        {
            var selectedState = _stateRepository.GetStateById(userModel.StateId);

            if (ModelState.IsValid)
            {
                _userRepository.AddUserAsync(userModel);
                return RedirectToAction(nameof(GetAll));
            }
            // If we got this far, something failed, redisplay form
            userModel.StatesList = (List<StateModel>)_stateRepository.GetAllStates();
            userModel.CitiesList = _cityRepository.GetCitiesByStateId(selectedState.StateId);

            return View(userModel);
        }

        // GET: /User/Update/5
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = _userRepository.GetUserByIdAsync(id.Value);
            if (userModel == null)
            {
                return NotFound();
            }

            var stateList = _stateRepository.GetAllStates();
            ViewBag.States = new SelectList(stateList, "StateId", "StateName", userModel.StateId);

            var cityList = _cityRepository.GetCitiesByStateId(userModel.StateId);
            ViewBag.Cities = new SelectList(cityList, "Id", "CityName", userModel.CityId);

            return View("Edit", userModel);
        }

        // POST: /User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _userRepository.UpdateUserAsync(id, userModel);
                return RedirectToAction(nameof(GetAll));
            }
            return View("Edit", userModel);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = _userRepository.DeleteUserAsync(id);
            if (result > 0)
            {
                return RedirectToAction(nameof(GetAll));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult GetCitiesByStateId(int stateId)
        {
            var cities = _cityRepository.GetCitiesByStateId(stateId);
            return Json(cities);
        }

    }
}
