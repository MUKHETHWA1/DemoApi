using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoApi.Models;
using DemoApi.Data;

namespace DemoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly ApiContext _context;
        public HotelBookingController(ApiContext context)
        {
            _context = context;
        }
        //create/edit
        [HttpPost]
        public JsonResult CreateEdit(HotelBooking booking)
        {
            if (booking.Id == 0)
            {
                _context.Bookings.Add(booking);
            }
            else
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);
                if (bookingInDb == null)
                    return new JsonResult(NotFound());
                bookingInDb = booking;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(booking));
        }

        //Get Booking
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Bookings.Find(id);
            //To check the Get
            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result =_context.Bookings.Find(id);

            if(result == null)
                return new JsonResult(NotFound());

            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Get All
        //to return all bookings
        [HttpGet()]
        public JsonResult GetAll()
        {
            var result = _context.Bookings.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
