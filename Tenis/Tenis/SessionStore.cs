using System.Web;

namespace Tenis
{
	public interface ISessionStore
	{
		object this[string index] { get; set; }
	}

	public class SessionStore : ISessionStore
	{
		public object this[string index]
		{
			get { return HttpContext.Current.Session[index]; }
			set { HttpContext.Current.Session[index] = value; }
		}
	}
}