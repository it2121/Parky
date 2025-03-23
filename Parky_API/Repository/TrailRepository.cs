using Parky_API.Data;
using Parky_API.Models;
using Parky_API.Repository.IRepository;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Parky_API.Repository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _db;
        public TrailRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateTrail(Trail Trail)
        {
                
            _db.Trails.Add(Trail);
            return save();
        }

        public bool DeleteTrail(Trail Trail)
        {
            _db.Trails.Remove(Trail);
            return save();
        }

        public Trail GetTrail(int trailId)
        {

            return _db.Trails.Include(c => c.NationalPark).FirstOrDefault(a => a.Id == trailId);

        }

        public ICollection<Trail> GetTrails()
        {

            return _db.Trails.Include(c => c.NationalPark).OrderBy(a => a.Name).ToList();

            }

        public bool TrailExist(string name)
        {
            bool value = _db.Trails.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());

            return value;
        
        
        }

        public bool TrailExist(int id)
        {

            bool value = _db.Trails.Any(a => a.Id == id);
            return value;

        }

        public bool save()
        {
            return _db.SaveChanges() >= 0 ? true : false;  
        
        
        }

        public bool UpdateTrail(Trail Trail)
        {
            _db.Trails.Update(Trail);
            return save();
        
        }

        public ICollection<Trail> GetTrailsInNationalPark(int npId)
        {
            return _db.Trails.Include(c => c.NationalPark).Where(c => c.NationalParkId == npId).ToList();
        }
    }
}
