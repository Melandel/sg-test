#if COMPILE_TESTS
using System;
using Xunit;
#endif

namespace Bookinator.UseCases.RoomBooking.Contract
{
	public class Room
	{
		public Guid Id { get; }
		public string Name { get; }
		private Room(Guid id, string name)
		{
			Id = id;
			Name = name;
		}

		public static Room Create(Guid id, string name) {
			return new Room(id, name);
		}

#if COMPILE_TESTS
		public class Should
		{
			[Fact]
			public void Reconstitute_instance_without_throwing() {
				// Arrange
				var id = Guid.NewGuid();
				var name = "Room0";

				// Act & Assert
				var sut = Room.Create(id, name);

				// Assert
				Assert.Equal(id, sut.Id);
				Assert.Equal("Room0", sut.Name);
			}
		}
#endif
	}
}
