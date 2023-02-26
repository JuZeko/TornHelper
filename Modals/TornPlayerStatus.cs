namespace TornHelperBe
{
    public class PlayerDetailStatus
    {
        public string? description { get; set; }
        public string? details { get; set; }
        public string? state { get; set; }
        public string? color { get; set; }
        public int until { get; set; }
    }

    public class TornPlayerStatus
    {
        public int level { get; set; }
        public string? gender { get; set; }
        public int player_id { get; set; }
        public string? name { get; set; }
        public PlayerDetailStatus? status { get; set; }
    }
}