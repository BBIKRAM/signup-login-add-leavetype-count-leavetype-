using BikramApi.Data;
using BikramApi.Modeels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BikramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        [Route("~/signup")]
        public IActionResult signup(User obj)
        {
            var data = _dbContext.tbl_user.Where(x => x.Name == obj.Name);
            if (data.Count() != 0)
            {

                return NotFound("Already exist");
            }
            else
            {
                _dbContext.tbl_user.Add(obj);
                _dbContext.SaveChanges();   
                return Ok("added");

            }
        }
            [HttpPost]
        [Route("~/login")]
        public IActionResult login(Login user)
        {
            //bikram
            var data= _dbContext.tbl_user.Where(x => x.Name == user.Name).ToList();
            if(data.Count() != 0)
            {
                var password= _dbContext.tbl_user.Where(x => x.Password == user.Password).ToList();
                if(password.Count()!=0)
                {
                    return Ok("Login Successfully");
                }
                else
                {
                    return NotFound("Password is incorrect");
                }
            }
            else
            {
                return NotFound("UserName Doesnot Exists");
            }
            
        }
        [HttpPost]
        [Route("~/api/takeleave")]
        public IActionResult TakeLeave(TakeLeave takeLeave)
        {
            var data= _dbContext.tbl_user.Where(x=>x.Name==takeLeave.Name);
            if(data.Count()!=0)
            {
                //if L in leave
                var data12 = _dbContext.tbl_user.Find(data.FirstOrDefault().Id);
                data12.Status = "L";
                data12.Name = data.FirstOrDefault().Name;
                data12.Email = data.FirstOrDefault().Email;
                data12.Password = data.FirstOrDefault().Password;
                
                data12.LeaveType = takeLeave.LeaveType;
                _dbContext.tbl_user.Update(data12);
                _dbContext.SaveChanges();
                return Ok("Leave Accepted Succefully");
            }
            else
            {
                return NotFound("User Not Found");
            }     
        }
        [HttpGet]
        [Route("~/api/countleave")]
        public IActionResult CountLeaveUser(string leavetype)
        {
            var data= _dbContext.tbl_user.Where(x => x.LeaveType == leavetype).ToList();
            return Ok(data.Count());
        }
        [HttpGet]
        [Route("~/api/countleavewithuser")]
        public IActionResult LeaveCountAccordingtoUser(string Name,string leavetype)
        {
            
                var data = _dbContext.tbl_user.Where(x => x.LeaveType == leavetype && x.Name==Name).ToList();
                return Ok(data.Count());  
        }

    }
}
