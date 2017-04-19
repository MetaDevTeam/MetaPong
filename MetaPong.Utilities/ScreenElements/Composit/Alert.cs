namespace MetaPong.Utilities.ScreenElements.Composit
{
    public class Alert: ScreenDecoration
    {
        public Alert(int row, int column, string text)
        {
           Elements.Add(Composer.GetBox(
               text.Length + 4, 
               5, 
               row - 2, column - (text.Length/2) - 3));

           Elements.Add(
               new Label(
                row,
                column - (text.Length / 2),
                text)
               );
        }
    }
}
