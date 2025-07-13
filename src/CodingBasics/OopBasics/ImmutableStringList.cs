// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

namespace CodingBasics.OopBasics
{
    /// <summary>
    /// Implements an immutable list of strings: you can add strings to this list but not remove strings or change the sort of the strings.
    /// </summary>
    public class ImmutableStringList
    {
        /// <summary>
        /// Internal field holding a list with string not allowed to be changed from outside
        /// </summary>
        private readonly List<string> _allItems = new();
        
        /// <summary>
        /// Read-only property to access a copx of the list with all string items 
        /// </summary>
        public List<string> AllItems => _allItems.ToList();

        /// <summary>
        /// Read-only property to get the current number of items in the list of all string items
        /// </summary>
        public int Count => _allItems.Count;

        /// <summary>
        /// Name property (read-write)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Add a string to the immutable list
        /// </summary>
        /// <param name="value">String to add</param>
        public void AddString(string value)
        {
            _allItems.Add(value);
        }
    }
}
