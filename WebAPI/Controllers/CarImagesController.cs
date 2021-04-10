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
using Core.Utilities.FileHelper;

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
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImageService.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            string path = _environment.WebRootPath + "\\Images";
            var guidPath = FileHelper.Add(file, path);
            var result = _carImageService.Add(new CarImage
            {
                CarId = carImage.CarId,
                Date = DateTime.Now,
                ImagePath = guidPath
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
            string path = _environment.WebRootPath + "\\Images";
            FileHelper.Delete(path + "\\" + carImage.ImagePath);

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
            string path = _environment.WebRootPath + "\\Images";

            string newGuid = FileHelper.Update(file, path, carImage.ImagePath);

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
