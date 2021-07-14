#if COMPILE_TESTS
using Xunit;
#endif
using System.Collections.Generic;
using Bookinator.UseCases.RoomBooking.Contract;

namespace Bookinator.UseCases.RoomBooking.Implementation.RepositoriesContracts
{
	public interface IRoomRepository
	{
		IReadOnlyCollection<Room> GetAll();


#if COMPILE_TESTS
		public abstract class Behavior
		{
			public abstract FixtureBuilder FixtureBuilder { get; }

			[Fact]
			protected virtual void Contain_10_rooms_named_RoomX()
			{
				// Arrange
				var environment = FixtureBuilder.Init(FixtureBase.HappyPath).Build();
				var sut = environment.SystemUnderTest;

				// Act
				var rooms = sut.GetAll();

				// Assert
				Assert.Collection(rooms,
					item => Assert.Equal("Room0", item.Name),
					item => Assert.Equal("Room1", item.Name),
					item => Assert.Equal("Room2", item.Name),
					item => Assert.Equal("Room3", item.Name),
					item => Assert.Equal("Room4", item.Name),
					item => Assert.Equal("Room5", item.Name),
					item => Assert.Equal("Room6", item.Name),
					item => Assert.Equal("Room7", item.Name),
					item => Assert.Equal("Room8", item.Name),
					item => Assert.Equal("Room9", item.Name)
						);
			}
		}


		public enum FixtureBase { HappyPath }
		public abstract class Fixture {
			public abstract IRoomRepository SystemUnderTest { get; }
		}
		public abstract class FixtureBuilder {
			public abstract FixtureBuilder Init(FixtureBase fixtureBase);
			// Add some methods here to have a convenient API for building test environments
			public abstract Fixture Build();
		}
#endif
	}
}
