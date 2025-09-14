using System.Collections.Generic;

using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

using GulfCoastWorkforceSolutions.Repositories.Filters;

namespace GulfCoastWorkforceSolutions.Repositories
{
    /// <summary>
    /// Represents a contract for a collection of brewers.
    /// </summary>
    public interface IBrewerRepository : IRepository
    {
        /// <summary>
        /// Returns an enumerable collection of brewers ordered by the date of publication.
        /// </summary>
        /// <param name="filter">Repository filter.</param>
        /// <param name="count">The number of brewers to return. Use 0 as value to return all records.</param>
        IEnumerable<Brewer> GetBrewers(IRepositoryFilter filter, int count = 0);
    }
}