#if COMPILE_TESTS
using Xunit;
#endif
using System;

namespace Domain.RoomBooking
{
	public class Room
	{
		public Guid Id { get; }
		public string Name { get; }
		private Room(Guid id, string name) {
			Id = id;
			Name = name;
		}

		public static Room CreateFromName(string name) {
			var id = Guid.NewGuid();
			return new Room(id, name);
		}
		public static Room Reconstitute(Guid id, string name) {
			return new Room(id, name);
		}

#if COMPILE_TESTS
		public class Should
		{
			[Fact]
			public void Create_instance_with_correct_properties() {
				// Arrange
				var name = "Room0";

				// Act
				var sut = Room.CreateFromName(name);

				// Assert
				Assert.Equal("Room0", sut.Name);
			}

			[Fact]
			public void Reconstitute_instance_withcorrect_properties() {
				// Arrange
				var id = Guid.NewGuid();
				var name = "Room0";

				// Act & Assert
				var sut = Room.Reconstitute(id, name);

				// Assert
				Assert.Equal("Room0", sut.Name);
			}
		}
#endif
	}
}
