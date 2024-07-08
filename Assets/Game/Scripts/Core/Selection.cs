using JetBrains.Annotations;

namespace Core
{
    public delegate void SelectedHandler<T>(Selection<T> self, T oldItem, T newItem);

    public class Selection<T>
    {
        public event SelectedHandler<T> Selected;
        
        private T _item;

        [CanBeNull] public T Item
        {
            get => _item;
            set
            {
                var oldItem = _item;
                _item = value;
                CallSelected(oldItem);
            }
        }

        private void CallSelected(T oldItem)
        {
            Selected?.Invoke(this, oldItem, _item);
        }
    }
}