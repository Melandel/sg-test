using System.Collections.Generic;
using Bookinator.UseCases.RoomBooking.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Startup.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RoomsController : ControllerBase
	{
		private readonly IListAllRooms _listAllRooms;
		public RoomsController(IListAllRooms listAllRooms) {
			_listAllRooms = listAllRooms;
		}

		[HttpGet]
		public IReadOnlyCollection<Room> GetAll() {
			var appRequest  = IListAllRooms.Request.Create();
			var appResponse = _listAllRooms.Process(appRequest);
			var result = appResponse.Rooms;
			return result;
		}
	}
}
