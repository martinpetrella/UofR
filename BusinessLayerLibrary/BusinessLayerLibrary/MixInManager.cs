namespace BusinessLayerLibrary
{
    /// <summary>
    /// Class to manage mix-ins
    /// Using a list to store data for now.
    /// </summary>
    public class MixInManager
    {
        private List<String> _mixIns = new List<String>() { "Peanuts", "Chocolate Chips", "Butterscotch Chips" };

        /// <summary>
        /// Get a list of mix-ins
        /// </summary>
        /// <returns>list of mix-ins</returns>
        public List<string> MixIns
        {
            get
            {
                return _mixIns;
            }
        }

        /// <summary>
        /// Add mix-in to list of mix-ins
        /// </summary>
        /// <param name="mixInName"></param>
        /// <returns>true if added, false if already in list</returns>
        public bool AddMixIn(string mixInName)
        {
            bool result = true;
            if (!_mixIns.Contains(mixInName))
            {
                _mixIns.Add(mixInName);
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Remove mix-in from list of mix-ins
        /// </summary>
        /// <param name="mixInName"></param>
        /// <returns>true if removed, false if not in list</returns>
        public bool DeleteMixIn(string mixInName)
        {
            bool result = true;

            if (_mixIns.Contains(mixInName))
            {
                _mixIns.Remove(mixInName);
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}