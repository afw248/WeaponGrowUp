namespace Singleton
{
    public abstract class Singleton
    {
        public static Singleton Instance { get; private set; }
        public Singleton()
        {
            if (Instance == null)
                Instance = this;
        }
        ~Singleton()
        {
            if (Instance == this)
                Instance = null;
        }
    }
}