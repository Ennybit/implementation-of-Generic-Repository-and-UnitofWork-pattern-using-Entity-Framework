using GenericRepo.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GenericRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly datacontext _context;
        private readonly IUnitofWork _unitofwork;
       
        public HomeController(datacontext context, IUnitofWork unitofWork)
        {
            _context = context;
            _unitofwork = unitofWork;
        }

        
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var result = await _unitofwork.Homess.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Home home)
        {
            await _unitofwork.Homess.Create(home);
            await _unitofwork.Save();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitofwork.Homess.Delete(id);
            await _unitofwork.Save();
            return Ok(_unitofwork);
        }

        [HttpPut]
        public async  Task<IActionResult> Update(int id, Home home)
        {
            var result = await _unitofwork.Homess.Getbyid(d => d.Id == id);
            _unitofwork.Homess.Update(home);
            await _unitofwork.Save();
            return Ok();
        }


    }
}
