using System;
using Concert.Models;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using ConcertRepository.Interfaces;
using ConcertRepository.Model;
using ConcertRepository.Services;     

namespace Concert.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService userService;

        string connectionString =
            ConfigurationManager.ConnectionStrings["VirtualConcertRegistrationConnection"].ConnectionString;

        public HomeController()
        {
            userService = new UserService(connectionString);
        }
        [HttpGet]
        public ActionResult Welcome()
        {
            User user = new User();

            return View(user);
        }

        //This redirects the user to the RegistrationList action.
        [HttpPost]
        public ActionResult ConcertDetails(User user)
        {

            if (!ModelState.IsValid)
            {
                return View("Welcome", user);
            }

            bool result = userService.RegisterUser(MapToDTO(user));

            if (result)
            {
                return RedirectToAction("RegistrationList");
            }

            //ModelState.AddModelError(
            //    "",
            //    "The registration was not saved successfully."
            //);


            return View("Welcome", user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RegistrationList(int? searchId)
        {
            if (searchId.HasValue)
            {
                UserDTO selectedUser =
                    userService.GetUserById(searchId.Value);

                if (selectedUser == null)
                {
                    ViewBag.SearchMessage =
                        "No registration found with ID " +
                        searchId.Value;

                    return View(
                        Enumerable.Empty<UserDTO>()
                    );
                }

                return View(new[] { selectedUser });
            }

            var users = userService.GetAllUsers();

            return View(users);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateFromList(UserDTO user)
        {
            userService.UpdateUser(user);
            return RedirectToAction("RegistrationList");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            userService.DeleteUser(id);
            return RedirectToAction("RegistrationList");
        }

        public UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                RegistrationId = user.RegistrationId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.EmailAddress,
                HomeAddress = user.HomeAddress,
                StreetAddress = user.StreetAddress,
                City = user.City,
                State = user.State,
                PinCode = user.PinCode,
                HeardAboutConcert = user.HeardAboutConcert,
                OtherSource = user.OtherSource,
                VirtualConcertFee = user.VirtualConcertFee,
                Quantity = user.Quantity,
                TotalAmount = user.TotalAmount,
                PaymentMethod = user.PaymentMethod
            };
        }
    }
}