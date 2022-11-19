using Khudmadad_Backend.Efcore;
using Khudmadad_Backend.EfCore;
using Khudmadad_Backend.Models;
using Npgsql.Replication;
using System;

namespace Khudmadad_Backend.DbUtils
{
    public class OfferDbUtils
    {
        private Ef_DataContext _context;

        public OfferDbUtils(Ef_DataContext context)
        {
            _context = context;
        }

        public List<OfferModel>? GetOffers()
        {
            List<OfferModel> response = new List<OfferModel>();
            var offerList = _context.offer.ToList();

            if (offerList == null)
                return null;

            else
            {
                offerList.ForEach(row => response.Add(new OfferModel()
                {
                    gigId = row.gigId,
                    freelancerId = row.freelancerId,
                    pay = row.pay,
                    status = row.status
                }));

                return response;
            }
        }

        public List<OfferModel>? GetOfferByGigId(int gigId)
        {
            List<OfferModel> response = new List<OfferModel>();
            var offerList = _context.offer.Where(o => o.gigId.Equals(gigId)).ToList();
            
            if (offerList == null)
                return null;
            else
            {
                foreach(var row in offerList)
                {
                    response.Add(new OfferModel()
                    {
                        gigId = row.gigId,
                        freelancerId = row.freelancerId,
                        pay = row.pay,
                        status = row.status
                    });
                }
                return response;
            }
        }
        
        public List<OfferModel>? GetOfferByFreelancerId(int freelancerId)
        {
            List<OfferModel> response = new List<OfferModel>();
            var offerList = _context.offer.Where(o => o.freelancerId.Equals(freelancerId)).ToList();
            if (offerList == null)
                return null;
            else
            {
                foreach (var row in offerList)
                {
                    response.Add(new OfferModel()
                    {
                        gigId = row.gigId,
                        freelancerId = row.freelancerId,
                        pay = row.pay,
                        status = row.status
                    });
                }
                return response;
            }
        }

        public void AddOffer(OfferModel offer)
        { 
            Offers o = new Offers();
            o.freelancerId = offer.freelancerId;
            o.gigId = offer.gigId;
            o.pay = offer.pay;

            _context.offer.Add(o);
            _context.SaveChanges();
        }

        public bool UpdateOfferStatus(OfferModel offer)
        {
            var _o = _context.offer.Where(o => o.gigId.Equals(offer.gigId) && o.freelancerId.Equals(offer.freelancerId)).FirstOrDefault();
            if (_o == null)
                return false;
            else
            {
                _o.status = offer.status;
                _context.SaveChanges();
                return true;
            }
        }
        
        public bool DeleteOffer(OfferModel offer)
        {
            var _o = _context.offer.Where(o => o.gigId.Equals(offer.gigId) && o.freelancerId.Equals(offer.freelancerId)).FirstOrDefault();
            if (_o == null)
                return false;
            else
            {
                _context.offer.Remove(_o);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
