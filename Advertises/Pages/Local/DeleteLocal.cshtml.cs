using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises
{
    public class DeleteLocalModel : PageModel
    {
        private IBaseService<Local> _localService;

        public DeleteLocalModel(IBaseService<Local> localService)
        {
            _localService = localService;
        }

        [BindProperty]
        public Local MyLocal
        { set; get; }
        public void OnGet(long id)
        {
            MyLocal = _localService.Get(id);
        }
        public void OnPost()
        {
           
            if (MyLocal != null)
            {
               _localService.Delete(MyLocal.Id);
                
            }
        }
    }
}