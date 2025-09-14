using CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc;

namespace GulfCoastWorkforceSolutions.Repositories
{
    /// <summary>
    /// Represents a contract for a collection of contact information.
    /// </summary>
    public interface IContactRepository : IRepository
    {
        /// <summary>
        /// Returns company's contact information.
        /// </summary>
        /// <returns>Company's contact information, if found; otherwise, null.</returns>
        Contact GetCompanyContact();
    }
}