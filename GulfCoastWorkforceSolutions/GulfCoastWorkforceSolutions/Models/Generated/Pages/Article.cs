using System;

namespace CMS.DocumentEngine.Types.GulfCoastWorkforceSolutionsMvc
{
    /// <summary>
    /// Custom Article members.
    /// </summary>
    public partial class Article
    {
        public DateTime PublicationDate
        {
            get
            {
                return GetDateTimeValue("DocumentPublishFrom", GetDateTimeValue("DocumentCreatedWhen", DateTime.MinValue));
            }
        }
    }
}