using Microsoft.AspNetCore.Mvc;
using FoodService.Core.Dto;
using FoodService.Core.Interface.Command;

namespace FoodService.Controllers
{
    public class AuthController(IAuthCommand authCommand) : Controller
    {
        private readonly IAuthCommand _authCommand = authCommand;

        /// <summary>
        /// Displays the sign-up page.
        /// </summary>
        /// <returns>The sign-up view.</returns>
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        /// <summary>
        /// Handles the sign-up form submission.
        /// </summary>
        /// <param name="signUpDto">The sign-up data.</param>
        /// <returns>The appropriate view based on success or failure of sign-up.</returns>
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            // If model state is not valid, return to the view
            if (!ModelState.IsValid)
            {
                return View(signUpDto);
            }

            // Call the SignUp method from the authentication command
            var response = await _authCommand.SignUp(signUpDto);

            // If the SignUp operation was not successful, add error message to model state and return to the view
            if (!response.IsSuccess)
            {
                ModelState.AddModelError("", response.Message);
                return View(signUpDto);
            }

            // Redirect to SignIn action if SignUp is successful
            return RedirectToAction("SignIn");
        }

        /// <summary>
        /// Displays the sign-in page.
        /// </summary>
        /// <returns>The sign-in view.</returns>
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        /// <summary>
        /// Handles the sign-in form submission.
        /// </summary>
        /// <param name="signInDTO">The sign-in data.</param>
        /// <returns>The appropriate view based on success or failure of sign-in.</returns>
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDTO)
        {
            // If model state is not valid, return to the view
            if (!ModelState.IsValid)
            {
                return View(signInDTO);
            }

            // Call the SignIn method from the authentication command
            var response = await _authCommand.SignIn(signInDTO);

            // If the SignIn operation was not successful, add error message to model state and return to the view
            if (!response.IsSuccess)
            {
                ModelState.AddModelError("", response.Message);
                return View(signInDTO);
            }
            // Here you can add logic to redirect to the desired page after successful login
            return RedirectToAction("Index", "Home");
        }
    }
}
