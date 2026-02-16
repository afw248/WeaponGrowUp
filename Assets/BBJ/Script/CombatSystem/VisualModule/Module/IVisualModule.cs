using Observer;

namespace Visual
{
    public interface IVisualModule: IObserver
    {
        VisualActionEnum Action { get; }
        public void Attach(IReadOnlyVisualRoot root);
        public void Detach();
    }
}