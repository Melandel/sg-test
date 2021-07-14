using System;
using System.Collections.Generic;
using Bookinator.UseCases.RoomBooking.Contract;
using Bookinator.UseCases.RoomBooking.Implementation.RepositoriesContracts;

namespace Bookinator.WebService.UseCases.RoomBooking.Implementation.InMemoryRepositories
{
	public class InMemoryRoomRepository : IRoomRepository
	{
		private static readonly Room Room0 = Room.Create(Guid.NewGuid(), "Room0");
		private static readonly Room Room1 = Room.Create(Guid.NewGuid(), "Room1");
		private static readonly Room Room2 = Room.Create(Guid.NewGuid(), "Room2");
		private static readonly Room Room3 = Room.Create(Guid.NewGuid(), "Room3");
		private static readonly Room Room4 = Room.Create(Guid.NewGuid(), "Room4");
		private static readonly Room Room5 = Room.Create(Guid.NewGuid(), "Room5");
		private static readonly Room Room6 = Room.Create(Guid.NewGuid(), "Room6");
		private static readonly Room Room7 = Room.Create(Guid.NewGuid(), "Room7");
		private static readonly Room Room8 = Room.Create(Guid.NewGuid(), "Room8");
		private static readonly Room Room9 = Room.Create(Guid.NewGuid(), "Room9");
		IReadOnlyCollection<Room> IRoomRepository.GetAll()
		{
			return new Room[10] {
				Room0,
				Room1,
				Room2,
				Room3,
				Room4,
				Room5,
				Room6,
				Room7,
				Room8,
				Room9
			};
		}


#if COMPILE_TESTS
		public class Should : IRoomRepository.Behavior {
			public override IRoomRepository.FixtureBuilder FixtureBuilder => new FixtureBuilder();
		}

		public class Fixture : IRoomRepository.Fixture {
			public override IRoomRepository SystemUnderTest => new InMemoryRoomRepository();
		}

		public class FixtureBuilder : IRoomRepository.FixtureBuilder {
			public override IRoomRepository.FixtureBuilder Init(IRoomRepository.FixtureBase fixtureBase) => this;
			public override IRoomRepository.Fixture        Build() => new Fixture();
		}
#endif
	}
}
