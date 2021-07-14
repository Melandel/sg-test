#if COMPILE_TESTS
using Xunit;
#endif
using System.Collections.Generic;

namespace Bookinator.UseCases.RoomBooking.Contract
{
	public interface IListAllRooms
	{
		Response Process(Request request);

		public class Request {
			private Request() { }
			public static Request Create() {
				return new Request();
			}
		}
		public class Response {
			public IReadOnlyCollection<Room> Rooms { get; }
			private Response(IReadOnlyCollection<Room> rooms) {
				this.Rooms = rooms;
			}

			public static Response Create(IReadOnlyCollection<Room> rooms) {
				return new Response(rooms);
			}
		}


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
				var request = Request.Create();

				// Act
				var response = sut.Process(request);

				// Assert
				Assert.Collection(response.Rooms,
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
			public abstract IListAllRooms SystemUnderTest { get; }
		}
		public abstract class FixtureBuilder {
			public abstract FixtureBuilder Init(FixtureBase fixtureBase);
			public abstract Fixture Build();
		}
#endif
	}
}
