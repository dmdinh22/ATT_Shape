using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT_Shape.domain.Models
{
    public class BaseViewModel
    {
        public bool IsLoggedIn { get; set; }


        /// <summary>
        ///  CSS Class Name for Body
        /// </summary>
        public string BodyPage { get; set; }

        /// <summary>
        /// The URL for the CDN of Media
        /// </summary>
        public string ContentUrl { get; set; }
        public bool IsAdmin { get; internal set; }
        public bool IsInfluencer { get; internal set; }
        public bool IsBlogAdmin { get; internal set; }
        public bool IsContentManager { get; internal set; }
        public bool IsSuperAdmin { get; internal set; }

        public string EntityId { get; internal set; }
        public int OwnerType { get; internal set; }
        public string MapApiKey { get; internal set; }
    }
}
