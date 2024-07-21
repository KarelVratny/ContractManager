namespace ContractManager.Models {
	public class Contract {
		public int Id { get; set; }
		public string Institution { get; set; }
		public Person Client { get; set; }
		public Advisor Manager { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime ValidUntil { get; set; }
		public DateTime? EndDate { get; set; }
		public ICollection<Advisor>? Advisors { get; set; }
	}
}
