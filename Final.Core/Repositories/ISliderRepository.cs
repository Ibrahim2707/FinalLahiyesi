using Final.Core.Entities;

namespace Final.Core.Repositories
{
    public interface ISliderRepository : IGenericRepository<Slider>
    {
        Task GetAllAsync();
    }
}
