namespace Visual
{
    public interface IVisualRoot: IReadOnlyVisualRoot
    {
        public void AttachModule(IVisualModule module);
        public void DetachAll();
    }
}