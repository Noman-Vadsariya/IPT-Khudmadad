using Khudmadad_Backend.DbUtils;
using Khudmadad_Backend.EfCore;
using Khudmadad_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Khudmadad_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly OfferDbUtils _db;

        public OfferController(Ef_DataContext _context)
        {
            _db = new OfferDbUtils(_context);
        }

        // GET: api/Offer
        [HttpGet]
        public ApiResponse Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<OfferModel>? data = _db.GetOffers();

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return ResponseHandler.GetAppResponse(type, data);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }

        }

        //GET: api/Offer/gigId/5
        [HttpGet("gigId/{gigId}")]
        public ApiResponse GetOffersByOfferId(int gigId)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<OfferModel>? data = _db.GetOfferByGigId(gigId);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return ResponseHandler.GetAppResponse(type, data);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

        //GET: api/Offer/freelancerId/5
        [HttpGet("freelancerId/{freelancerId}")]
        public ApiResponse GetOffersByFreelancerId(int freelancerId)
        {
            ResponseType type = ResponseType.Success;
            Console.WriteLine("\n\n" + freelancerId + "\nHello");
            try
            {
                IEnumerable<OfferModel>? data = _db.GetOfferByFreelancerId(freelancerId);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return ResponseHandler.GetAppResponse(type, data);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }
        
        //GET: api/Offer/clientId/5
        [HttpGet("clientId/{clientId}")]
        public ApiResponse GetOffersByClientId(int clientId)
        {
            ResponseType type = ResponseType.Success;
            Console.WriteLine("\n\n" + clientId + "\nHello");
            try
            {
                IEnumerable<GigOfferModel>? data = _db.GetOffersByClientId(clientId);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return ResponseHandler.GetAppResponse(type, data);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

        // GET: api/Offer/Create
        [HttpPost("Create")]
        public ApiResponse Create(OfferModel offer)
        {
            try
            {
                _db.AddOffer(offer);
                return ResponseHandler.GetAppResponse(ResponseType.Success, offer);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }

        [HttpPut("UpdateStatus")]
        public ApiResponse UpdateOfferStatus(OfferModel offer)
        {
            try
            {
                var _o = _db.UpdateOfferStatus(offer);
                if(_o)
                    return ResponseHandler.GetAppResponse(ResponseType.Success, _o);
                else
                    return ResponseHandler.GetAppResponse(ResponseType.Failure, _o);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }
        //Delete
        [HttpDelete("delete")]
        public ApiResponse DeleteOffer(OfferModel offer)
        {
            try
            {
                var _o = _db.DeleteOffer(offer);
                if(_o)
                    return ResponseHandler.GetAppResponse(ResponseType.Success, _o);
                else
                    return ResponseHandler.GetAppResponse(ResponseType.Failure, _o);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }
        
        //Delete all offers with given gigId accept the one accepted by client
        [HttpDelete("delete/{gigId}")]
        public ApiResponse DeleteOfferGivenGigId(int gigId)
        {
            try
            {
                var _o = _db.DeleteOffersWithGigId(gigId);
                if(_o)
                    return ResponseHandler.GetAppResponse(ResponseType.Success, _o);
                else
                    return ResponseHandler.GetAppResponse(ResponseType.Failure, _o);
            }
            catch (Exception ex)
            {
                return ResponseHandler.GetExceptionResponse(ex);
            }
        }
    }
}
