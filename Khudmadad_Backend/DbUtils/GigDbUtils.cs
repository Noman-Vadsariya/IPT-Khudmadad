using Khudmadad_Backend.EfCore;
using Khudmadad_Backend.Models;
using Npgsql.Replication;
using System;

namespace Khudmadad_Backend.DbUtils
{
    public class GigDbUtils
    {
        private Ef_DataContext _context;

        public GigDbUtils(Ef_DataContext context)
        {
            _context = context;
        }

        public List<GigModel>? GetGigs()
        {
            List<GigModel> response = new List<GigModel>();
            var gigList = _context.gig.ToList();

            if (gigList == null)
                return null;

            else
            {
                gigList.ForEach(row => response.Add(new GigModel()
                {
                    creatorId = row.creatorId,
                    gigId = row.gigId,
                    gigName = row.gigName,
                    deadline = row.deadline,
                    description = row.description,
                    pay = row.pay
                }));

                return response;
            }
        }
        
        public List<GigModel>? GetUnacceptedGigs()
        {
            List<GigModel> response = new List<GigModel>();
            var gigList = (from gig in _context.gig
                           join offer in _context.offer on gig.gigId equals offer.gigId into ps_jointable 
                           from p in ps_jointable.DefaultIfEmpty()
                           where p.status != true
                           select new
                           {
                               creatorId = gig.creatorId,
                               gigId = gig.gigId,
                               gigName = gig.gigName,
                               description = gig.description,
                               deadline = gig.deadline,
                               pay = gig.pay
                           }).ToList();

            if (gigList == null)
                return null;
            else
            {
                gigList.ForEach(row => response.Add(new GigModel()
                {
                    creatorId = row.creatorId,
                    gigId = row.gigId,
                    gigName = row.gigName,
                    deadline = row.deadline,
                    description = row.description,
                    pay = row.pay
                }));

                return response;
            }
        }

        public List<GigModel>? GetGigsByCreatorId(int creatorId)
        {
            List<GigModel> response = new List<GigModel>();
            var gigList = _context.gig.Where(o => o.creatorId.Equals(creatorId)).ToList();

            if (gigList == null)
                return null;

            else
            {
                gigList.ForEach(row => response.Add(new GigModel()
                {
                    creatorId = row.creatorId,
                    gigId = row.gigId,
                    gigName = row.gigName,
                    deadline = row.deadline,
                    description = row.description,
                    pay = row.pay
                }));

                return response;
            }
        }

        public void AddGig(GigModel gig)
        {
            Gig g = new Gig();
            g.creatorId = gig.creatorId;
            g.deadline = gig.deadline;
            g.gigName = gig.gigName;
            g.description = gig.description;
            g.pay = gig.pay;

            _context.gig.Add(g);
            _context.SaveChanges();
        }

        public GigModel? GetGigById(int id)
        {
            GigModel g = new GigModel();
            var gig = _context.gig.Where(u => u.gigId.Equals(id)).FirstOrDefault();
            if (gig == null)
                return null;
            else
            {
                g.creatorId = gig.creatorId;
                g.gigId = gig.gigId;
                g.gigName = gig.gigName;
                g.deadline = gig.deadline;
                g.description = gig.description;
                g.pay = gig.pay;

                return g;
            }
        }

        public bool UpdateGigInfo(GigModel gig)
        {
            var _g = _context.gig.Where(g => g.gigId.Equals(gig.gigId)).FirstOrDefault();
            if (_g == null)
                return false;
            else
            {
                _g.pay = gig.pay;
                _g.description = gig.description;
                _g.gigName = gig.gigName;
                _g.deadline = gig.deadline;
                _context.SaveChanges();
                return true;
            }
        }

        public bool DeleteGig(GigModel gig)
        {
            var _g = _context.gig.Where(g => g.gigId.Equals(gig.gigId)).FirstOrDefault();
            if (_g == null)
                return false;
            else
            {
                _context.gig.Remove(_g);
                _context.SaveChanges();
                return true;
            }
        }

    }
}
