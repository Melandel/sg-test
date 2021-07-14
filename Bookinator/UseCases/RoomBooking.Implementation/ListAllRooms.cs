#if COMPILE_TESTS
using Bookinator.UseCases.RoomBooking.Implementation.InMemoryRepositories;
#endif
using Bookinator.UseCases.RoomBooking.Contract;
using Bookinator.UseCases.RoomBooking.Implementation.RepositoriesContracts;

namespace Bookinator.UseCases.RoomBooking.Implementation
{
	public class ListAllRooms : IListAllRooms
	{
		private readonly IRoomRepository _roomRepository;
		public ListAllRooms(IRoomRepository roomRepository) {
			_roomRepository = roomRepository;
		}

		IListAllRooms.Response IListAllRooms.Process(IListAllRooms.Request request) {
			return IListAllRooms.Response.Create(_roomRepository.GetAll());
		}


#if COMPILE_TESTS
		public class Should : IRoomRepository.Behavior {
			public override IRoomRepository.FixtureBuilder FixtureBuilder => new FixtureBuilder();
		}

		public class Fixture : IRoomRepository.Fixture {
			public override IRoomRepository SystemUnderTest => new InMemoryRoomRepository() as IRoomRepository;
		}

		public class FixtureBuilder : IRoomRepository.FixtureBuilder {
			public override IRoomRepository.FixtureBuilder Init(IRoomRepository.FixtureBase fixtureBase) => this;
			public override IRoomRepository.Fixture        Build() => new Fixture();
		}
#endif
	}
}
