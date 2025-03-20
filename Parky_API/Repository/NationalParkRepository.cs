using Parky_API.Data;
using Parky_API.Models;
using Parky_API.Repository.IRepository;

namespace Parky_API.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _db;
        public NationalParkRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateNationalPark(NationalPark nationalPark)
        {
                
            _db.NationalPark.Add(nationalPark);
            return save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _db.NationalPark.Remove(nationalPark);
            return save();
        }

        public NationalPark GetNationalPark(int natonalParkId)
        {

            return _db.NationalPark.FirstOrDefault(a => a.Id == natonalParkId);

        }

        public ICollection<NationalPark> GetNationalParks()
        {

            return _db.NationalPark.OrderBy(a => a.Name).ToList();

            }

        public bool NationalParkExist(string name)
        {
            bool value = _db.NationalPark.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());

            return value;
        
        
        }

        public bool NtionalParkExist(int id)
        {

            bool value = _db.NationalPark.Any(a => a.Id == id);
            return value;

        }

        public bool save()
        {
            return _db.SaveChanges() >= 0 ? true : false;  
        
        
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _db.NationalPark.Update(nationalPark);
            return save();
        
        }
    }
}
