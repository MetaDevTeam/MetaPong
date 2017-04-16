namespace MetaPong.Utilities.ScreenElements.Composit
{
    using System.Collections.Generic;

    /// <summary>
    /// A group of scree elements that should be displayed or act together.
    /// Add the elements with the Add() method.
    /// </summary>
    public abstract class ScreenGroup
    {
        protected List<ScreenElement> _elements;

        protected ScreenGroup()
        {
            Elements = new List<ScreenElement>();
        }

        protected ScreenGroup(List<ScreenElement> elements)
        {
            Elements = elements;
        }

        protected List<ScreenElement> Elements
        {
            get { return _elements; }
            set { _elements = value; }
        }

        public void Add(ScreenElement element)
        {
            _elements.Add(element);
        }

        public abstract void Print();
    }
}
