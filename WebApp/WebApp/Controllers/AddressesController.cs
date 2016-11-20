using System.Net;
using System.Web.Mvc;
using WebApp.Services.Interfaces.UserInfo;
using WebApp.ViewModels;
using WebApp.Models;
using WebApp.Services.Interfaces;
namespace WebApp.Controllers
{
    public class AddressesController : BaseController
    {
        private readonly IAddressService<AddressViewModel, Address, int> _addressService;

        public AddressesController(IAddressService<AddressViewModel, Address, int> addressService)
        {
            _addressService = addressService;
        }

        // GET: Addresses
        public ActionResult Index()
        {
            //Notice that I am sending back a list of view models in the service, so you have to change it in the view as well
            return View(_addressService.Index());
        }

        //GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Notice that I am using the view model here, so you have to change it in the view as well
            AddressViewModel address = _addressService.DetailsGet(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        [Authorize]
        public ActionResult Create()
        {
            //Getting rid of these view bags in favor of view model objects of type SelectList
            //ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Tld"); //  Get these from the view model and fill them in the get calls
            //ViewBag.StateParishId = new SelectList(db.StateParishes, "StateParishId", "StateParishName");
            return View(_addressService.CreateGet());

        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "AddressId,AddressName,AddressLn1,AddressLn2,CountryId,StateParishId,UserId")] AddressViewModel address)
        {
            if (!ModelState.IsValid) return View(_addressService.CreatePostFailed(address));
            _addressService.CreatePost(address);
            return RedirectToAction("Index");
        }

        // GET: Addresses/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressViewModel address = _addressService.EditGet(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "AddressId,AddressName,AddressLn1,AddressLn2,CountryId,StateParishId,UserId")] AddressViewModel address)
        {
            if (!ModelState.IsValid) return View(address);
            //address.UserId = User.Identity.GetUserId();
            _addressService.EditPost(address);
            return RedirectToAction("Index");
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressViewModel address = _addressService.DeleteGet(id.Value);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _addressService.DeletePost(id);
            return RedirectToAction("Index");
        }


    }
}
