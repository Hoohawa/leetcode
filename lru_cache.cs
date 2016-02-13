public class LRUCache
{
    public class Item
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public long LastAccessed { get; set; }
    }

    private int capacity;
    private Dictionary<int, Item> itemDictionary;
    private SortedDictionary<long, Item> sortedItemDictionary;
    private long ticksSinceStart = 0;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        this.itemDictionary = new Dictionary<int, Item>();
        this.sortedItemDictionary = new SortedDictionary<long, Item>();
    }

    public int Get(int key)
    {
        if (this.itemDictionary.ContainsKey(key))
        {
            var item = this.itemDictionary[key];
            this.Update(item.Key, item.Value);
            return item.Value;
        }
        else
        {
            return -1;
        }
    }

    public void Set(int key, int value)
    {
        var shouldUpdate = this.itemDictionary.ContainsKey(key);
        if (shouldUpdate)
        {
            this.Update(key, value);
        }
        else
        {
            if (this.itemDictionary.Count == this.capacity)
            {
                var itemToInvalidate = this.sortedItemDictionary.First().Value;
                this.Remove(itemToInvalidate.Key);
            }

            this.Insert(key, value);
        }
    }

    private void Update(int key, int value)
    {
        this.sortedItemDictionary.Remove(itemDictionary[key].LastAccessed);
        itemDictionary[key].Value = value;
        itemDictionary[key].LastAccessed = this.ticksSinceStart++;
        this.sortedItemDictionary.Add(this.itemDictionary[key].LastAccessed, this.itemDictionary[key]);
    }

    private void Insert(int key, int value)
    {
        var item = new Item { Key = key, Value = value, LastAccessed = this.ticksSinceStart++ };
        itemDictionary.Add(key, item);
        sortedItemDictionary.Add(item.LastAccessed, item);
    }

    private void Remove(int key)
    {
        var item = this.itemDictionary[key];
        this.itemDictionary.Remove(item.Key);
        this.sortedItemDictionary.Remove(item.LastAccessed);
    }
}