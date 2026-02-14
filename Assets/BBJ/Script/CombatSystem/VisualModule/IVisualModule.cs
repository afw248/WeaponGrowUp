namespace Visual
{
    public interface IVisualModule
    {
        public void Attach(IReadOnlyVisualRoot root);
        public void Detach();
    }
}