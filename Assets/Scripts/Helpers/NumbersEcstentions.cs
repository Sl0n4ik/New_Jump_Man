namespace Scripts.Helpers
{
    public static class NumbersEcstentions
    {
        public static int InUnit(this float value)
        {
            int rValue = 0;
            if (value > 0) rValue = 1;
            else if (value < 0) rValue = -1;
            return rValue;
        }
    }
}