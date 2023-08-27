using Microsoft.AspNetCore.Mvc;
using SpeakHub.Service.Interfaces.Common;
using SpeakHub.Service.ViewModels;

namespace SpeakHub.ViewComponents
{
    public class IdentityViewComponent : ViewComponent
    {
        private readonly IIdentityService _identityService;
        public IdentityViewComponent(IIdentityService identity)
        {
            this._identityService = identity;
        }
        public IViewComponentResult Invoke()
        {
            AccountBaseViewModel accountBaseViewModel = new AccountBaseViewModel()
            {
                Id = _identityService.Id!.Value,
                PhoneNumber = _identityService.PhoneNumber,
                FirstName = _identityService.FirstName,
                LastName = _identityService.LastName,
                ImagePath = _identityService.ImagePath
            };
            return View(accountBaseViewModel);
        }
    }
}
