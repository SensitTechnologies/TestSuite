using System;

namespace Sensit.TestSDK.Utility
{
	/// <summary>
	/// Class that ensures an object is properly disposed, even if a property assignment causes an exception.
	/// </summary>
	/// <remarks>
	/// Useful for cases when CA2000 warning (need to dispose of object before
	/// it goes out of scope) is triggered when creating winforms controls
	/// dynamically.
	/// Origin is from an answer to this question:
	/// https://stackoverflow.com/questions/8795005/code-analysis-warning-about-disposing-a-form
	/// 
	/// The original implementation above causes FxCop warnings, so I modified it according to this:
	/// https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1816-call-gc-suppressfinalize-correctly
	/// </remarks>
	/// <example>
	/// <code>
	///	using (var autoDisposer = new AutoDisposer<Foo>(new Foo())
	///	{
	///		Form form = autoDisposer.Child;
	///
	///		// Do stuff with "form".
	///
	///		return autoDisposer.Release();
	///	}
	/// </code>
	/// </example>
	public class AutoDisposer<T> : IDisposable where T : class
	{
		public T Child { get; private set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="child"></param>
		public AutoDisposer(T child)
		{
			Child = child;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (Child is IDisposable d)
				{
					d.Dispose();
				}
			}
		}

		public T Release()
		{
			T retval = Child;

			Child = null;

			return retval;
		}
	}
}
