using Microsoft.AspNetCore.Mvc;
using FoodService.Dto;
using FoodService.Config.Globalization;

namespace FoodService.Controllers
{
    /// <summary>
    /// Controller for handling user authentication related actions such as sign-up and sign-in.
    /// </summary>
    public class AuthController : BaseController
    {
        private readonly IAuthCommand _authCommand;

        /// <summary>
        /// Constructor for AuthController.
        /// </summary>
        /// <param name="authCommand">The authentication command.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="localization">The localization service.</param>
        public AuthController(
            IAuthCommand authCommand,
            ILogger<AuthController> logger,
            LanguageService localization
        ) : base(logger, localization)
        {
            _authCommand = authCommand;
        }

        /// <summary>
        /// Displays the sign-up page.
        /// </summary>
        /// <returns>The sign-up view.</returns>
        [HttpGet]
        public IActionResult SignUp()
        {
            _logger.LogInformation("Displaying the sign-up page.");
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
            _logger.LogInformation("Attempting sign-up.");

            // If model state is not valid, return to the view
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state during sign-up.");
                return View(signUpDto);
            }

            // Call the SignUp method from the authentication command
            var response = await _authCommand.SignUp(signUpDto);

            // If the SignUp operation was not successful, add error message to model state and return to the view
            if (!response.IsSuccess)
            {
                _logger.LogError("Sign-up failed: {ErrorMessage}", response.Message);
                ModelState.AddModelError("", response.Message);
                return View(signUpDto);
            }

            _logger.LogInformation("Sign-up successful. Redirecting to sign-in page.");
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
            _logger.LogInformation("Displaying the sign-in page.");
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
            _logger.LogInformation("Attempting sign-in.");

            // If model state is not valid, return to the view
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state during sign-in.");
                return View(signInDTO);
            }

            // Call the SignIn method from the authentication command
            var response = await _authCommand.SignIn(signInDTO);

            // If the SignIn operation was not successful, add error message to model state and return to the view
            if (!response.IsSuccess)
            {
                _logger.LogError("Sign-in failed: {ErrorMessage}", response.Message);
                ModelState.AddModelError("", response.Message);
                return View(signInDTO);
            }

            _logger.LogInformation("Sign-in successful. Redirecting to home page.");
            // Here you can add logic to redirect to the desired page after successful login
            return RedirectToAction("Index", "Home");
        }
    }
}
