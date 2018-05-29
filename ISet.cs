namespace Trees {

  interface ISet<T>
  {
    bool Add(T val); // Add a value. Returns true if added, false if already present.
    bool Remove(T val); // Remove a value. Returns true if removed, false if not present.
    bool Contains(T val); // Return true if a value is present in the set.
  }

}
