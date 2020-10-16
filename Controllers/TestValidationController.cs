using Microsoft.AspNetCore.Mvc;
using TestVal.Models;
using TestVal.Util;

namespace TestVal.Controllers{
    [Route("test")]
    public class TestValidationController:Controller{
        private readonly StringStore _store;
        public TestValidationController(StringStore store)
        {
            _store = store;
        }

        [HttpGet("my")]
        public IActionResult MyForm(){
            return View();
        }

        [HttpPost("my")]
        public IActionResult MyForm(FormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            _store.Strings.Add(vm.Name);
            return RedirectToAction(nameof(MyForm));
        }
    }
}