using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImageService;
        private readonly IWebHostEnvironment _environment;
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _environment = webHostEnvironment;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            string path = _environment.WebRootPath + "\\Images\\";
            var newGuidPath = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fileStream = System.IO.File.Create(path + newGuidPath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            if (file==null)
            {
                carImage.ImagePath = path + "default.png";
            }

            var result = _carImageService.Add(new CarImage
            {
                CarId = carImage.CarId,
                Date = DateTime.Now,
                ImagePath = newGuidPath
            });

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            string path = _environment.WebRootPath + "\\Images\\";
            System.IO.File.Delete(path + carImage.ImagePath);

            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage, [FromForm(Name = ("Image"))] IFormFile file)
        {
            string path = _environment.WebRootPath + "\\Images\\";
            string updateImagePath = Path.Combine(path, carImage.ImagePath);
            string newGuid = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var newGuidPath = Path.Combine(path, newGuid);
            System.IO.File.Move(updateImagePath, newGuidPath);

            carImage.ImagePath = newGuid;
            carImage.Date = DateTime.Now;
            var result = _carImageService.Update(carImage);
            

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
