using System;
namespace ePizzaHub.Entities
{
	public class Address
	{
		public int Id { get; set; }

		public string Street { get; set; }

		public string PostCode { get; set; }

		public string City { get; set; }

		public string PhoneNumber { get; set; }

		public string Locality { get; set; }

		public int UserId { get; set; }
	}
}

