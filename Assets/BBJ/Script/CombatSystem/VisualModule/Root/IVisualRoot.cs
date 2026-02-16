namespace Visual
{
    public interface IVisualRoot: IReadOnlyVisualRoot
    {
        public void AttachModule(VisualActionEnum action, IVisualModule module);
        public void DetachAll();
    }
}