namespace MetaPong.Utilities.ScreenElements.Composit
{
    public class ScreenDecoration : ScreenGroup
    {
        public override void Print()
        {
            foreach (var element in Elements)
            {
                element.Print();
            }
        }
    }
}