namespace MyWebApiApplication
{
    public static class Extensions
    {
        public static List<List<T>> partition<T>(this List<T> values, int chunkSize)
        {
            var partitions = new List<List<T>>();
            for (int i = 0; i < values.Count; i += chunkSize)
            {
                partitions.Add(values.GetRange(i, Math.Min(chunkSize, values.Count - i)));
            }
            return partitions;
        }
    }
}
