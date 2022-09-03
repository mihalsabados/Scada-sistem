namespace Scada
{
    public class Alarm
    {
        public enum AlarmType { LOW,HIGH};
        public AlarmType Type { get; set; }
        public int Priority { get; set; }
        public double Limit { get; set; }
        public string tagId { get; set; }

    }
}