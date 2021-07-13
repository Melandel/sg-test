#if COMPILE_TESTS
using Xunit;
#endif
using System;

namespace Domain.RoomBooking
{
	public class Room
	{
		public Guid id { get; }
		private Room(Guid id) {
			this.id = id;
		}

		public static Room Create() {
			var id = Guid.NewGuid();
			return new Room(id);
		}
		public static Room Reconstitute(Guid id) {
			return new Room(id);
		}

#if COMPILE_TESTS
		public class Should
		{
			[Fact]
			public void Create_instance_without_throwing() {
				var sut = Room.Create();
			}

			[Fact]
			public void Reconstitute_instance_without_throwing() {
				// Arrange
				var id = Guid.NewGuid();

				// Act & Assert
				var sut = Room.Reconstitute(id);
			}
		}
#endif
	}
}
