using Microsoft.AspNetCore.Mvc;
using TestVal.Models;
using TestVal.Util;

namespace TestVal.Controllers{
    [Route("test")]
    public class TestValidationController:Controller{
        private StringStore _store;
        public TestValidationController(StringStore store)
        {
            _store = store;
        }

        [HttpGet("my")]
        public IActionResult MyForm(){
            ViewBag.Strings=_store.strings;
            return View();
        }

        [HttpPost("my")]
        public IActionResult MyForm(FormViewModel vm){
            if(!ModelState.IsValid)
            return View(vm);
            _store.strings.Add(vm.Name);
            return RedirectToAction(nameof(MyForm));
        }
    }
}