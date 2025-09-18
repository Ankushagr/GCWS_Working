using CMS.DocumentEngine.Types.GCWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfCoastWorkforceSolutions.Repositories
{
	public interface INewsRepository:IRepository
	{
		IEnumerable<News> GetTopNews(int count);
	}
}
