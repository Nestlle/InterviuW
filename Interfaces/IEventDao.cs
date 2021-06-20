using InterviuW.Models;

namespace InterviuW.Interfaces
{
    public interface IEventDao
    {
         void Insert(int organiserId, Event eventTobeAdded);
         Event Find(int organiserId, int eventId);
    }
}