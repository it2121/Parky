using Parky_API.Models;

namespace Parky_API.Repository.IRepository
{
    public interface ITrailRepository
    {
        ICollection<Trail> GetTrails();
        ICollection<Trail> GetTrailsInNationalPark(int npId);
        Trail GetTrail(int trailId);


        bool TrailExist(string name);
        bool TrailExist(int id);
        bool CreateTrail(Trail Trail);
        bool UpdateTrail(Trail Trail);
        bool DeleteTrail(Trail Trail);

        bool save();
    }
}
