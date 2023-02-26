namespace TornHelperBe.Modals
{
    public class UserStats
    {
        public int ServerTime { get; set; }
        public Happy Happy { get; set; }
        public Life Life { get; set; }
        public Energy Energy { get; set; }
        public Nerve Nerve { get; set; }
        public Chain Chain { get; set; }
    }

    public class Happy
    {
        public int Current { get; set; }
        public int Maximum { get; set; }
        public int Increment { get; set; }
        public int Interval { get; set; }
        public int Ticktime { get; set; }
        public int Fulltime { get; set; }
    }

    public class Life
    {
        public int Current { get; set; }
        public int Maximum { get; set; }
        public int Increment { get; set; }
        public int Interval { get; set; }
        public int Ticktime { get; set; }
        public int Fulltime { get; set; }
    }

    public class Energy
    {
        public int Current { get; set; }
        public int Maximum { get; set; }
        public int Increment { get; set; }
        public int Interval { get; set; }
        public int Ticktime { get; set; }
        public int Fulltime { get; set; }
    }

    public class Nerve
    {
        public int Current { get; set; }
        public int Maximum { get; set; }
        public int Increment { get; set; }
        public int Interval { get; set; }
        public int Ticktime { get; set; }
        public int Fulltime { get; set; }
    }

    public class Chain
    {
        public int Current { get; set; }
        public int Maximum { get; set; }
        public int Timeout { get; set; }
        public int Modifier { get; set; }
        public int Cooldown { get; set; }
    }
}