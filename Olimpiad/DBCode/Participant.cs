namespace Olympiad
{
    internal class Participant
    {
        public int Id { get; set; }
        public string ParticipantName { get; set; }
        public int CountryId { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public byte[] Photo { get; set; }

    }
}
