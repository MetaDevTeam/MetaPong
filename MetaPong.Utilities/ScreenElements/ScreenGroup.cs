namespace MetaPong.Utilities.ScreenElements
{
    using System.Collections.Generic;


    /// <summary>
    /// A group of scree elements that should be displayed together.
    /// Add the elements with the Add() method.
    /// </summary>
    public class ScreenGroup
    {
        private List<ScreenElement> _elements;

        public ScreenGroup()
        {
            Elements = new List<ScreenElement>();
        }

        public List<ScreenElement> Elements
        {
            get { return _elements; }
            set { _elements = value; }
        }

        public void Add(ScreenElement element)
        {
            _elements.Add(element);
        }

        /// <summary>
        /// Prints the setr of elements on the screen.
        /// </summary>
        public void Print()
        {
            foreach (var element in Elements)
            {
                element.Print();
            }
        }
    }
}
