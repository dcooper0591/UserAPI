using FSPUserApi.Managers;
using FSPUserApi.Models;
using FSPUserApi.Validations;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FSPUserApi.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager _userManager;
        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("/fetch")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult FetchUser(string userId)
        {
            try
            {
                ValidateUser.ValidateUserId(userId);

                Guid userIdGuid = Guid.Parse(userId);
                User? user = _userManager.GetUser(userIdGuid);

                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost("/save")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult SaveUser(string userFirstName, string userLastName, string userEmail)
        {
            try
            {
                User user = new User(userFirstName, userLastName, userEmail);

                ValidateUser.ValidateUserInfo(userFirstName, userLastName, userEmail);
                Guid? userGuid = _userManager.AddUser(user);
                if (userGuid != null)
                {
                    User? storedUser = _userManager.GetUser(userGuid.Value);
                    if (storedUser != null)
                    {
                        return Ok(storedUser);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(ValidationException ex)
            {
                return BadRequest();
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("/fetch-all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult FetchAllUsers()
        {
            try
            {
                List<User> allUsers = _userManager.GetAllUsers();

                if (allUsers != null)
                {
                    return Ok(allUsers);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
