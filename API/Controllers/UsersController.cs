using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//2.15{
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }


//api/users/

    [HttpGet]   
    //public  ActionResult<IEnumerable<AppUser>> GetUsers(){
public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers(){

/*
option 1:
 var users = _context.Users.ToList();
 return users;
*/
//Option 2:
//return _context.Users.ToList();

//option3 (Asynchronous):
return await  _context.Users.ToListAsync();

    }    


//api/users/3
//api/users/id

    [HttpGet("{id}")/*("3")*/]   
//    public ActionResult<AppUser> GetUser(int id){
    public async Task< ActionResult<AppUser>> GetUser(int id){

/*
option 1:
 var user = _context.Users.Find(id);
 return user;
*/
//option 2:
//return _context.Users.Find(id);
//option3 (Asynchronous):
return await _context.Users.FindAsync(id);
    }    
    }
    //}2.15
}