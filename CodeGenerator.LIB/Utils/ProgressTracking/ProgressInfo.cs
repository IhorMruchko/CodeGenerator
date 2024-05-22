namespace CodeGenerator.LIB.Utils.ProgressTracking
{
    public class ProgressInfo<TInfo>
    {
        public int CurrentIndex { get; set; }

        public int TotalAmount { get; set; }

        public TInfo CurrentItem { get; set; }

        public double Percentage => (CurrentIndex * 100d) / TotalAmount;
    }
}
