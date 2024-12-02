using cloudscribe.Pagination.Models; // Ensure this is the correct namespace
using Hospital.ViewModels;

namespace Hospital.Services
{
    public interface IRoomServices
    {
        cloudscribe.Pagination.Models.PagedResult<RoomViewModels> GetAll(int pageNumber, int pageSize); // Use cloudscribe.Pagination.Models.PagedResult here
        RoomViewModels GetRoomByID(int roomID);
        void UpdateRoom(RoomViewModels room);
        void InsertRoom(RoomViewModels room);
        void DeleteRoom(int id);
    }
}
