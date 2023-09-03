public abstract class SingletonBase<T> where T : SingletonBase<T>
{
	public static T Instance { get; } = System.Activator.CreateInstance<T>();

	protected virtual void Initialize()
	{
		// This method is intended to be overridden by derived classes
	}

	protected SingletonBase()
	{
		Initialize();
	}
}
