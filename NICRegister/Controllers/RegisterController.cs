using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NICRegister.DbContexts;
using NICRegister.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NICRegister.Controllers
{
    public class RegisterController : Controller
    {
        private readonly NICDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;

        public RegisterController(NICDBContext nICDBContext, IMapper mapper, IWebHostEnvironment env)
        {
            this.dbContext = nICDBContext;
            this.mapper = mapper;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        public async Task<IActionResult> Add(AddRegister addRegister)
        {
            #region
            if (ModelState.IsValid)
            {
               
                //using var memoryStream = new MemoryStream();
                //await addRegister.ImageFile.CopyToAsync(memoryStream);

                var users = new Register
                {
                    Name = addRegister.Name,
                    FatherName = addRegister.FatherName,
                    Gender = addRegister.Gender,
                    Email = addRegister.Email,
                    Mobile = addRegister.Mobile,
                    AdharNumber = addRegister.AdharNumber,
                    District = addRegister.District,
                    Mondal = addRegister.Mondal,
                    Village = addRegister.Village,
                    Address = addRegister.Address,
                    //ImageFile = addRegister.ImageFile,
                    //Title = addRegister.Title,
                };

                if (addRegister.ImageFile != null)
                {
                    // unique file name
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + addRegister.ImageFile.FileName;
                    // Set the path to save the file
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    var filePath = Path.Combine(uploads, uniqueFileName);

                    //directory exists
                    Directory.CreateDirectory(uploads);

                    // Save the file
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await addRegister.ImageFile.CopyToAsync(fileStream);
                    }

                    // Set the ImagePath property
                    users.ImagePath = "/images/" + uniqueFileName;
                }


                await dbContext.MyRegistrations.AddAsync(users);
                await dbContext.SaveChangesAsync();
                TempData["Alert"] = $"{addRegister.Name} Added Succesfully..!";
            }
            #endregion

            //var user = mapper.Map<Register>(addRegister);
            //await dbContext.MyRegistrations.AddAsync(user);
            //await dbContext.SaveChangesAsync();

            //TempData["Alert"] = $"{addRegister.Name} Added Succesfully..!";
            return RedirectToAction("List", "Register");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            List<Register> users = await dbContext.MyRegistrations.ToListAsync();
            return View(users);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var student = await dbContext.MyRegistrations.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Register viewModel)
        {
            //var user = await applicationDbContext.Students.AsNoTracking()
            //    .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            var user = await dbContext.MyRegistrations.
                FindAsync(viewModel.Id);
            if (user is not null)
            {
                user.Name = viewModel.Name;
                user.FatherName = viewModel.FatherName;
                user.Gender = viewModel.Gender;
                user.Email = viewModel.Email;
                user.Mobile = viewModel.Mobile;
                user.AdharNumber = viewModel.AdharNumber;
                user.District = viewModel.District;
                user.Mondal = viewModel.Mondal;
                user.Village = viewModel.Village;
                user.Address = viewModel.Address;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Register");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Register viewstudent)
        {
            var student = await dbContext.MyRegistrations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewstudent.Id);
            if (student is not null)
            {
                dbContext.Remove(viewstudent);
                await dbContext.SaveChangesAsync();
                TempData["Alert"] = $"{viewstudent.Id} Deleted Succesfully..!";
            }
            return RedirectToAction("List", "Register");
        }
    }
}
